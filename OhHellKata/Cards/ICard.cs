namespace OhHellKata.Cards
{
    public interface ICard
    {
        int Rank { get; }
        Suit Suit { get; }
    }
}