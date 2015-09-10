using System.Collections.Generic;
using OhHellKata.Cards;

namespace OhHellKata
{
    public class Deck : IDeck
    {
        private Stack<ICard> _Cards;

        public ICard NextCard()
        {
            return _Cards.Peek();
        }

    }
}