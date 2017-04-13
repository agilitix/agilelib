using System;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using log4net.Appender;
using log4net.Core;

namespace AxCommonLogger.Appenders
{
    public class Log4netReactiveForwardingAppender : ForwardingAppender
    {
        private readonly EventLoopScheduler _orderedScheduler = new EventLoopScheduler();
        protected ISubject<LoggingEvent[]> _loggingSubject = new Subject<LoggingEvent[]>();

        public Log4netReactiveForwardingAppender()
        {
            _loggingSubject.AsObservable()
                           .ObserveOn(_orderedScheduler)
                           .Subscribe(x => base.Append(x));
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
    }
}
