using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickFix;

namespace AxFixEngine.Extensions
{
    public static class SessionIDExtensions
    {
        public static SessionID GetReverseSessionID(this SessionID self)
        {
            return new SessionID(self.BeginString,
                                 self.TargetCompID,
                                 self.TargetSubID,
                                 self.TargetLocationID,
                                 self.SenderCompID,
                                 self.SenderSubID,
                                 self.SenderLocationID);
        }
    }
}
