using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxFixEngine.Extensions;
using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine.Handlers
{
    public class FixMessageCrackerProvider : IFixMessageCrackerProvider
    {
        protected IDictionary<string, IList<IFixMessageCracker>> _handlers = new Dictionary<string, IList<IFixMessageCracker>>();

        public void AddMessageCracker(SessionID sessionId, IFixMessageCracker cracker)
        {
            string key = BuildKey(sessionId);
            if (_handlers.ContainsKey(key) == false)
            {
                _handlers[key] = new List<IFixMessageCracker>();
            }
            _handlers[key].Add(cracker);
        }

        public IList<IFixMessageCracker> GetMessageCrackers(SessionID sessionId)
        {
            IList<IFixMessageCracker> handlers;
            return _handlers.TryGetValue(BuildKey(sessionId), out handlers)
                       ? handlers
                       : null;
        }

        public IList<IFixMessageCracker> GetInboundMessageCrackers(SessionID sessionId)
        {
            return GetdMessageHandlers(sessionId, FixMessageDirection.Inbound);
        }

        public IList<IFixMessageCracker> GetOutboundMessageCrackers(SessionID sessionId)
        {
            return GetdMessageHandlers(sessionId, FixMessageDirection.Outbound);
        }

        protected IList<IFixMessageCracker> GetdMessageHandlers(SessionID sessionId, FixMessageDirection direction)
        {
            IList<IFixMessageCracker> handlers;
            return _handlers.TryGetValue(BuildKey(sessionId), out handlers)
                       ? handlers.Where(x => x.Direction == direction).ToList()
                       : null;
        }

        protected string BuildKey(SessionID sessionId)
        {
            return sessionId.BeginString + ":" + sessionId.SenderCompID + "/" + sessionId.TargetCompID;
        }
    }
}
