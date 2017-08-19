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
        protected IDictionary<string, IList<IFixMessageHandler>> _handlers = new Dictionary<string, IList<IFixMessageHandler>>();

        public void AddMessageHandler(SessionID sessionId, IFixMessageHandler handler)
        {
            string key = BuildKey(sessionId);
            if (_handlers.ContainsKey(key) == false)
            {
                _handlers[key] = new List<IFixMessageHandler>();
            }
            _handlers[key].Add(handler);
        }

        public IList<IFixMessageHandler> GetMessageHandlers(SessionID sessionId)
        {
            IList<IFixMessageHandler> handlers;
            return _handlers.TryGetValue(BuildKey(sessionId), out handlers)
                       ? handlers
                       : null;
        }

        protected string BuildKey(SessionID sessionId)
        {
            return sessionId.BeginString + ":" + sessionId.SenderCompID + "/" + sessionId.TargetCompID;
        }
    }
}
