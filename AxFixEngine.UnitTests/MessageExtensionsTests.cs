using System.Xml;
using System.Xml.Linq;
using AxFixEngine.Extensions;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;
using QuickFix.DataDictionary;
using Message = QuickFix.Message;

namespace AxFixEngine.UnitTests
{
    internal class MessageExtensionsTests : ArrangeActAssert
    {
        protected readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        protected DataDictionary FixDictionary44;
        protected string FixMessage;
        protected string ExpectedDocument;
        protected string ActualDocument;

        protected Message ObjectUnderTest;

        public override void Arrange()
        {
            FixDictionary44 = new DataDictionary();
            FixDictionary44.Load(TestDirectory + ".\\Spec\\FIX44.xml");
        }
    }

    internal class MessageExtensionsTests_generate_XDocument : MessageExtensionsTests
    {
        public override void Arrange()
        {
            base.Arrange();

            ExpectedDocument =
                "<message name=\"ORDER_SINGLE\"><header><BeginString tag=\"8\" value=\"FIX.4.4\" type=\"STRING\" /><BodyLength tag=\"9\" value=\"235\" type=\"LENGTH\" /><MsgSeqNum tag=\"34\" value=\"4\" type=\"SEQNUM\" /><MsgType tag=\"35\" value=\"D\" desc=\"ORDER_SINGLE\" type=\"STRING\" /><SenderCompID tag=\"49\" value=\"BANZAI\" type=\"STRING\" /><SendingTime tag=\"52\" value=\"20121105-23:24:55\" type=\"UTCTIMESTAMP\" /><TargetCompID tag=\"56\" value=\"EXEC\" type=\"STRING\" /></header><body><ClOrdID tag=\"11\" value=\"1352157895032\" type=\"STRING\" /><HandlInst tag=\"21\" value=\"1\" desc=\"AUTOMATED_EXECUTION_ORDER_PRIVATE\" type=\"CHAR\" /><OrderQty tag=\"38\" value=\"10000\" type=\"QTY\" /><OrdType tag=\"40\" value=\"1\" desc=\"MARKET\" type=\"CHAR\" /><Side tag=\"54\" value=\"1\" desc=\"BUY\" type=\"CHAR\" /><Symbol tag=\"55\" value=\"ORCL\" type=\"STRING\" /><TimeInForce tag=\"59\" value=\"0\" desc=\"DAY\" type=\"CHAR\" /><EncodedTextLen tag=\"354\" value=\"119\" type=\"LENGTH\" /><EncodedText tag=\"355\" type=\"DATA\"><box><bag><fruit>Apples</fruit><fruit>Bananas</fruit></bag></box></EncodedText></body><trailer><CheckSum tag=\"10\" value=\"103\" type=\"STRING\" /></trailer></message>";

            FixMessage = "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=119^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>^10=103^"
                .Replace("^", Message.SOH);

            ObjectUnderTest = new Message(FixMessage, FixDictionary44, true);
        }

        public override void Act()
        {
            XDocument doc = ObjectUnderTest.ToXDocument(FixDictionary44);
            ActualDocument = doc.ToString(SaveOptions.DisableFormatting);
        }

        [Test]
        public void Assert_xdocument_is_generated_from_fix_message()
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
                "<message name=\"MASS_QUOTE\"><header><BeginString tag=\"8\" value=\"FIX.4.4\" type=\"STRING\" /><BodyLength tag=\"9\" value=\"128\" type=\"LENGTH\" /><MsgSeqNum tag=\"34\" value=\"2\" type=\"SEQNUM\" /><MsgType tag=\"35\" value=\"i\" desc=\"MASS_QUOTE\" type=\"STRING\" /><SenderCompID tag=\"49\" value=\"PXMD\" type=\"STRING\" /><SendingTime tag=\"52\" value=\"20140922-14:48:49.825\" type=\"UTCTIMESTAMP\" /><TargetCompID tag=\"56\" value=\"Q037\" type=\"STRING\" /></header><body><QuoteID tag=\"117\" value=\"1\" type=\"STRING\" /><NoQuoteSets tag=\"296\" value=\"1\" type=\"NUMINGROUP\"><QuoteSetID tag=\"302\" value=\"123\" type=\"STRING\" /><NoQuoteEntries tag=\"295\" value=\"1\" type=\"NUMINGROUP\"><QuoteEntryID tag=\"299\" value=\"0\" type=\"STRING\" /><BidSize tag=\"134\" value=\"1000000\" type=\"QTY\" /><OfferSize tag=\"135\" value=\"900000\" type=\"QTY\" /><BidSpotRate tag=\"188\" value=\"1.4363\" type=\"PRICE\" /><OfferSpotRate tag=\"190\" value=\"1.4365\" type=\"PRICE\" /></NoQuoteEntries></NoQuoteSets></body><trailer><CheckSum tag=\"10\" value=\"086\" type=\"STRING\" /></trailer></message>";

            FixMessage = "8=FIX.4.4^9=128^35=i^34=2^49=PXMD^52=20140922-14:48:49.825^56=Q037^117=1^296=1^302=123^295=1^299=0^134=1000000^135=900000^188=1.4363^190=1.4365^10=086^"
                .Replace("^", Message.SOH);

            ObjectUnderTest = new Message(FixMessage, FixDictionary44, true);
        }

