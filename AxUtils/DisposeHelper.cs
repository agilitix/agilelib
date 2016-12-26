using System;

namespace AxUtils
{
    public class DisposeHelper<T> where T : IDisposable
    {
        private bool _disposed;
        private readonly T _disposee;
        private readonly Action _disposeManagedResources;
        private readonly Action _disposeUnmanagedResources;

        public DisposeHelper(T disposee, Action disposeManagedResources)
            : this(disposee, disposeManagedResources, null)
        {
        }

        public DisposeHelper(T disposee, Action disposeManagedResources, Action disposeUnmanagedResources)
        {
            if (disposee == null)
            {
                throw new ArgumentNullException();
            }

            _disposee = disposee;
            _disposeManagedResources = disposeManagedResources;
            _disposeUnmanagedResources = disposeUnmanagedResources;
        }

        public void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing && _disposeManagedResources != null)
            {
                _disposeManagedResources();
            }

            bool hasUnmanaged = _disposeUnmanagedResources != null;
            if (hasUnmanaged)
            {
                _disposeUnmanagedResources();
            }

            _disposed = true;

            if (disposing && hasUnmanaged)
            {
                GC.SuppressFinalize((object) _disposee);
            }
        }
    }

    ///// <summary>
    ///// Example of use.
    ///// </summary>
    //internal class MyDisposableClassSample : IDisposable
    //{
    //    protected readonly DisposeHelper<MyDisposableClassSample> _disposeMyClass;

    //    public MyDisposableClassSample()
    //    {
    //        _disposeMyClass = new DisposeHelper<MyDisposableClassSample>(this,
    //                                                                     () => { /* dispose managed here */ },
    //                                                                     () => { /* dispose unmanaged here */ });
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //    }

    //    ~MyDisposableClassSample()
    //    {
    //        Dispose(false);
    //    }

    //    protected void Dispose(bool disposing)
    //    {
    //        _disposeMyClass.Dispose(disposing);
    //    }
    //}
}
