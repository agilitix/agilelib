using System.Collections.Generic;
using QuickFix;
using QuickFix.DataDictionary;

namespace AxFixEngine.Interfaces
{
    public interface IFixDialects
    {
        IDictionary<SessionID, DataDictionary> GetAllDataDictionaries();
        DataDictionary GetDataDictionary(SessionID sessionId);
        bool TryGetDataDictionary(SessionID sessionId, out DataDictionary dataDictionary);
    }
}
