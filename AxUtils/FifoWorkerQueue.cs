using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace AxUtils
{
    public class FifoWorkerQueue
    {
        protected readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        protected readonly BlockingCollection<Action> _jobs = new BlockingCollection<Action>();
        protected readonly Task _runner;

        public FifoWorkerQueue()
        {
            _runner = Task.Factory.StartNew(state =>
                                            {
                                                CancellationToken token = (CancellationToken)state;
                                                try
                                                {
                                                    foreach (Action job in _jobs.GetConsumingEnumerable(token))
                                                    {
                                                        job();
                                                    }
                                                }
                                                catch (OperationCanceledException)
                                                {
                                                }
                                            },
                                            _cancellationTokenSource.Token,
                                            TaskCreationOptions.LongRunning);
        }

        public bool Enqueue(Action job)
        {
            try
            {
                _jobs.Add(job);
                return true;
            }
            catch (InvalidOperationException)
            {
            }

            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _jobs?.CompleteAdding();
                _cancellationTokenSource?.Cancel();
                _runner.Wait();

                _cancellationTokenSource?.Dispose();
                _jobs?.Dispose();
                _runner?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~FifoWorkerQueue()
        {
            Dispose(false);
        }
    }
}
