using System;
using System.ComponentModel;
using System.Linq;

namespace AxExtensions
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum self)
        {
            return Enum.GetName(self.GetType(), self);
        }

        public static string GetDescription(this Enum self)
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