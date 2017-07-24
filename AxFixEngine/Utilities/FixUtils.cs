using QuickFix;
using QuickFix.Fields;

namespace AxFixEngine.Utilities
{
    public static class FixUtils
    {
        public static SessionID ParseSessionID(string fixMessage)
        {
            Message msg = new Message();
            if (msg.FromStringHeader(fixMessage))
            {
                return msg.GetSessionID(msg);
            }

            return null;
        }

        public static MsgType ParseMsgType(string fixMessage)
        {
            Message msg = new Message();
            if (msg.FromStringHeader(fixMessage))
            {
                return new MsgType(msg.Header.GetField(Tags.MsgType));
            }

            return null;
        }

        public static string ParseBeginString(string fixMessage)
        {
            return Message.ExtractBeginString(fixMessage);
        }
    }
}
