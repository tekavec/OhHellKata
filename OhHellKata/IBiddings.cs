using OhHellKata.Players;

namespace OhHellKata
{
    public interface IBiddings
    {
        int BidOf(IPlayer player);
        void SetBid(IPlayer player, int bid);
    }
}