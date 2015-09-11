using Moq;
using NUnit.Framework;
using OhHellKata.Cards;

namespace OhHellKata.Tests.UnitTests
{
    [TestFixture]
    public class RoundShould
    {
        private Mock<IFourPlayers> _Players;
        private Biddings _Biddings;
        private Player _Player1;
        private Player _Player2;
        private Player _Player3;
        private Player _Player4;
        private Round _Round;

        [SetUp]
        public void Init()
        {
            _Players = new Mock<IFourPlayers>();
            _Biddings = new Biddings();
            _Player1 = new Player();
            _Player2 = new Player();
            _Player3 = new Player();
            _Player4 = new Player();
            _Players.Setup(a => a.Player1).Returns(_Player1);
            _Players.Setup(a => a.Player2).Returns(_Player2);
            _Players.Setup(a => a.Player3).Returns(_Player3);
            _Players.Setup(a => a.Player4).Returns(_Player4);
            _Round = new Round(_Players.Object, Suit.Spades, _Biddings);
        }

        [Test]
        public void PerformABidding()
        {
            _Round.PerformBidding();

            Assert.That(_Biddings.BidOf(_Player1), Is.TypeOf<int>());
            Assert.That(_Biddings.BidOf(_Player2), Is.TypeOf<int>());
            Assert.That(_Biddings.BidOf(_Player3), Is.TypeOf<int>());
            Assert.That(_Biddings.BidOf(_Player4), Is.TypeOf<int>());
        }

        [Test]
        public void DetermineTheHighestCard()
        {
            var cardCalculator = new Mock<CardCalculator>();
            _Player1.Hand().Add(Six.Of(Suit.Diamonds));
            _Player2.Hand().Add(Six.Of(Suit.Diamonds));
            _Player3.Hand().Add(Six.Of(Suit.Diamonds));
            _Player4.Hand().Add(Six.Of(Suit.Diamonds));
            _Round.DetermineHighestCard();
        
            cardCalculator.Verify(a => a.HighestCard());
        }
         
    }
}