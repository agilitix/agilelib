using System;
using System.Collections.Generic;
using AxFixEngine.Dialects;
using AxFixEngine.Extensions;
using AxFixEngine.Interfaces;
using AxFixEngine.Utilities;
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

        public Message CreateMessageFromString(string fixMessage)
        {
            SessionID sessionId = FixUtils.GetSessionID(fixMessage);
            Message message = new Message(fixMessage,
                                          FixDialectsProvider.Dialects.GetDataDictionary(sessionId),
                                          false);
            return message;
        }

        public Message CreateValidatedMessageFromString(string fixMessage)
        {
            SessionID sessionId = FixUtils.GetSessionID(fixMessage);
            Message message = new Message(fixMessage,
                                          FixDialectsProvider.Dialects.GetDataDictionary(sessionId),
                                          true);
            return message;
        }

        public T CreateMessage<T>(SessionID sessionID, string msgType) where T : Message
        {
            Message msg = _factory.Create(sessionID.BeginString, msgType);
            return (T) msg;
        }
    }
}
