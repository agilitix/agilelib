using System;
using System.IO;
using AxFixEngine.Interfaces;
using AxUtils;
using AxUtils.Interfaces;
using QuickFix;

namespace AxFixEngine.Utilities
{
    public class FixMessageFileHistorizer : IFixMessageHistorizer
    {
        protected readonly string _historyFolder;
        protected readonly IWorkerQueue<Action> _workerQueue = new WorkerQueue<Action>(action => action());

        public FixMessageFileHistorizer(string historyFolder)
        {
            _historyFolder = historyFolder;
        }

        public bool Historize(Message message)
        {
            return _workerQueue.TryAdd(() => { File.AppendAllText(GetFileName(), message + Environment.NewLine); });
        }

        protected string GetFileName()
        {
            return _historyFolder + @"\" + DateTime.Now.ToString("yyyyMMdd") + "-messages.log";
        }
    }
}
