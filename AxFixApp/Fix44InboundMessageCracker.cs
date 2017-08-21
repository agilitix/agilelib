using AxFixEngine.Handlers;
using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixApp
{
    public class Fix44InboundMessageCracker : FixMessageCrackerBase
    {
        public Fix44InboundMessageCracker()
            :base(FixMessageDirection.Inbound)
        {
        }

        #region Admin messages

        public void OnMessage(QuickFix.FIX44.Logon message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.Logout message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.TestRequest message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.ResendRequest message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.SequenceReset message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.Reject message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.Heartbeat message, SessionID sessionId)
        {
        }

        #endregion

        #region App messages

        public void OnMessage(QuickFix.FIX44.BusinessMessageReject message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.OrderCancelReject message, SessionID sessionId)
        {
        }

        #endregion
    }
}
