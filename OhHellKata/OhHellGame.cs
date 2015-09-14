using OhHellKata.Cards;
using OhHellKata.Players;
using OhHellKata.Rules;

namespace OhHellKata
{
    public class OhHellGame
    {
        private readonly FourPlayers _Players;
        private readonly IBiddings _Biddings;
        private readonly IDeck _Deck;
        private readonly Dealer _Dealer;
        private Suit _Trump;

        public OhHellGame(FourPlayers players, IBiddings biddings, IDeck deck)
        {
            _Players = players;
            _Biddings = biddings;
            _Deck = deck;
            _Dealer = new Dealer();
        }

        public void NextRound()
        {
            _Dealer.Deal(_Deck).To(_Players);
            _Trump = _Dealer.PickTrumpFrom(_Deck);
            var round = new Round(_Players, _Biddings, new CardCalculator(_Trump));
            round.PerformBidding();
            round.DetermineHighestCard();
            round.SetScoresToPlayers();
        }

        public int ScoreOf(IPlayer player)
        {
            return player.Score;
        }
    }
}