using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxFixEngine.Extensions;
using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine.Handlers
{
    public class FixMessageHandlerProvider : IFixMessageHandlerProvider
    {
        protected IDictionary<SessionID, IList<IFixMessageHandler>> _handlers = new Dictionary<SessionID, IList<IFixMessageHandler>>();

        public void AddMessageHandler(SessionID sessionId, IFixMessageHandler handler)
        {
            if (_handlers.ContainsKey(sessionId) == false)
            {
                _handlers[sessionId] = new List<IFixMessageHandler>();
            }
            _handlers[sessionId].Add(handler);
        }

        public IList<IFixMessageHandler> GetMessageHandlers(SessionID sessionId, FixMessageDirection direction)
        {
            IList<IFixMessageHandler> handlers;
            return _handlers.TryGetValue(sessionId, out handlers)
                       ? handlers.Where(x => direction == FixMessageDirection.Both || x.Direction == direction).ToList()
                       : null;
        }
    }
}
