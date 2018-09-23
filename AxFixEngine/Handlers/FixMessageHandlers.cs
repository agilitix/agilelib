using System.Collections.Generic;
using AxFixEngine.Extensions;
using QuickFix;

namespace AxFixEngine.Handlers
{
    public class FixMessageHandlers : IFixMessageHandlers
    {
        protected IDictionary<SessionID, IFixMessageHandler> _handlers = new Dictionary<SessionID, IFixMessageHandler>();

        public void SetMessageHandler(SessionID sessionId, IFixMessageHandler handler)
        {
            _handlers[sessionId] = handler;
            _handlers[sessionId.GetReverseSessionID()] = handler;
        }

        public IFixMessageHandler GetMessageHandler(SessionID sessionId)
        {
            IFixMessageHandler handler;
            return _handlers.TryGetValue(sessionId, out handler)
                       ? handler
                       : _handlers.TryGetValue(sessionId.GetReverseSessionID(), out handler)
                           ? handler
                           : null;
        }
    }
}
