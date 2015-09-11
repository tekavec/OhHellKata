using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using OhHellKata.Cards;

namespace OhHellKata.Tests
{
    [TestFixture]
    public class OhHellFeatures
    {
        [Test]
        public void PlayingSimpleHand()
        {
            var biddings = new Mock<IBiddings>();    
            var players = new FourPlayers();
            var deck = new Mock<IDeck>();

            MockDeckForPlayers(deck, new List<ICard> {Six.Of(Suit.Spades), Two.Of(Suit.Diamonds), Six.Of(Suit.Clubs), King.Of(Suit.Spades)});
            MockTrumpCard(deck, Queen.Of(Suit.Clubs));
            biddings.Setup(a => a.BidOf(players.Player1)).Returns(0);
            biddings.Setup(a => a.BidOf(players.Player2)).Returns(0);
            biddings.Setup(a => a.BidOf(players.Player3)).Returns(1);
            biddings.Setup(a => a.BidOf(players.Player4)).Returns(1);

            var game = new OhHellGame(players, biddings.Object, deck.Object);

            game.NextRound();

            Assert.That(game.ScoreOf(players.Player1), Is.EqualTo(5));
            Assert.That(game.ScoreOf(players.Player2), Is.EqualTo(5));
            Assert.That(game.ScoreOf(players.Player3), Is.EqualTo(6));
            Assert.That(game.ScoreOf(players.Player4), Is.EqualTo(-5));
        }

        private void MockTrumpCard(Mock<IDeck> deck, ICard card)
        {
            deck.Setup(a => a.NextCard()).Returns(card);
        }

        private void MockDeckForPlayers(Mock<IDeck> deck, IEnumerable<ICard> cards)
        {
            foreach (var card in cards)
            {
                deck.Setup(a => a.NextCard()).Returns(card);
            }
        }
    }
}
