using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using AxUtils.Interfaces;

namespace AxUtils
{
    public class WorkerQueue : IWorkerQueue<Action>
    {
        protected readonly CancellationTokenSource _cancellationTokenSource;
        protected readonly BlockingCollection<Action> _jobs;
        protected readonly Task _consumer;

        public event EventHandler<WorkerQueueExceptionEventArgs> OnWorkerQueueException;

        public WorkerQueue(int capacity = -1)
        {
            _jobs = capacity > 0
                        ? new BlockingCollection<Action>(capacity)
                        : new BlockingCollection<Action>();

            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = _cancellationTokenSource.Token;

            _consumer = Task.Factory.StartNew(() =>
                                              {
                                                  try
                                                  {
                                                      foreach (Action job in _jobs.GetConsumingEnumerable(token))
                                                      {
                                                          token.ThrowIfCancellationRequested();

                                                          try
                                                          {
                                                              job();
                                                          }
                                                          catch (Exception e)
                                                          {
                                                              OnWorkerQueueException?.Invoke(this, new WorkerQueueExceptionEventArgs(new WorkerQueueException("Exception caught from job execution in the queue.", e)));
                                                          }
                                                      }
                                                  }
                                                  catch (Exception e)
                                                  {
                                                      CompleteAdding();
                                                      OnWorkerQueueException?.Invoke(this, new WorkerQueueExceptionEventArgs(new WorkerQueueException("Exception caught while consuming jobs from the queue.", e)));
                                                  }
                                              },
                                              token,
                                              TaskCreationOptions.LongRunning,
                                              TaskScheduler.Default);
        }

        public bool TryAdd(Action job)
        {
            return TryAdd(job, TimeSpan.Zero);
        }

        public bool TryAdd(Action job, TimeSpan timeout)
        {
            try
            {
                return _jobs.TryAdd(job, timeout);
            }
            catch (Exception e)
            {
                OnWorkerQueueException?.Invoke(this, new WorkerQueueExceptionEventArgs(new WorkerQueueException("Exception caught while trying to add a new job in the queue.", e)));
                return false;
            }
        }

        public void Add(Action job)
        {
            try
            {
                _jobs.Add(job);
            }
            catch (Exception e)
            {
                OnWorkerQueueException?.Invoke(this, new WorkerQueueExceptionEventArgs(new WorkerQueueException("Exception caught while adding a new job in the queue.", e)));
            }
        }

        public void Cancel(TimeSpan timeout)
        {
            CompleteAdding();

            _consumer.Wait(timeout);
            _cancellationTokenSource.Cancel();
            _consumer.Wait();

            _cancellationTokenSource.Dispose();
            _jobs.Dispose();
            _consumer.Dispose();
        }

        public void Cancel()
        {
            Cancel(TimeSpan.Zero);
        }

        protected void CompleteAdding()
        {
            try
            {
                if (!_jobs.IsAddingCompleted)
                {
                    _jobs.CompleteAdding();
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}
