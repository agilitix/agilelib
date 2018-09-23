using System.Xml;
using System.Xml.Linq;
using AxFixEngine.Dialects;
using AxFixEngine.Extensions;
using AxFixEngine.Messages;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;
using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;
using Message = QuickFix.Message;

namespace AxFixEngine.UnitTests
{
    internal class MessageExtensionsTests : ArrangeActAssert
    {
        protected readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        protected string FixMessage;
        protected string ExpectedDocument;
        protected string ActualDocument;
        protected IFixDialects Dialects;
        protected IFixMessageParser MessagesParser;

        protected NewOrderSingle NewOrderSingleUnderTest;
        protected MassQuote MassQuoteUnderTest;

        public override void Arrange()
        {
            SessionSettings sessionSettings = SessionSettingsTestsProvider.GetSessionSettings4("FIX.4.4", TestDirectory + @"\Spec\FIX44.xml");

            Dialects = new FixDialects();
            Dialects.AddSessionSettings(sessionSettings);

            MessagesParser = new FixMessageParser(Dialects, new DefaultMessageFactory());
        }
    }

    internal class MessageExtensionsTests_generate_XDocument : MessageExtensionsTests
    {
        public override void Arrange()
        {
            base.Arrange();

            ExpectedDocument =
                "<Message MsgType=\"D\" MsgName=\"ORDER_SINGLE\"><Header><BeginString Tag=\"8\" Value=\"FIX.4.4\" /><BodyLength Tag=\"9\" Value=\"235\" /><MsgType Tag=\"35\" Value=\"D\" HasEnums=\"true\" EnumValue=\"ORDER_SINGLE\" /><MsgSeqNum Tag=\"34\" Value=\"4\" /><SenderCompID Tag=\"49\" Value=\"BANZAI\" /><SendingTime Tag=\"52\" Value=\"20121105-23:24:55\" /><TargetCompID Tag=\"56\" Value=\"EXEC\" /></Header><Body><ClOrdID Tag=\"11\" Value=\"1352157895032\" /><HandlInst Tag=\"21\" Value=\"1\" HasEnums=\"true\" EnumValue=\"AUTOMATED_EXECUTION_ORDER_PRIVATE\" /><OrderQty Tag=\"38\" Value=\"10000\" /><OrdType Tag=\"40\" Value=\"1\" HasEnums=\"true\" EnumValue=\"MARKET\" /><Side Tag=\"54\" Value=\"1\" HasEnums=\"true\" EnumValue=\"BUY\" /><Symbol Tag=\"55\" Value=\"ORCL\" /><TimeInForce Tag=\"59\" Value=\"0\" HasEnums=\"true\" EnumValue=\"DAY\" /><EncodedTextLen Tag=\"354\" Value=\"119\" /><EncodedText Tag=\"355\" EncodedType=\"XML\"><box><bag><fruit>Apples</fruit><fruit>Bananas</fruit></bag></box></EncodedText></Body><Trailer><CheckSum Tag=\"10\" Value=\"103\" /></Trailer></Message>";

            FixMessage = "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=119^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>^10=103^"
                .Replace("^", Message.SOH);

            NewOrderSingleUnderTest = (NewOrderSingle) MessagesParser.ParseMessage(FixMessage);
        }

        public override void Act()
        {
            XDocument doc = NewOrderSingleUnderTest.ToXDocument(Dialects);
            ActualDocument = doc.ToString(SaveOptions.DisableFormatting);
        }

        [Test]
        public void Assert_xdocument_is_generated_from_fix_message()
        {
            ActualDocument.Should().Be(ExpectedDocument);
        }
    }

