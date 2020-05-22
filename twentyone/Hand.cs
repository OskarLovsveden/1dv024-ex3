using System.Collections.Generic;

namespace examination_3
{
    abstract class Hand
    {
        public List<Card> Cards { get; private set; }
        public int Aces { get; private set; }
        public int SumOfHand { get; private set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

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