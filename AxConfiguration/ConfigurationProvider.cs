using System;
using System.Configuration;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;

namespace AxConfiguration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        /// <summary>
        /// The first file found in the config folder will be used as startup config file.
        /// </summary>
        protected static string[] _defaultConfigurationFiles =
        {
            string.Format("unity.{0}.config", Environment.UserName),
            string.Format("unity.{0}.config", Environment.MachineName),
            "unity.config",
            string.Format("main.{0}.config", Environment.UserName),
            string.Format("main.{0}.config", Environment.MachineName),
            "main.config",
            Path.GetFileName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)    // application.exe.config
        };

        public string ConfigurationFile { get; }
        public Configuration Configuration { get; }

        public ConfigurationProvider()
            : this(".")
        {
        }

        public ConfigurationProvider(string configurationFolder)
        {
            if (!Directory.Exists(configurationFolder))
            {
                throw new ArgumentException();
            }

            ConfigurationFile = GetDefaultConfigurationFile(configurationFolder);
            if (string.IsNullOrWhiteSpace(ConfigurationFile))
            {
                throw new FileNotFoundException();
            }

            ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap {ExeConfigFilename = ConfigurationFile};
            Configuration = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
        }

        protected string GetDefaultConfigurationFile(string configurationFolder)
        {
            return _defaultConfigurationFiles.Select(fileName => Path.Combine(configurationFolder, fileName))
                                             .FirstOrDefault(File.Exists);
        }
    }
}