    internal class MessageExtensionsTests_generate_XDocument_with_custom_tag : MessageExtensionsTests
    {
        public override void Arrange()
        {
            base.Arrange();

            ExpectedDocument =
                "<Message MsgType=\"D\" MsgName=\"ORDER_SINGLE\"><Header><BeginString Tag=\"8\" Value=\"FIX.4.4\" /><BodyLength Tag=\"9\" Value=\"235\" /><MsgType Tag=\"35\" Value=\"D\" HasEnums=\"true\" EnumValue=\"ORDER_SINGLE\" /><MsgSeqNum Tag=\"34\" Value=\"4\" /><SenderCompID Tag=\"49\" Value=\"BANZAI\" /><SendingTime Tag=\"52\" Value=\"20121105-23:24:55\" /><TargetCompID Tag=\"56\" Value=\"EXEC\" /></Header><Body><ClOrdID Tag=\"11\" Value=\"1352157895032\" /><HandlInst Tag=\"21\" Value=\"1\" HasEnums=\"true\" EnumValue=\"AUTOMATED_EXECUTION_ORDER_PRIVATE\" /><OrderQty Tag=\"38\" Value=\"10000\" /><OrdType Tag=\"40\" Value=\"1\" HasEnums=\"true\" EnumValue=\"MARKET\" /><Side Tag=\"54\" Value=\"1\" HasEnums=\"true\" EnumValue=\"BUY\" /><Symbol Tag=\"55\" Value=\"ORCL\" /><TimeInForce Tag=\"59\" Value=\"0\" HasEnums=\"true\" EnumValue=\"DAY\" /><CustomTag_219 Tag=\"219\" Value=\"A\" /><EncodedTextLen Tag=\"354\" Value=\"119\" /><EncodedText Tag=\"355\" EncodedType=\"XML\"><box><bag><fruit>Apples</fruit><fruit>Bananas</fruit></bag></box></EncodedText></Body><Trailer><CheckSum Tag=\"10\" Value=\"103\" /></Trailer></Message>";

            FixMessage = "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=119^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>^10=103^"
                .Replace("^", Message.SOH);

            NewOrderSingleUnderTest = (NewOrderSingle) MessagesParser.ParseMessage(FixMessage);
            NewOrderSingleUnderTest.SetField(new Benchmark('A')); // For unit test purpose only: this tag is not in NewOrderSingle, it will be considered as a custom tag.
        }

        public override void Act()
        {
            XDocument doc = NewOrderSingleUnderTest.ToXDocument(Dialects);
            ActualDocument = doc.ToString(SaveOptions.DisableFormatting);
        }

        [Test]
        public void Assert_xdocument_is_generated_from_fix_message()
        {
            ActualDocument.Should().Be(ExpectedDocument);
        }
    }

    internal class MessageExtensionsTests_generate_XDocument_with_CDATA : MessageExtensionsTests
    {
        public override void Arrange()
        {
            base.Arrange();

            ExpectedDocument =
                "<Message MsgType=\"D\" MsgName=\"ORDER_SINGLE\"><Header><BeginString Tag=\"8\" Value=\"FIX.4.4\" /><BodyLength Tag=\"9\" Value=\"143\" /><MsgType Tag=\"35\" Value=\"D\" HasEnums=\"true\" EnumValue=\"ORDER_SINGLE\" /><MsgSeqNum Tag=\"34\" Value=\"4\" /><SenderCompID Tag=\"49\" Value=\"BANZAI\" /><SendingTime Tag=\"52\" Value=\"20121105-23:24:55\" /><TargetCompID Tag=\"56\" Value=\"EXEC\" /></Header><Body><ClOrdID Tag=\"11\" Value=\"1352157895032\" /><HandlInst Tag=\"21\" Value=\"1\" HasEnums=\"true\" EnumValue=\"AUTOMATED_EXECUTION_ORDER_PRIVATE\" /><OrderQty Tag=\"38\" Value=\"10000\" /><OrdType Tag=\"40\" Value=\"1\" HasEnums=\"true\" EnumValue=\"MARKET\" /><Side Tag=\"54\" Value=\"1\" HasEnums=\"true\" EnumValue=\"BUY\" /><Symbol Tag=\"55\" Value=\"ORCL\" /><TimeInForce Tag=\"59\" Value=\"0\" HasEnums=\"true\" EnumValue=\"DAY\" /><EncodedTextLen Tag=\"354\" Value=\"119\" /><EncodedText Tag=\"355\" EncodedType=\"DATA\"><![CDATA[Lorem ipsum dolor sit amet.]]></EncodedText></Body><Trailer><CheckSum Tag=\"10\" Value=\"120\" /></Trailer></Message>";

            FixMessage = "8=FIX.4.4^9=143^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=119^355=Lorem ipsum dolor sit amet.^10=120^"
                .Replace("^", Message.SOH);

            NewOrderSingleUnderTest = (NewOrderSingle) MessagesParser.ParseMessage(FixMessage);
        }

