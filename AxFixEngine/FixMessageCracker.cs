using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine
{
    public class FixMessageCracker : MessageCracker, IFixMessageCracker
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
