﻿using System;
using System.Collections.Generic;

namespace AxUtils
{
    /// <summary>
    /// Compares two objects and indicates whether one is less than, equal to,
    /// or greater than the other. The comparison is done on a key extracted
    /// from the object.
    /// </summary>
    public class AnonymousComparer<T, TKey> : IComparer<T>
    {
        private readonly Func<T, TKey> _ketGetter;
        private readonly IComparer<TKey> _keyComparer;

        public AnonymousComparer(Func<T, TKey> keyGetter, IComparer<TKey> keyComparer)
        {
            _ketGetter = keyGetter;
            _keyComparer = keyComparer ?? Comparer<TKey>.Default;
        }

        public AnonymousComparer(Func<T, TKey> keyGetter)
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