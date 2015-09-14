using System.Collections.Generic;
using OhHellKata.Cards;

namespace OhHellKata
{
    public class Deck : IDeck
    {
        private Stack<ICard> _Cards = new Stack<ICard>();

        public Stack<ICard> Cards
        {
            get { return _Cards; }
        }

        public ICard NextCard()
        {
            return _Cards.Pop();
        }

    }
}