        public override void Act()
        {
            XDocument doc = NewOrderSingleUnderTest.ToXDocument(Dialects);
            ActualDocument = doc.ToString(SaveOptions.DisableFormatting);
        }

        [Test]
        public void Assert_xdocument_is_generated_from_fix_message_and_contains_CDATA()
        {
            ActualDocument.Should().Be(ExpectedDocument);
        }
    }

    internal class MessageExtensionsTests_generate_XDocument_with_groups : MessageExtensionsTests
    {
        public override void Arrange()
        {
            base.Arrange();

            ExpectedDocument =
                "<Message MsgType=\"i\" MsgName=\"MASS_QUOTE\"><Header><BeginString Tag=\"8\" Value=\"FIX.4.4\" /><BodyLength Tag=\"9\" Value=\"176\" /><MsgType Tag=\"35\" Value=\"i\" HasEnums=\"true\" EnumValue=\"MASS_QUOTE\" /><MsgSeqNum Tag=\"34\" Value=\"2\" /><SenderCompID Tag=\"49\" Value=\"PXMD\" /><SendingTime Tag=\"52\" Value=\"20140922-14:48:49.825\" /><TargetCompID Tag=\"56\" Value=\"Q037\" /></Header><Body><QuoteID Tag=\"117\" Value=\"1\" /><NoQuoteSets Tag=\"296\" Value=\"1\" IsGroup=\"Y\" GroupsCount=\"1\"><QuoteSetIDGroup1><QuoteSetID Tag=\"302\" Value=\"123\" /><NoQuoteEntries Tag=\"295\" Value=\"2\" IsGroup=\"Y\" GroupsCount=\"2\"><QuoteEntryIDGroup1><QuoteEntryID Tag=\"299\" Value=\"0\" /><BidSize Tag=\"134\" Value=\"1000000\" /><OfferSize Tag=\"135\" Value=\"900000\" /><BidSpotRate Tag=\"188\" Value=\"1.4363\" /><OfferSpotRate Tag=\"190\" Value=\"1.4365\" /></QuoteEntryIDGroup1><QuoteEntryIDGroup2><QuoteEntryID Tag=\"299\" Value=\"1\" /><BidSize Tag=\"134\" Value=\"9850000\" /><OfferSize Tag=\"135\" Value=\"750000\" /><BidSpotRate Tag=\"188\" Value=\"10.63\" /><OfferSpotRate Tag=\"190\" Value=\"2.65\" /></QuoteEntryIDGroup2></NoQuoteEntries></QuoteSetIDGroup1></NoQuoteSets></Body><Trailer><CheckSum Tag=\"10\" Value=\"038\" /></Trailer></Message>";

            FixMessage = "8=FIX.4.4^9=176^35=i^34=2^49=PXMD^52=20140922-14:48:49.825^56=Q037^117=1^296=1^302=123^295=2^299=0^134=1000000^135=900000^188=1.4363^190=1.4365^299=1^134=9850000^135=750000^188=10.63^190=2.65^10=038^"
                .Replace("^", Message.SOH);

            MassQuoteUnderTest = (MassQuote) MessagesParser.ParseMessage(FixMessage);
        }

        public override void Act()
        {
            XDocument doc = MassQuoteUnderTest.ToXDocument(Dialects);
            ActualDocument = doc.ToString(SaveOptions.DisableFormatting);
        }

        [Test]
        public void Assert_xdocument_is_generated_from_fix_message()
        {
            ActualDocument.Should().Be(ExpectedDocument);
        }
    }

