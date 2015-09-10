namespace OhHellKata.Cards
{
    public class Six : ICard
    {
        private Suit _Suit;

        public static ICard Of(Suit suit)
        {
            var six = new Six {_Suit = suit};
            return six;
        }

        public int Rank
        {
            get { return 6; }
        }

        public Suit Suit
        {
            get { return _Suit; }
        }

        protected bool Equals(Six other)
        {
            return _Suit == other._Suit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Six) obj);
        }

        public override int GetHashCode()
        {
            return (int) _Suit;
        }
    }
}