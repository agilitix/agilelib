using System.Xml.Linq;
using AxFixEngine.Extensions;
using Message = QuickFix.Message;

namespace AxFixEngine.Decorators
{
    public class FixMessageDecorator : Message
    {
        private readonly Message _message;

        public FixMessageDecorator(Message message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return _message.ToString();
        }

        public XDocument ToXDocument()
        {
            return _message.ToXDocument();
        }

        public T Decorated<T>() where T : Message
        {
            return (T) _message;
        }
    }
}
