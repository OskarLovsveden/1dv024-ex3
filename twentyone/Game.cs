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
            ThrowPile = new List<Card>();
        }

        public void GeneratePlayers()
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                string name = $"Player #{i + 1}";
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
        public void MergeDrawThrow()
        {
            DrawPile.Cards = DrawPile.Cards.Concat(ThrowPile).ToList();
            ThrowPile = new List<Card>();
            DrawPile.Shuffle();
        }

        public void PlayRound(Player playerOrDealer)
        {
            // If drawpile is at 1 card...
            if (DrawPile.Cards.Count == 1)
            {
                // ...merge drawpile with throwpile and shuffle
                MergeDrawThrow();
            }

            // ...deal a card to the player or dealer
            Card drawnCard = DrawPile.Draw();
            playerOrDealer.Cards.Add(drawnCard);
        }

        public void LogResult(bool playerWin, Player player, Player dealer)
        {
            if (playerWin)
            {
                System.Console.WriteLine("Player Wins!");
                System.Console.WriteLine(player.ToString());
                System.Console.WriteLine(dealer.ToString());
            }
            else
            {
                System.Console.WriteLine("Dealer Wins!");
                System.Console.WriteLine(player.ToString());
                System.Console.WriteLine(dealer.ToString());
            }
        }

        public void Play()
        {
            // Shuffle deck
            DrawPile.Shuffle();

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
                    PlayRound(player);
                }

                // Player loses / busted
                if (player.SumOfHand() > 21)
                {
                    Player dummyDealer = new Dealer();
                    LogResult(false, player, dummyDealer);
                    // Console.WriteLine("Dealer Wins");
                    // Console.WriteLine(player.ToString());
                    // Console.WriteLine(dummyDealer.ToString());
                }
                // Player Wins
                else if (player.SumOfHand() == 21 || player.Cards.Count == 5)
                {
                    Player dummyDealer = new Dealer();
                    LogResult(true, player, dummyDealer);
                    // Console.WriteLine("Player Wins");
                    // Console.WriteLine(player.ToString());
                    // Console.WriteLine(dummyDealer.ToString());
                }
                // Dealer plays vs current player.
                else
                {
                    Dealer dealer = new Dealer(player.SumOfHand());

                    // While dealer has not reached limit...
                    while (dealer.SumOfHand() < dealer.Limit)
                    {
                        PlayRound(dealer);
                    }

                    // IF dealer sum is higher than current player sum AND is lower than or equal to 21 OR dealer sum is equal to player sum
                    if ((dealer.SumOfHand() > player.SumOfHand() && dealer.SumOfHand() <= 21) || dealer.SumOfHand() == player.SumOfHand())
                    {
                        LogResult(false, player, dealer);
                        // Console.WriteLine("Dealer Wins");
                        // Console.WriteLine(player.ToString());
                        // Console.WriteLine(dealer.ToString());
                    }
                    // ELSE player wins
                    else
                    {
                        LogResult(true, player, dealer);
                        // Console.WriteLine("Player Wins");
                        // Console.WriteLine(player.ToString());
                        // Console.WriteLine(dealer.ToString());
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