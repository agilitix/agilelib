using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixMessageHistory
    {
        bool Historize(Message message);
    }
}
