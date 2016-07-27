using System;
using System.Threading;

namespace AxExtensions
{
    public static class ReaderWriterLockSlimExtensions
    {
        public static IDisposable GetReadLock(this ReaderWriterLockSlim self)
        {
            self.EnterReadLock();
            return new DisposableReaderWriterLock(self.ExitReadLock);
        }

        public static IDisposable GetWriteLock(this ReaderWriterLockSlim self)
        {
            self.EnterWriteLock();
            return new DisposableReaderWriterLock(self.ExitWriteLock);
        }

        public static IDisposable GetUpgradeableReadLock(this ReaderWriterLockSlim self)
        {
            self.EnterUpgradeableReadLock();
            return new DisposableReaderWriterLock(self.ExitUpgradeableReadLock);
        }

        private sealed class DisposableReaderWriterLock : IDisposable
        {
            private readonly Action _action;
            public DisposableReaderWriterLock(Action action)
            {
                _action = action;
            }

            public void Dispose()
            {
                _action();
            }
        }
    }
}