    internal class MessageExtensionsTests_generate_XmlDocument : MessageExtensionsTests
    {
        public override void Arrange()
        {
            base.Arrange();

            ExpectedDocument =
                "<Message MsgType=\"D\" MsgName=\"ORDER_SINGLE\"><Header><BeginString Tag=\"8\" Value=\"FIX.4.4\" /><BodyLength Tag=\"9\" Value=\"235\" /><MsgType Tag=\"35\" Value=\"D\" HasEnums=\"true\" EnumValue=\"ORDER_SINGLE\" /><MsgSeqNum Tag=\"34\" Value=\"4\" /><SenderCompID Tag=\"49\" Value=\"BANZAI\" /><SendingTime Tag=\"52\" Value=\"20121105-23:24:55\" /><TargetCompID Tag=\"56\" Value=\"EXEC\" /></Header><Body><ClOrdID Tag=\"11\" Value=\"1352157895032\" /><HandlInst Tag=\"21\" Value=\"1\" HasEnums=\"true\" EnumValue=\"AUTOMATED_EXECUTION_ORDER_PRIVATE\" /><OrderQty Tag=\"38\" Value=\"10000\" /><OrdType Tag=\"40\" Value=\"1\" HasEnums=\"true\" EnumValue=\"MARKET\" /><Side Tag=\"54\" Value=\"1\" HasEnums=\"true\" EnumValue=\"BUY\" /><Symbol Tag=\"55\" Value=\"ORCL\" /><TimeInForce Tag=\"59\" Value=\"0\" HasEnums=\"true\" EnumValue=\"DAY\" /><EncodedTextLen Tag=\"354\" Value=\"119\" /><EncodedText Tag=\"355\" EncodedType=\"XML\"><box><bag><fruit>Apples</fruit><fruit>Bananas</fruit></bag></box></EncodedText></Body><Trailer><CheckSum Tag=\"10\" Value=\"103\" /></Trailer></Message>";

            FixMessage = "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=119^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>^10=103^"
                .Replace("^", Message.SOH);

            NewOrderSingleUnderTest = (NewOrderSingle) MessagesParser.ParseMessage(FixMessage);
        }

        public override void Act()
        {
            XmlDocument doc = NewOrderSingleUnderTest.ToXmlDocument(Dialects);
            ActualDocument = doc.OuterXml;
        }

        [Test]
        public void Assert_xmldocument_is_generated_from_fix_message()
        {
            ActualDocument.Should().Be(ExpectedDocument);
        }
    }

    internal class MessageExtensionsTests_generate_XmlDocument_with_groups : MessageExtensionsTests
    {
        public override void Arrange()
        {
            base.Arrange();

            ExpectedDocument =
                "<Message MsgType=\"i\" MsgName=\"MASS_QUOTE\"><Header><BeginString Tag=\"8\" Value=\"FIX.4.4\" /><BodyLength Tag=\"9\" Value=\"176\" /><MsgType Tag=\"35\" Value=\"i\" HasEnums=\"true\" EnumValue=\"MASS_QUOTE\" /><MsgSeqNum Tag=\"34\" Value=\"2\" /><SenderCompID Tag=\"49\" Value=\"PXMD\" /><SendingTime Tag=\"52\" Value=\"20140922-14:48:49.825\" /><TargetCompID Tag=\"56\" Value=\"Q037\" /></Header><Body><QuoteID Tag=\"117\" Value=\"1\" /><NoQuoteSets Tag=\"296\" Value=\"1\" IsGroup=\"Y\" GroupsCount=\"1\"><QuoteSetIDGroup1><QuoteSetID Tag=\"302\" Value=\"123\" /><NoQuoteEntries Tag=\"295\" Value=\"2\" IsGroup=\"Y\" GroupsCount=\"2\"><QuoteEntryIDGroup1><QuoteEntryID Tag=\"299\" Value=\"0\" /><BidSize Tag=\"134\" Value=\"1000000\" /><OfferSize Tag=\"135\" Value=\"900000\" /><BidSpotRate Tag=\"188\" Value=\"1.4363\" /><OfferSpotRate Tag=\"190\" Value=\"1.4365\" /></QuoteEntryIDGroup1><QuoteEntryIDGroup2><QuoteEntryID Tag=\"299\" Value=\"1\" /><BidSize Tag=\"134\" Value=\"9850000\" /><OfferSize Tag=\"135\" Value=\"750000\" /><BidSpotRate Tag=\"188\" Value=\"10.63\" /><OfferSpotRate Tag=\"190\" Value=\"2.65\" /></QuoteEntryIDGroup2></NoQuoteEntries></QuoteSetIDGroup1></NoQuoteSets></Body><Trailer><CheckSum Tag=\"10\" Value=\"038\" /></Trailer></Message>";

            FixMessage = "8=FIX.4.4^9=176^35=i^34=2^49=PXMD^52=20140922-14:48:49.825^56=Q037^117=1^296=1^302=123^295=2^299=0^134=1000000^135=900000^188=1.4363^190=1.4365^299=1^134=9850000^135=750000^188=10.63^190=2.65^10=038^"
                .Replace("^", Message.SOH);

            MassQuoteUnderTest = (MassQuote) MessagesParser.ParseMessage(FixMessage);
        }

