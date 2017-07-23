using System;
using System.Threading;
using AxFixEngine.Interfaces;
using AxUtils;

namespace AxFixEngine.Dialects
{
    public static class FixDialectsProvider
    {
        public static void Attach(IFixDialects dialects)
        {
            InstanceHolder<IFixDialects>.Attach(dialects);
        }

        public static void Detach()
        {
            InstanceHolder<IFixDialects>.Detach();
        }

        public static IFixDialects Dialects => InstanceHolder<IFixDialects>.Instance;
    }
}
