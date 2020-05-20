namespace examination_3
{
    class Card
    {
        public int Value { get; private set; }
        public string NumberAndSuit { get; private set; }

        public Card(int value, string numberAndSuit)
        {
            Value = value;
            NumberAndSuit = numberAndSuit;
        }
    }
}