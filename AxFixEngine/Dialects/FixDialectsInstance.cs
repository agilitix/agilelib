using System;
using System.Threading;

namespace AxFixEngine.Dialects
{
    public static class FixDialectsInstance
    {
        private static int _latch;
        private static IFixDialects _instance;

        public static bool Set(IFixDialects dialects)
        {
            if (Interlocked.Exchange(ref _latch, 1) == 0)
            {
                _instance = dialects;
                return true;
            }

            return false;
        }

        public static IFixDialects Dialects => _instance;
    }
}
