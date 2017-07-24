using AxFixEngine.Dialects;
using AxFixEngine.Interfaces;
using AxFixEngine.Utilities;
using QuickFix;
using QuickFix.Fields;
using Message = QuickFix.Message;

namespace AxFixEngine.Factories
{
    public class FixMessageFactory : IFixMessageFactory
    {
        private readonly IMessageFactory _factory;

        public FixMessageFactory(IMessageFactory factory)
        {
            _factory = factory;
        }

        public Message CreateMessageFromString(string fixMessage)
        {
            SessionID sessionId = FixUtils.GetSessionID(fixMessage);
            Message message = new Message(fixMessage,
                                          FixDialectsProvider.Dialects.GetDataDictionary(sessionId),
                                          false);
            return message;
        }

        public Message CreateValidatedMessageFromString(string fixMessage)
        {
            SessionID sessionId = FixUtils.GetSessionID(fixMessage);
            Message message = new Message(fixMessage,
                                          FixDialectsProvider.Dialects.GetDataDictionary(sessionId),
                                          true);
            return message;
        }

        public TMessage CreateMessage<TMessage>(SessionID sessionID, MsgType msgType) where TMessage : Message
        {
            Message msg = _factory.Create(sessionID.BeginString, msgType.getValue());
            return (TMessage) msg;
        }

        public TReply CreateReplyMessage<TReply>(Message request, MsgType replyType) where TReply : Message
        {
            Message msg = _factory.Create(request.GetField(Tags.BeginString), replyType.getValue());
            msg.ReverseRoute(request.Header);
            return (TReply) msg;
        }
    }
}
