namespace examination_3
{
    class Card
    {
        public CardSuit Suit { get; private set; }
        public CardRank Rank { get; private set; }
        public int Value { get; private set; }

        public Card(CardSuit suit, CardRank rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }
    }
}