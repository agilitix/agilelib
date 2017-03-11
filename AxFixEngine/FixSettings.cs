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

        public FixSettings(string configFileName)
        {
            _iniFile = new IniFile(configFileName);
            _sessionSettings = new SessionSettings(configFileName);
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
            Dictionary dictionary = GetSessionSettings(sessionID);
            return (T) Convert.ChangeType(dictionary.GetString(settingName), typeof(T));
        }

        public T GetSettingValue<T>(string sectionName, string settingName)
        {
            return _iniFile.GetSetting<T>(sectionName, settingName);
        }
    }
}
