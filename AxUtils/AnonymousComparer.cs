using System;
using System.Collections.Generic;

namespace AxUtils
{
    public class AnonymousComparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _comparer;

        public static IComparer<T> DefaultComparer
        {
            get { return Comparer<T>.Default; }
        }

        public AnonymousComparer(Func<T, T, int> comparer)
        {
            _comparer = comparer;
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
            return _comparer(first, second);
        }
    }
}