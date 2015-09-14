using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using OhHellKata.Bids;
using OhHellKata.Cards;
using OhHellKata.Players;

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
            IDeck deck = new Deck();

            SetupTrumpCard(deck, Queen.Of(Suit.Clubs));
            SetupDeckForPlayers(deck, new List<ICard> {Six.Of(Suit.Spades), Two.Of(Suit.Diamonds), Six.Of(Suit.Clubs), King.Of(Suit.Spades)});
            biddings.Setup(a => a.BidOf(players.Player1)).Returns(0);
            biddings.Setup(a => a.BidOf(players.Player2)).Returns(1);
            biddings.Setup(a => a.BidOf(players.Player3)).Returns(0);
            biddings.Setup(a => a.BidOf(players.Player4)).Returns(1);

            var game = new OhHellGame(players, biddings.Object, deck);

            game.NextRound();

            Assert.That(game.ScoreOf(players.Player1), Is.EqualTo(5));
            Assert.That(game.ScoreOf(players.Player2), Is.EqualTo(6));
            Assert.That(game.ScoreOf(players.Player3), Is.EqualTo(5));
            Assert.That(game.ScoreOf(players.Player4), Is.EqualTo(-5));
        }

        private void SetupTrumpCard(IDeck deck, ICard card)
        {
            deck.Cards.Push(card);
        }

        private void SetupDeckForPlayers(IDeck deck, IEnumerable<ICard> cards)
        {
            foreach (var card in cards)
            {
                deck.Cards.Push(card);
            }
        }
    }
}
