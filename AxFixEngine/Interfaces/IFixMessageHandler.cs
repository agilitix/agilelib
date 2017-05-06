using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixMessageHandler
    {
        void OnLogon(SessionID sessionId);
        void OnLogout(SessionID sessionId);

        void SendingToAdmin(Message message, SessionID sourceSessionId);
        void ReceivingFromAdmin(Message message, SessionID sourceSessionId);

        void SendingToApp(Message message, SessionID sourceSessionId);
        void ReceivingFromApp(Message message, SessionID sourceSessionId);
    }
}
