using AxFixEngine.Dialects;
using AxFixEngine.Extensions;
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
            return CreateMessageFromString(fixMessage, false);
        }

        public Message CreateValidatedMessageFromString(string fixMessage)
        {
            return CreateMessageFromString(fixMessage, true);
        }

        public TMessage CreateMessage<TMessage>(SessionID sessionID, MsgType msgType) where TMessage : Message
        {
            Message msg = _factory.Create(sessionID.BeginString, msgType.getValue());
            return (TMessage) msg;
        }

        private Message CreateMessageFromString(string fixMessage, bool validate)
        {
            Message headerOnly = new Message();
            headerOnly.FromStringHeader(fixMessage);

            Message message = new Message(fixMessage,
                                          FixDialectsProvider.Dialects.GetDataDictionary(headerOnly.GetSessionID()),
                                          validate);
            return message;
        }

    }
}
