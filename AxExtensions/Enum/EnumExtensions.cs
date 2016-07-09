using System;
using System.ComponentModel;
using System.Linq;

namespace AxExtensions.Enum
{
    public static class EnumExtensions
    {
        public static string GetName(this System.Enum self)
        {
            return System.Enum.GetName(self.GetType(), self);
        }

        public static string GetDescription(this System.Enum self)
        {
            Type type = self.GetType();
            return type.GetField(self.ToString())
                       .GetCustomAttributes(typeof (DescriptionAttribute), false)
                       .Cast<DescriptionAttribute>()
                       .Select(attribute => attribute.Description)
                       .FirstOrDefault();
        }
    }
}