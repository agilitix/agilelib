using AxFixEngine;
using QuickFix;

namespace AxFixServer
{
    public class FixMessageHandler : FixMessageHandlerBase
    {
        public string Name { get; private set; }

        public FixMessageHandler()
            : this(nameof(FixMessageHandler))
        {
        }

        public FixMessageHandler(string name)
        {
            Name = name;
        }

        public void OnMessage(QuickFix.FIX44.Logon message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.Logout message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.BusinessMessageReject message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.OrderCancelReject message, SessionID sessionId)
        {
        }
    }
}
