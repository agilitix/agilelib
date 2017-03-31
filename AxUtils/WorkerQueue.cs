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
        protected readonly BlockingCollection<Action> _items;
        protected readonly Task[] _consumers;

        public event EventHandler<WorkerQueueExceptionEventArgs> OnWorkerQueueException;

        public WorkerQueue()
            : this(1)
        {
        }

        public WorkerQueue(int concurrencyLevel, int capacity = -1)
        {
            _items = capacity > 0
                        ? new BlockingCollection<Action>(capacity)
                        : new BlockingCollection<Action>();

            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = _cancellationTokenSource.Token;

            _consumers = new Task[concurrencyLevel];
            for (int i = 0; i < concurrencyLevel; ++i)
            {
                _consumers[i] = Task.Factory.StartNew(() =>
                                                      {
                                                          try
                                                          {
                                                              foreach (Action item in _items.GetConsumingEnumerable(token))
                                                              {
                                                                  token.ThrowIfCancellationRequested();

                                                                  try
                                                                  {
                                                                      item();
                                                                  }
                                                                  catch (Exception e)
                                                                  {
                                                                      OnWorkerQueueException?.Invoke(this, new WorkerQueueExceptionEventArgs(new WorkerQueueException("Exception caught from item execution in the queue.", e)));
                                                                  }
                                                              }
                                                          }
                                                          catch (Exception e)
                                                          {
                                                              CompleteAdding();
                                                              OnWorkerQueueException?.Invoke(this, new WorkerQueueExceptionEventArgs(new WorkerQueueException("Exception caught while consuming items from the queue.", e)));
                                                          }
                                                      },
                                                      token,
                                                      TaskCreationOptions.LongRunning,
                                                      TaskScheduler.Default);
            }
        }

        public bool TryAdd(Action item)
        {
            return TryAdd(item, TimeSpan.Zero);
        }

        public bool TryAdd(Action item, TimeSpan timeout)
        {
            try
            {
                return _items.TryAdd(item, timeout);
            }
            catch (Exception e)
            {
                OnWorkerQueueException?.Invoke(this, new WorkerQueueExceptionEventArgs(new WorkerQueueException("Exception caught while trying to add a new item in the queue.", e)));
                return false;
            }
        }

        public void Add(Action item)
        {
            try
            {
                _items.Add(item);
            }
            catch (Exception e)
            {
                OnWorkerQueueException?.Invoke(this, new WorkerQueueExceptionEventArgs(new WorkerQueueException("Exception caught while adding a new item in the queue.", e)));
            }
        }

        public void Cancel(TimeSpan timeout)
        {
            CompleteAdding();

            Task.WaitAll(_consumers, timeout);
            _cancellationTokenSource.Cancel();
            Task.WaitAll(_consumers);

            _cancellationTokenSource.Dispose();
            _items.Dispose();

            foreach (Task consumer in _consumers)
            {
                consumer.Dispose();
            }
        }

        public void Cancel()
        {
            Cancel(TimeSpan.Zero);
        }

        protected void CompleteAdding()
        {
            try
            {
                if (!_items.IsAddingCompleted)
                {
                    _items.CompleteAdding();
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}
