namespace examination_3
{
    class Game
    {
        public Deck Deck { get; private set; }
        public int NumberOfPlayers { get; private set; }

        public Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            Deck = new Deck();
        }

        public void StartGame()
        {
            Deck.GenerateDeck();
            Deck.ShuffleDeck();
        }
    }
}