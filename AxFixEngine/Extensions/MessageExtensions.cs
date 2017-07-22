using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using AxFixEngine.Utilities;
using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;

namespace AxFixEngine.Extensions
{
    public static class MessageExtensions
    {
        public static MsgType GetMsgType(this Message self)
        {
            string msgType = self.GetField(Tags.MsgType);
            return new MsgType(msgType);
        }

        public static SessionID GetSessionID(this Message self)
        {
            SessionID sessionId = self.GetSessionID(self);
            return sessionId;
        }

        public static string GetName(this Message self, DataDictionary dictionary)
        {
            string msgType = self.Header.GetField(Tags.MsgType);
            return dictionary.GetEnumLabel(Tags.MsgType, msgType);
        }

        public static string GetFieldEnum(this Message self, int tag, DataDictionary dictionary)
        {
            DataDictionaryProvider p;
            string value;
            return TryGetField(self, tag, out value)
                       ? dictionary.GetEnumLabel(tag, value)
                       : null;
        }

        public static T GetField<T>(this Message self, int tag, T defaultValue = default(T))
        {
            T value;
            return TryGetField(self, tag, out value)
                       ? value
                       : defaultValue;
        }

        public static bool TryGetField<T>(this Message self, int tag, out T value)
        {
            try
            {
                FieldMap fieldMap = self.IsSetField(tag)
                                        ? self
                                        : self.Header.IsSetField(tag)
                                            ? self.Header
                                            : self.Trailer.IsSetField(tag)
                                                ? self.Trailer as FieldMap
                                                : null;
                if (fieldMap != null)
                {
                    value = FixValueConverter.FromString<T>(fieldMap.GetString(tag));
                    return true;
                }
            }
            catch
            {
                // ignored
            }

            value = default(T);
            return false;
        }

        public static XDocument ToXDocument(this Message self, DataDictionary dictionary)
        {
            string msgName = GetName(self, dictionary);
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", null));

            XElement root = new XElement("message");
            root.Add(new XAttribute("name", msgName));
            doc.Add(root);

            XElement header = new XElement("header");
            root.Add(header);
            IList<KeyValuePair<int, string>> outputFields = new List<KeyValuePair<int, string>>();
            DumpFields(self.Header, outputFields, self.Header.HEADER_FIELD_ORDER);
            foreach (KeyValuePair<int, string> field in outputFields)
            {
                XElement fieldElement = CreateElement(field.Key, field.Value, dictionary);
                header.Add(fieldElement);
            }

            XElement body = new XElement("body");
            root.Add(body);
            outputFields.Clear();
            DumpFields(self, outputFields);
            foreach (KeyValuePair<int, string> field in outputFields)
            {
                XElement fieldElement = CreateElement(field.Key, field.Value, dictionary);
                body.Add(fieldElement);
            }

            XElement trailer = new XElement("trailer");
            root.Add(trailer);
            outputFields.Clear();
            DumpFields(self.Trailer, outputFields);
            foreach (KeyValuePair<int, string> field in outputFields)
            {
                XElement fieldElement = CreateElement(field.Key, field.Value, dictionary);
                trailer.Add(fieldElement);
            }

            return doc;
        }

        public static XmlDocument ToXmlDocument(this Message self, DataDictionary dataDictionary)
        {
            XDocument xdoc = ToXDocument(self, dataDictionary);
            XmlDocument xmldoc = new ConfigXmlDocument();
            using (XmlReader xmlreader = xdoc.CreateReader())
            {
                xmldoc.Load(xmlreader);
            }
            return xmldoc;
        }

