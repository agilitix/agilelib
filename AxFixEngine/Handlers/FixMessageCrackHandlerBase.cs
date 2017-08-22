using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine.Handlers
{
    public abstract class FixMessageCrackHandlerBase : MessageCracker, IFixMessageHandler
    {
        public FixMessageDirection Direction { get; }

        protected FixMessageCrackHandlerBase(FixMessageDirection direction)
        {
            Direction = direction;
        }

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
