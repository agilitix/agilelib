using QuickFix;

namespace AxFixEngine.Extensions
{
    public static class SessionIDExtensions
    {
        public static SessionID GetReverseSessionID(this SessionID self)
        {
            Message dummyMessage = new Message();
            dummyMessage.SetSessionID(self);
            return Message.GetReverseSessionID(dummyMessage);
        }
    }
}
