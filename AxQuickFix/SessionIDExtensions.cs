
using QuickFix;

namespace AxQuickFix
{
    public static class SessionIDExtensions
    {
        public static SessionID ToReverse(this SessionID self)
        {
            return new SessionID(self.BeginString, self.TargetCompID, self.SenderCompID, self.SessionQualifier);
        }
    }
}
