using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using AxFixEngine.Dialects;
using Newtonsoft.Json;
using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;

namespace AxFixEngine.Extensions
{
    public static class MessageExtensions
    {
        public static DataDictionary GetDialect(this Message self)
        {
            DataDictionary dictionary = FixDialectsProvider.Dialects.GetDataDictionary(self.Header.GetString(Tags.BeginString));
            return dictionary;
        }

        public static SessionID GetSessionID(this Message self)
        {
            SessionID sessionId = self.GetSessionID(self);
            return sessionId;
        }

        public static string GetMsgType(this Message self)
        {
            string msgType = self.Header.GetString(Tags.MsgType);
            return msgType;
        }

        public static string GetMsgName(this Message self)
        {
            string msgType = GetMsgType(self);
            DataDictionary dictionary = GetDialect(self);
            return dictionary.GetEnumName(Tags.MsgType, msgType);
        }

        public static string GetEnumNameSafe(this Message self, int tag, string defaultValue = null)
        {
            FieldMap fm = GetFieldMap(self, tag);
            string enumValue = fm?.GetString(tag);
            if (!string.IsNullOrWhiteSpace(enumValue))
            {
                DataDictionary dictionary = GetDialect(self);
                return dictionary.GetEnumName(tag, enumValue) ?? defaultValue;
            }

            return defaultValue;
        }

        public static string GetStringSafe(this Message self, int tag, string defaultValue = null)
        {
            FieldMap fm = GetFieldMap(self, tag);
            return fm?.GetString(tag) ?? defaultValue;
        }

        public static decimal GetDecimalSafe(this Message self, int tag, decimal defaultValue = 0)
        {
            FieldMap fm = GetFieldMap(self, tag);
            return fm?.GetDecimal(tag) ?? defaultValue;
        }

        public static double GetDoubleSafe(this Message self, int tag, double defaultValue = 0)
        {
            return (double) GetDecimalSafe(self, tag, (decimal) defaultValue);
        }

        public static DateTime GetDateTimeSafe(this Message self, int tag, DateTime defaultValue = default(DateTime))
        {
            FieldMap fm = GetFieldMap(self, tag);
            return fm?.GetDateTime(tag) ?? defaultValue;
        }

        public static FieldMap GetFieldMap(this Message self, int tag)
        {
            return self.IsSetField(tag)
                       ? self
                       : (self.Header.IsSetField(tag)
                              ? (FieldMap) self.Header
                              : (self.Trailer.IsSetField(tag)
                                     ? self.Trailer
                                     : null));
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
            FieldMapToXml(self, body, dictionary, new int[0]);

            XElement trailer = new XElement("Trailer");
            root.Add(trailer);
            FieldMapToXml(self.Trailer, trailer, dictionary, new int[0]);

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

        public static string ToJson(this Message self)
        {
            XmlDocument doc = ToXmlDocument(self);
            return JsonConvert.SerializeXmlNode(doc);
        }

        private static void FieldMapToXml(FieldMap fieldMap,
                                          XElement parent,
                                          DataDictionary dictionary,
                                          int[] precedingFields)
        {
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
                            // Try to parse the value as XML content.
                            XElement data = XElement.Parse(value);
                            child.Add(new XAttribute("EncodedType", "XML"));
                            child.Add(data);
                        }
                        catch
                        {
                            // XML parsing failed, add the value as CDATA.
                            XCData data = new XCData(value);
                            child.Add(new XAttribute("EncodedType", "DATA"));
                            child.Add(data);
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
                    child = new XElement("CustomTag_" + tag);
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
    }
}
