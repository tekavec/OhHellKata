using System.Threading;
using Moq;
using NUnit.Framework;

namespace OhHellKata.Tests.UnitTests
{
    [TestFixture]
    public class PlayerShould
    {
        [Test]
        public void BidsToBiddings()
        {
            IBiddings biddings = new Biddings();
            var bidGenerator = new Mock<IBidGenerator>();
            IPlayer player = new Player(bidGenerator.Object);

            bidGenerator.Setup(a => a.Bid()).Returns(1);
            player.BidsTo(biddings);

            Assert.That(biddings.BidOf(player), Is.EqualTo(1));
        }

    }
}