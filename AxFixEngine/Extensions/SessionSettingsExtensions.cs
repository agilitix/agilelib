using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxExtensions;
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
                {typeof(long), (dictionary, key, type) => Convert.ChangeType(dictionary.GetLong(key), type)},
                {typeof(DateTime), (dictionary, key, type) => Convert.ChangeType(dictionary.GetTime(key), type)}
            };

        public static string Dump(this SessionSettings sessionSettings)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<Dictionary> settings = sessionSettings.GetSessions().Select(sessionSettings.Get);
            foreach (Dictionary dictionary in settings)
            {
                dictionary.AsEnumerable()
                          .Select(x => x.ToString())
                          .ForEach(x => sb.Append(x));
                sb.AppendLine();
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static bool HasSessionInTime(this SessionSettings sessionSettings)
        {
            DateTime now = DateTime.UtcNow;
            IEnumerable<Dictionary> settings = sessionSettings.GetSessions().Select(sessionSettings.Get);
            foreach (Dictionary setting in settings)
            {
                DateTime startTime = setting.GetTime(SessionSettings.START_TIME);
                DateTime endTime = setting.GetTime(SessionSettings.END_TIME);
                if (endTime < startTime)
                {
                    endTime = endTime.AddDays(1);
                }
                if (now >= startTime && now <= endTime)
                {
                    return true;
                }
            }

            return false;
        }

        public static T GetSetting<T>(this SessionSettings self, SessionID sessionId, string settingName)
        {
            Dictionary settings = self.Get(sessionId);
            return GetSettingValue<T>(settings, settingName);
        }

        public static T GetSetting<T>(this SessionSettings self, string settingName)
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
