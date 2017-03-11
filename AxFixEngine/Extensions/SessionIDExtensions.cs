
using QuickFix;

namespace AxFixEngine.Extensions
{
    public static class SessionIdExtensions
    {
        public static SessionID ToReverse(this SessionID self)
        {
            return new SessionID(self.BeginString, self.TargetCompID, self.SenderCompID, self.SessionQualifier);
        }
    }
}
