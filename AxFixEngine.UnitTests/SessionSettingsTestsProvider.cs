using System.Text;
using QuickFix;

namespace AxFixEngine.UnitTests
{
    internal class SessionSettingsTestsProvider
    {
        public static SessionSettings GetSessionSettings1()
        {
            string settingsString = new StringBuilder()
                .AppendLine("[DEFAULT]")
                .AppendLine("ConnectionType=initiator")
                .AppendLine("HeartBtInt=60")
                .AppendLine()
                .AppendLine("[SESSION]")
                .AppendLine("BeginString=FIX.4.2")
                .AppendLine("SenderCompID=Company")
                .AppendLine("SenderSubID=FixedIncome")
                .AppendLine("SenderLocationID=HongKong")
                .AppendLine("TargetCompID=CLIENT1")
                .AppendLine("TargetSubID=HedgeFund")
                .AppendLine("TargetLocationID=NYC")
                .AppendLine("SendRedundantResendRequests=Y")
                .AppendLine("MillisecondsInTimeStamp=Y")
                .AppendLine("EnableLastMsgSeqNumProcessed=Y")
                .AppendLine("MaxMessagesInResendRequest=2500")
                .AppendLine("StartDay=Monday")
                .AppendLine("StartTime=06:00:00")
                .AppendLine("EndDay=Friday")
                .AppendLine("EndTime=05:59:00")
                .ToString();

            SessionSettings settings = new SessionSettings(new System.IO.StringReader(settingsString));

            return settings;
        }

        public static SessionSettings GetSessionSettings2()
        {
            string configuration = new StringBuilder()
                .AppendLine("[DEFAULT]")
                .AppendLine("CONNECTIONTYPE=initiator")
                .AppendLine("BEGINSTRING=FIX.4.0")
                .AppendLine()
                .AppendLine("[SESSION]")
                .AppendLine("BEGINSTRING=FIX.4.2")
                .AppendLine("SENDERCOMPID=ISLD")
                .AppendLine("TARGETCOMPID=TW")
                .AppendLine("VALUE=1")
                .AppendLine()
                .AppendLine("[SESSION]")
                .AppendLine("BEGINSTRING=FIX.4.1")
                .AppendLine("SENDERCOMPID=ISLD")
                .AppendLine("TARGETCOMPID=WT")
                .AppendLine("VALUE=2")
                .ToString();

            SessionSettings settings = new SessionSettings(new System.IO.StringReader(configuration));

            return settings;
        }

        public static SessionSettings GetSessionSettings3()
        {
            string configuration = new StringBuilder()
                .AppendLine("[DEFAULT]")
                .AppendLine("CONNECTIONTYPE=initiator")
                .AppendLine("BEGINSTRING=FIX.4.2")
                .AppendLine()
                .AppendLine("[SESSION]")
                .AppendLine("BeginString=FIX.4.4")
                .AppendLine("SenderCompID=ISLD")
                .AppendLine("TargetCompID=TW")
                .AppendLine("Value=1")
                .AppendLine("# this is a comment")
                .AppendLine()
                .AppendLine("[SESSION]")
                .AppendLine("BeginString=FIX.4.1")
                .AppendLine("SenderCompID=ISLD")
                .AppendLine("TargetCompID=WT")
                .AppendLine("Value=2")
                .AppendLine()
                .AppendLine("[SESSION]")
                .AppendLine("SenderCompID=ARCA")
                .AppendLine("TargetCompID=TW")
                .AppendLine("Value=3")
                .AppendLine()
                .AppendLine("[SESSION]")
                .AppendLine("SenderCompID=ARCA")
                .AppendLine("TargetCompID=WT")
                .AppendLine()
                .AppendLine("[SESSION]")
                .AppendLine("SenderCompID=NYSE")
                .AppendLine("TargetCompID=TW")
                .AppendLine("SessionQualifier=QUAL1")
                .AppendLine("Value=5")
                .AppendLine()
                .AppendLine("[SESSION]")
                .AppendLine("SenderCompID=NYSE")
                .AppendLine("TargetCompID=TW")
                .AppendLine("SessionQualifier=QUAL2")
                .AppendLine("Value=6")
                .ToString();

            SessionSettings settings = new SessionSettings(new System.IO.StringReader(configuration));

            return settings;
        }
    }
}
