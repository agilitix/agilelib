using System;
using QuickFix;
using AxFixEngine.Interfaces;

namespace AxFixEngine.Handlers
{
    public class FixMessageEventHandler : IFixMessageHandler
    {
        public event Action<SessionID> OnLogon;
        public event Action<SessionID> OnLogout;
        public event Action<Message, SessionID> OnInboundMessage;
        public event Action<Message, SessionID> OnOutboundMessage;

        void IFixMessageHandler.OnLogon(SessionID sessionId)
        {
            OnLogon?.Invoke(sessionId);
        }

        void IFixMessageHandler.OnLogout(SessionID sessionId)
        {
            OnLogout?.Invoke(sessionId);
        }

        void IFixMessageHandler.ToAdmin(Message message, SessionID sessionId)
        {
            OnOutboundMessage?.Invoke(message, sessionId);
        }

        void IFixMessageHandler.FromAdmin(Message message, SessionID sessionId)
        {
            OnInboundMessage?.Invoke(message, sessionId);
        }

        void IFixMessageHandler.ToApp(Message message, SessionID sessionId)
        {
            OnOutboundMessage?.Invoke(message, sessionId);
        }

        void IFixMessageHandler.FromApp(Message message, SessionID sessionId)
        {
            OnInboundMessage?.Invoke(message, sessionId);
        }
    }
}
