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
    /// Allow a Unity container to load several files and merge them together through kind of
    /// inheritance tree files. A child file can inherit from several parent files, the parent
    /// files will be processed first before the child file (like base class/child class
    /// when constructed).
    ///
    /// Example of usage in a "child" file called "unity.main.config" :
    /// ....
    /// <appSettings>
    ///    <add key="base" value="unity.dev-instances.config, unity.dev-database.config" />
    /// </appSettings>
    /// ....
    /// The child file depends on two base files, the initialization sequence will be :
    ///     1) unity.dev-instances.config
    ///     2) unity.dev-database.config
    ///     3) unity.main.config
    /// 
    /// This sequence allow you to declare the most generic/common initializations in the base files,
    /// and more specific initializations in the children files.
    /// </summary>
    public static class UnityContainerExtensions
    {
        private static bool LoadConfigurationFromFile(this IUnityContainer self,
                                                      string configurationFileName,
                                                      string containerName)
        {
            // Indicates if we have load something or not.
            bool result = false;

            // Open the given configuration file.
            var fileMap = new ExeConfigurationFileMap {ExeConfigFilename = configurationFileName};
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None);

            // Load first the "base/parents" files (if "base" is declared in the current configuration file).
            KeyValueConfigurationElement baseFiles = configuration.AppSettings.Settings["base"];
            if (baseFiles != null)
            {
                string[] files = baseFiles.Value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string file in files)
                {
                    string baseFile = Path.GetDirectoryName(configurationFileName) + "\\" + file.Trim();
                    if (!File.Exists(baseFile))
                    {
                        throw new FileNotFoundException(string.Format("Unity configuration file '{0}' not found",
                                                                      baseFile));
                    }

                    result = self.LoadConfigurationFromFile(baseFile, containerName);
                }
            }

            // No more base/parents files, start loading the configurations.
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

        /// <summary>
        /// Load Unity configuration file.
        /// </summary>
        public static void LoadUnityConfiguration(this IUnityContainer self,
                                                  IConfigurationProvider configurationProvider,
                                                  string unityContainerName = null)
        {
            string mainConfigFile = configurationProvider.ConfigurationFile;
            if (!string.IsNullOrWhiteSpace(mainConfigFile))
            {
                bool result = LoadConfigurationFromFile(self, mainConfigFile, unityContainerName);
                if (result)
                {
                    return;
                }
                throw new ArgumentException("The requested container does not exist in the unity configuration files");
            }

            throw new FileLoadException("Cannot load the Unity configuration file");
        }
    }
}