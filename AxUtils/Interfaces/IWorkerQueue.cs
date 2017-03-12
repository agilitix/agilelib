using System;

namespace AxUtils.Interfaces
{
    public interface IWorkerQueue<in T> : IDisposable
    {
        bool TryEnqueue(T job);
        void Enqueue(T job);
    }
}
