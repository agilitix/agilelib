using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AxFixEngine.Extensions;
using AxFixEngine.Interfaces;
using QuickFix;
using QuickFix.DataDictionary;

namespace AxFixEngine.Dialects
{
    public class FixDialects : IFixDialects
    {
        protected readonly IDictionary<string, DataDictionary> _dataDictionariesByBeginString = new Dictionary<string, DataDictionary>();

        public FixDialects()
        {
        }

        public FixDialects(string fixSettingsFile)
            : this(new SessionSettings(fixSettingsFile))
        {
        }

        public FixDialects(SessionSettings fixSettings)
        {
            HashSet<SessionID> sessions = fixSettings.GetSessions();
            foreach (SessionID sessionId in sessions)
            {
                if (_dataDictionariesByBeginString.ContainsKey(sessionId.BeginString))
                {
                    continue;
                }

                Dictionary settings = fixSettings.Get(sessionId);
                string specFile = settings.GetString(SessionSettings.DATA_DICTIONARY);

                DataDictionary dataDictionary = new DataDictionary();
                dataDictionary.Load(specFile);
                if (dataDictionary.Version != sessionId.BeginString)
                {
                    throw new InvalidOperationException("BeginString mismatch between session=" + sessionId + " and dictionary spec file=" + specFile);
                }

                _dataDictionariesByBeginString[sessionId.BeginString] = dataDictionary;
            }
        }

        public IDictionary<string, DataDictionary> GetAllDataDictionaries()
        {
            return _dataDictionariesByBeginString;
        }

        public void SetDataDictionary(string beginString, DataDictionary dataDictionary)
        {
            _dataDictionariesByBeginString[beginString] = dataDictionary;
        }

        public DataDictionary GetDataDictionary(string beginString)
        {
            DataDictionary dataDictionary;
            if (TryGetDataDictionary(beginString, out dataDictionary))
            {
                return dataDictionary;
            }

            return null;
        }

        public bool TryGetDataDictionary(string beginString, out DataDictionary dataDictionary)
        {
            return _dataDictionariesByBeginString.TryGetValue(beginString, out dataDictionary);
        }
    }
}
