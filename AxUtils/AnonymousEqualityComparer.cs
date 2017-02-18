using System;
using System.Collections.Generic;

namespace AxUtils
{
    public class AnonymousEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _comparer;

        public static IEqualityComparer<T> DefaultEqualityComparer => EqualityComparer<T>.Default;

        public AnonymousEqualityComparer(Func<T, T, bool> comparer)
        {
            _comparer = comparer;
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
            return _comparer(first, second);
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