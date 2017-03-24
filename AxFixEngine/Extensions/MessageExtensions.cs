using System.Collections.Generic;
using System.Xml.Linq;
using AxFixEngine.Interfaces;
using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;

namespace AxFixEngine.Extensions
{
    public static class MessageExtensions
    {
        public static string GetName(this Message self, DataDictionary dictionary)
        {
            string msgType = self.Header.GetField(Tags.MsgType);    // "D"
            return dictionary.GetEnumLabel(Tags.MsgType, msgType);  // "ORDER_SINGLE"
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
            foreach (KeyValuePair<int, IField> field in self.Header)
            {
                XElement fieldElement = CreateElement(field, dictionary);
                header.Add(fieldElement);
            }

            XElement body = new XElement("body");
            root.Add(body);
            foreach (KeyValuePair<int, IField> field in self)
            {
                XElement fieldElement = CreateElement(field, dictionary);
                body.Add(fieldElement);
            }

            XElement trailer = new XElement("trailer");
            root.Add(trailer);
            foreach (KeyValuePair<int, IField> field in self.Trailer)
            {
                XElement fieldElement = CreateElement(field, dictionary);
                trailer.Add(fieldElement);
            }

            return doc;
        }

        private static XElement CreateElement(KeyValuePair<int, IField> field, DataDictionary dictionary)
        {
            int tagNumber = field.Key;                          // 21
            string tagName = dictionary.GetTagName(tagNumber);  // "HandlInst"
            string tagValue = field.Value.ToString();           // "1"
            string tagType = dictionary.GetTagType(tagNumber);  // "CHAR"

            XElement element = new XElement(tagName);

            element.Add(new XAttribute("tag", tagNumber));

            if (tagType.Equals("DATA"))
            {
                try
                {
                    XElement data = XElement.Parse(tagValue);
                    element.Add(data);
                }
                catch
                {
                    element.Add(new XCData(tagValue));
                }
            }
            else
            {
                element.Add(new XAttribute("value", tagValue));
                string enumLabel = dictionary.GetEnumLabel(tagNumber, tagValue); // "HandlInst=1" => "AUTOMATED_EXECUTION_ORDER_PRIVATE"
                if (!string.IsNullOrWhiteSpace(enumLabel))
                {
                    element.Add(new XAttribute("desc", enumLabel));
                }
            }

            element.Add(new XAttribute("type", tagType));

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
