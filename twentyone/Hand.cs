using System.Collections.Generic;

namespace examination_3
{
    abstract class Hand
    {
        public List<Card> Cards { get; set; }
        public int Aces { get; private set; }
        public int Sum { get; private set; }

        public void SumOfHand()
        {
            foreach (Card card in Cards)
            {
                if (card.Value == 14)
                {
                    Aces++;
                }
                Sum += card.Value;
            }

            if (Aces > 0 && Sum > 21)
            {
                Sum -= Aces * 13;
                Aces = 0;
            }
        }
    }
}