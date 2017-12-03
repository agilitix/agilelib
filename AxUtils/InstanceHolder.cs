using System;
using System.Threading;

namespace AxUtils
{
    /// <summary>
    /// Simple global instance holder and provider.
    /// You should attach an interface of the global instance,
    /// it will be easier to mock and unit test.
    /// </summary>
    public static class InstanceHolder<T> where T : class
    {
        private static readonly object _sync = new object();

        public static void Attach(T instance)
        {
            lock (_sync)
            {
                if (Instance == null)
                    Instance = instance;
                else
                    throw new InvalidOperationException();
            }
        }

        public static T Detach()
        {
            lock (_sync)
            {
                T current = Instance;
                Instance = null;
                return current;
            }
        }

        public static T Instance { get; private set; }
    }
}
