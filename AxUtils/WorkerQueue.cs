using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using AxUtils.Interfaces;

namespace AxUtils
{
    public class WorkerQueue<T> : IWorkerQueue<T>
    {
        protected readonly Action<T> _consumer;
        protected readonly CancellationTokenSource _cancellationTokenSource;
        protected readonly BlockingCollection<T> _items;
        protected readonly Task[] _tasks;

        public event EventHandler<WorkerQueueExceptionEventArgs> OnWorkerQueueException;

        public WorkerQueue(Action<T> consumer)
            : this(consumer, 1)
        {
        }

        public WorkerQueue(Action<T> consumer, int concurrencyLevel, int capacity = -1)
        {
            Ensure.That(concurrencyLevel > 0, nameof(concurrencyLevel));
            Ensure.That(capacity == -1 || capacity > 0, nameof(capacity));

            _consumer = consumer;

            _items = capacity > 0
                        ? new BlockingCollection<T>(capacity)  // Bounded queue, new additions will block if the queue is filled.
                        : new BlockingCollection<T>();         // Unbounded queue.

            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = _cancellationTokenSource.Token;

            _tasks = new Task[concurrencyLevel];
            for (int i = 0; i < concurrencyLevel; ++i) // Consume items concurrently if concurrencyLevel>1.
            {
                _tasks[i] = Task.Factory.StartNew(() =>
                                                      {
                                                          try
                                                          {
                                                              foreach (T item in _items.GetConsumingEnumerable(token))
                                                              {
                                                                  // Will throw if the token has been canceled.
                                                                  token.ThrowIfCancellationRequested();

                                                                  try
                                                                  {
                                                                      // Call the consumer with current item.
                                                                      _consumer(item);
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

        public bool TryAdd(T item)
        {
            return TryAdd(item, TimeSpan.Zero);
        }

        public bool TryAdd(T item, TimeSpan timeout)
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

        public void Add(T item)
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

            // Wait and give time to consume outstanding items.
            // If the timeout is too low, several items may be ignored.
            Task.WaitAll(_tasks, timeout);

            // Now cancel the consuming task loop.
            _cancellationTokenSource.Cancel();

            // Wait the task loop to exit.
            Task.WaitAll(_tasks);

            // Now cleaup everything. The WorkerQueue can not be used anymore.
            _cancellationTokenSource.Dispose();
            _items.Dispose();
            foreach (Task task in _tasks)
            {
                task.Dispose();
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
                    // Do not accept new items additions.
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
