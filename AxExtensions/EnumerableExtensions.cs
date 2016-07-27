using System;
using System.Collections.Generic;
using System.Linq;

namespace AxExtensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            if (self == null || action == null)
            {
                throw new ArgumentNullException();
            }

            foreach (T item in self)
            {
                action(item);
            }

            return self;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> self)
        {
            return self == null || !self.Any();
        }
    }
}