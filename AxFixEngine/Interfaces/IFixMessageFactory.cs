using QuickFix;
using QuickFix.Fields;

namespace AxFixEngine.Interfaces
{
    public interface IFixMessageFactory
    {
        T CreateMessage<T>(SessionID sessionID, MsgType msgType) where T : Message;
        TReply CreateReplyMessage<TReply>(Message request, MsgType replyType) where TReply : Message;

        Message CreateMessageFromString(string fixMessage);
        Message CreateValidatedMessageFromString(string fixMessage);
    }
}
