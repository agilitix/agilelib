using QuickFix;
using QuickFix.Fields;

namespace AxFixEngine.Messages
{
    public interface IFixMessageParser
    {
        BeginString ParseBeginString(string fixMessage);
        MsgType ParseMsgType(string fixMessage);

        Header ParseHeader(string fixMessage);
        Message ParseMessage(string fixMessage, bool validate = true);
    }
}
