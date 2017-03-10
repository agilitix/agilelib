using System;
using System.IO;
using AxFixEngine.Interfaces;
using AxUtils;
using QuickFix;

namespace AxFixEngine
{
    public class FixMessageFileHistory : IFixMessageHistory
    {
        protected readonly string _fileName;
        protected readonly FifoWorkerQueue _workerQueue = new FifoWorkerQueue();

        public FixMessageFileHistory(string fileName)
        {
            _fileName = fileName;
        }

        public bool Historize(Message message)
        {
            return _workerQueue.Enqueue(() => { File.AppendAllText(_fileName, message + Environment.NewLine); });
        }
    }
}
