using System;
using System.Collections.Generic;
using System.Linq;

namespace AxEnum
{
    public static class EnumUtils
    {
        public static IEnumerable<T> AsEnumarable<T>() where T : struct
        {
            Type typeT = typeof (T);
            if (!typeT.IsEnum)
            {
                throw new ArgumentException();
            }
            return Enum.GetValues(typeT).Cast<T>().AsEnumerable();
        }
    }
}
