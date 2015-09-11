using System;
using System.Collections.Generic;
using System.Linq;
using OhHellKata.Cards;

namespace OhHellKata
{
    public class CardCalculator
    {
        private IList<ICard> _Cards;
        private Suit _Trump;

        public CardCalculator(Suit trump, IList<ICard> cards)
        {
            _Trump = trump;
            _Cards = cards;
        }

        public ICard HighestCard()
        {
            ICard card = null;
            ICard highestTrumpCard =
                _Cards.Where(a => a.Suit == _Trump).Aggregate(card,
                    (curMin, x) =>
                        (x.Rank  > curMin.Rank ? x : curMin));
            if (highestTrumpCard != null)
            {
                return highestTrumpCard;
            }
            var firstSuit = _Cards[0].Suit;
            return _Cards.Where(a => a.Suit == firstSuit).Aggregate(
                    (curMin, x) =>
                        (x.Rank > curMin.Rank ? x : curMin));
        }
    }
}