using System;

namespace examination_3
{
    class Player : Hand
    {
        public string Name { get; set; }
        public int Limit { get; set; }

        public Player(string name, int limit)
        : base()
        {
            Name = name;
            Limit = limit;
        }

        public override string ToString()
        {
            string str = "";
            int sum = SumOfHand();

            foreach (Card card in Cards)
            {
                str += $"[{card.Rank} of {card.Suit}] ";
            }

            return sum <= 21 ?
                String.Format("{0,-12}: Sum: ({1}) {2}", Name, sum, str) :
                String.Format("{0,-12}: Sum: ({1}) {2} BUSTED!", Name, sum, str);
        }
    }
}