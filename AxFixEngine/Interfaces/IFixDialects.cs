using System.Collections.Generic;
using QuickFix;
using QuickFix.DataDictionary;

namespace AxFixEngine.Interfaces
{
    public interface IFixDialects
    {
        IDictionary<string /*BeginString*/, DataDictionary> GetAllDataDictionaries();

        void SetDataDictionary(string beginString, DataDictionary dataDictionary);

        DataDictionary GetDataDictionary(string beginString);
        bool TryGetDataDictionary(string beginString, out DataDictionary dataDictionary);
    }
}
