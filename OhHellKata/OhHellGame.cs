namespace OhHellKata
{
    public class OhHellGame
    {
        private readonly FourPlayers _Players;
        private readonly IBiddings _Biddings;
        private readonly IDeck _Deck;
        private readonly Dealer _Dealer = new Dealer();

        public OhHellGame(FourPlayers players, IBiddings biddings, IDeck deck)
        {
            _Players = players;
            _Biddings = biddings;
            _Deck = deck;
        }

        public void NextRound()
        {
            _Dealer.Deal(_Deck).To(_Players);

            var trump = _Dealer.PickTrumpFrom(_Deck);

            _Players.Player1.BidsTo(_Biddings);
            _Players.Player2.BidsTo(_Biddings);
            _Players.Player3.BidsTo(_Biddings);
            _Players.Player4.BidsTo(_Biddings);

        }
    }
}