using System;
using System.IO;
using AxFixEngine.Interfaces;
using AxUtils;
using AxUtils.Interfaces;
using QuickFix;

namespace AxFixEngine
{
    public class FixMessageFileHistorizer : IFixMessageHistorizer
    {
        protected readonly string _historyOutputFileName;
        protected readonly IWorkerQueue<Action> _workerQueue = new WorkerQueue<Action>(action => action());

        public FixMessageFileHistorizer(string historyOutputFileName)
        {
            _historyOutputFileName = historyOutputFileName;
        }

        public bool Historize(Message message)
        {
            return _workerQueue.TryAdd(() => { File.AppendAllText(_historyOutputFileName, message + Environment.NewLine); });
        }
    }
}