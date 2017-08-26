using System;
using QuickFix;

namespace AxFixEngine.Handlers
{
    public abstract class FixMessageCrackHandlerBase : FixMessageCracker, IFixMessageHandler
    {
        protected FixMessageCrackHandlerBase()
        {
        }

        protected FixMessageCrackHandlerBase(Action<Message, SessionID> unsupportedMessageAction)
            : base(unsupportedMessageAction)
        {
        }

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
            CrackFrom(message, sessionId);
        }

        public virtual void ToAdmin(Message message, SessionID sessionId)
        {
            CrackTo(message, sessionId);
        }

        public virtual void FromApp(Message message, SessionID sessionId)
        {
            CrackFrom(message, sessionId);
        }

        public virtual void ToApp(Message message, SessionID sessionId)
        {
            CrackTo(message, sessionId);
        }
    }
}
