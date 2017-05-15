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
        public string IniConfigFile { get; }

        public ConfigurationFileProvider(string configurationFolder)
        {
            ConfigFolder = configurationFolder;

            AppConfigFile = GetDefaultConfigFile("app", "config");
            IocConfigFile = GetDefaultConfigFile("unity", "config");
            IniConfigFile = GetDefaultConfigFile("app", "ini");
        }

        protected string GetDefaultConfigFile(string baseName, string extension)
        {
            string[] defaultConfigFiles =
            {
                string.Format("{0}.user.{1}.{2}", baseName, Environment.UserName, extension),
                string.Format("{0}.host.{1}.{2}", baseName, Environment.MachineName, extension),
                string.Format("{0}.main.{1}", baseName, extension)
            };

            return defaultConfigFiles.Select(fileName => Path.Combine(ConfigFolder, fileName))
                                     .FirstOrDefault(File.Exists);
        }
    }
}
