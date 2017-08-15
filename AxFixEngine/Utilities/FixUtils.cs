using AxFixEngine.Dialects;
using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;

namespace AxFixEngine.Utilities
{
    public static class FixUtils
    {
        //public static Message ParseHeader(string fixMessage)
        //{
        //    Message dummyMessage = new Message();
        //    return dummyMessage.FromStringHeader(fixMessage)
        //               ? dummyMessage
        //               : null;
        //}

        //public static string ParseBeginString(string fixMessage)
        //{
        //    return Message.ExtractBeginString(fixMessage);
        //}

        //public static SessionID ParseSessionID(string fixMessage)
        //{
        //    Message dummyMessage = new Message();
        //    return dummyMessage.FromStringHeader(fixMessage)
        //               ? dummyMessage.GetSessionID(dummyMessage)
        //               : null;
        //}

        //public static MsgType ParseMsgType(string fixMessage)
        //{
        //    return Message.IdentifyType(fixMessage);
        //}
    }
}
