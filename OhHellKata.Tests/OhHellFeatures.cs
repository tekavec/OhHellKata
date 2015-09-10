using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace OhHellKata.Tests
{
    [TestFixture]
    public class OhHellFeatures
    {
        [Test]
        public void PlayingSimpleHand()
        {
            var bidCollector = new Mock<BidPaper>();    
            var players = new FourPlayers();
            var deck = new Mock<Deck>();
            var game = new OhHellGame(players, bidCollector.Object, deck.Object);

            MockDeckForPlayers(deck, new List<Card> {Six.Of(Suit.Spades), Two.Of(Suit.Diamonds), Six.Of(Suit.Clubs), King.Of(Suit.Spades)});
            MockTrumpCard(deck, Queen.Of(Suit.Clubs));
            MockBids(bidCollector, players);

            game.NextRound();

            Assert.That(players.Player1().Score(), Is.EqualTo(5));
            Assert.That(players.Player1().Score(), Is.EqualTo(5));
            Assert.That(players.Player1().Score(), Is.EqualTo(6));
            Assert.That(players.Player1().Score(), Is.EqualTo(-5));
        }

        private static void MockBids(Mock<BidPaper> bidPaper, FourPlayers players)
        {
            bidPaper.Setup(a => a.BidOf(players.Player1())).Returns(0);
            bidPaper.Setup(a => a.BidOf(players.Player2())).Returns(0);
            bidPaper.Setup(a => a.BidOf(players.Player3())).Returns(1);
            bidPaper.Setup(a => a.BidOf(players.Player4())).Returns(1);
        }

        private void MockTrumpCard(Mock<Deck> deck, Card card)
        {
            deck.Setup(a => a.NextCard()).Returns(card);
        }

        private void MockDeckForPlayers(Mock<Deck> deck, IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                deck.Setup(a => a.NextCard()).Returns(card);
            }
        }
    }
}
