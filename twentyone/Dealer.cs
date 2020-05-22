namespace examination_3
{
    /// <summary>
    /// Class representing a Dealer for the game twenty-one(21) that inherits from Player
    /// </summary>
    class Dealer : Player
    {
        /// <summary>
        /// Public constructor for creating a new dealer.
        /// Takes the optional parameters limit and name
        /// </summary>
        /// <param name="limit">Limit represents the sum of the hand the dealer is willing to go to</param>
        /// <param name="name">Name of the dealer</param>
        public Dealer(int limit = 0, string name = "Dealer")
        : base(name, limit)
        { }
    }
}