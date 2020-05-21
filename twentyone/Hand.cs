using System.Collections.Generic;

namespace examination_3
{
    abstract class Hand
    {
        public List<Card> Cards { get; set; }
        public int Aces { get; private set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public int SumOfHand()
        {
            int sum = 0;

            foreach (Card card in Cards)
            {
                if (card.Value == 14)
                {
                    Aces++;
                }
                sum += card.Value;
            }

            if (Aces > 0 && sum > 21)
            {
                sum -= Aces * 13;
                Aces = 0;
            }

            return sum;
        }
    }
}