        public override void Act()
        {
            XmlDocument doc = MassQuoteUnderTest.ToXmlDocument(Dialects);
            ActualDocument = doc.OuterXml;
        }

        [Test]
        public void Assert_xmldocument_is_generated_from_fix_message()
        {
            ActualDocument.Should().Be(ExpectedDocument);
        }
    }

    internal class MessageExtensionsTests_message_name : MessageExtensionsTests
    {
        protected string ExpectedMessageName;
        protected string ActualMessageName;

        public override void Arrange()
        {
            base.Arrange();

            FixMessage = "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=127^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>^10=102^"
                .Replace("^", Message.SOH);

            ExpectedMessageName = "ORDER_SINGLE";

            NewOrderSingleUnderTest = (NewOrderSingle) MessagesParser.ParseMessage(FixMessage);
        }

        public override void Act()
        {
            ActualMessageName = NewOrderSingleUnderTest.GetMsgName(Dialects);
        }

        [Test]
        public void Assert_message_name_is_working()
        {
            ActualMessageName.Should().Be(ExpectedMessageName);
        }
    }

    internal class MessageExtensionsTests_generate_Json : MessageExtensionsTests
    {
        public override void Arrange()
        {
            base.Arrange();

            ExpectedDocument =
                "{\"Message\":{\"@MsgType\":\"D\",\"@MsgName\":\"ORDER_SINGLE\",\"Header\":{\"BeginString\":{\"@Tag\":\"8\",\"@Value\":\"FIX.4.4\"},\"BodyLength\":{\"@Tag\":\"9\",\"@Value\":\"235\"},\"MsgType\":{\"@Tag\":\"35\",\"@Value\":\"D\",\"@HasEnums\":\"true\",\"@EnumValue\":\"ORDER_SINGLE\"},\"MsgSeqNum\":{\"@Tag\":\"34\",\"@Value\":\"4\"},\"SenderCompID\":{\"@Tag\":\"49\",\"@Value\":\"BANZAI\"},\"SendingTime\":{\"@Tag\":\"52\",\"@Value\":\"20121105-23:24:55\"},\"TargetCompID\":{\"@Tag\":\"56\",\"@Value\":\"EXEC\"}},\"Body\":{\"ClOrdID\":{\"@Tag\":\"11\",\"@Value\":\"1352157895032\"},\"HandlInst\":{\"@Tag\":\"21\",\"@Value\":\"1\",\"@HasEnums\":\"true\",\"@EnumValue\":\"AUTOMATED_EXECUTION_ORDER_PRIVATE\"},\"OrderQty\":{\"@Tag\":\"38\",\"@Value\":\"10000\"},\"OrdType\":{\"@Tag\":\"40\",\"@Value\":\"1\",\"@HasEnums\":\"true\",\"@EnumValue\":\"MARKET\"},\"Side\":{\"@Tag\":\"54\",\"@Value\":\"1\",\"@HasEnums\":\"true\",\"@EnumValue\":\"BUY\"},\"Symbol\":{\"@Tag\":\"55\",\"@Value\":\"ORCL\"},\"TimeInForce\":{\"@Tag\":\"59\",\"@Value\":\"0\",\"@HasEnums\":\"true\",\"@EnumValue\":\"DAY\"},\"EncodedTextLen\":{\"@Tag\":\"354\",\"@Value\":\"119\"},\"EncodedText\":{\"@Tag\":\"355\",\"@EncodedType\":\"XML\",\"box\":{\"bag\":{\"fruit\":[\"Apples\",\"Bananas\"]}}}},\"Trailer\":{\"CheckSum\":{\"@Tag\":\"10\",\"@Value\":\"103\"}}}}";

            FixMessage = "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=119^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>^10=103^"
                .Replace("^", Message.SOH);

            NewOrderSingleUnderTest = (NewOrderSingle) MessagesParser.ParseMessage(FixMessage);
        }

