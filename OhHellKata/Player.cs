using System;
using System.Collections.Generic;
using OhHellKata.Cards;

namespace OhHellKata
{
    public class Player : IPlayer
    {
        private IList<ICard> _Cards = new List<ICard>();

        public void RevealsCardIn(Round round)
        {
            throw new NotImplementedException();
        }

        public void BidsTo(IBiddings biddings)
        {
            throw new NotImplementedException();
        }

        public int Score()
        {
            throw new NotImplementedException();
        }

        public IList<ICard> Hand()
        {
            return _Cards;
        }
    }
}