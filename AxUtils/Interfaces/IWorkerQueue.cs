using System;

namespace AxUtils.Interfaces
{
    public interface IWorkerQueue<in T>
    {
        event EventHandler<WorkerQueueExceptionEventArgs> OnWorkerQueueException;

        bool TryAdd(T item);
        bool TryAdd(T item, TimeSpan timeout);

        void Add(T item);

        void Cancel();
        void Cancel(TimeSpan timeout);
    }
}
