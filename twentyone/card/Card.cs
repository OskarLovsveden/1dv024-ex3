namespace examination_3
{
    /// <summary>
    /// Class representing a standard playing card
    /// </summary>
    class Card
    {
        public CardSuit Suit { get; private set; }
        public CardRank Rank { get; private set; }
        public int Value { get; private set; }

        /// <summary>
        /// Public constructor for creating a new card.
        /// Takes parameters suit, rank and value
        /// </summary>
        /// <param name="suit">Suit of the card</param>
        /// <param name="rank">Rank of the card</param>
        /// <param name="value">Value of the card</param>
        public Card(CardSuit suit, CardRank rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }
    }
}