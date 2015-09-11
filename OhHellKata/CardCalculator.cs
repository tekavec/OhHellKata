using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }
    }
}