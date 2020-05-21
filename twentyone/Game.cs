using System;
using System.Collections.Generic;

namespace examination_3
{
    class Game
    {
        public Deck DrawPile { get; set; }
        public List<Card> ThrowPile { get; set; }
        public int NumberOfPlayers { get; set; }
        public List<Player> Players { get; set; }

        public Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            DrawPile = new Deck();
            DrawPile.Shuffle();
            ThrowPile = new List<Card>();

        }

        public void GeneratePlayers()
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

        public void DealOneCardEach()
        {
            foreach (Player player in Players)
            {
                Card drawnCard = DrawPile.Draw();
                player.Cards.Add(drawnCard);
            }
        }

        public void StartGame()
        {
            GeneratePlayers();
            DealOneCardEach();
            // Console.WriteLine($"{drawnCard.Rank} of {drawnCard.Suit} with value: {drawnCard.Value}");
            // ThrowPile.Add(drawnCard);
            // Console.WriteLine(DrawPile.Cards.ToArray().Length);
            // Console.WriteLine(ThrowPile.ToArray().Length);
        }
    }
}