using QuickFix;
using QuickFix.DataDictionary;

namespace AxFixEngine.Dialects
{
    public interface IFixDialects
    {
        void AddDataDictionaries(SessionSettings fixSettings);

        DataDictionary GetDataDictionary(string beginString);
        bool TryGetDataDictionary(string beginString, out DataDictionary dataDictionary);
    }
}
