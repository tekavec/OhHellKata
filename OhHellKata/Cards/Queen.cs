namespace OhHellKata.Cards
{
    public class Queen : ICard
    {
        private Suit _Suit;

        public static Queen Of(Suit suit)
        {
            return new Queen {_Suit = suit};
        }

        public int Rank
        {
            get { return 12; }
        }

        public Suit Suit
        {
            get { return _Suit; }
        }

        protected bool Equals(Queen other)
        {
            return _Suit == other._Suit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Queen) obj);
        }

        public override int GetHashCode()
        {
            return (int) _Suit;
        }
    }
}