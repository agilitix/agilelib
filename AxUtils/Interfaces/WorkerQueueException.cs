using System;

namespace AxUtils
{
    public sealed class WorkerQueueExceptionEventArgs : EventArgs
    {
        public WorkerQueueException Exception { get; }

        public WorkerQueueExceptionEventArgs(WorkerQueueException e)
        {
            Exception = e;
        }
    }

    public sealed class WorkerQueueException : Exception
    {
        public WorkerQueueException()
        {
        }

        public WorkerQueueException(string message)
            : base(message)
        {
        }

        public WorkerQueueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
