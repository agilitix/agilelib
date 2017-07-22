using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine.Factories
{
    public class FixMessageFactory : IFixMessageFactory
    {
        protected readonly IMessageFactory _messageFactory;

        public FixMessageFactory(IMessageFactory messageFactory)
        {
            _messageFactory = messageFactory;
        }

        // TODO.
    }
}
