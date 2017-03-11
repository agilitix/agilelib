using System;
using System.IO;
using AxFixEngine.Interfaces;
using AxUtils;
using QuickFix;

namespace AxFixEngine
{
    public class FixMessageFileHistorizer : IFixMessageHistorizer
    {
        protected readonly string _historyOutputFileName;
        protected readonly FifoWorkerQueue _workerQueue = new FifoWorkerQueue();

        public FixMessageFileHistorizer(string historyOutputFileName)
        {
            _historyOutputFileName = historyOutputFileName;
        }

        public bool Historize(Message message)
        {
            return _workerQueue.Enqueue(() => { File.AppendAllText(_historyOutputFileName, message + Environment.NewLine); });
        }
    }
}
