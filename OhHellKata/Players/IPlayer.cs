using System.Collections.Generic;
using OhHellKata.Cards;

namespace OhHellKata.Players
{
    public interface IPlayer
    {
        void RevealsCardIn(Round round);
        void BidsTo(IBiddings biddings);
        IList<ICard> Hand();
        int Score { get; set; }
    }
}