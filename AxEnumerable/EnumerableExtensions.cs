using System;
using System.Collections.Generic;

namespace AxEnumerable.Extensions
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
    }
}