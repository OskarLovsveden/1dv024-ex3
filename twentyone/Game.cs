using System.Collections.Generic;

namespace examination_3
{
    class Game
    {
        public Deck Deck { get; private set; }
        public int NumberOfPlayers { get; private set; }
        public List<Player> Players { get; private set; }

        public Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            Deck = new Deck();
        }

        public void generatePlayers()
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Player player = new Player("Player" + (i + 1), 15);
                players.Add(player);
            }
            Players = players;
        }

        public void StartGame()
        {
            Deck.GenerateDeck();
            Deck.ShuffleDeck();
        }
    }
}