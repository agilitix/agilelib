using System;
using System.Collections.Generic;
using AxFixEngine.Interfaces;
using AxUtils;
using AxUtils.Interfaces;
using QuickFix;

namespace AxFixEngine
{
    public class FixSettings : IFixSettings
    {
        protected IIniFile _iniFile;
        protected SessionSettings _sessionSettings;
        protected IDictionary<Type, Func<Dictionary, string, Type, object>> _converters;

        public FixSettings(string configFileName)
        {
            _iniFile = new IniFile(configFileName);
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

        public T GetSetting<T>(SessionID sessionID, string settingName)
        {
            Dictionary dictionary = GetSessionSettings(sessionID);
            Func<Dictionary, string, Type, object> converter;
            if (_converters.TryGetValue(typeof(T), out converter))
            {
                return (T) converter(dictionary, settingName, typeof(T));
            }

            throw new ArgumentException();
        }

        public T GetSetting<T>(string sectionName, string settingName)
        {
            return _iniFile.GetSetting<T>(sectionName, settingName);
        }
    }
}
