using System;
using System.Linq;

namespace AxUtils
{
    static class CommonExtensions
    {
        public static bool IsAnyOf<T>(this T self, params T[] any)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }
            return any.Contains(self);
        }
    }
}
