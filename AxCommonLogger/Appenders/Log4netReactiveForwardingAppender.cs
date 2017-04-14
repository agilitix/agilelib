using System;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using log4net.Appender;
using log4net.Core;

namespace AxCommonLogger.Appenders
{
    public class Log4netReactiveForwardingAppender : ForwardingAppender, IDisposable
    {
        protected IDisposable _cleanUp;
        protected EventLoopScheduler _orderedScheduler = new EventLoopScheduler();
        protected ISubject<LoggingEvent[]> _loggingSubject = new Subject<LoggingEvent[]>();

        public Log4netReactiveForwardingAppender()
        {
            IDisposable appender = _loggingSubject.AsObservable()
                                                  .ObserveOn(_orderedScheduler)
                                                  .Where(x => x != null)
                                                  .Subscribe(x => base.Append(x));

            _cleanUp = Disposable.Create(() => { appender.Dispose(); });
        }

        [DebuggerStepThrough]
        protected override void Append(LoggingEvent loggingEvent)
        {
            _loggingSubject.OnNext(new[] {loggingEvent});
        }

        [DebuggerStepThrough]
        protected override void Append(LoggingEvent[] loggingEvents)
        {
            _loggingSubject.OnNext(loggingEvents);
        }

        [DebuggerStepThrough]
        protected override void OnClose()
        {
            _loggingSubject.OnCompleted();
            base.OnClose();
        }

        public void Dispose()
        {
            _cleanUp?.Dispose();
            _cleanUp = null;

            _loggingSubject?.OnCompleted();
            _loggingSubject = null;

            _orderedScheduler?.Dispose();
            _orderedScheduler = null;
        }
    }
}
