using System;

namespace AxUtils
{
    /// <summary>
    /// Simple global and lazy instance.
    /// </summary>
    public static class GlobalInstance<T>
    {
        private static readonly object _sync = new object();
        private static Lazy<T> _instance;

        public static T Instance => _instance.Value;

        public static void Set(Func<T> factory)
        {
            lock (_sync)
            {
                if (_instance != null)
                {
                    throw new InvalidOperationException();
                }

                _instance = new Lazy<T>(factory);
            }
        }

        public static T Clear()
        {
            lock (_sync)
            {
                if (_instance.IsValueCreated)
                {
                    T current = _instance.Value;
                    _instance = null;
                    return current;
                }

                return default(T);
            }
        }
    }
}
