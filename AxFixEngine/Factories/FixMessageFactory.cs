using AxFixEngine.Dialects;
using AxFixEngine.Interfaces;
using QuickFix;
using QuickFix.DataDictionary;
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

        public Message CreateMessage(string fixMessage, bool validate = true)
        {
            string beginString = Message.ExtractBeginString(fixMessage);
            MsgType msgType = Message.IdentifyType(fixMessage);
            DataDictionary dataDictionary = FixDialectsProvider.Dialects.GetDataDictionary(beginString);

            Message message = _factory.Create(beginString, msgType.getValue());
            message.FromString(fixMessage,
                               validate,
                               dataDictionary,
                               dataDictionary,
                               null);

            return message;
        }
    }
}
