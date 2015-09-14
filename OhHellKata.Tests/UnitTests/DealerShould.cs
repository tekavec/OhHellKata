using Moq;
using NUnit.Framework;
using OhHellKata.Cards;
using OhHellKata.Players;

namespace OhHellKata.Tests.UnitTests
{
    [TestFixture]
    public class DealerShould
    {
        private IDeck _Deck;
        private Dealer _Dealer;

        [SetUp]
        public void Init()
        {
            _Deck = new Deck();
            _Dealer = new Dealer();
        }

        [Test]
        public void DealDeckToPlayers()
        {
            var players = new FourPlayers();

            _Deck.Cards.Push(Queen.Of(Suit.Hearts));
            _Deck.Cards.Push(King.Of(Suit.Clubs));
            _Deck.Cards.Push(Two.Of(Suit.Diamonds));
            _Deck.Cards.Push(Six.Of(Suit.Spades));

            _Dealer.Deal(_Deck).To(players);

            //TODO Moq went nuts
            Assert.That(players.Player1.Hand(), Contains.Item(Six.Of(Suit.Spades)));
            Assert.That(players.Player2.Hand(), Contains.Item(Two.Of(Suit.Diamonds)));
            Assert.That(players.Player3.Hand(), Contains.Item(King.Of(Suit.Clubs)));
            Assert.That(players.Player4.Hand(), Contains.Item(Queen.Of(Suit.Hearts)));
        }

        [Test]
        public void PickATrumpFromADeck()
        {
            _Deck.Cards.Push(Queen.Of(Suit.Spades));
            Suit trump = _Dealer.PickTrumpFrom(_Deck);

            Assert.That(trump, Is.EqualTo(Suit.Spades));
        }
    }
}