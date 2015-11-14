using System;
using System.Collections.Generic;
using System.Linq;

namespace AxEnumerable
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            if (self == null || action == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in self)
            {
                action(item);
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> self)
        {
            return self == null || !self.Any();
        }
    }
}