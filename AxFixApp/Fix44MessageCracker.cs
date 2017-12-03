using AxFixEngine.Extensions;
using AxFixEngine.Handlers;
using QuickFix;

namespace AxFixApp
{
    public class Fix44MessageCracker : FixMessageCrackerBase
    {
        #region Admin inbound messages

        public void OnMessageFrom(QuickFix.FIX44.Logon message, SessionID sessionID)
        {
        }

        public void OnMessageFrom(QuickFix.FIX44.Logout message, SessionID sessionID)
        {
        }

        public void OnMessageFrom(QuickFix.FIX44.TestRequest message, SessionID sessionID)
        {
        }

        public void OnMessageFrom(QuickFix.FIX44.ResendRequest message, SessionID sessionID)
        {
        }

        public void OnMessageFrom(QuickFix.FIX44.SequenceReset message, SessionID sessionID)
        {
        }

        public void OnMessageFrom(QuickFix.FIX44.Reject message, SessionID sessionID)
        {
        }

        public void OnMessageFrom(QuickFix.FIX44.Heartbeat message, SessionID sessionID)
        {
        }

        #endregion

        #region Admin outbound messages

        public void OnMessageTo(QuickFix.FIX44.Logon message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.Logout message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.TestRequest message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.ResendRequest message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.SequenceReset message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.Reject message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.Heartbeat message, SessionID sessionID)
        {
        }

        #endregion

        #region Business reject

        public void OnMessageFrom(QuickFix.FIX44.BusinessMessageReject message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.BusinessMessageReject message, SessionID sessionID)
        {
        }

        #endregion

        #region Quote

        public void OnMessageFrom(QuickFix.FIX44.QuoteRequest message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.QuoteRequestReject message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.Quote message, SessionID sessionID)
        {
        }

        public void OnMessageFrom(QuickFix.FIX44.QuoteStatusRequest message, SessionID sessionID)
        {
        }

        public void OnMessageTo(QuickFix.FIX44.QuoteStatusReport message, SessionID sessionID)
        {
        }

        #endregion
    }
}
