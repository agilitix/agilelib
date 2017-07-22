using System;
using System.Threading;
using AxFixEngine.Interfaces;

namespace AxFixEngine.Dialects
{
    public static class FixDialectsProvider
    {
        private static int _latch;
        private static IFixDialects _dialects;

        public static void Initialize(IFixDialects dialects)
        {
            if (Interlocked.Exchange(ref _latch, 1) == 0)
            {
                _dialects = dialects;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public static IFixDialects Dialects => _dialects;
    }
}
