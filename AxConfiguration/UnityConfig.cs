using System;
using System.Configuration;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace AxConfiguration
{
    public class UnityConfig : IUnityConfig
    {
        protected AliasElementCollection _baseAliases;
        protected IUnityContainer _container;

        public string ConfigFile { get; }
        public string ContainerName { get; }

        public UnityConfig(string configFile, string containerName = "")
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException("Unity config file not found", configFile);
            }

            ConfigFile = configFile;
            ContainerName = !string.IsNullOrWhiteSpace(containerName)
                                ? containerName
                                : string.Empty;

            _container = new UnityContainer();
            LoadUnityContainer(ConfigFile);

            _baseAliases = null;
        }

        public bool IsRegistered<T>(string name = "")
        {
            return string.IsNullOrWhiteSpace(name)
                       ? _container.IsRegistered<T>()
                       : _container.IsRegistered<T>(name);
        }

        public T Resolve<T>(string name = "")
        {
            return string.IsNullOrWhiteSpace(name)
                       ? _container.Resolve<T>()
                       : _container.Resolve<T>(name);
        }

        protected void LoadUnityContainer(string configFile)
        {
            // Open the configurationFileName file.
            var fileMap = new ExeConfigurationFileMap {ExeConfigFilename = configFile};
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            // Walk to the most top base file and start loading unity from there.
            KeyValueConfigurationElement baseFiles = configuration.AppSettings.Settings["base"];
            if (baseFiles != null)
            {
                string[] files = baseFiles.Value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string file in files)
                {
                    string baseFile = Path.Combine(Path.GetDirectoryName(configFile), file.Trim());
                    if (!File.Exists(baseFile))
                    {
                        throw new FileNotFoundException(string.Format("Configuration file '{0}' not found", baseFile));
                    }

                    // Go to base file.
                    LoadUnityContainer(baseFile);
                }
            }

            // We are at the top of the config files hierarchy, start reading the files from there to the bottom hierarchy.
            UnityConfigurationSection unitySection = (UnityConfigurationSection) configuration.GetSection("unity");

            // Propagate base aliases to children. Other declarations than aliases are not inherited.
            if (_baseAliases != null)
            {
                foreach (AliasElement baseAlias in _baseAliases)
                {
                    if (unitySection.TypeAliases.Any(x => x.Alias == baseAlias.Alias))
                    {
                        continue;
                    }

                    unitySection.TypeAliases[baseAlias.Alias] = baseAlias.TypeName;
                }
            }

            _baseAliases = unitySection.TypeAliases;
            _container.LoadConfiguration(unitySection, ContainerName);
        }
    }
}
