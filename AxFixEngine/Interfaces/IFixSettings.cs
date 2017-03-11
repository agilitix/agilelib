using System.Collections.Generic;
using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixSettings
    {
        SessionSettings GetSessionSettings();

        IEnumerable<SessionID> GetAllSessions();
        Dictionary GetSessionSettings(SessionID sessionID);

        T GetDefaultSettingValue<T>(string settingName);
        T GetSessionSettingValue<T>(SessionID sessionID, string settingName);
    }
}
