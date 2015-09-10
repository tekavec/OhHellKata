using System.Collections.Generic;
using OhHellKata.Cards;

namespace OhHellKata
{
    public interface IPlayer
    {
        void RevealsCardIn(Round round);
        void BidsTo(IBiddings biddings);
        int Score();
        IList<ICard> Hand();
    }
}