using System.Configuration;
using System.IO;

namespace AxConfiguration
{
    public static class ConfigurationFactory
    {
        public static Configuration BuildConfiguration(string filePath = null)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = "App.config";
            }
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap {ExeConfigFilename = filePath};

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(
                exeConfigurationFileMap,
                ConfigurationUserLevel.None);

            return config;
        }
    }
}