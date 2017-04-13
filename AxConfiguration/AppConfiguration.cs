using System;
using System.Configuration;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;

namespace AxConfiguration
{
    public class AppConfiguration : IAppConfiguration
    {
        public Configuration Configuration { get; private set; }
        public string ConfigurationFile { get; private set; }

        public void LoadConfiguration(string configurationFile)
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
