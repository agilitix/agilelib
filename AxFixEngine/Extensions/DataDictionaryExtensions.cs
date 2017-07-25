using System.Collections.Generic;
using System.Text;
using QuickFix.DataDictionary;

namespace AxFixEngine.Extensions
{
    public static class DataDictionaryExtensions
    {
        public static string GetDescription(this DataDictionary self)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Version=" + self.Version);
            sb.Append(", MajorVersion=" + self.MajorVersion);
            sb.Append(", MinorVersion=" + self.MinorVersion);
            sb.Append(", MessagesCount=" + self.Messages.Count);
            sb.Append(", TagsCount=" + self.FieldsByTag.Count);
            sb.Append(", CheckFieldsHaveValues=" + self.CheckFieldsHaveValues);
            sb.Append(", CheckFieldsOutOfOrder=" + self.CheckFieldsOutOfOrder);
            sb.Append(", CheckUserDefinedFields=" + self.CheckUserDefinedFields);
            return sb.ToString();
        }

        public static bool IsBodyField(this DataDictionary self, int tag)
        {
            DDField ddField;
            return self.FieldsByTag.TryGetValue(tag, out ddField)
                   && !self.IsHeaderField(tag)
                   && !self.IsTrailerField(tag);
        }

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
        /// Get enum Name from tag number and enum value: 54, "2" => "SELL"
        /// </summary>
        public static string GetEnumName(this DataDictionary self, int tagNumber, string enumValue)
        {
            string enumName;
            TryGetEnumName(self, tagNumber, enumValue, out enumName);
            return enumName;
        }

        public static bool TryGetEnumName(this DataDictionary self, int tagNumber, string enumValue, out string enumName)
        {
            enumName = string.Empty;
            DDField ddField;
            return self.FieldsByTag.TryGetValue(tagNumber, out ddField)
                   && ddField.EnumDict.TryGetValue(enumValue, out enumName);
        }

        /// <summary>
        /// Get enum value from tag number and enum Name: 54, "SELL" => "2"
        /// </summary>
        public static string GetEnumValue(this DataDictionary self, int tagNumber, string enumName)
        {
            string enumValue;
            TryGetEnumValue(self, tagNumber, enumName, out enumValue);
            return enumValue;
        }

        public static bool TryGetEnumValue(this DataDictionary self, int tagNumber, string enumName, out string enumValue)
        {
            DDField ddField;
            if (self.FieldsByTag.TryGetValue(tagNumber, out ddField))
            {
                foreach (KeyValuePair<string, string> enumDictInfo in ddField.EnumDict)
                {
                    if (enumDictInfo.Value.Equals(enumName))
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
        /// Get enum Name from tag name and enum value: "Side", "2" => "SELL"
        /// </summary>
        public static string GetEnumName(this DataDictionary self, string tagName, string enumValue)
        {
            int tagNumber;
            if (TryGetTagNumber(self, tagName, out tagNumber))
            {
                string enumName;
                TryGetEnumName(self, tagNumber, enumValue, out enumName);
                return enumName;
            }

            return string.Empty;
        }

        /// <summary>
        /// Get enum value from tag name and enum Name: "Side", "SELL" => "2"
        /// </summary>
        public static string GetEnumValue(this DataDictionary self, string tagName, string enumName)
        {
            int tagNumber;
            if (TryGetTagNumber(self, tagName, out tagNumber))
            {
                string enumValue;
                TryGetEnumValue(self, tagNumber, enumName, out enumValue);
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
