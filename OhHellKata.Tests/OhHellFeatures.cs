using System;
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
            var bidCollector = new Mock<BidCollector>();    
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

        private static void MockBids(Mock<BidCollector> bidCollector, FourPlayers players)
        {
            bidCollector.Setup(a => a.BidOf(players.Player1())).Returns(0);
            bidCollector.Setup(a => a.BidOf(players.Player2())).Returns(0);
            bidCollector.Setup(a => a.BidOf(players.Player3())).Returns(1);
            bidCollector.Setup(a => a.BidOf(players.Player4())).Returns(1);
        }

        private void MockTrumpCard(Mock<Deck> deck, Card card)
        {
            deck.Setup(a => a.NextCard()).Returns(card);
        }

        private void MockDeckForPlayers(Mock<Deck> deck, List<Card> cards)
        {
            foreach (var card in cards)
            {
                deck.Setup(a => a.NextCard()).Returns(card);
            }
        }
    }

    public class BidCollector
    {
        public int BidOf(Player player)
        {
            throw new NotImplementedException();
        }
    }

    public enum Suit
    {
        Hearts, Spades, Diamonds, Clubs
    }

    public class Queen : Card
    {
        public static Queen Of(Suit suit)
        {
            throw new NotImplementedException();
        }
    }

    public class King : Card
    {
        public static King Of(Suit suit)
        {
            throw new NotImplementedException();
        }
    }

    public class Two : Card
    {
        public static Two Of(Suit suit)
        {
            throw new NotImplementedException();
        }
    }

    public class Six : Card
    {
        public static Six Of(Suit suit)
        {
            throw new NotImplementedException();
        }
    }

    public class Card
    {
    }

    public class Deck
    {
        public Card NextCard()
        {
            throw new NotImplementedException();
        }
    }

    public class OhHellGame
    {
        private readonly FourPlayers _Players;
        private readonly BidCollector _BidCollector;
        private readonly Deck _Deck;
        private Dealer _Dealer = new Dealer();

        public OhHellGame(FourPlayers players, BidCollector bidCollector, Deck deck)
        {
            _Players = players;
            _BidCollector = bidCollector;
            _Deck = deck;
        }

        public Round NextRoundWith(Suit trumpCard, Mock<BidCollector> bidCollector)
        {
            throw new NotImplementedException();
        }

        public void NextRound()
        {
            _Dealer.Deal(_Deck).To(_Players);

            var trump = _Dealer.PickTrumpFrom(_Deck);

            _Players.Player1().BidsTo(_BidCollector);
            _Players.Player2().BidsTo(_BidCollector);
            _Players.Player3().BidsTo(_BidCollector);
            _Players.Player4().BidsTo(_BidCollector);

        }
    }

    public class Round
    {
        public void DetermineWinner()
        {
            throw new NotImplementedException();
        }
    }

    public class Dealer
    {
        public Dealer Deal(Deck deck)
        {
            throw new NotImplementedException();
        }

        public void To(FourPlayers players)
        {
            throw new NotImplementedException();
        }

        public Suit PickTrumpFrom(Deck deck)
        {
            throw new NotImplementedException();
        }
    }

    public class FourPlayers
    {
        public Player Player1()
        {
            throw new NotImplementedException();
        }

        public Player Player2()
        {
            throw new NotImplementedException();
        }

        public Player Player3()
        {
            throw new NotImplementedException();
        }

        public Player Player4()
        {
            throw new NotImplementedException();
        }
    }

    public class Player
    {
        public void RevealsCardIn(Round round)
        {
            throw new NotImplementedException();
        }

        public void BidsTo(BidCollector bidCollector)
        {
            throw new NotImplementedException();
        }

        public int Score()
        {
            throw new NotImplementedException();
        }
    }
}
