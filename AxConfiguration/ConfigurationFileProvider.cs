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
        public string IocConfigFile { get; }

        public ConfigurationFileProvider(string configurationFolder)
        {
            ConfigFolder = configurationFolder;

            AppConfigFile = GetDefaultConfigFile("app");
            IocConfigFile = GetDefaultConfigFile("unity");
        }

        protected string GetDefaultConfigFile(string baseName)
        {
            string[] defaultUnityConfigFiles =
            {
                string.Format("{0}.user.{1}.config", baseName, Environment.UserName),
                string.Format("{0}.host.{1}.config", baseName, Environment.MachineName),
                string.Format("{0}.main.config", baseName)
            };

            string defaultconfigFile = defaultUnityConfigFiles.Select(fileName => Path.Combine(ConfigFolder, fileName))
                                                              .FirstOrDefault(File.Exists);

            return defaultconfigFile;
        }
    }
}
