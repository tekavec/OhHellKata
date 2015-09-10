namespace OhHellKata.Cards
{
    public class King : ICard
    {
        private Suit _Suit;

        public static King Of(Suit suit)
        {
            return new King
            {
                _Suit = suit
            };
        }

        public int Rank
        {
            get { return 13; }
        }

        public Suit Suit
        {
            get { return _Suit; }
        }

        protected bool Equals(King other)
        {
            return _Suit == other._Suit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((King) obj);
        }

        public override int GetHashCode()
        {
            return (int) _Suit;
        }
    }
}