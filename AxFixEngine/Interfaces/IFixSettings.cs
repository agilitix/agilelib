using System.Collections.Generic;
using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixSettings
    {
        SessionSettings GetSessionSettings();

        IEnumerable<SessionID> GetAllSessions();
        Dictionary GetSessionSettings(SessionID sessionID);

        T GetSessionSettingValue<T>(SessionID sessionID, string settingName);
        T GetSettingValue<T>(string sectionName, string settingName);
    }
}
