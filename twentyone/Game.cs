using System;
using System.Collections.Generic;

namespace examination_3
{
    class Game
    {
        public List<Card> Deck21 { get; private set; }
        public int NumberOfPlayers { get; private set; }
        public List<Player> Players { get; private set; }

        public Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
        }

        public void generatePlayers()
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                string name = $"Player{i + 1}";
                int limit = new Random().Next(15, 20);

                Player player = new Player(name, limit);
                players.Add(player);
            }
            Players = players;
        }

        public void StartGame()
        {
            List<Card> deck = Deck.GenerateDeck();
            Deck.ShuffleDeck(deck);
            Deck21 = deck;
        }
    }
}