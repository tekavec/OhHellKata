namespace OhHellKata.Cards
{
    public class Two : ICard
    {
        public Suit _Suit;

        public static Two Of(Suit suit)
        {
            return new Two {_Suit = suit};
        }

        public int Rank
        {
            get { return 2; } 
        }

        public Suit Suit
        {
            get { return _Suit; }
        }

        protected bool Equals(Two other)
        {
            return _Suit == other._Suit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Two) obj);
        }

        public override int GetHashCode()
        {
            return (int) _Suit;
        }
    }
}