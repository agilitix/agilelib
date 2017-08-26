using QuickFix;

namespace AxFixEngine.Handlers
{
    public abstract class FixMessageHandlerBase : IFixMessageHandler
    {
        public virtual void OnCreate(SessionID sessionId)
        {
        }

        public virtual void OnLogon(SessionID sessionId)
        {
        }

        public virtual void OnLogout(SessionID sessionId)
        {
        }

        public virtual void FromAdmin(Message message, SessionID sessionId)
        {
        }

        public virtual void ToAdmin(Message message, SessionID sessionId)
        {
        }

        public virtual void FromApp(Message message, SessionID sessionId)
        {
        }

        public virtual void ToApp(Message message, SessionID sessionId)
        {
        }
    }
}
