using System;
using System.Threading;
using AxUtils;
using AxUtils.Interfaces;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace AxCommonLogger
{
    public class Log4netAsyncAppender : BufferingForwardingAppender
    {
        protected IWorkerQueue<Action> _workerQueue;

        public Log4netAsyncAppender()
        {
            _workerQueue = new WorkerQueue<Action>(item => item());
            _workerQueue.OnWorkerQueueException += (s, a) => LogLog.Error(typeof(Log4netAsyncAppender), "Async log4net appender exception", a.Exception);
        }

        public override void ActivateOptions()
        {
            base.ActivateOptions();

            if (!Lossy)
            {
                return;
            }

            var warn = new LoggingEvent(new LoggingEventData
                                        {
                                            Level = Level.Warn,
                                            LoggerName = GetType().Name,
                                            ThreadName = Thread.CurrentThread.ManagedThreadId.ToString(),
                                            TimeStampUtc = DateTime.UtcNow,
                                            Message = "This appender is 'lossy', log messages may be dropped."
                                        });
            Lossy = false;
            Append(warn);
            Flush();
            Lossy = true;
        }

        /// <summary>
        /// Forward log events to the configured appenders.
        /// </summary>
        protected override void SendBuffer(LoggingEvent[] events)
        {
            // Try sending events in async mode.
            bool addedEvents = _workerQueue.TryAdd(() =>
                                                   {
                                                       base.SendBuffer(events);
                                                       Flush();
                                                   });

            // Worker queue seems canceled, do it in sync mode.
            if (!addedEvents)
            {
                base.SendBuffer(events);
                Flush();
            }
        }

        protected override void OnClose()
        {
            // Cancel async worker queue.
            _workerQueue.Cancel();

            base.OnClose();
        }
    }
}
