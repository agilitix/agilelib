using System;

namespace AxUtils.Interfaces
{
    public interface IWorkerQueue<in T>
    {
        event EventHandler<WorkerQueueExceptionEventArgs> OnWorkerQueueException;

        bool TryAdd(T job);
        bool TryAdd(Action job, TimeSpan timeout);

        void Add(T job);

        void Cancel();
        void Cancel(TimeSpan timeouts);
    }
}
