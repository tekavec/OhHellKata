using OhHellKata.Cards;

namespace OhHellKata
{
    public interface IDeck
    {
        ICard NextCard();
    }
}