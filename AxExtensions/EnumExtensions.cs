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
            return type.GetField(Enum.GetName(type, self))
                       .GetCustomAttributes(typeof(DescriptionAttribute), false)
                       .Cast<DescriptionAttribute>()
                       .Select(attribute => attribute.Description)
                       .FirstOrDefault();
        }

        public static TTarget ChangeTo<TTarget>(this Enum self) where TTarget : struct
        {
            return (TTarget)Enum.Parse(typeof(TTarget), self.GetName());
        }

        public static TTarget ChangeToOrDefault<TTarget>(this Enum self, TTarget defaultOutput) where TTarget : struct
        {
            TTarget output;
            return Enum.TryParse(self.GetName(), out output)
                       ? output
                       : defaultOutput;
        }

        public static bool TryChangeTo<TTarget>(this Enum self, out TTarget output) where TTarget : struct
        {
            return Enum.TryParse(self.GetName(), out output);
        }

        public static bool TryChangeToOrDefault<TTarget>(this Enum self, out TTarget output, TTarget defaultOutput) where TTarget : struct
        {
            if (Enum.TryParse(self.GetName(), out output))
                return true;

            output = defaultOutput;
            return false;
        }
    }
}
