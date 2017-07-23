using AxFixEngine;
using AxFixEngine.Handlers;
using QuickFix;

namespace AxFixServer
{
    public class Fix44MessageHandler : FixMessageCrackerHandlerBase
    {
        #region Session level messages

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

        #region Business level messages

        public void OnMessage(QuickFix.FIX44.BusinessMessageReject message, SessionID sessionId)
        {
        }

        public void OnMessage(QuickFix.FIX44.OrderCancelReject message, SessionID sessionId)
        {
        }

        #endregion
    }
}
