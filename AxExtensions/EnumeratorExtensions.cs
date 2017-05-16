﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxExtensions
{
    public static class EnumeratorExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this IEnumerator<T> self)
        {
            while (self.MoveNext())
            {
                yield return self.Current;
            }

            self.Reset();
        }

        public static IEnumerable<T> AsEnumerable<T>(this IEnumerator self)
        {
            while (self.MoveNext())
            {
                yield return (T) self.Current;
            }

            self.Reset();
        }
    }
}
