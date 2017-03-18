using System;
using System.Configuration;
using System.Linq;

namespace AxConfiguration
{
    public static class ConfigurationExtensions
    {
        public static T GetSetting<T>(this Configuration self, string key)
        {
            KeyValueConfigurationElement setting = self.AppSettings
                                                       .Settings
                                                       .Cast<KeyValueConfigurationElement>()
                                                       .FirstOrDefault(x => x.Key.Equals(key));
            if (setting != null)
            {
                return (T) Convert.ChangeType(setting.Value, typeof(T));
            }

            return default(T);
        }

        public static bool TryGetSetting<T>(this Configuration self, string key, out T value)
        {
            try
            {
                value = GetSetting<T>(self, key);
                return true;
            }
            catch
            {
                // ignored
            }

            value = default(T);
            return false;
        }
    }
}
