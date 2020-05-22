using System;
using System.Collections.Generic;
using System.Linq;

namespace examination_3
{
    class Game
    {
        public Deck DrawPile { get; private set; }
        public List<Card> ThrowPile { get; private set; }
        public int NumberOfPlayers { get; private set; }
        public List<Player> Players { get; private set; }

        public Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            DrawPile = new Deck();
            ThrowPile = new List<Card>();
        }

        public void GeneratePlayers()
        {
            if (NumberOfPlayers < 0 || NumberOfPlayers > 40) throw new ArgumentOutOfRangeException();

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
            playerOrDealer.AddUpHand();
        }

        public void ThrowHand(Player playerOrDealer)
        {
            ThrowPile = ThrowPile.Concat(playerOrDealer.Cards).ToList();
        }

        public static void LogResult(bool playerWin, Player player, Player dealer)
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
                while (player.SumOfHand < player.Limit)
                {
                    PlayRound(player);
                }

                // Player loses / busted
                if (player.SumOfHand > 21)
                {
                    Player dummyDealer = new Dealer();
                    LogResult(false, player, dummyDealer);
                }
                // Player Wins
                else if (player.SumOfHand == 21 || player.Cards.Count == 5)
                {
                    Player dummyDealer = new Dealer();
                    LogResult(true, player, dummyDealer);
                }
                // Dealer plays vs current player.
                else
                {
                    Dealer dealer = new Dealer(player.SumOfHand);

                    // While dealer has not reached limit...
                    while (dealer.SumOfHand < dealer.Limit)
                    {
                        PlayRound(dealer);
                    }

                    // IF dealer sum is higher than current player sum AND is lower than or equal to 21 OR dealer sum is equal to player sum
                    if ((dealer.SumOfHand > player.SumOfHand && dealer.SumOfHand <= 21) || dealer.SumOfHand == player.SumOfHand)
                    {
                        LogResult(false, player, dealer);
                    }
                    // ELSE player wins
                    else
                    {
                        LogResult(true, player, dealer);
                    }

                    // Throw dealer hand when done
                    ThrowHand(dealer);
                }

                // Throw player hand when done
                ThrowHand(player);
            }
        }
    }
}