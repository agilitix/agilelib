using QuickFix;
using QuickFix.DataDictionary;

namespace AxFixEngine.Dialects
{
    public interface IFixDialects
    {
        void AddSessionSettings(SessionSettings fixSettings);

        DataDictionary GetDataDictionary(SessionID sessionId);
        bool TryGetDataDictionary(SessionID sessionId, out DataDictionary dataDictionary);
    }
}
