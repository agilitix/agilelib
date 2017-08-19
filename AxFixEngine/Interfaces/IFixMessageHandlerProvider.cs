using System.Collections.Generic;
using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixMessageHandlerProvider
    {
        void AddMessageHandler(SessionID sessionId, IFixMessageHandler handler);
        IList<IFixMessageHandler> GetMessageHandlers(SessionID sessionId);
    }
}
