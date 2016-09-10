using System;
using System.Collections.Generic;

namespace AxUtils
{
    public class AnonymousKeyEqualityComparer<T, TKey> : IEqualityComparer<T>
    {
        private readonly Func<T, TKey> _ketGetter;
        private readonly IEqualityComparer<TKey> _keyComparer;

        public static IEqualityComparer<TKey> DefaultKeyEqualityComparer
        {
            get { return EqualityComparer<TKey>.Default; }
        }

        public AnonymousKeyEqualityComparer(Func<T, TKey> keyGetter, IEqualityComparer<TKey> keyComparer)
        {
            _ketGetter = keyGetter;
            _keyComparer = keyComparer ?? DefaultKeyEqualityComparer;
        }

        public AnonymousKeyEqualityComparer(Func<T, TKey> keyGetter)
            : this(keyGetter, null)
        {
        }

        public bool Equals(T first, T second)
        {
            if (first == null && second == null)
            {
                return true;
            }
            if (first == null || second == null)
            {
                return false;
            }
            return _keyComparer.Equals(_ketGetter(first), _ketGetter(second));
        }

        public int GetHashCode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            return _ketGetter(value).GetHashCode();
        }
    }
}