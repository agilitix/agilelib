using System;
using System.Configuration;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace AxConfiguration
{
    /// <summary>
    /// Load hierarchical configuration files.
    /// 
    /// Please look at the unit tests and the "unity.config" file parameter [add key="base" value="unity.dev.config"]
    /// as an example on how to make hierarchical configurations.
    /// </summary>
    public static class UnityContainerExtensions
    {
        private static bool LoadConfigurationFromFile(this IUnityContainer self,
                                                      string configurationFileName,
                                                      string containerName)
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

                    // We found "base" files to load.
                    result = self.LoadConfigurationFromFile(baseFile, containerName);
                }
            }

            // No more "base" files to lookup, start reading the configurations.
            UnityConfigurationSection unitySection = (UnityConfigurationSection) configuration.GetSection("unity");
            if (!string.IsNullOrWhiteSpace(containerName))
            {
                if (unitySection.Containers.Any(container => container.Name.Equals(containerName)))
                {
                    self.LoadConfiguration(unitySection, containerName);
                    result = true;
                }
            }
            else
            {
                if (unitySection.Containers.Any(container => string.IsNullOrWhiteSpace(container.Name)))
                {
                    self.LoadConfiguration(unitySection);
                    result = true;
                }
            }

            return result;
        }

        public static void Load(this IUnityContainer self,
                                string unityConfigurationFile,
                                string unityContainerName = null)
        {
            if (string.IsNullOrWhiteSpace(unityConfigurationFile)
                || File.Exists(unityConfigurationFile) == false
                || LoadConfigurationFromFile(self, unityConfigurationFile, unityContainerName) == false)
            {
                throw new FileLoadException();
            }
        }

        public static void Load(this IUnityContainer self,
                                IAppConfiguration appConfiguration,
                                string unityContainerName = null)
        {
            Load(self, appConfiguration.ConfigurationFile, unityContainerName);
        }
    }
}
