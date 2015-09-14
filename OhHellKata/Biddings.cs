using System;
using System.Collections.Generic;
using OhHellKata.Players;

namespace OhHellKata
{
    public class Biddings : IBiddings
    {
        private readonly IDictionary<IPlayer, int> _Biddings = new Dictionary<IPlayer, int>();

        public int BidOf(IPlayer player)
        {
            return _Biddings[player];
        }

        public void SetBid(IPlayer player, int bid)
        {
            _Biddings.Add(player, bid);
        }
    }
}