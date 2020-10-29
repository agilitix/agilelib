using AxFixEngine.Extensions;
using FluentAssertions;
using NUnit.Framework;
using QuickFix;

namespace AxFixEngine.UnitTests
{
    [TestFixture]
    internal class SessionIDTests
    {
        [Test]
        public void Given_SessionID_should_be_reversed()
        {
            // Arrange
            SessionID sessionID = new SessionID("beginString", "senderCompId", "senderSubId", "senderLocationId", "targetCompId", "targetSubId", "targetLocationId");

            Message msg = new Message();
            msg.SetSessionID(sessionID);
            SessionID expectedSessionID = Message.GetReverseSessionID(msg);

            // Act.
            SessionID actualSessionID = sessionID.GetReverseSessionID();

            // Assert.
            actualSessionID.Should().Be(expectedSessionID);
        }
    }
}
