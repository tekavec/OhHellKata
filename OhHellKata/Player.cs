using System;
using System.Collections.Generic;
using OhHellKata.Cards;

namespace OhHellKata
{
    public class Player : IPlayer
    {
        private readonly IList<ICard> _Cards = new List<ICard>();
        private readonly IBidGenerator _BidGenerator;

        public Player() : this (new BidGenerator())
        {
        }

        public Player(IBidGenerator bidGenerator)
        {
            _BidGenerator = bidGenerator;
        }

        public void RevealsCardIn(Round round)
        {
            throw new NotImplementedException();
        }

        public void BidsTo(IBiddings biddings)
        {
            biddings.SetBid(this, NextBid());
        }

        public int Score()
        {
            throw new NotImplementedException();
        }

        public IList<ICard> Hand()
        {
            return _Cards;
        }

        private int NextBid()
        {
            return _BidGenerator.Bid();
        }
    }
}