using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickFix;

namespace AxFixEngine
{
    public class FixMessageHandler : MessageCracker
    {
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
