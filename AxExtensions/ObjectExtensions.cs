using System;
using System.Linq;

namespace AxExtensions
{
    public static class ObjectExtensions
    {
        public static object ConvertTo(this object self, Type targetType)
        {
            object targetObject;
            TryConvertTo(self, targetType, out targetObject);
            return targetObject;
        }

        public static bool TryConvertTo(this object self, Type targetType, out object targetObject)
        {
            if (self != null
                && self != DBNull.Value
                && self is IConvertible)
            {
                if (self.GetType() == targetType)
                {
                    targetObject = self;
                    return true;
                }

                Type underlyingTargetType = Nullable.GetUnderlyingType(targetType) ?? targetType;

                if (underlyingTargetType == typeof(bool))
                {
                    string val = self.ToString().ToLower();
                    targetObject = _boolTrue.Contains(val);
                    return true;
                }

                try
                {
                    targetObject = Convert.ChangeType(self, underlyingTargetType);
                    return true;
                }
                catch
                {
                    // ignored
                }
            }

            targetObject = Activator.CreateInstance(targetType);
            return false;
        }

        public static T ConvertTo<T>(this object self)
        {
            T result;
            TryConvertTo<T>(self, out result);
            return result;
        }

        public static bool TryConvertTo<T>(this object self, out T result)
        {
            object targetObject;
            bool converted = TryConvertTo(self, typeof(T), out targetObject);
            result = (T) targetObject;
            return converted;
        }

        private static readonly string[] _boolTrue = {"true", "1", "yes", "y"};
    }
}
