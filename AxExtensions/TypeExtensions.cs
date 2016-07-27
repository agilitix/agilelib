using System;

namespace AxExtensions
{
    public static class TypeExtensions
    {
        public static bool IsNullable(this Type self)
        {
            return !self.IsValueType || self.IsGenericType && self.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type GetCoreType(this Type self)
        {
            if (self != null && IsNullable(self))
            {
                if (!self.IsValueType)
                {
                    return self;
                }
                return Nullable.GetUnderlyingType(self);
            }
            return self;
        }
    }
}
