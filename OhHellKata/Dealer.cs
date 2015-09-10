using OhHellKata.Cards;

namespace OhHellKata
{
    public class Dealer
    {
        private IDeck _Deck;

        public Dealer Deal(IDeck deck)
        {
            var dealer = new Dealer
            {
                _Deck = deck
            };
            return dealer;
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