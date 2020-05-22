using System.Collections.Generic;

namespace examination_3
{
    /// <summary>
    /// Class representing a Hand of cards
    /// </summary>
    abstract class Hand
    {
        public List<Card> Cards { get; private set; }
        public int Aces { get; private set; }
        public int SumOfHand { get; private set; }

        /// <summary>
        /// Public constructor for new empty hand.
        /// </summary>
        public Hand()
        {
            Cards = new List<Card>();
        }

        /// <summary>
        /// Add all cards' values in the hand and sets property SumOfHand to its total value
        /// </summary>
        public void AddUpHand()
        {
            SumOfHand = 0;

            foreach (Card card in Cards)
            {
                if (card.Value == 14)
                {
                    Aces++;
                }
                SumOfHand += card.Value;
            }

            if (Aces > 0 && SumOfHand > 21)
            {
                SumOfHand -= Aces * 13;
                Aces = 0;
            }
        }
    }
}