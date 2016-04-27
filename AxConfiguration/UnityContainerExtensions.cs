using System;
using System.Configuration;
using System.IO;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace AxConfiguration
{
    /// <summary>
    /// Allow Unity container to load several files and merge them together through kind of
    /// inheritance files tree. A child file can inherit from several parent files, the parent
    /// files will apply first before the child file, just like base classes of a child class.
    ///
    /// Example of use from a "child" file "unity.dev.config" :
    /// ....
    /// <appSettings>
    ///    <add key="base" value="unity.dev-components.config, unity.dev-database.config" />
    /// </appSettings>
    /// ....
    /// The child file declares two base files which are read and applied first,
    /// the whole files will be run in this order :
    ///     1) unity.dev-components.config
    ///     2) unity.dev-database.config
    ///     3) unity.dev.config
    /// </summary>
    internal static class UnityContainerExtensions
    {
        private static void LoadConfigurationFromFile(this IUnityContainer self,
                                                      string configurationFileName,
                                                      string containerName)
        {
            // Open the given configuration file.
            var fileMap = new ExeConfigurationFileMap {ExeConfigFilename = configurationFileName};
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,
                                                                                          ConfigurationUserLevel.None);

            // Load the "base/parents" configuration files.
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

                    self.LoadConfigurationFromFile(baseFile, containerName);
                }
            }

            // Load the Unity configuration from current file.
            UnityConfigurationSection unitySection = (UnityConfigurationSection) configuration.GetSection("unity");
            self.LoadConfiguration(unitySection, containerName);
        }

        public static void LoadConfigurationFromFolder(this IUnityContainer self,
                                                       string folderName,
                                                       string unityContainerName = "")
        {
            // Lookup sequentially to those files in the given folder, the first existing file will be used as the root
            // configuration file, the following files in the array will be ignored.
            string[] defaultFiles =
            {
                string.Format("unity.{0}.config", Environment.UserName), // unity.antonio.config
                string.Format("unity.{0}.config", Environment.MachineName), // unity.FR001VIRGO.config
                "unity.default.config",
            };

            foreach (string file in defaultFiles)
            {
                string rootFile = Path.Combine(folderName, file);
                if (File.Exists(rootFile))
                {
                    // We found an existing root file, load it and its children then return.
                    LoadConfigurationFromFile(self, rootFile, unityContainerName);
                    return;
                }
            }

            throw new FileNotFoundException("Cannot find the default unity configuration file");
        }
    }
}