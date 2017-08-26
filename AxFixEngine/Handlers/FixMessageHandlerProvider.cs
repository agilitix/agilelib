using System.Collections.Generic;
using QuickFix;

namespace AxFixEngine.Handlers
{
    public class FixMessageHandlerProvider : IFixMessageHandlerProvider
    {
        protected IDictionary<SessionID, IFixMessageHandler> _handlers = new Dictionary<SessionID, IFixMessageHandler>();

        public void SetMessageHandler(SessionID sessionId, IFixMessageHandler handler)
        {
            _handlers[sessionId] = handler;
        }

        public IFixMessageHandler GetMessageHandler(SessionID sessionId)
        {
            IFixMessageHandler handler;
            return _handlers.TryGetValue(sessionId, out handler)
                       ? handler
                       : null;
        }
    }
}