        private static void DumpFields(FieldMap current, IList<KeyValuePair<int, string>> output, int[] precedingFields = null)
        {
            if (precedingFields == null)
            {
                precedingFields = new int[] { };
            }

            IList<int> groupTags = current.GetGroupTags();

            // The preceding fields and groups must appear first.
            foreach (int preField in precedingFields)
            {
                if (current.IsSetField(preField))
                {
                    output.Add(new KeyValuePair<int, string>(preField, current.GetField(preField)));
                    if (groupTags.Contains(preField))
                    {
                        for (int i = 0; i < current.GroupCount(preField); ++i)
                        {
                            Group group = current.GetGroup(i + 1, preField);
                            DumpFields(group, output, new[] {group.Delim});
                        }
                    }
                }
            }

            // The remaining fields after the preceding.
            foreach (KeyValuePair<int, IField> field in current)
            {
                if (!precedingFields.Contains(field.Key) && !groupTags.Contains(field.Key))
                {
                    output.Add(new KeyValuePair<int, string>(field.Key, field.Value.ToString()));
                }
            }

            // The remaining groups after the preceding.
            foreach (int grpTag in groupTags)
            {
                if (!precedingFields.Contains(grpTag))
                {
                    output.Add(new KeyValuePair<int, string>(grpTag, current.GetField(grpTag)));
                    for (int i = 0; i < current.GroupCount(grpTag); ++i)
                    {
                        Group group = current.GetGroup(i + 1, grpTag);
                        DumpFields(group, output, new[] {group.Delim});
                    }
                }
            }
        }

        private static XElement CreateElement(int tagNumber, string tagValue, DataDictionary dictionary)
        {
            string tagName = dictionary.GetTagName(tagNumber);
            string tagType = dictionary.GetTagType(tagNumber);

            XElement element = new XElement(tagName);

            element.Add(new XAttribute("tag", tagNumber));

            if (tagType.Equals("DATA"))
            {
                try
                {
                    // Try to convert field DATA to an XML content.
                    XElement data = XElement.Parse(tagValue);
                    element.Add(data);
                }
                catch
                {
                    // XML parsing has failed, add it as CDATA.
                    element.Add(new XCData(tagValue));
                }
            }
            else
            {
                element.Add(new XAttribute("value", tagValue));
                string enumLabel = dictionary.GetEnumLabel(tagNumber, tagValue);
                if (!string.IsNullOrWhiteSpace(enumLabel))
                {
                    element.Add(new XAttribute("desc", enumLabel));
                }
            }

            element.Add(new XAttribute("type", tagType));

            // Cleanup namespaces decorations (may occur within encoded fields having XML).
            foreach (XElement descendant in element.Descendants())
            {
                descendant.Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
                descendant.Name = descendant.Name.LocalName;
            }

            return element;
        }

        // "8=FIX.4.1^9=103^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=127
        //  ^355=<Allocations><Allocation><BookingEntity>TEST</BookingEntity><BookingQuantity>50000</BookingQuantity></Allocation></Allocations>
        //  ^10=047^"
        //
        // <message name="ORDER_SINGLE">
        //   <header>
        //      <BeginString tag="8" value="FIX.4.1" type="STRING" />
        //		<BodyLength tag="9" value="103" type="LENGTH" />
        //		<MsgSeqNum tag="34" value="4" type="SEQNUM" />
        //		<MsgType tag="35" value="D" desc="ORDER_SINGLE" type="STRING" />
        //		<SenderCompID tag="49" value="BANZAI" type="STRING" />
        //		<SendingTime tag="52" value="20121105-23:24:55" type="UTCTIMESTAMP" />
        //		<TargetCompID tag="56" value="EXEC" type="STRING" />
        //   </header>
        //	 <body>
        //		<ClOrdID tag="11" value="1352157895032" type="STRING" />
        //		<HandlInst tag="21" value="1" desc="AUTOMATED_EXECUTION_ORDER_PRIVATE" type="CHAR" />
        //		<OrderQty tag="38" value="10000" type="QTY" />
        //		<OrdType tag="40" value="1" desc="MARKET" type="CHAR" />
        //		<Side tag="54" value="1" desc="BUY" type="CHAR" />
        //		<Symbol tag="55" value="ORCL" type="STRING" />
        //		<TimeInForce tag="59" value="0" desc="DAY" type="CHAR" />
        //		<EncodedTextLen tag="354" value="127" type="LENGTH" />
        //		<EncodedText tag="355" type="DATA">
        //			<Allocations>
        //				<Allocation>
        //					<BookingEntity>TEST</BookingEntity>
        //					<BookingQuantity>50000</BookingQuantity>
        //				</Allocation>
        //			</Allocations>
        //		</EncodedText>
        //	 </body>
        //	 <trailer>
        //		<CheckSum tag="10" value="047" type="STRING" />
        //	 </trailer>
        // </message>
    }
}
