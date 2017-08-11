using System.Collections.Generic;
using QuickFix;
using QuickFix.DataDictionary;

namespace AxFixEngine.Interfaces
{
    public interface IFixDialects
    {
        void AddDataDictionaries(SessionSettings fixSettings);

        DataDictionary GetDataDictionary(SessionID sessionID);
        bool TryGetDataDictionary(SessionID sessionID, out DataDictionary dataDictionary);
    }
}
