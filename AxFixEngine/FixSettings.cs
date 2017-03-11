using System;
using System.Collections.Generic;
using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine
{
    public class FixSettings : IFixSettings
    {
        protected SessionSettings _sessionSettings;
        protected IDictionary<Type, Func<Dictionary, string, Type, object>> _converters;

        public const string MESSAGE_HISTORIZATION_FILE = "MessageHistorizationFile";

        public FixSettings(string configFileName)
        {
            _sessionSettings = new SessionSettings(configFileName);

            _converters = new Dictionary<Type, Func<Dictionary, string, Type, object>>
            {
                { typeof(string), (dictionary, key, type) => Convert.ChangeType(dictionary.GetString(key), type) },
                { typeof(bool), (dictionary, key, type) => Convert.ChangeType(dictionary.GetBool(key), type) },
                { typeof(double), (dictionary, key, type) => Convert.ChangeType(dictionary.GetDouble(key), type) },
                { typeof(DayOfWeek), (dictionary, key, type) => Convert.ChangeType(dictionary.GetDay(key), type) },
                { typeof(int), (dictionary, key, type) => Convert.ChangeType(dictionary.GetInt(key), type) },
                { typeof(long), (dictionary, key, type) => Convert.ChangeType(dictionary.GetLong(key), type) }
            };
        }

        public SessionSettings GetSessionSettings()
        {
            return _sessionSettings;
        }

        public IEnumerable<SessionID> GetAllSessions()
        {
            return _sessionSettings.GetSessions();
        }

        public Dictionary GetSessionSettings(SessionID sessionID)
        {
            return _sessionSettings.Get(sessionID);
        }

        public T GetSessionSettingValue<T>(SessionID sessionID, string settingName)
        {
            Dictionary settings = _sessionSettings.Get(sessionID);
            return GetSettingValue<T>(settings, settingName);
        }

        public T GetDefaultSettingValue<T>(string settingName)
        {
            Dictionary defaultSettings = _sessionSettings.Get();
            return GetSettingValue<T>(defaultSettings, settingName);
        }

        protected T GetSettingValue<T>(Dictionary settings, string settingName)
        {
            Func<Dictionary, string, Type, object> converter;
            if (_converters.TryGetValue(typeof(T), out converter))
            {
                return (T)converter(settings, settingName, typeof(T));
            }

            return (T)Convert.ChangeType(settings.GetString(settingName), typeof(T));
        }
    }
}
