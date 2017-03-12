using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using AxUtils.Interfaces;

namespace AxUtils
{
    public class FifoWorkerQueue: IWorkerQueue<Action>
    {
        protected readonly CancellationTokenSource _cancellationTokenSource;
        protected readonly CancellationToken _cancellationToken;
        protected readonly BlockingCollection<Action> _jobs;
        protected readonly Task _runner;

        public FifoWorkerQueue()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            _jobs = new BlockingCollection<Action>();

            _runner = Task.Factory.StartNew(state =>
                {
                    CancellationToken token = (CancellationToken) state;
                    try
                    {
                        foreach (Action job in _jobs.GetConsumingEnumerable(token))
                        {
                            job();
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // The task has been cancelled.
                    }
                    catch (ThreadAbortException)
                    {
                        // May occur on domain unload.
                        _jobs.CompleteAdding();
                    }
                    catch (Exception)
                    {
                        // Other exceptions.
                        _jobs.CompleteAdding();
                    }
                },
                _cancellationToken,
                TaskCreationOptions.LongRunning);
        }

        public bool TryEnqueue(Action job)
        {
            try
            {
                _jobs.Add(job, _cancellationToken);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        public void Enqueue(Action job)
        {
            _jobs.Add(job, _cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Stop adding new jobs.
                _jobs?.CompleteAdding();

                // Cancel the job task runner.
                _cancellationTokenSource?.Cancel();

                // Wait the task runner for completion.
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