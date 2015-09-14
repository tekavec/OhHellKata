using OhHellKata.Cards;
using OhHellKata.Players;

namespace OhHellKata
{
    public class Dealer
    {
        private IDeck _Deck;

        public Dealer Deal(IDeck deck)
        {
            _Deck = deck;
            return this;
        }

        public void To(FourPlayers players)
        {
            players.Player1.Hand().Add(_Deck.NextCard());
            players.Player2.Hand().Add(_Deck.NextCard());
            players.Player3.Hand().Add(_Deck.NextCard());
            players.Player4.Hand().Add(_Deck.NextCard());
        }

        public Suit PickTrumpFrom(IDeck deck)
        {
            return deck.NextCard().Suit;
        }
    }
}