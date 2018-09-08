using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AxUtils
{
    public static class EnumUtils<T> where T : struct
    {
        static EnumUtils()
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new NotSupportedException();
            }
        }

        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static string GetName(T enumValue)
        {
            return Enum.GetName(typeof(T), enumValue);
        }

        public static IEnumerable<string> GetNames()
        {
            return Enum.GetNames(typeof(T));
        }

        public static string GetDescription(T enumValue)
        {
            Type type = typeof(T);
            return type.GetField(Enum.GetName(type, enumValue))
                       .GetCustomAttributes(typeof(DescriptionAttribute), false)
                       .Cast<DescriptionAttribute>()
                       .Select(attribute => attribute.Description)
                       .FirstOrDefault();
        }

        public static IEnumerable<string> GetDescriptions()
        {
            return GetValues().Select(GetDescription);
        }

        public static int GetNumber(T enumValue)
        {
            return (int)Convert.ChangeType(enumValue, typeof(int));
        }

        public static IEnumerable<int> GetNumbers()
        {
            return GetValues().Select(GetNumber);
        }

        public static T FromDescription(string enumDescription)
        {
            T enumOutput;
            if (TryFromDescription(enumDescription, out enumOutput))
            {
                return enumOutput;
            }

            throw new ArgumentOutOfRangeException(nameof(enumDescription));
        }

        public static T FromDescriptionOrDefault(string enumDescription, T defaultValue)
        {
            T enumOutput;
            TryFromDescriptionOrDefault(enumDescription, out enumOutput, defaultValue);
            return enumOutput;
        }

        public static bool TryFromDescription(string enumDescription, out T enumOutput)
        {
            var found = Enum.GetValues(typeof(T))
                            .Cast<T>()
                            .Where(enumValue => enumDescription != null && enumDescription == GetDescription(enumValue))
                            .Select(x => new {Val = x})
                            .FirstOrDefault();
            if (found != null)
            {
                enumOutput = found.Val;
                return true;
            }

            enumOutput = default(T);
            return false;
        }

        public static bool TryFromDescriptionOrDefault(string enumDescription, out T enumOutput, T defaultValue)
        {
            if (TryFromDescription(enumDescription, out enumOutput))
                return true;

            enumOutput = defaultValue;
            return false;
        }

        public static T FromName(string enumName)
        {
            return (T)Enum.Parse(typeof(T), enumName);
        }

        public static T FromNameOrDefault(string enumName, T defaultValue)
        {
            T enumOutput;
            TryFromNameOrDefault(enumName, out enumOutput, defaultValue);
            return enumOutput;
        }

        public static bool TryFromName(string enumName, out T enumOutput)
        {
            return Enum.TryParse(enumName, false, out enumOutput);
        }

        public static bool TryFromNameOrDefault(string enumName, out T enumOutput, T defaultValue)
        {
            if (TryFromName(enumName, out enumOutput))
                return true;

            enumOutput = defaultValue;
            return false;
        }

        public static T Cast(int enumNumber)
        {
            return (T)Enum.ToObject(typeof(T), enumNumber);
        }

        public static T CastOrDefault(int enumNumber, T defaultValue)
        {
            T enumOutput;
            TryCastOrDefault(enumNumber, out enumOutput, defaultValue);
            return enumOutput;
        }

        public static bool TryCast(int enumNumber, out T enumOutput)
        {
            try
            {
                enumOutput = (T)Enum.ToObject(typeof(T), enumNumber);
                return true;
            }
            catch
            {
                // ignored
            }

            enumOutput = default(T);
            return false;
        }

        public static bool TryCastOrDefault(int enumNumber, out T enumOutput, T defaultValue)
        {
            if (TryCast(enumNumber, out enumOutput))
                return true;

            enumOutput = defaultValue;
            return false;
        }

        public static TTarget ChangeTo<TTarget>(T enumInput) where TTarget : struct
        {
            return (TTarget)Enum.Parse(typeof(TTarget), Enum.GetName(typeof(T), enumInput) ?? "");
        }

        public static TTarget ChangeToOrDefault<TTarget>(T enumInput, TTarget defaultValue) where TTarget : struct
        {
            TTarget enumOutput;
            TryChangeToOrDefault(enumInput, out enumOutput, defaultValue);
            return enumOutput;
        }

        public static bool TryChangeTo<TTarget>(T enumInput, out TTarget enumOutput) where TTarget : struct
        {
            return Enum.TryParse(Enum.GetName(typeof(T), enumInput) ?? "", false, out enumOutput);
        }

        public static bool TryChangeToOrDefault<TTarget>(T enumInput, out TTarget enumOutput, TTarget defaultValue) where TTarget : struct
        {
            if (TryChangeTo(enumInput, out enumOutput))
                return true;

            enumOutput = defaultValue;
            return false;
        }

        public static bool IsNumberDefined(int enumNumber)
        {
            try
            {
                return Enum.IsDefined(typeof(T), enumNumber);
            }
            catch
            {
                // ignored
            }

            return false;
        }

        public static bool IsNameDefined(string enumName)
        {
            try
            {
                return Enum.IsDefined(typeof(T), enumName);
            }
            catch
            {
                // ignored
            }

            return false;
        }

        public static bool IsDescriptionDefined(string enumDescription)
        {
            T enumOutput;
            return TryFromDescription(enumDescription, out enumOutput);
        }

        public static IEnumerable<EnumInfos<T>> GetEnumInfos()
        {
            return GetValues().Select(enumValue => new EnumInfos<T>
                                                   {
                                                       Value = enumValue,
                                                       Number = GetNumber(enumValue),
                                                       Description = GetDescription(enumValue),
                                                       Name = GetName(enumValue)
                                                   });
        }
    }
}
