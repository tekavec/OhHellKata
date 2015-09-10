using System;

namespace OhHellKata
{
    public class BidGenerator : IBidGenerator
    {
        private const int MaxValue = 9;

        public int Bid()
        {
            var random = new Random();
            return random.Next(0, MaxValue);
        }
 
    }
}