using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxEqualityComparer
{
    public class EqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equalityComparer;

        public EqualityComparer(Func<T, T, bool> equalityComparer)
        {
            if (equalityComparer == null)
            {
                throw new ArgumentNullException();
            }
            _equalityComparer = equalityComparer;
        }

        bool IEqualityComparer<T>.Equals(T x, T y)
        {
            return _equalityComparer(x, y);
        }

        int IEqualityComparer<T>.GetHashCode(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            return obj.GetHashCode();
        }
    }
}