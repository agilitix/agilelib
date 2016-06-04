using System;
using System.Collections.Generic;

namespace AxComparison
{
    /// <summary>
    /// Compare two objects for equality, the evaluation is done on a key provided by a key getter.
    /// </summary>
    public class AnonymousEqualityComparer<T, TKey> : IEqualityComparer<T>
    {
        private readonly Func<T, TKey> _ketGetter;
        private readonly IEqualityComparer<TKey> _keyComparer;

        public AnonymousEqualityComparer(Func<T, TKey> keyGetter, IEqualityComparer<TKey> keyComparer)
        {
            _ketGetter = keyGetter;
            _keyComparer = keyComparer ?? EqualityComparer<TKey>.Default;
        }

        public AnonymousEqualityComparer(Func<T, TKey> keyGetter)
            : this(keyGetter, null) {}

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
            return value.GetHashCode();
        }
    }
}