        public override void Act()
        {
            XDocument doc = ObjectUnderTest.ToXDocument(FixDictionary44);
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
                "<message name=\"ORDER_SINGLE\"><header><BeginString tag=\"8\" value=\"FIX.4.4\" type=\"STRING\" /><BodyLength tag=\"9\" value=\"235\" type=\"LENGTH\" /><MsgSeqNum tag=\"34\" value=\"4\" type=\"SEQNUM\" /><MsgType tag=\"35\" value=\"D\" desc=\"ORDER_SINGLE\" type=\"STRING\" /><SenderCompID tag=\"49\" value=\"BANZAI\" type=\"STRING\" /><SendingTime tag=\"52\" value=\"20121105-23:24:55\" type=\"UTCTIMESTAMP\" /><TargetCompID tag=\"56\" value=\"EXEC\" type=\"STRING\" /></header><body><ClOrdID tag=\"11\" value=\"1352157895032\" type=\"STRING\" /><HandlInst tag=\"21\" value=\"1\" desc=\"AUTOMATED_EXECUTION_ORDER_PRIVATE\" type=\"CHAR\" /><OrderQty tag=\"38\" value=\"10000\" type=\"QTY\" /><OrdType tag=\"40\" value=\"1\" desc=\"MARKET\" type=\"CHAR\" /><Side tag=\"54\" value=\"1\" desc=\"BUY\" type=\"CHAR\" /><Symbol tag=\"55\" value=\"ORCL\" type=\"STRING\" /><TimeInForce tag=\"59\" value=\"0\" desc=\"DAY\" type=\"CHAR\" /><EncodedTextLen tag=\"354\" value=\"127\" type=\"LENGTH\" /><EncodedText tag=\"355\" type=\"DATA\"><box><bag><fruit>Apples</fruit><fruit>Bananas</fruit></bag></box></EncodedText></body><trailer><CheckSum tag=\"10\" value=\"102\" type=\"STRING\" /></trailer></message>";

            FixMessage = "8=FIX.4.4^9=235^35=D^34=4^49=BANZAI^52=20121105-23:24:55^56=EXEC^11=1352157895032^21=1^38=10000^40=1^54=1^55=ORCL^59=0^354=127^355=<h:box xmlns:h=\"http://www.w3.org/TR/html4/\"><h:bag><h:fruit>Apples</h:fruit><h:fruit>Bananas</h:fruit></h:bag></h:box>^10=102^"
                .Replace("^", Message.SOH);

            ObjectUnderTest = new Message(FixMessage, FixDictionary44, true);
        }

        public override void Act()
        {
            XmlDocument doc = ObjectUnderTest.ToXmlDocument(FixDictionary44);
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
                "<message name=\"MASS_QUOTE\"><header><BeginString tag=\"8\" value=\"FIX.4.4\" type=\"STRING\" /><BodyLength tag=\"9\" value=\"128\" type=\"LENGTH\" /><MsgSeqNum tag=\"34\" value=\"2\" type=\"SEQNUM\" /><MsgType tag=\"35\" value=\"i\" desc=\"MASS_QUOTE\" type=\"STRING\" /><SenderCompID tag=\"49\" value=\"PXMD\" type=\"STRING\" /><SendingTime tag=\"52\" value=\"20140922-14:48:49.825\" type=\"UTCTIMESTAMP\" /><TargetCompID tag=\"56\" value=\"Q037\" type=\"STRING\" /></header><body><QuoteID tag=\"117\" value=\"1\" type=\"STRING\" /><NoQuoteSets tag=\"296\" value=\"1\" type=\"NUMINGROUP\"><QuoteSetID tag=\"302\" value=\"123\" type=\"STRING\" /><NoQuoteEntries tag=\"295\" value=\"1\" type=\"NUMINGROUP\"><QuoteEntryID tag=\"299\" value=\"0\" type=\"STRING\" /><BidSize tag=\"134\" value=\"1000000\" type=\"QTY\" /><OfferSize tag=\"135\" value=\"900000\" type=\"QTY\" /><BidSpotRate tag=\"188\" value=\"1.4363\" type=\"PRICE\" /><OfferSpotRate tag=\"190\" value=\"1.4365\" type=\"PRICE\" /></NoQuoteEntries></NoQuoteSets></body><trailer><CheckSum tag=\"10\" value=\"086\" type=\"STRING\" /></trailer></message>";

            FixMessage = "8=FIX.4.4^9=128^35=i^34=2^49=PXMD^52=20140922-14:48:49.825^56=Q037^117=1^296=1^302=123^295=1^299=0^134=1000000^135=900000^188=1.4363^190=1.4365^10=086^"
                .Replace("^", Message.SOH);

            ObjectUnderTest = new Message(FixMessage, FixDictionary44, true);
        }

        public override void Act()
        {
            XmlDocument doc = ObjectUnderTest.ToXmlDocument(FixDictionary44);
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

            ObjectUnderTest = new Message(FixMessage, FixDictionary44, true);
        }

        public override void Act()
        {
            ActualMessageName = ObjectUnderTest.GetName(FixDictionary44);
        }

        [Test]
        public void Assert_message_name_is_working()
        {
            ActualMessageName.Should().Be(ExpectedMessageName);
        }
    }
}
