using System;
using System.Collections.Generic;
using AxFixEngine.Extensions;
using AxFixEngine.Interfaces;
using QuickFix;
using QuickFix.DataDictionary;

namespace AxFixEngine.Dialects
{
    public class FixDialects : IFixDialects
    {
        protected readonly IDictionary<SessionID, DataDictionary> _dataDictionaries = new Dictionary<SessionID, DataDictionary>();
        protected readonly IDictionary<string, DataDictionary> _dataDictionariesBySpecFile = new Dictionary<string, DataDictionary>();

        public void AddDataDictionaries(SessionSettings fixSettings)
        {
            HashSet<SessionID> sessions = fixSettings.GetSessions();
            foreach (SessionID sessionId in sessions)
            {
                Dictionary settings = fixSettings.Get(sessionId);
                string specFile = settings.GetString(SessionSettings.DATA_DICTIONARY);

                DataDictionary dataDictionary;
                if (!_dataDictionariesBySpecFile.TryGetValue(specFile, out dataDictionary))
                {
                    dataDictionary = new DataDictionary();
                    dataDictionary.Load(specFile);
                    if (dataDictionary.Version != sessionId.BeginString)
                    {
                        throw new InvalidOperationException("Cannot use SessionID=" + sessionId + " with dictionary read from spec file=" + specFile + " => the BeginString are not equal");
                    }
                }

                _dataDictionaries[sessionId] = _dataDictionaries[sessionId.GetReverseSessionID()] = dataDictionary;
            }
        }

        public DataDictionary GetDataDictionary(SessionID sessionID)
        {
            DataDictionary dataDictionary;
            return TryGetDataDictionary(sessionID, out dataDictionary)
                       ? dataDictionary
                       : null;
        }

        public bool TryGetDataDictionary(SessionID sessionID, out DataDictionary dataDictionary)
        {
            return _dataDictionaries.TryGetValue(sessionID, out dataDictionary);
        }
    }
}
