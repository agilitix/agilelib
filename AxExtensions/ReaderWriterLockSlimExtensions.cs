using System;
using System.Threading;

namespace AxExtensions
{
    public static class ReaderWriterLockSlimExtensions
    {
        public static IDisposable GetReadLock(this ReaderWriterLockSlim self)
        {
            self.EnterReadLock();
            return new ReaderWriterLockDisposable(self.ExitReadLock);
        }

        public static IDisposable GetWriteLock(this ReaderWriterLockSlim self)
        {
            self.EnterWriteLock();
            return new ReaderWriterLockDisposable(self.ExitWriteLock);
        }

        public static IDisposable GetUpgradeableReadLock(this ReaderWriterLockSlim self)
        {
            self.EnterUpgradeableReadLock();
            return new ReaderWriterLockDisposable(self.ExitUpgradeableReadLock);
        }

        private sealed class ReaderWriterLockDisposable : IDisposable
        {
            private readonly Action _action;
            public ReaderWriterLockDisposable(Action action)
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