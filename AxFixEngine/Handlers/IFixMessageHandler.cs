using QuickFix;

namespace AxFixEngine.Handlers
{
    public interface IFixMessageHandler
    {
        void OnCreate(SessionID sessionId);
        void OnLogon(SessionID sessionId);
        void OnLogout(SessionID sessionId);

        void FromAdmin(Message message, SessionID sessionId);
        void ToAdmin(Message message, SessionID sessionId);

        void FromApp(Message message, SessionID sessionId);
        void ToApp(Message message, SessionID sessionId);
    }
}
