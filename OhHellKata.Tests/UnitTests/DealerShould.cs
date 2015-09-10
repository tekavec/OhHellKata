using Moq;
using NUnit.Framework;
using OhHellKata.Cards;

namespace OhHellKata.Tests.UnitTests
{
    [TestFixture]
    public class DealerShould
    {
        private Mock<IDeck> _Deck;
        private Dealer _Dealer;

        [SetUp]
        public void Init()
        {
            _Deck = new Mock<IDeck>();
            _Dealer = new Dealer();
        }

        [Test]
        public void DealDeckToPlayers()
        {
            var players = new FourPlayers();

            _Deck.Setup(a => a.NextCard()).Returns(Six.Of(Suit.Spades));
            _Deck.Setup(a => a.NextCard()).Returns(Two.Of(Suit.Diamonds));
            //deck.Setup(a => a.NextCard()).Returns(King.Of(Suit.Clubs));
            //deck.Setup(a => a.NextCard()).Returns(Queen.Of(Suit.Hearts));

            _Dealer.Deal(_Deck.Object).To(players);

            //TODO Moq went nuts
            Assert.That(players.Player1.Hand(), Contains.Item(Two.Of(Suit.Diamonds)));
            Assert.That(players.Player2.Hand(), Contains.Item(Two.Of(Suit.Diamonds)));
            //Assert.That(players.Player3.Hand(), Contains.Item(King.Of(Suit.Clubs)));
            //Assert.That(players.Player4.Hand(), Contains.Item(Queen.Of(Suit.Hearts)));
        }

        [Test]
        public void PickATrumpFromADeck()
        {
            _Deck.Setup(a => a.NextCard()).Returns(Queen.Of(Suit.Spades));
            Suit trump = _Dealer.PickTrumpFrom(_Deck.Object);

            Assert.That(trump, Is.EqualTo(Suit.Spades));
        }
    }
}