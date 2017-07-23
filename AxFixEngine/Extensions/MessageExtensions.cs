using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using AxFixEngine.Dialects;
using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;

namespace AxFixEngine.Extensions
{
    public static class MessageExtensions
    {
        public static DataDictionary GetDialect(this Message self)
        {
            SessionID sessionId = self.GetSessionID(self);
            DataDictionary dictionary = FixDialectsProvider.Dialects.GetDataDictionary(sessionId);
            return dictionary;
        }

        public static SessionID GetSessionID(this Message self)
        {
            SessionID sessionId = self.GetSessionID(self);
            return sessionId;
        }

        public static MsgType GetMsgType(this Message self)
        {
            string msgType = self.Header.GetField(Tags.MsgType);
            return new MsgType(msgType);
        }

        public static string GetMsgName(this Message self)
        {
            DataDictionary dictionary = GetDialect(self);
            string msgType = self.Header.GetField(Tags.MsgType);
            return dictionary.GetEnumName(Tags.MsgType, msgType);
        }

        public static string GetEnumName(this Message self, IField field)
        {
            return GetEnumName(self, field.Tag);
        }

        public static string GetEnumName(this Message self, int tag)
        {
            FieldMap fm = FindFieldMap(self, tag);
            string value = fm?.GetString(tag);
            if (!string.IsNullOrWhiteSpace(value))
            {
                DataDictionary dictionary = GetDialect(self);
                return dictionary.GetEnumName(tag, value);
            }

            return string.Empty;
        }

        public static bool IsField(this Message self, IField field)
        {
            return IsField(self, field.Tag);
        }

        public static bool IsField(this Message self, int tag)
        {
            DataDictionary dictionary = GetDialect(self);
            return dictionary.Messages[self.Header.GetField(Tags.MsgType)].IsField(tag);
        }

        public static bool IsHeaderField(this Message self, IField field)
        {
            return IsHeaderField(self, field.Tag);
        }

        public static bool IsHeaderField(this Message self, int tag)
        {
            DataDictionary dictionary = GetDialect(self);
            return dictionary.IsHeaderField(tag);
        }

        public static bool IsBodyField(this Message self, IField field)
        {
            return IsBodyField(self, field.Tag);
        }

        public static bool IsBodyField(this Message self, int tag)
        {
            DataDictionary dictionary = GetDialect(self);
            return dictionary.IsBodyField(tag);
        }

        public static bool IsTrailerField(this Message self, IField field)
        {
            return IsTrailerField(self, field.Tag);
        }

        public static bool IsTrailerField(this Message self, int tag)
        {
            DataDictionary dictionary = GetDialect(self);
            return dictionary.IsTrailerField(tag);
        }

        public static FieldMap FindFieldMap(this Message self, IField field)
        {
            return FindFieldMap(self, field.Tag);
        }

        public static FieldMap FindFieldMap(this Message message, int tag)
        {
            FieldMap fieldMap = message.IsSetField(tag)
                                    ? message
                                    : message.Header.IsSetField(tag)
                                        ? message.Header
                                        : message.Trailer.IsSetField(tag)
                                            ? message.Trailer as FieldMap
                                            : null;
            return fieldMap;
        }

        public static XDocument ToXDocument(this Message self)
        {
            string msgName = GetMsgName(self);
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", null));

            XElement root = new XElement("Message");
            root.Add(new XAttribute("MsgType", self.Header.GetField(Tags.MsgType)));
            root.Add(new XAttribute("MsgName", msgName));
            doc.Add(root);

            DataDictionary dictionary = GetDialect(self);

            XElement header = new XElement("Header");
            root.Add(header);
            FieldMapToXml(self.Header, header, dictionary, self.Header.HEADER_FIELD_ORDER);

            XElement body = new XElement("Body");
            root.Add(body);
            FieldMapToXml(self, body, dictionary);

            XElement trailer = new XElement("Trailer");
            root.Add(trailer);
            FieldMapToXml(self.Trailer, trailer, dictionary);

            return doc;
        }

        public static XmlDocument ToXmlDocument(this Message self)
        {
            XDocument xdoc = ToXDocument(self);
            XmlDocument xmldoc = new ConfigXmlDocument();
            using (XmlReader xmlreader = xdoc.CreateReader())
            {
                xmldoc.Load(xmlreader);
            }
            return xmldoc;
        }

