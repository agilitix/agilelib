using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixMessageHistorizer
    {
        bool Historize(Message message);
    }
}
