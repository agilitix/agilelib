using System;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using log4net.Appender;
using log4net.Core;

namespace AxCommonLogger.Appenders
{
    public class Log4netReactiveForwardingAppender : ForwardingAppender, IDisposable
    {
        // The EventLoopScheduler preserve order of events on dedicated thread.
        protected EventLoopScheduler _scheduler = new EventLoopScheduler();
        protected long _disposed;
        protected ISubject<LoggingEvent> _loggingSubject = new Subject<LoggingEvent>();
        protected IDisposable _appender;

        public Log4netReactiveForwardingAppender()
        {
            _appender = _loggingSubject.AsObservable()
                                       .ObserveOn(_scheduler)
                                       .Where(x => x != null)
                                       .Subscribe(base.Append);
        }

        [DebuggerStepThrough]
        protected override void Append(LoggingEvent loggingEvent)
        {
            _loggingSubject.OnNext(loggingEvent);
        }

        [DebuggerStepThrough]
        protected override void Append(LoggingEvent[] loggingEvents)
        {
            foreach (LoggingEvent loggingEvent in loggingEvents)
            {
                _loggingSubject.OnNext(loggingEvent);
            }
        }

        [DebuggerStepThrough]
        protected override void OnClose()
        {
            _loggingSubject.OnCompleted();
            base.OnClose();
        }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 1)
            {
                return;
            }

            _loggingSubject?.OnCompleted();
            _loggingSubject = null;

            _appender?.Dispose();
            _appender = null;

            _scheduler?.Dispose();
            _scheduler = null;
        }
    }
}
