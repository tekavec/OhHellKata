using System.Collections.Generic;
using OhHellKata.Bids;
using OhHellKata.Cards;

namespace OhHellKata.Players
{
    public interface IPlayer
    {
        void BidsTo(IBiddings biddings);
        IList<ICard> Hand();
        int Score { get; set; }
    }
}