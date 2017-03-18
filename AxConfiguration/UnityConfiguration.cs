using System;
using System.Configuration;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace AxConfiguration
{
    public class UnityConfiguration : IUnityConfiguration
    {
        /// <summary>
        /// The first file found in the config folder will be used as config file.
        /// </summary>
        protected static string[] _defaultConfigurationFiles =
        {
            string.Format("unity.{0}.config", Environment.UserName),
            string.Format("unity.{0}.config", Environment.MachineName),
            "unity.config"
        };

        protected readonly string _containerName;

        public IUnityContainer Container { get; private set; }
        public string ConfigurationFile { get; private set; }

        public UnityConfiguration()
        {
        }

        public UnityConfiguration(string containerName)
        {
            _containerName = containerName;
        }

        public void LoadDefaultFile(string configurationFolder)
        {
            string defaultConfigurationFile = _defaultConfigurationFiles.Select(fileName => Path.Combine(configurationFolder, fileName))
                                                                        .FirstOrDefault(File.Exists);
            LoadFile(defaultConfigurationFile);
        }

        public void LoadFile(string configurationFile)
        {
            if (!File.Exists(configurationFile))
            {
                throw new FileNotFoundException();
            }

            ConfigurationFile = configurationFile;
            Container = new UnityContainer();

            if (!LoadUnityContainer(Container, configurationFile, _containerName))
            {
                throw new FileLoadException();
            }
        }

        protected bool LoadUnityContainer(IUnityContainer unityContainer, string configurationFileName, string containerName)
        {
            // Indicates if we have loaded something so far.
            bool result = false;

            // Open the configurationFileName file.
            var fileMap = new ExeConfigurationFileMap {ExeConfigFilename = configurationFileName};
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            // Firstly we lookup to the "base" files to load.
            KeyValueConfigurationElement baseFiles = configuration.AppSettings.Settings["base"];
            if (baseFiles != null)
            {
                string[] files = baseFiles.Value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string file in files)
                {
                    string baseFile = Path.GetDirectoryName(configurationFileName) + "\\" + file.Trim();
                    if (!File.Exists(baseFile))
                    {
                        throw new FileNotFoundException(string.Format("Configuration file '{0}' not found", baseFile));
                    }

                    // Found "base" files to load.
                    result = LoadUnityContainer(unityContainer, baseFile, containerName);
                }
            }

            // No more "base" files to lookup, start reading the configurations.
            UnityConfigurationSection unitySection = (UnityConfigurationSection) configuration.GetSection("unity");
            if (!string.IsNullOrWhiteSpace(containerName))
            {
                if (unitySection.Containers.Any(container => container.Name.Equals(containerName)))
                {
                    unityContainer.LoadConfiguration(unitySection, containerName);
                    result = true;
                }
            }
            else
            {
                if (unitySection.Containers.Any(container => string.IsNullOrWhiteSpace(container.Name)))
                {
                    unityContainer.LoadConfiguration(unitySection);
                    result = true;
                }
            }

            return result;
        }
    }
}
