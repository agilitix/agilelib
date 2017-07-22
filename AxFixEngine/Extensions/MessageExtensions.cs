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
            AppendFields(self.Header, header, dictionary);

            XElement body = new XElement("body");
            root.Add(body);
            AppendFields(self, body, dictionary);

            XElement trailer = new XElement("trailer");
            root.Add(trailer);
            AppendFields(self.Trailer, trailer, dictionary);

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

        private struct FixField
        {
            public int Tag;
            public string TagName;
            public string Value;
            public string ValueName;
            public string Type;
            public IList<FixField> Group;
        }

        private static void AppendFields(FieldMap fromMap, XElement toElement, DataDictionary dictionary)
        {
            IList<FixField> collectedFields = new List<FixField>();
            CollectFields(fromMap, collectedFields, dictionary);
            foreach (FixField field in collectedFields)
            {
                XElement fieldElement = CreateElement(field);
                toElement.Add(fieldElement);
            }
        }

        private static void CollectFields(FieldMap currentMap,
                                          IList<FixField> output,
                                          DataDictionary dictionary,
                                          int[] precedingFields = null,
                                          FixField? groupField = null)
        {
            if (precedingFields == null)
            {
                precedingFields = new int[] { };
            }

            IList<int> groupTags = currentMap.GetGroupTags();

            // Preceding tags must appear first.
            foreach (int preField in precedingFields)
            {
                if (currentMap.IsSetField(preField))
                {
                    string value = currentMap.GetField(preField);
                    FixField newField = new FixField
                                        {
                                            Tag = preField,
                                            Value = value,
                                            Group = new List<FixField>(),
                                            Type = dictionary.GetTagType(preField),
                                            TagName = dictionary.GetTagName(preField),
                                            ValueName = dictionary.GetEnumLabel(preField, value) ?? string.Empty
                                        };
                    if (groupField.HasValue)
                    {
                        groupField.Value.Group.Add(newField);
                    }
                    else
                    {
                        output.Add(newField);
                    }
                    if (groupTags.Contains(preField))
                    {
                        for (int i = 0; i < currentMap.GroupCount(preField); ++i)
                        {
                            Group group = currentMap.GetGroup(i + 1, preField);
                            CollectFields(group, output, dictionary, new[] {group.Delim}, newField);
                        }
                    }
                }
            }

            // Other fields after preceding tags.
            foreach (KeyValuePair<int, IField> field in currentMap)
            {
                if (!precedingFields.Contains(field.Key) && !groupTags.Contains(field.Key))
                {
                    string value = currentMap.GetField(field.Key);
                    FixField newField = new FixField
                                        {
                                            Tag = field.Key,
                                            Value = value,
                                            Group = new List<FixField>(),
                                            Type = dictionary.GetTagType(field.Key),
                                            TagName = dictionary.GetTagName(field.Key),
                                            ValueName = dictionary.GetEnumLabel(field.Key, value) ?? string.Empty
                                        };
                    if (groupField.HasValue)
                    {
                        groupField.Value.Group.Add(newField);
                    }
                    else
                    {
                        output.Add(newField);
                    }
                }
            }

            // Other groups after preceding tags.
            foreach (int grpTag in groupTags)
            {
                if (!precedingFields.Contains(grpTag))
                {
                    FixField newField = new FixField
                                        {
                                            Tag = grpTag,
                                            Value = currentMap.GetField(grpTag),
                                            Group = new List<FixField>(),
                                            Type = dictionary.GetTagType(grpTag),
                                            TagName = dictionary.GetTagName(grpTag)
                                        };
                    if (groupField.HasValue)
                    {
                        groupField.Value.Group.Add(newField);
                    }
                    else
                    {
                        output.Add(newField);
                    }
                    for (int i = 0; i < currentMap.GroupCount(grpTag); ++i)
                    {
                        Group group = currentMap.GetGroup(i + 1, grpTag);
                        CollectFields(group, output, dictionary, new[] {group.Delim}, newField);
                    }
                }
            }
        }

        private static XElement CreateElement(FixField field)
        {
            XElement element = new XElement(field.TagName);
            element.Add(new XAttribute("tag", field.Tag));

            foreach (FixField group in field.Group)
            {
                XElement child = CreateElement(group);
                element.Add(child);
            }

            if (field.Type.Equals("DATA"))
            {
                try
                {
                    // Try to convert field DATA to an XML content.
                    XElement data = XElement.Parse(field.Value);
                    element.Add(data);
                }
                catch
                {
                    // XML parsing has failed, add it as CDATA.
                    element.Add(new XCData(field.Value));
                }
            }
            else
            {
                element.Add(new XAttribute("value", field.Value));
                if (!string.IsNullOrWhiteSpace(field.ValueName))
                {
                    element.Add(new XAttribute("desc", field.ValueName));
                }
            }

            element.Add(new XAttribute("type", field.Type));

            // Cleanup namespaces decorations (may occur within encoded fields having XML).
            foreach (XElement descendant in element.Descendants())
            {
                descendant.Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
                descendant.Name = descendant.Name.LocalName;
            }

            return element;
        }

        // Message with XML encoded field in tag[355] :
        //
        // "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032
        //  ^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=119
        //  ^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>
        //  ^10=103^"
        //
        //  <message name = "ORDER_SINGLE" >
        //      <header>
        //          <BeginString tag="8" value="FIX.4.4" type="STRING" />
        //          <BodyLength tag = "9" value="235" type="LENGTH" />
        //          <MsgSeqNum tag = "34" value="4" type="SEQNUM" />
        //          <MsgType tag = "35" value="D" desc="ORDER_SINGLE" type="STRING" />
        //          <SenderCompID tag = "49" value="BANZAI" type="STRING" />
        //          <SendingTime tag = "52" value="20121105-23:24:55" type="UTCTIMESTAMP" />
        //          <TargetCompID tag = "56" value="EXEC" type="STRING" />
        //      </header>
        //      <body>
        //          <ClOrdID tag = "11" value="1352157895032" type="STRING" />
        //          <HandlInst tag = "21" value="1" desc="AUTOMATED_EXECUTION_ORDER_PRIVATE" type="CHAR" />
        //          <OrderQty tag = "38" value="10000" type="QTY" />
        //          <OrdType tag = "40" value="1" desc="MARKET" type="CHAR" />
        //          <Side tag = "54" value="1" desc="BUY" type="CHAR" />
        //          <Symbol tag = "55" value="ORCL" type="STRING" />
        //          <TimeInForce tag = "59" value="0" desc="DAY" type="CHAR" />
        //          <EncodedTextLen tag = "354" value="119" type="LENGTH" />
        //          <EncodedText tag = "355" type="DATA">
        //              <box>
        //                  <bag>
        //                      <fruit>Apples</fruit>
        //                      <fruit>Bananas</fruit>
        //                  </bag>
        //              </box>
        //          </EncodedText>
        //      </body>
        //      <trailer>
        //          <CheckSum tag = "10" value="103" type="STRING" />
        //      </trailer>
        //  </message>

        // Message with embedded groups :
        //
        //  "8=FIX.4.4^9=128^35=i^34=2^49=PXMD^52=20140922-14:48:49.825^56=Q037^117=1
        //   ^296=1^302=123^295=1^299=0^134=1000000^135=900000^188=1.4363^190=1.4365^10=086^"
        //
        //  <message name = "MASS_QUOTE" >
        //      <header>
        //          <BeginString tag="8" value="FIX.4.4" type="STRING" />
        //          <BodyLength tag = "9" value="128" type="LENGTH" />
        //          <MsgSeqNum tag = "34" value="2" type="SEQNUM" />
        //          <MsgType tag = "35" value="i" desc="MASS_QUOTE" type="STRING" />
        //          <SenderCompID tag = "49" value="PXMD" type="STRING" />
        //          <SendingTime tag = "52" value="20140922-14:48:49.825" type="UTCTIMESTAMP" />
        //          <TargetCompID tag = "56" value="Q037" type="STRING" />
        //          </header>
        //      <body>
        //          <QuoteID tag = "117" value="1" type="STRING" />
        //          <NoQuoteSets tag = "296" value="1" type="NUMINGROUP">
        //              <QuoteSetID tag = "302" value="123" type="STRING" />
        //              <NoQuoteEntries tag = "295" value="1" type="NUMINGROUP">
        //                  <QuoteEntryID tag = "299" value="0" type="STRING" />
        //                  <BidSize tag = "134" value="1000000" type="QTY" />
        //                  <OfferSize tag = "135" value="900000" type="QTY" />
        //                  <BidSpotRate tag = "188" value="1.4363" type="PRICE" />
        //                  <OfferSpotRate tag = "190" value="1.4365" type="PRICE" />
        //              </NoQuoteEntries>
        //          </NoQuoteSets>
        //      </body>
        //      <trailer>
        //          <CheckSum tag = "10" value="086" type="STRING" />
        //      </trailer>
        //  </message>
    }
}
