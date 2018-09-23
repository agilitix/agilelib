using QuickFix;

namespace AxFixEngine.Handlers
{
    public interface IFixMessageHandlers
    {
        void SetMessageHandler(SessionID sessionId, IFixMessageHandler handler);
        IFixMessageHandler GetMessageHandler(SessionID sessionId);
    }
}
