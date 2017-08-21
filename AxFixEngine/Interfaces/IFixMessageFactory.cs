using QuickFix;
using QuickFix.Fields;

namespace AxFixEngine.Interfaces
{
    public interface IFixMessageFactory
    {
        Message CreateMessage(string fixMessage, bool validate = true);
    }
}
