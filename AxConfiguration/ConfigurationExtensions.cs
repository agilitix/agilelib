using System;
using System.Configuration;
using System.Linq;

namespace AxConfiguration
{
    public static class ConfigurationExtensions
    {
        public static T GetSetting<T>(this Configuration self, string key, T defaultValue = default(T))
        {
            KeyValueConfigurationElement setting = GetSettingKeyValue(self, key);
            if (setting != null)
            {
                return (T) Convert.ChangeType(setting.Value, typeof(T));
            }

            return defaultValue;
        }

        public static bool TryGetSetting<T>(this Configuration self, string key, out T value)
        {
            try
            {
                KeyValueConfigurationElement setting = GetSettingKeyValue(self, key);
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

            value = default(T);
            return false;
        }

        public static KeyValueConfigurationElement GetSettingKeyValue(this Configuration self, string key)
        {
            KeyValueConfigurationElement setting = self.AppSettings
                                                       .Settings
                                                       .Cast<KeyValueConfigurationElement>()
                                                       .FirstOrDefault(x => x.Key.Equals(key));
            return setting;
        }
    }
}
