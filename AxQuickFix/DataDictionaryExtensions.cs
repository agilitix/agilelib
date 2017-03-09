
using System.Collections.Generic;
using QuickFix.DataDictionary;

namespace AxQuickFix
{
    public static class DataDictionaryExtensions
    {
        /// <summary>
        /// Get tag name from tag number: 35 => "MsgType"
        /// </summary>
        public static string GetTagName(this DataDictionary self, int tagNumber)
        {
            string fieldName;
            TryGetTagName(self, tagNumber, out fieldName);
            return fieldName;
        }

        public static bool TryGetTagName(this DataDictionary self, int tagNumber, out string tagName)
        {
            DDField ddField;
            if (self.FieldsByTag.TryGetValue(tagNumber, out ddField))
            {
                tagName = ddField.Name;
                return true;
            }

            tagName = string.Empty;
            return false;
        }

        /// <summary>
        /// Get tag number from tag name: "MsgType" => 35
        /// </summary>
        public static int GetTagNumber(this DataDictionary self, string tagName)
        {
            int fieldTag;
            TryGetTagNumber(self, tagName, out fieldTag);
            return fieldTag;
        }

        public static bool TryGetTagNumber(this DataDictionary self, string tagName, out int tagNumber)
        {
            DDField ddField;
            if (self.FieldsByName.TryGetValue(tagName, out ddField))
            {
                tagNumber = ddField.Tag;
                return true;
            }

            tagNumber = 0;
            return false;
        }

        /// <summary>
        /// Get enum label from tag number and enum value: 54, "2" => "SELL"
        /// </summary>
        public static string GetEnumLabel(this DataDictionary self, int tagNumber, string enumValue)
        {
            string enumLabel;
            TryGetEnumLabel(self, tagNumber, enumValue, out enumLabel);
            return enumLabel;
        }

        public static bool TryGetEnumLabel(this DataDictionary self, int tagNumber, string enumValue, out string enumLabel)
        {
            enumLabel = string.Empty;
            DDField ddField;
            return self.FieldsByTag.TryGetValue(tagNumber, out ddField)
                   && ddField.EnumDict.TryGetValue(enumValue, out enumLabel);
        }

        /// <summary>
        /// Get enum value from tag number and enum label: 54, "SELL" => "2"
        /// </summary>
        public static string GetEnumValue(this DataDictionary self, int tagNumber, string enumLabel)
        {
            string enumValue;
            TryGetEnumValue(self, tagNumber, enumLabel, out enumValue);
            return enumValue;
        }

        public static bool TryGetEnumValue(this DataDictionary self, int tagNumber, string enumLabel, out string enumValue)
        {
            DDField ddField;
            if (self.FieldsByTag.TryGetValue(tagNumber, out ddField))
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

        /// <summary>
        /// Get tag type from tag number: 54 => "CHAR"
        /// </summary>
        public static string GetTagType(this DataDictionary self, int tagNumber)
        {
            string fixFieldType;
            TryGetTagType(self, tagNumber, out fixFieldType);
            return fixFieldType;
        }

        public static bool TryGetTagType(this DataDictionary self, int tagNumber, out string tagType)
        {
            DDField ddField;
            if (self.FieldsByTag.TryGetValue(tagNumber, out ddField))
            {
                tagType = ddField.FixFldType;
                return true;
            }

            tagType = string.Empty;
            return false;
        }

        /// <summary>
        /// Get enum label from tag name and enum value: "Side", "2" => "SELL"
        /// </summary>
        public static string GetEnumLabel(this DataDictionary self, string tagName, string enumValue)
        {
            int tagNumber;
            if (TryGetTagNumber(self, tagName, out tagNumber))
            {
                string enumLabel;
                TryGetEnumLabel(self, tagNumber, enumValue, out enumLabel);
                return enumLabel;
            }

            return string.Empty;
        }

        /// <summary>
        /// Get enum value from tag name and enum label: "Side", "SELL" => "2"
        /// </summary>
        public static string GetEnumValue(this DataDictionary self, string tagName, string enumLabel)
        {
            int tagNumber;
            if (TryGetTagNumber(self, tagName, out tagNumber))
            {
                string enumValue;
                TryGetEnumValue(self, tagNumber, enumLabel, out enumValue);
                return enumValue;
            }

            return string.Empty;
        }

        /// <summary>
        /// Get tag type from tag name: "Side" => "CHAR"
        /// </summary>
        public static string GetTagType(this DataDictionary self, string tagName)
        {
            int tagNumber;
            if (TryGetTagNumber(self, tagName, out tagNumber))
            {
                string fixFieldType;
                TryGetTagType(self, tagNumber, out fixFieldType);
                return fixFieldType;
            }

            return string.Empty;
        }
    }
}
