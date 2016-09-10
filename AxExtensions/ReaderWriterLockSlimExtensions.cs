using System;
using System.Threading;
using AxUtils;

namespace AxExtensions
{
    public static class ReaderWriterLockSlimExtensions
    {
        public static IDisposable GetReadLock(this ReaderWriterLockSlim self)
        {
            self.EnterReadLock();
            return new DisposableAction(self.ExitReadLock);
        }

        public static IDisposable GetWriteLock(this ReaderWriterLockSlim self)
        {
            self.EnterWriteLock();
            return new DisposableAction(self.ExitWriteLock);
        }

        public static IDisposable GetUpgradeableReadLock(this ReaderWriterLockSlim self)
        {
            self.EnterUpgradeableReadLock();
            return new DisposableAction(self.ExitUpgradeableReadLock);
        }
    }
}