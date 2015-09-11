using System.Collections.Generic;
using System.Linq;
using OhHellKata.Cards;

namespace OhHellKata
{
    public class Round
    {
        private readonly IList<IPlayer> _Players;
        private readonly Suit _Trump;
        private readonly IBiddings _Biddings;
        private ICard _HighestCard;

        public Round(IFourPlayers players, Suit trump, IBiddings biddings)
        {
            _Players = new List<IPlayer>{players.Player1, players.Player2, players.Player3, players.Player4};
            _Trump = trump;
            _Biddings = biddings;
        }

        public void PerformBidding()
        {
            foreach (var player in _Players)
            {
                player.BidsTo(_Biddings);
            }
        }

        public void DetermineHighestCard()
        {
            var cards = _Players.Select(a => a.Hand().Last()).ToList();
            var cardCalculator = new CardCalculator(_Trump, cards);
            _HighestCard = cardCalculator.HighestCard();
        }

        public void SetScoresToPlayers()
        {
            var playerWithHighestCard = _Players.FirstOrDefault(a => a.Hand().Last().Equals(_HighestCard));
            //set score to each player
            if (playerWithHighestCard != null)
            {
                playerWithHighestCard.Score = 1;
            }
            foreach (var player in _Players)
            {
                if (player.Equals(playerWithHighestCard))
                {
                    if (_Biddings.BidOf(player) == 1)
                    {
                        player.Score += 5;
                    }
                    else
                    {
                        player.Score -= 5;
                    }
                }
                else
                {
                    if (_Biddings.BidOf(player) == 0)
                    {
                        player.Score += 5;
                    }
                    else
                    {
                        player.Score -= 5;
                    }
                }
            }
        }
    }
}