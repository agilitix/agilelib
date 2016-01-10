using System;
using System.Collections.Generic;

namespace AxEqualityComparer
{
    public class KeyEqualityComparer<T, TKey> : IEqualityComparer<T>
    {
        private readonly Func<T, TKey> _keyGetter;

        public KeyEqualityComparer(Func<T, TKey> keyGetter)
        {
            if (keyGetter == null)
            {
                throw new ArgumentNullException();
            }
            _keyGetter = keyGetter;
        }

        bool IEqualityComparer<T>.Equals(T x, T y)
        {
            return EqualityComparer<TKey>.Default.Equals(_keyGetter(x), _keyGetter(y));
        }

        int IEqualityComparer<T>.GetHashCode(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            return EqualityComparer<TKey>.Default.GetHashCode(_keyGetter(obj));
        }
    }
}