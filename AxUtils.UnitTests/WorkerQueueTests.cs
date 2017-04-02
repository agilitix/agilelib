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

        public override void Arrange()
        {
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
        protected int Value;

        public override void Act()
        {
            ObjectUnderTest.Add(() =>
                                {
                                    Thread.Sleep(100);
                                    Value = 100;
                                });
            Thread.Sleep(5);
            ObjectUnderTest.Cancel();
            ObjectUnderTest.Add(() => Thread.Sleep(100));
        }

        [Test]
        public void Assert_canceled_queue_but_currently_running_job_is_working()
        {
            Value.Should().Be(100);
        }

        [Test]
        public void Assert_canceled_queue_raises_WorkerQueueException_when_adding_items()
        {
            RaisedException.Should().BeOfType<WorkerQueueException>();
        }

        [Test]
        public void Assert_cancelled_queue_raises_innerexception_ObjectDisposedException()
        {
            RaisedException.InnerException.Should().BeOfType<ObjectDisposedException>();
        }
    }

    internal class WorkerQueueTests_queue_canceled_while_running_items : WorkerQueueTests
    {
        private int Value;

        public override void Act()
        {
            ObjectUnderTest.Add(() =>
            {
                Value++;
                Thread.Sleep(1000);
            });
            ObjectUnderTest.Add(() =>
            {
                Value++;
                Thread.Sleep(1000);
            });
            Thread.Sleep(5);
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
        public void Assert_canceled_consuming_queue_has_run_only_one_item()
        {
            Value.Should().Be(1);
        }
    }
}