        private static void FieldMapToXml(FieldMap fieldMap,
                                          XElement parent,
                                          DataDictionary dictionary,
                                          int[] precedingFields = null)
        {
            if (precedingFields == null)
            {
                precedingFields = new int[0];
            }

            // Sort by preceding tags first then append other tags.
            IEnumerable<int> sortedTags = fieldMap.Where(x => precedingFields.Contains(x.Key))
                                                  .Concat(fieldMap.Where(x => !precedingFields.Contains(x.Key)))
                                                  .Select(x => x.Key);

            AppendToXml(fieldMap, sortedTags, parent, dictionary);
        }

        private static void AppendToXml(FieldMap fieldMap,
                                        IEnumerable<int> sortedTags,
                                        XElement parent,
                                        DataDictionary dictionary)
        {
            foreach (int tag in sortedTags)
            {
                XElement child;
                Type fieldType;

                string value = fieldMap.GetField(tag);

                if (dictionary.TryGetFieldType(tag, out fieldType))
                {
                    DDField ddField = dictionary.FieldsByTag[tag];

                    child = new XElement(ddField.Name);
                    child.Add(new XAttribute("Tag", tag));

                    if (ddField.FixFldType == "DATA")
                    {
                        try
                        {
                            // Try to parse an encoded field as XML.
                            XElement data = XElement.Parse(value);
                            child.Add(new XAttribute("EncodedType", "XML"));
                            child.Add(data);
                        }
                        catch
                        {
                            // XML parsing failed, add content as CDATA.
                            child.Add(new XCData(value));
                        }
                    }
                    else
                    {
                        child.Add(new XAttribute("Value", value));
                    }

                    if (ddField.HasEnums())
                    {
                        child.Add(new XAttribute("HasEnums", true));
                        string enumValue = ddField.EnumDict
                                                  .FirstOrDefault(t => t.Key == value)
                                                  .Value;
                        if (!string.IsNullOrEmpty(enumValue))
                        {
                            child.Add(new XAttribute("EnumValue", enumValue));
                        }
                    }

                    int groupCount = fieldMap.GroupCount(tag);
                    if (groupCount > 0)
                    {
                        child.Add(new XAttribute("IsGroup", "Y"));
                        child.Add(new XAttribute("GroupsCount", groupCount));
                        for (int i = 1; i <= groupCount; i++)
                        {
                            Group group = fieldMap.GetGroup(i, tag);
                            DDField grpDdField = dictionary.FieldsByTag[group.Delim];
                            XElement grpElt = new XElement(grpDdField.Name + "Group" + i);
                            child.Add(grpElt);
                            FieldMapToXml(group, grpElt, dictionary, new[] {group.Delim});
                        }
                    }
                }
                else
                {
                    child = new XElement("UserTag_" + tag);
                    child.Add(new XAttribute("Tag", tag));
                    child.Add(new XAttribute("Value", value));
                }

                // Cleanup namespaces decorations.
                foreach (XElement descendant in child.Descendants())
                {
                    descendant.Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
                    descendant.Name = descendant.Name.LocalName;
                }

                parent.Add(child);
            }
        }

        #region Dump FIX fields to XML

        ////private struct FixField
        ////{
        ////    public int Tag;
        ////    public string TagName;
        ////    public string Value;
        ////    public string ValueName;
        ////    public string Type;
        ////    public IList<FixField> Group;
        ////}

        ////private static void AppendFields(FieldMap fromMap, XElement toElement, DataDictionary dictionary)
        ////{
        ////    IList<FixField> collectedFields = new List<FixField>();
        ////    CollectFields(fromMap, collectedFields, dictionary);
        ////    foreach (FixField field in collectedFields)
        ////    {
        ////        XElement fieldElement = CreateElement(field);
        ////        toElement.Add(fieldElement);
        ////    }
        ////}

        ////private static void CollectFields(FieldMap currentMap,
        ////                                  IList<FixField> output,
        ////                                  DataDictionary dictionary,
        ////                                  int[] precedingFields = null,
        ////                                  FixField? groupField = null)
        ////{
        ////    if (precedingFields == null)
        ////    {
        ////        precedingFields = new int[] { };
        ////    }

        ////    IList<int> groupTags = currentMap.GetGroupTags();

