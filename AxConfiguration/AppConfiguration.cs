using System;
using System.Configuration;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;

namespace AxConfiguration
{
    public class AppConfiguration : IAppConfiguration
    {
        /// <summary>
        /// The first file found in the config folder will be used as config file.
        /// </summary>
        protected static string[] _defaultConfigurationFiles =
        {
            string.Format("main.{0}.config", Environment.UserName),
            string.Format("main.{0}.config", Environment.MachineName),
            "main.config"
        };

        public Configuration Configuration { get; private set; }
        public string ConfigurationFile { get; private set; }

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
            ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap {ExeConfigFilename = configurationFile};
            Configuration = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
        }
    }
}
