using System;
using System.Configuration;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;

namespace AxConfiguration
{
    public class AppConfig : IAppConfig
    {
        protected readonly Configuration _configuration;

        public string ConfigFile { get; }

        public AppConfig(string configFile)
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException("App config file not found", configFile);
            }

            ConfigFile = configFile;
            ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap {ExeConfigFilename = ConfigFile};
            _configuration = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
        }

        public bool ContainsKey(string key)
        {
            KeyValueConfigurationElement setting = GetKeyValueElement(key);
            return setting != null;
        }

        public T GetKey<T>(string key, T defaultValue = default(T))
        {
            T value;
            TryGetKey(key, out value, defaultValue);
            return value;
        }

        public bool TryGetKey<T>(string key, out T value, T defaultValue = default(T))
        {
            try
            {
                KeyValueConfigurationElement setting = GetKeyValueElement(key);
                if (setting != null)
                {
                    value = (T) Convert.ChangeType(setting.Value, typeof(T));
                    return true;
                }
            }
            catch
            {
                // ignored
            }

            value = defaultValue;
            return false;
        }

        protected KeyValueConfigurationElement GetKeyValueElement(string key)
        {
            KeyValueConfigurationElement setting = _configuration.AppSettings
                                                                 .Settings
                                                                 .Cast<KeyValueConfigurationElement>()
                                                                 .FirstOrDefault(x => x.Key.Equals(key));
            return setting;
        }
    }
}
