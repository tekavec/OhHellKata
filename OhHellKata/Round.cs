using System.Collections.Generic;
using System.Linq;
using OhHellKata.Bids;
using OhHellKata.Cards;
using OhHellKata.Players;
using OhHellKata.Rules;

namespace OhHellKata
{
    public class Round
    {
        private readonly IList<IPlayer> _Players;
        private readonly IBiddings _Biddings;
        private ICard _HighestCard;
        private readonly ICardCalculator _CardCalculator;

        public Round(
            IFourPlayers players, 
            IBiddings biddings, 
            ICardCalculator cardCalculator)
        {
            _Players = new List<IPlayer>{players.Player1, players.Player2, players.Player3, players.Player4};
            _CardCalculator = cardCalculator;
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
            _HighestCard = _CardCalculator.HighestCard(cards);
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