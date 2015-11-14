using System;
using System.Collections.Generic;
using System.Linq;

namespace AxEnum
{
    public static class Enum<T> where T : struct
    {
        public static IEnumerable<T> AsEnumarable()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().AsEnumerable();
        }

        public static T Parse(string enumString)
        {
            return Parse(enumString, false);
        }

        public static T Parse(string enumString, bool ignoreCase)
        {
            return (T)Enum.Parse(typeof(T), enumString, ignoreCase);
        }

        public static bool TryParse(string enumString, out T result)
        {
            return TryParse(enumString, false, out result);
        }

        public static bool TryParse(string enumString, bool ignoreCase, out T result)
        {
            return Enum.TryParse(enumString, ignoreCase, out result);
        }
    }
}
