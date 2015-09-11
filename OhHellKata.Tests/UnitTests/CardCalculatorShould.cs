using System.Collections.Generic;
using NUnit.Framework;
using OhHellKata.Cards;

namespace OhHellKata.Tests.UnitTests
{
    [TestFixture]
    public class CardCalculatorShould
    {

        [Test]
        public void ReturnTheHighestCardWhenOneOfThemIsTrumpSuit()
        {
            IList<ICard> cards = new List<ICard>
            {
                King.Of(Suit.Hearts),
                King.Of(Suit.Diamonds),
                Two.Of(Suit.Spades),
                Six.Of(Suit.Spades)
            };
            var calculator = new CardCalculator(Suit.Spades, cards);

            ICard highestCard = calculator.HighestCard();

            Assert.That(highestCard, Is.EqualTo(Six.Of(Suit.Spades)));
        }

        [Test]
        public void ReturnTheHighestCardOfTheFirstSuitWhenNoneOfThemIsNotTrumpSuit()
        {
            IList<ICard> cards = new List<ICard>
            {
                Queen.Of(Suit.Hearts),
                King.Of(Suit.Diamonds),
                Two.Of(Suit.Hearts),
                Six.Of(Suit.Spades)
            };
            var calculator = new CardCalculator(Suit.Clubs, cards);

            ICard highestCard = calculator.HighestCard();

            Assert.That(highestCard, Is.EqualTo(Queen.Of(Suit.Hearts)));
        }
    }
}