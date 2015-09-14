using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using OhHellKata.Bids;
using OhHellKata.Cards;
using OhHellKata.Players;
using OhHellKata.Rules;

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
        private const Suit Trump = Suit.Spades;

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
        }

        [Test]
        public void PerformABidding()
        {
            var round = new Round(_Players.Object, _Biddings, new HighestCardCalculator(Trump));

            round.PerformBidding();

            Assert.That(_Biddings.BidOf(_Player1), Is.TypeOf<int>());
            Assert.That(_Biddings.BidOf(_Player2), Is.TypeOf<int>());
            Assert.That(_Biddings.BidOf(_Player3), Is.TypeOf<int>());
            Assert.That(_Biddings.BidOf(_Player4), Is.TypeOf<int>());
        }

        [Test]
        public void DetermineTheHighestCard()
        {
            var cardCalculator = new Mock<ICardCalculator>();
            var round = new Round(_Players.Object, _Biddings, cardCalculator.Object);
            IList<ICard> cards = new List<ICard>
            {
                Queen.Of(Suit.Hearts),
                King.Of(Suit.Diamonds),
                Two.Of(Suit.Hearts),
                Six.Of(Suit.Spades)
            };
            _Player1.Hand().Add(cards[0]);
            _Player2.Hand().Add(cards[1]);
            _Player3.Hand().Add(cards[2]);
            _Player4.Hand().Add(cards[3]);

            round.DetermineHighestCard();
        
            cardCalculator.Verify(a => a.HighestCard(cards));
        }
         
    }
}