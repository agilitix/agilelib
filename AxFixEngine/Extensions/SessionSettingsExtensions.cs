using System;
using System.Collections.Generic;
using QuickFix;

namespace AxFixEngine.Extensions
{
    public static class SessionSettingsExtensions
    {
        private static readonly IDictionary<Type, Func<Dictionary, string, Type, object>> _converters =
            new Dictionary<Type, Func<Dictionary, string, Type, object>>
            {
                {typeof(string), (dictionary, key, type) => Convert.ChangeType(dictionary.GetString(key), type)},
                {typeof(bool), (dictionary, key, type) => Convert.ChangeType(dictionary.GetBool(key), type)},
                {typeof(double), (dictionary, key, type) => Convert.ChangeType(dictionary.GetDouble(key), type)},
                {typeof(DayOfWeek), (dictionary, key, type) => Convert.ChangeType(dictionary.GetDay(key), type)},
                {typeof(int), (dictionary, key, type) => Convert.ChangeType(dictionary.GetInt(key), type)},
                {typeof(long), (dictionary, key, type) => Convert.ChangeType(dictionary.GetLong(key), type)}
            };

        public static T GetSessionSettingValue<T>(this SessionSettings self, SessionID sessionId, string settingName)
        {
            Dictionary settings = self.Get(sessionId);
            return GetSettingValue<T>(settings, settingName);
        }

        public static T GetDefaultSettingValue<T>(this SessionSettings self, string settingName)
        {
            Dictionary defaultSettings = self.Get();
            return GetSettingValue<T>(defaultSettings, settingName);
        }

        private static T GetSettingValue<T>(Dictionary settings, string settingName)
        {
            Func<Dictionary, string, Type, object> converter;
            if (_converters.TryGetValue(typeof(T), out converter))
            {
                return (T) converter(settings, settingName, typeof(T));
            }

            return (T) Convert.ChangeType(settings.GetString(settingName), typeof(T));
        }
    }
}