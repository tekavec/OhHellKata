using OhHellKata.Players;

namespace OhHellKata.Bids
{
    public interface IBiddings
    {
        int BidOf(IPlayer player);
        void SetBid(IPlayer player, int bid);
    }
}