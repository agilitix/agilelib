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
        public static DataDictionary GetDialect(this Message self, IFixDialects dialects)
        {
            DataDictionary dictionary = dialects.GetDataDictionary(self.GetSessionID());
            return dictionary;
        }

        public static SessionID GetSessionID(this Message self)
        {
            SessionID sessionId = self.GetSessionID(self);
            return sessionId;
        }

        public static MsgType GetMsgType(this Message self)
        {
            string msgType = self.Header.GetString(Tags.MsgType);
            return new MsgType(msgType);
        }

        public static string GetMsgName(this Message self, IFixDialects dialects)
        {
            DataDictionary dictionary = GetDialect(self, dialects);
            MsgType msgType = GetMsgType(self);
            return dictionary.GetEnumName(msgType);
        }

        #region ToXDocument sample

        // This method converts this regular FIX message :
        // "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=119^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>^10=103^"
        //
        // ...into this XML message :
        //<Message MsgType="D" MsgName="ORDER_SINGLE">
        //    <Header>
        //        <BeginString Tag="8" Value="FIX.4.4" />
        //        <BodyLength Tag="9" Value="235" />
        //        <MsgType Tag="35" Value="D" HasEnums="true" EnumValue="ORDER_SINGLE" />
        //        <MsgSeqNum Tag="34" Value="4" />
        //        <SenderCompID Tag="49" Value="BANZAI" />
        //        <SendingTime Tag="52" Value="20121105-23:24:55" />
        //        <TargetCompID Tag="56" Value="EXEC" />
        //    </Header>
        //    <Body>
        //        <ClOrdID Tag="11" Value="1352157895032" />
        //        <HandlInst Tag="21" Value="1" HasEnums="true" EnumValue="AUTOMATED_EXECUTION_ORDER_PRIVATE" />
        //        <OrderQty Tag="38" Value="10000" />
        //        <OrdType Tag="40" Value="1" HasEnums="true" EnumValue="MARKET" />
        //        <Side Tag="54" Value="1" HasEnums="true" EnumValue="BUY" />
        //        <Symbol Tag="55" Value="ORCL" />
        //        <TimeInForce Tag="59" Value="0" HasEnums="true" EnumValue="DAY" />
        //        <EncodedTextLen Tag="354" Value="119" />
        //        <EncodedText Tag="355" EncodedType="XML">
        //            <box>
        //                <bag>
        //                    <fruit>Apples</fruit>
        //                    <fruit>Bananas</fruit>
        //                </bag>
        //            </box>
        //        </EncodedText>
        //    </Body>
        //    <Trailer>
        //        <CheckSum Tag="10" Value="103" />
        //    </Trailer>
        //</Message>

        #endregion

        public static XDocument ToXDocument(this Message self, IFixDialects dialects)
        {
            string msgName = GetMsgName(self, dialects);
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", null));

            XElement root = new XElement("Message");
            root.Add(new XAttribute("MsgType", self.Header.GetString(Tags.MsgType)));
            root.Add(new XAttribute("MsgName", msgName));
            doc.Add(root);

            DataDictionary dictionary = GetDialect(self, dialects);

            XElement header = new XElement("Header");
            root.Add(header);
            FieldMapToXml(self.Header, header, dictionary, self.Header.HEADER_FIELD_ORDER);

            XElement body = new XElement("Body");
            root.Add(body);
            FieldMapToXml(self, body, dictionary, new int[0]);

            XElement trailer = new XElement("Trailer");
            root.Add(trailer);
            FieldMapToXml(self.Trailer, trailer, dictionary, new int[0]);

            // Cleanup namespaces decorations.
            foreach (XElement descendant in header.Descendants()
                                                  .Concat(body.Descendants())
                                                  .Concat(trailer.Descendants()))
            {
                descendant.Attributes().Where(x => x.IsNamespaceDeclaration).Remove();
                descendant.Name = descendant.Name.LocalName;
            }

            return doc;
        }

        public static XmlDocument ToXmlDocument(this Message self, IFixDialects dialects)
        {
            XDocument xdoc = ToXDocument(self, dialects);
            XmlDocument xmldoc = new XmlDocument();
            using (XmlReader xmlreader = xdoc.CreateReader())
            {
                xmldoc.Load(xmlreader);
            }

            return xmldoc;
        }

        #region ToJson sample

        // This method converts this regular FIX message :
        // "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=119^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>^10=103^"
        //
        // ...into this Json message :
        //{
        //  "Message":{  
        //    "@MsgType":"D",
        //    "@MsgName":"ORDER_SINGLE",
        //    "Header":{  
        //      "BeginString":{  
        //        "@Tag":"8",
        //        "@Value":"FIX.4.4"
        //      },
        //      "BodyLength":{  
        //        "@Tag":"9",
        //        "@Value":"235"
        //      },
        //      "MsgType":{  
        //        "@Tag":"35",
        //        "@Value":"D",
        //        "@HasEnums":"true",
        //        "@EnumValue":"ORDER_SINGLE"
        //      },
        //      "MsgSeqNum":{  
        //        "@Tag":"34",
        //        "@Value":"4"
        //      },
        //      "SenderCompID":{  
        //        "@Tag":"49",
        //        "@Value":"BANZAI"
        //      },
        //      "SendingTime":{  
        //        "@Tag":"52",
        //        "@Value":"20121105-23:24:55"
        //      },
        //      "TargetCompID":{  
        //        "@Tag":"56",
        //        "@Value":"EXEC"
        //      }
        //    },
        //    "Body":{  
        //      "ClOrdID":{  
        //        "@Tag":"11",
        //        "@Value":"1352157895032"
        //      },
        //      "HandlInst":{  
        //        "@Tag":"21",
        //        "@Value":"1",
        //        "@HasEnums":"true",
        //        "@EnumValue":"AUTOMATED_EXECUTION_ORDER_PRIVATE"
        //      },
        //      "OrderQty":{  
        //        "@Tag":"38",
        //        "@Value":"10000"
        //      },
        //      "OrdType":{  
        //        "@Tag":"40",
        //        "@Value":"1",
        //        "@HasEnums":"true",
        //        "@EnumValue":"MARKET"
        //      },
        //      "Side":{  
        //        "@Tag":"54",
        //        "@Value":"1",
        //        "@HasEnums":"true",
        //        "@EnumValue":"BUY"
        //      },
        //      "Symbol":{  
        //        "@Tag":"55",
        //        "@Value":"ORCL"
        //      },
        //      "TimeInForce":{  
        //        "@Tag":"59",
        //        "@Value":"0",
        //        "@HasEnums":"true",
        //        "@EnumValue":"DAY"
        //      },
        //      "EncodedTextLen":{  
        //        "@Tag":"354",
        //        "@Value":"119"
        //      },
        //      "EncodedText":{  
        //        "@Tag":"355",
        //        "@EncodedType":"XML",
        //        "box":{  
        //          "bag":{  
        //            "fruit":[
        //              "Apples",
        //              "Bananas"
        //            ]
        //          }
        //        }
        //      }
        //    },
        //    "Trailer":{  
        //      "CheckSum":{  
        //        "@Tag":"10",
        //        "@Value":"103"
        //      }
        //    }
        //  }
        //}

        #endregion

        public static string ToJson(this Message self, IFixDialects dialects)
        {
            XmlDocument doc = ToXmlDocument(self, dialects);
            return JsonConvert.SerializeXmlNode(doc);
        }

        private static void FieldMapToXml(FieldMap fieldMap,
                                          XElement parent,
                                          DataDictionary dictionary,
                                          int[] precedingFields)
        {
            // Sort by preceding tags first then by other tags.
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

                string value = fieldMap.GetString(tag);

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

                parent.Add(child);
            }
        }
    }
}
