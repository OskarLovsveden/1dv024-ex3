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
                Console.WriteLine("_____");
                // While player has not reached limit...
                while (player.SumOfHand() < player.Limit)
                {
                    // If drawpile is at 1 card...
                    if (DrawPile.Cards.Count == 1)
                    {
                        // ...merge drawpile with throwpile and shuffle
                        DrawPile.Cards = DrawPile.Cards.Concat(ThrowPile).ToList();
                        ThrowPile = new List<Card>();
                        DrawPile.Shuffle();
                    }

                    // ...deal a card to the player
                    Card drawnCard = DrawPile.Draw();
                    player.Cards.Add(drawnCard);
                }

                // Player loses / busted
                if (player.SumOfHand() > 21)
                {
                    Console.WriteLine("Dealer Wins");
                    Console.WriteLine(player.ToString());
                }
                // Player Wins
                else if (player.SumOfHand() == 21 || player.Cards.Count == 5)
                {
                    Console.WriteLine("Player Wins");
                    Console.WriteLine(player.ToString());
                }
                // Dealer plays vs current player.
                else
                {
                    Dealer dealer = new Dealer(player.SumOfHand());
                    Console.WriteLine("Dealer vs Player");

                    // While dealer has not reached limit...
                    while (dealer.SumOfHand() < dealer.Limit)
                    {
                        // If drawpile is at 1 card...
                        if (DrawPile.Cards.Count == 1)
                        {
                            // ...merge drawpile with throwpile and shuffle
                            DrawPile.Cards = DrawPile.Cards.Concat(ThrowPile).ToList();
                            ThrowPile = new List<Card>();
                            DrawPile.Shuffle();
                        }

                        // ...deal a card to the dealer
                        Card drawnCard = DrawPile.Draw();
                        dealer.Cards.Add(drawnCard);
                    }

                    // IF dealer sum is higher than current player sum AND is lower than or equal to 21 OR dealer sum is equal to player sum
                    if ((dealer.SumOfHand() > player.SumOfHand() && dealer.SumOfHand() <= 21) || dealer.SumOfHand() == player.SumOfHand())
                    {
                        Console.WriteLine("Dealer Wins");
                        Console.WriteLine(player.ToString());
                        Console.WriteLine(dealer.ToString());
                    }
                    // ELSE player wins
                    else
                    {
                        Console.WriteLine("Player Wins");
                        Console.WriteLine(player.ToString());
                        Console.WriteLine(dealer.ToString());
                    }

                    // Throw dealer hand when done
                    ThrowPile = ThrowPile.Concat(dealer.Cards).ToList();
                }

                // Throw player hand when done
                ThrowPile = ThrowPile.Concat(player.Cards).ToList();
            }
        }
    }
}