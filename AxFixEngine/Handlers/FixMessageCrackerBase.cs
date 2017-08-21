using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine.Handlers
{
    public abstract class FixMessageCrackerBase : MessageCracker, IFixMessageHandler
    {
        public void OnCreate(SessionID sessionId)
        {
        }

        public virtual void OnLogon(SessionID sessionId)
        {
        }

        public virtual void OnLogout(SessionID sessionId)
        {
        }

        public virtual void OnAdmin(Message message, SessionID sourceSessionId)
        {
            Crack(message, sourceSessionId);
        }

        public virtual void OnApp(Message message, SessionID sourceSessionId)
        {
            Crack(message, sourceSessionId);
        }
    }
}
