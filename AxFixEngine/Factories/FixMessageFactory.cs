using AxFixEngine.Dialects;
using AxFixEngine.Interfaces;
using QuickFix;
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

        public T CreateMessage<T>(string beginString, string msgType) where T : Message
        {
            return (T) _factory.Create(beginString, msgType);
        }

        public Message CreateMessage(string fixMessage, bool validate = true)
        {
            string beginString = Message.ExtractBeginString(fixMessage);
            Message message = new Message(fixMessage,
                                          FixDialectsProvider.Dialects.GetDataDictionary(beginString),
                                          validate);
            return message;
        }
    }
}