        ////    // Preceding tags must appear first.
        ////    foreach (int preField in precedingFields)
        ////    {
        ////        if (currentMap.IsSetField(preField))
        ////        {
        ////            string value = currentMap.GetField(preField);
        ////            FixField newField = new FixField
        ////                                {
        ////                                    Tag = preField,
        ////                                    Value = value,
        ////                                    Group = new List<FixField>(),
        ////                                    Type = dictionary.GetTagType(preField),
        ////                                    TagName = dictionary.GetTagName(preField),
        ////                                    ValueName = dictionary.GetEnumLabel(preField, value) ?? string.Empty
        ////                                };
        ////            if (groupField.HasValue)
        ////            {
        ////                groupField.Value.Group.Add(newField);
        ////            }
        ////            else
        ////            {
        ////                output.Add(newField);
        ////            }
        ////            if (groupTags.Contains(preField))
        ////            {
        ////                for (int i = 0; i < currentMap.GroupCount(preField); ++i)
        ////                {
        ////                    Group group = currentMap.GetGroup(i + 1, preField);
        ////                    CollectFields(group, output, dictionary, new[] {group.Delim}, newField);
        ////                }
        ////            }
        ////        }
        ////    }

        ////    // Other fields after preceding tags.
        ////    foreach (KeyValuePair<int, IField> field in currentMap)
        ////    {
        ////        if (!precedingFields.Contains(field.Key) && !groupTags.Contains(field.Key))
        ////        {
        ////            string value = currentMap.GetField(field.Key);
        ////            FixField newField = new FixField
        ////                                {
        ////                                    Tag = field.Key,
        ////                                    Value = value,
        ////                                    Group = new List<FixField>(),
        ////                                    Type = dictionary.GetTagType(field.Key),
        ////                                    TagName = dictionary.GetTagName(field.Key),
        ////                                    ValueName = dictionary.GetEnumLabel(field.Key, value) ?? string.Empty
        ////                                };
        ////            if (groupField.HasValue)
        ////            {
        ////                groupField.Value.Group.Add(newField);
        ////            }
        ////            else
        ////            {
        ////                output.Add(newField);
        ////            }
        ////        }
        ////    }

        ////    // Other groups after preceding tags.
        ////    foreach (int grpTag in groupTags)
        ////    {
        ////        if (!precedingFields.Contains(grpTag))
        ////        {
        ////            FixField newField = new FixField
        ////                                {
        ////                                    Tag = grpTag,
        ////                                    Value = currentMap.GetField(grpTag),
        ////                                    Group = new List<FixField>(),
        ////                                    Type = dictionary.GetTagType(grpTag),
        ////                                    TagName = dictionary.GetTagName(grpTag)
        ////                                };
        ////            if (groupField.HasValue)
        ////            {
        ////                groupField.Value.Group.Add(newField);
        ////            }
        ////            else
        ////            {
        ////                output.Add(newField);
        ////            }
        ////            for (int i = 0; i < currentMap.GroupCount(grpTag); ++i)
        ////            {
        ////                Group group = currentMap.GetGroup(i + 1, grpTag);
        ////                CollectFields(group, output, dictionary, new[] {group.Delim}, newField);
        ////            }
        ////        }
        ////    }
        ////}

        ////private static XElement CreateElement(FixField field)
        ////{
        ////    XElement element = new XElement(field.TagName);
        ////    element.Add(new XAttribute("tag", field.Tag));

        ////    foreach (FixField group in field.Group)
        ////    {
        ////        XElement child = CreateElement(group);
        ////        element.Add(child);
        ////    }

        ////    if (field.Type.Equals("DATA"))
        ////    {
        ////        try
        ////        {
        ////            // Try to convert field DATA to an XML content.
        ////            XElement data = XElement.Parse(field.Value);
        ////            element.Add(data);
        ////        }
        ////        catch
        ////        {
        ////            // XML parsing has failed, add it as CDATA.
        ////            element.Add(new XCData(field.Value));
        ////        }
        ////    }
        ////    else
        ////    {
        ////        element.Add(new XAttribute("value", field.Value));
        ////        if (!string.IsNullOrWhiteSpace(field.ValueName))
        ////        {
        ////            element.Add(new XAttribute("desc", field.ValueName));
        ////        }
        ////    }

        ////    element.Add(new XAttribute("type", field.Type));

        ////    // Cleanup namespaces decorations (may occur within encoded fields having XML).
        ////    foreach (XElement descendant in element.Descendants())
        ////    {
        ////        descendant.Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
        ////        descendant.Name = descendant.Name.LocalName;
        ////    }

        ////    return element;
        ////}

        #endregion
    }
}
