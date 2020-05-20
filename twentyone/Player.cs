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
            string str = "";
            foreach (Card card in Cards)
            {
                str += card.NumberAndSuit + " ";
            }

            return Sum <= 21 ?
                $"{Name}: {str}({Sum})" :
                $"{Name}: {str}({Sum}) BUSTED!";
        }
    }
}