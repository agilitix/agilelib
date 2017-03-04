
using System.Collections.Generic;
using QuickFix.DataDictionary;

namespace AxQuickFix
{
    public static class DataDictionaryExtensions
    {
        public static string GetFieldName(this DataDictionary self, int tag)
        {
            string fieldName;
            TryGetFieldName(self, tag, out fieldName);
            return fieldName;
        }

        public static bool TryGetFieldName(this DataDictionary self, int tag, out string fieldName)
        {
            DDField ddField;
            if (self.FieldsByTag.TryGetValue(tag, out ddField))
            {
                fieldName = ddField.Name;
                return true;
            }

            fieldName = string.Empty;
            return false;
        }

        public static int GetFieldTag(this DataDictionary self, string fieldName)
        {
            int fieldTag;
            TryGetFieldTag(self, fieldName, out fieldTag);
            return fieldTag;
        }

        public static bool TryGetFieldTag(this DataDictionary self, string fieldName, out int tag)
        {
            DDField ddField;
            if (self.FieldsByName.TryGetValue(fieldName, out ddField))
            {
                tag = ddField.Tag;
                return true;
            }

            tag = 0;
            return false;
        }

        public static string GetEnumLabel(this DataDictionary self, int tag, string enumValue)
        {
            string enumLabel;
            TryGetEnumLabel(self, tag, enumValue, out enumLabel);
            return enumLabel;
        }

        public static bool TryGetEnumLabel(this DataDictionary self, int tag, string enumValue, out string enumLabel)
        {
            enumLabel = string.Empty;
            DDField ddField;
            return self.FieldsByTag.TryGetValue(tag, out ddField)
                   && ddField.EnumDict.TryGetValue(enumValue, out enumLabel);
        }

        public static string GetEnumValue(this DataDictionary self, int tag, string enumLabel)
        {
            string enumValue;
            TryGetEnumValue(self, tag, enumLabel, out enumValue);
            return enumValue;
        }

        public static bool TryGetEnumValue(this DataDictionary self, int tag, string enumLabel, out string enumValue)
        {
            DDField ddField;
            if (self.FieldsByTag.TryGetValue(tag, out ddField))
            {
                foreach (KeyValuePair<string, string> enumDictInfo in ddField.EnumDict)
                {
                    if (enumDictInfo.Value.Equals(enumLabel))
                    {
                        enumValue = enumDictInfo.Key;
                        return true;
                    }
                }
            }

            enumValue = string.Empty;
            return false;
        }

        public static string GetFieldFixType(this DataDictionary self, int tag)
        {
            string fixFieldType;
            TryGetFieldFixType(self, tag, out fixFieldType);
            return fixFieldType;
        }

        public static bool TryGetFieldFixType(this DataDictionary self, int tag, out string fixFieldType)
        {
            DDField ddField;
            if (self.FieldsByTag.TryGetValue(tag, out ddField))
            {
                fixFieldType = ddField.FixFldType;
                return true;
            }

            fixFieldType = string.Empty;
            return false;
        }
    }
}
