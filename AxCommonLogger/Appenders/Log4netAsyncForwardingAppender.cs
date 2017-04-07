using System;
using System.Diagnostics;
using AxUtils;
using AxUtils.Interfaces;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace AxCommonLogger.Appenders
{
    public class Log4netAsyncForwardingAppender : ForwardingAppender
    {
        protected IWorkerQueue<Action> _workerQueue;

        public Log4netAsyncForwardingAppender()
        {
            _workerQueue = new WorkerQueue<Action>(appendLog => appendLog());
            _workerQueue.OnWorkerQueueException += (s, e) =>
                                                   {
                                                       LogLog.Error(typeof(Log4netAsyncForwardingAppender),
                                                                    "WorkerQueue has raised an exception in the log4net async appender",
                                                                    e.Exception);
                                                   };
        }

        [DebuggerStepThrough]
        protected override void Append(LoggingEvent loggingEvent)
        {
            if (!_workerQueue.TryAdd(() => base.Append(loggingEvent)))
            {
                base.Append(loggingEvent);
            }
        }

        [DebuggerStepThrough]
        protected override void Append(LoggingEvent[] loggingEvents)
        {
            if (!_workerQueue.TryAdd(() => base.Append(loggingEvents)))
            {
                base.Append(loggingEvents);
            }
        }

        [DebuggerStepThrough]
        protected override void OnClose()
        {
            _workerQueue.Cancel();
            base.OnClose();
        }
    }
}
