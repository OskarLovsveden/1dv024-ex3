using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Play()
        {
            // Generate players
            GeneratePlayers();

            // Deal one card to each player
            DealOneCardEach();

            // Loop players
            foreach (Player player in Players)
            {
                // While player has not reached limit...
                while (player.SumOfHand() < player.Limit)
                {
                    // If drawpile is at 1 card...
                    if (DrawPile.Cards.Count == 1)
                    {
                        // ...merge drawpile and throwpile
                        DrawPile.Cards = DrawPile.Cards.Concat(ThrowPile).ToList();
                        ThrowPile = new List<Card>();
                    }

                    // ...deal a card to the player
                    Card drawnCard = DrawPile.Draw();
                    player.Cards.Add(drawnCard);
                }

                // Player loses / busted
                if (player.SumOfHand() > 21)
                {
                    Console.WriteLine("Busted! Dealer Wins");
                }
                // Player Wins
                else if (player.SumOfHand() == 21 || player.Cards.Count == 5)
                {
                    Console.WriteLine("Player Wins");
                }
                // Dealer plays vs current player.
                else
                {
                    Dealer dealer = new Dealer(player.SumOfHand());
                    Console.WriteLine("Dealer vs Player");
                }

                // Throw player hand when done
                ThrowPile = ThrowPile.Concat(player.Cards).ToList();
            }
        }
    }
}