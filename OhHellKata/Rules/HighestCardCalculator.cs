using System.Collections.Generic;
using System.Linq;
using OhHellKata.Cards;

namespace OhHellKata.Rules
{
    public class HighestCardCalculator : ICardCalculator
    {
        private readonly Suit _Trump;

        public HighestCardCalculator(Suit trump)
        {
            _Trump = trump;
        }

        public ICard HighestCard(IList<ICard> cards)
        {
            //TODO use aggregates instead:
            //ICard highestTrumpCard =
            //    _Cards.Where(a => a.Suit == _Trump).Aggregate(card,
            //        (curMin, x) =>
            //            (x.Rank  > curMin.Rank ? x : curMin));
            var trumpCards = cards.Where(a => a.Suit == _Trump).ToList();
            if (trumpCards.Any())
            {
                ICard highestTrumpCard = trumpCards[0];
                foreach (var card in trumpCards)
                {
                    if (card.Rank > highestTrumpCard.Rank)
                    {
                        highestTrumpCard = card;
                    }
                }
                return highestTrumpCard;
            }
            var firstSuit = cards[0].Suit;
            return cards.Where(a => a.Suit == firstSuit).Aggregate(
                    (curMin, x) =>
                        (x.Rank > curMin.Rank ? x : curMin));
        }
    }
}