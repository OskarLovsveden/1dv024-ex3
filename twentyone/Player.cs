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
            foreach (Card card in Cards)
            {
                str += $"{card.Rank}{card.Suit} ";
            }

            return Sum <= 21 ?
                $"{Name}: {str}({Sum})" :
                $"{Name}: {str}({Sum}) BUSTED!";
        }
    }
}