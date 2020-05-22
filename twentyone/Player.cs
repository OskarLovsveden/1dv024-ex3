using System;

namespace examination_3
{
    /// <summary>
    /// Class representing a Player that inherits from Hand
    /// </summary>
    class Player : Hand
    {
        public string Name { get; private set; }
        public int Limit { get; private set; }

        /// <summary>
        /// Public constructor for new player.
        /// Takes parameters name and limit
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="limit">Limit represents the sum of the hand the player is willing to go to</param>
        public Player(string name, int limit)
        : base()
        {
            Name = name;
            Limit = limit;
        }

        /// <summary>
        /// Returns a string representing the current state for the player in the game 
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            string cardsInHand = "";

            foreach (Card card in Cards)
            {
                cardsInHand += $"[{card.Rank} of {card.Suit}] ";
            }

            return SumOfHand <= 21 ?
                String.Format("{0,-12}: Sum: ({1}) {2}", Name, SumOfHand, cardsInHand) :
                String.Format("{0,-12}: Sum: ({1}) {2} BUSTED!", Name, SumOfHand, cardsInHand);
        }
    }
}