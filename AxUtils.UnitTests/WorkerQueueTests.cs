using System;
using System.Threading;
using AxQuality;
using AxUtils.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace AxUtils.UnitTests
{
    internal class WorkerQueueTests : ArrangeActAssert
    {
        protected WorkerQueue<Action> ObjectUnderTest;
        protected Exception RaisedException;
        protected AutoResetEvent WaitEvent;

        public override void Arrange()
        {
            WaitEvent = new AutoResetEvent(false);

            ObjectUnderTest = new WorkerQueue<Action>(action => action());
            ObjectUnderTest.OnWorkerQueueException += OnWorkerQueueException;
        }

        private void OnWorkerQueueException(object sender, WorkerQueueExceptionEventArgs e)
        {
            RaisedException = e.Exception;
        }
    }

    internal class WorkerQueueTests_add_on_canceled_queue : WorkerQueueTests
    {
        public override void Act()
        {
            ObjectUnderTest.Cancel();
            ObjectUnderTest.Add(() => { });
        }

        [Test]
        public void Assert_canceled_queue_raises_WorkerQueueException_when_adding_items()
        {
            RaisedException.Should().BeOfType<WorkerQueueException>();
        }
    }

    internal class WorkerQueueTests_queue_canceled_while_running_items : WorkerQueueTests
    {
        private int Value;

        public override void Act()
        {
            for (int i = 0; i < 10; ++i)
            {
                ObjectUnderTest.Add(() =>
                                    {
                                        Value++;
                                        if (Value == 5)
                                        {
                                            WaitEvent.Set();
                                        }
                                        Thread.Sleep(10);
                                    });
            }

            WaitEvent.WaitOne();
            ObjectUnderTest.Cancel();
        }

        [Test]
        public void Assert_canceled_queue_raises_WorkerQueueException()
        {
            RaisedException.Should().BeOfType<WorkerQueueException>();
        }

        [Test]
        public void Assert_canceled_queue_raises_innerexception_OperationCanceledException()
        {
            RaisedException.InnerException.Should().BeOfType<OperationCanceledException>();
        }

        [Test]
        public void Assert_canceled_consuming_queue_has_run_some_items()
        {
            Value.Should().BeGreaterThan(0);
        }
    }
}
