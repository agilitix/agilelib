using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixMessageHandler
    {
        void OnLogon(SessionID sessionId);
        void OnLogout(SessionID sessionId);

        void ToAdmin(Message message, SessionID sourceSessionId);
        void FromAdmin(Message message, SessionID sourceSessionId);

        void ToApp(Message message, SessionID sourceSessionId);
        void FromApp(Message message, SessionID sourceSessionId);
    }
}
