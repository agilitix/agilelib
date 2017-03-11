using System.Collections.Generic;
using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixSettings
    {
        SessionSettings GetSessionSettings();

        IEnumerable<SessionID> GetAllSessions();
        Dictionary GetSessionSettings(SessionID sessionID);

        T GetSetting<T>(SessionID sessionID, string settingName);
        T GetSetting<T>(string sectionName, string settingName);
    }
}
