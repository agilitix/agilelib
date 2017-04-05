using System;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;

namespace AxConfiguration
{
    public class ConfigurationFileProvider : IConfigurationFileProvider
    {
        public string ConfigFolder { get; }

        public string AppConfigFile { get; }
        public string UnityConfigFile { get; }

        public ConfigurationFileProvider(string configurationFolder)
        {
            ConfigFolder = configurationFolder;

            AppConfigFile = GetDefaultConfigFile("main");
            UnityConfigFile = GetDefaultConfigFile("unity");
        }

        protected string GetDefaultConfigFile(string baseName)
        {
            string[] defaultUnityConfigFiles =
            {
                string.Format("{0}.{1}.config", baseName, Environment.UserName),
                string.Format("{0}.{1}.config", baseName, Environment.MachineName),
                string.Format("{0}.config", baseName)
            };

            string defaultconfigFile = defaultUnityConfigFiles.Select(fileName => Path.Combine(ConfigFolder, fileName))
                                                              .FirstOrDefault(File.Exists);

            return defaultconfigFile;
        }
    }
}
