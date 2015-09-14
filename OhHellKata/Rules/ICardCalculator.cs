using System.Collections.Generic;
using OhHellKata.Cards;

namespace OhHellKata.Rules
{
    public interface ICardCalculator
    {
        ICard HighestCard(IList<ICard> cards);
    }
}