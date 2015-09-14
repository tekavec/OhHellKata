using System.Collections.Generic;
using OhHellKata.Cards;

namespace OhHellKata
{
    public interface IDeck
    {
        Stack<ICard> Cards { get; }
        ICard NextCard();
    }
}