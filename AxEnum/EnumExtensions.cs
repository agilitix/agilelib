using System;

namespace AxEnum
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum self)
        {
            string name = Enum.GetName(self.GetType(), self);
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException();
            }
            return name;
        }

        public static T ToEnum<T>(this string self) where T : struct
        {
            Type typeT = typeof(T);
            if (!typeT.IsEnum)
            {
                throw new ArgumentException();
            }
            return (T)Enum.Parse(typeT, self);
        }
    }
}
