using System;

namespace OhHellKata
{
    public class OhHellGame
    {
        private readonly FourPlayers _Players;
        private readonly BidPaper _BidPaper;
        private readonly Deck _Deck;
        private Dealer _Dealer = new Dealer();

        public OhHellGame(FourPlayers players, BidPaper bidPaper, Deck deck)
        {
            _Players = players;
            _BidPaper = bidPaper;
            _Deck = deck;
        }

        public Round NextRoundWith(Suit trumpCard, Mock<BidPaper> bidCollector)
        {
            throw new NotImplementedException();
        }

        public void NextRound()
        {
            _Dealer.Deal(_Deck).To(_Players);

            var trump = _Dealer.PickTrumpFrom(_Deck);

            _Players.Player1().BidsTo(_BidPaper);
            _Players.Player2().BidsTo(_BidPaper);
            _Players.Player3().BidsTo(_BidPaper);
            _Players.Player4().BidsTo(_BidPaper);

        }
    }
}