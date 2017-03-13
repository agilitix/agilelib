using System.Xml.Linq;
using AxFixEngine.Extensions;
using AxQuality;
using NFluent;
using NUnit.Framework;
using QuickFix.DataDictionary;
using Message = QuickFix.Message;

namespace AxFixEngine.UnitTests
{
    internal class MessageExtensionsTests : ArrangeActAssert
    {
        protected readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        protected DataDictionary FixDictionary;
        protected string FixMessage;
        protected Message ObjectUnderTest;

        public override void Arrange()
        {
            FixMessage = "8=FIX.4.19=10335=D34=449=BANZAI52=20121105-23:24:5556=EXEC11=135215789503221=138=1000040=154=155=ORCL59=0354=127355=<Allocations><Allocation><BookingEntity>TEST</BookingEntity><BookingQuantity>50000</BookingQuantity></Allocation></Allocations>10=047";
            FixDictionary = new DataDictionary();
            FixDictionary.Load(TestDirectory + ".\\Spec\\FIX44.xml");

            ObjectUnderTest = new Message(FixMessage, FixDictionary, false );
        }
    }

    internal class MessageExtensionsTests_generate_XDocument : MessageExtensionsTests
    {
        protected string ExpectedXDocument;
        protected string ActualXDocument;

        public override void Arrange()
        {
            base.Arrange();
            ExpectedXDocument = "<message name=\"ORDER_SINGLE\"><header><BeginString tag=\"8\" value=\"FIX.4.1\" type=\"STRING\" /><BodyLength tag=\"9\" value=\"103\" type=\"LENGTH\" /><MsgSeqNum tag=\"34\" value=\"4\" type=\"SEQNUM\" /><MsgType tag=\"35\" value=\"D\" desc=\"ORDER_SINGLE\" type=\"STRING\" /><SenderCompID tag=\"49\" value=\"BANZAI\" type=\"STRING\" /><SendingTime tag=\"52\" value=\"20121105-23:24:55\" type=\"UTCTIMESTAMP\" /><TargetCompID tag=\"56\" value=\"EXEC\" type=\"STRING\" /></header><body><ClOrdID tag=\"11\" value=\"1352157895032\" type=\"STRING\" /><HandlInst tag=\"21\" value=\"1\" desc=\"AUTOMATED_EXECUTION_ORDER_PRIVATE\" type=\"CHAR\" /><OrderQty tag=\"38\" value=\"10000\" type=\"QTY\" /><OrdType tag=\"40\" value=\"1\" desc=\"MARKET\" type=\"CHAR\" /><Side tag=\"54\" value=\"1\" desc=\"BUY\" type=\"CHAR\" /><Symbol tag=\"55\" value=\"ORCL\" type=\"STRING\" /><TimeInForce tag=\"59\" value=\"0\" desc=\"DAY\" type=\"CHAR\" /><EncodedTextLen tag=\"354\" value=\"127\" type=\"LENGTH\" /><EncodedText tag=\"355\" type=\"DATA\"><Allocations><Allocation><BookingEntity>TEST</BookingEntity><BookingQuantity>50000</BookingQuantity></Allocation></Allocations></EncodedText></body><trailer><CheckSum tag=\"10\" value=\"047\" type=\"STRING\" /></trailer></message>";
        }

        public override void Act()
        {
            XDocument doc = ObjectUnderTest.ToXDocument(FixDictionary);
            ActualXDocument = doc.ToString(SaveOptions.DisableFormatting);
        }

        [Test]
        public void Assert_xdocument_is_generated_from_fix_message()
        {
            Check.That(ActualXDocument).IsEqualTo(ExpectedXDocument);
        }
    }

    internal class MessageExtensionsTests_message_name : MessageExtensionsTests
    {
        protected string ExpectedMessageName;
        protected string ActualMessageName;

        public override void Arrange()
        {
            base.Arrange();
            ExpectedMessageName = "ORDER_SINGLE";
        }

        public override void Act()
        {
            ActualMessageName = ObjectUnderTest.GetName(FixDictionary);
        }

        [Test]
        public void Assert_message_name_is_working()
        {
            Check.That(ActualMessageName).IsEqualTo(ExpectedMessageName);
        }
    }
}
