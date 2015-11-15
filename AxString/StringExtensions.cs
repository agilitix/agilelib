using System;

namespace AxString
{
    public static class StringExtensions
    {
        public static string Right(this string self, int length)
        {
            return self != null && self.Length > length
                ? self.Substring(self.Length - length)
                : self;
        }

        public static string Left(this string self, int length)
        {
            return self != null && self.Length > length
                ? self.Substring(0, length)
                : self;
        }

        public static string Format(this string self, params object[] args)
        {
            return self != null
                ? string.Format(self, args)
                : null;
        }

        public static bool IsNullOrEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        public static bool IsNullOrWhiteSpace(this string self)
        {
            return string.IsNullOrWhiteSpace(self);
        }

        public static string Reverse(this string self)
        {
            if (string.IsNullOrEmpty(self) || self.Length == 1)
            {
                return self;
            }
            char[] charArray = self.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string JoinValues<T>(this string self, string separator, T[] values)
        {
            return JoinValues(self, separator, values, val => val.ToString());
        }

        public static string JoinValues<T>(this string self,
                                           string separator,
                                           T[] values,
                                           Converter<T, string> valueToStringConverter)
        {
            if (values == null || values.Length == 0)
            {
                return self;
            }
            if (string.IsNullOrEmpty(separator))
            {
                separator = string.Empty;
            }
            return string.Join(separator, Array.ConvertAll(values, valueToStringConverter));
        }
    }
}