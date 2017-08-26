using QuickFix;

namespace AxFixEngine.Handlers
{
    public interface IFixMessageHandlerProvider
    {
        void SetMessageHandler(SessionID sessionId, IFixMessageHandler handler);
        IFixMessageHandler GetMessageHandler(SessionID sessionId);
    }
}
