using System;

namespace examination_3
{
    class Player : Hand
    {
        public string Name { get; private set; }
        public int Limit { get; private set; }

        public Player(string name, int limit)
        : base()
        {
            Name = name;
            Limit = limit;
        }

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