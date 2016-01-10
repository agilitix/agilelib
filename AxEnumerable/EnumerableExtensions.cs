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

        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> self, Func<T, TKey> keyGetter)
        {
            var keys = new HashSet<TKey>();
            foreach (T item in self)
            {
                TKey key = keyGetter(item);
                if (keys.Add(key))
                    yield return item;
            }
        }
    }
}
