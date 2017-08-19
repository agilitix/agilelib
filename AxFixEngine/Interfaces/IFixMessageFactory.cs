using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixMessageFactory
    {
        T CreateMessage<T>(string beginString, string msgType) where T : Message;
        Message CreateMessage(string fixMessage, bool validate = true);
    }
}
