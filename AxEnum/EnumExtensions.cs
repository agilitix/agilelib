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
    }
}