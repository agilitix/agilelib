using System;
using System.Threading;

namespace AxUtils
{
    /// <summary>
    /// Simple global instance holder and provider.
    /// You should attach an interface of the global instance,
    /// it will be easier to mock and unit test.
    /// </summary>
    public static class InstanceHolder<T>
    {
        private static int _latch;
        private static T _instance;

        public static void Attach(T instance)
        {
            if (Interlocked.Exchange(ref _latch, 1) == 0)
            {
                _instance = instance;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public static T Detach()
        {
            T current = default(T);
            if (Interlocked.Exchange(ref _latch, 0) == 1)
            {
                current = _instance;
                _instance = default(T);
            }

            return current;
        }

        public static T Instance => _instance;
    }
}
