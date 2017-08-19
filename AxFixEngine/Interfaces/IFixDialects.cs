using System.Collections.Generic;
using QuickFix;
using QuickFix.DataDictionary;

namespace AxFixEngine.Interfaces
{
    public interface IFixDialects
    {
        void AddDataDictionaries(SessionSettings fixSettings);

        DataDictionary GetDataDictionary(string beginString);
        bool TryGetDataDictionary(string beginString, out DataDictionary dataDictionary);
    }
}
