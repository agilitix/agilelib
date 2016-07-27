using System;
using System.Linq;

namespace AxExtensions
{
    internal static class CommonExtensions
    {
        public static bool IsAnyOf<T>(this T self, params T[] any)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }
            return any.Contains(self);
        }

        public static void ThrowIfNull<T>(this T self) where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
