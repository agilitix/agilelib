using System;
using System.Collections.Generic;

namespace AxUtils
{
    public class AnonymousKeyComparer<T, TKey> : IComparer<T>
    {
        private readonly Func<T, TKey> _ketGetter;
        private readonly IComparer<TKey> _keyComparer;

        public static IComparer<TKey> DefaultKeyComparer
        {
            get { return Comparer<TKey>.Default; }
        }

        public AnonymousKeyComparer(Func<T, TKey> keyGetter, IComparer<TKey> keyComparer)
        {
            _ketGetter = keyGetter;
            _keyComparer = keyComparer ?? DefaultKeyComparer;
        }

        public AnonymousKeyComparer(Func<T, TKey> keyGetter)
            : this(keyGetter, null)
        {
        }

        public int Compare(T first, T second)
        {
            if (first == null && second == null)
            {
                return 0;
            }
            if (first == null)
            {
                return -1;
            }
            if (second == null)
            {
                return 1;
            }
            return _keyComparer.Compare(_ketGetter(first), _ketGetter(second));
        }
    }
}