        public override void Act()
        {
            ActualDocument = NewOrderSingleUnderTest.ToJson(Dialects);
        }

        [Test]
        public void Assert_json_is_generated_from_fix_message()
        {
            ActualDocument.Should().Be(ExpectedDocument);
        }
    }

    internal class MessageExtensionsTests_generate_Json_with_groups : MessageExtensionsTests
    {
        public override void Arrange()
        {
            base.Arrange();

            ExpectedDocument =
                "{\"Message\":{\"@MsgType\":\"i\",\"@MsgName\":\"MASS_QUOTE\",\"Header\":{\"BeginString\":{\"@Tag\":\"8\",\"@Value\":\"FIX.4.4\"},\"BodyLength\":{\"@Tag\":\"9\",\"@Value\":\"176\"},\"MsgType\":{\"@Tag\":\"35\",\"@Value\":\"i\",\"@HasEnums\":\"true\",\"@EnumValue\":\"MASS_QUOTE\"},\"MsgSeqNum\":{\"@Tag\":\"34\",\"@Value\":\"2\"},\"SenderCompID\":{\"@Tag\":\"49\",\"@Value\":\"PXMD\"},\"SendingTime\":{\"@Tag\":\"52\",\"@Value\":\"20140922-14:48:49.825\"},\"TargetCompID\":{\"@Tag\":\"56\",\"@Value\":\"Q037\"}},\"Body\":{\"QuoteID\":{\"@Tag\":\"117\",\"@Value\":\"1\"},\"NoQuoteSets\":{\"@Tag\":\"296\",\"@Value\":\"1\",\"@IsGroup\":\"Y\",\"@GroupsCount\":\"1\",\"QuoteSetIDGroup1\":{\"QuoteSetID\":{\"@Tag\":\"302\",\"@Value\":\"123\"},\"NoQuoteEntries\":{\"@Tag\":\"295\",\"@Value\":\"2\",\"@IsGroup\":\"Y\",\"@GroupsCount\":\"2\",\"QuoteEntryIDGroup1\":{\"QuoteEntryID\":{\"@Tag\":\"299\",\"@Value\":\"0\"},\"BidSize\":{\"@Tag\":\"134\",\"@Value\":\"1000000\"},\"OfferSize\":{\"@Tag\":\"135\",\"@Value\":\"900000\"},\"BidSpotRate\":{\"@Tag\":\"188\",\"@Value\":\"1.4363\"},\"OfferSpotRate\":{\"@Tag\":\"190\",\"@Value\":\"1.4365\"}},\"QuoteEntryIDGroup2\":{\"QuoteEntryID\":{\"@Tag\":\"299\",\"@Value\":\"1\"},\"BidSize\":{\"@Tag\":\"134\",\"@Value\":\"9850000\"},\"OfferSize\":{\"@Tag\":\"135\",\"@Value\":\"750000\"},\"BidSpotRate\":{\"@Tag\":\"188\",\"@Value\":\"10.63\"},\"OfferSpotRate\":{\"@Tag\":\"190\",\"@Value\":\"2.65\"}}}}}},\"Trailer\":{\"CheckSum\":{\"@Tag\":\"10\",\"@Value\":\"038\"}}}}";

            FixMessage = "8=FIX.4.4^9=176^35=i^34=2^49=PXMD^52=20140922-14:48:49.825^56=Q037^117=1^296=1^302=123^295=2^299=0^134=1000000^135=900000^188=1.4363^190=1.4365^299=1^134=9850000^135=750000^188=10.63^190=2.65^10=038^"
                .Replace("^", Message.SOH);

            MassQuoteUnderTest = (MassQuote) MessagesParser.ParseMessage(FixMessage);
        }

        public override void Act()
        {
            ActualDocument = MassQuoteUnderTest.ToJson(Dialects);
        }

        [Test]
        public void Assert_json_is_generated_from_fix_message()
        {
            ActualDocument.Should().Be(ExpectedDocument);
        }
    }
}
