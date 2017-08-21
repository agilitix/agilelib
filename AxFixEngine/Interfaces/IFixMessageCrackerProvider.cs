using System.Collections.Generic;
using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixMessageCrackerProvider
    {
        void AddMessageCracker(SessionID sessionId, IFixMessageCracker cracker);

        IList<IFixMessageCracker> GetMessageCrackers(SessionID sessionId);
        IList<IFixMessageCracker> GetInboundMessageCrackers(SessionID sessionId);
        IList<IFixMessageCracker> GetOutboundMessageCrackers(SessionID sessionId);
    }
}
