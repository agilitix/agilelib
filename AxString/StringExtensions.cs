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
    }
}