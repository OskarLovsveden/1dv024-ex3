using System;
using System.Collections.Generic;
using System.Linq;

namespace examination_3
{
    /// <summary>
    /// Class representing a Game of twenty-one(21)
    /// </summary>
    class Game
    {
        public Deck DrawPile { get; private set; }
        public List<Card> ThrowPile { get; private set; }
        public int NumberOfPlayers { get; private set; }
        public List<Player> Players { get; private set; }

        /// <summary>
        /// Public constructor for new game of 21.
        /// Takes a parameter for numer of players.
        /// </summary>
        /// <param name="numberOfPlayers">Number of players to participate in this game of 21</param>
        public Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            DrawPile = new Deck();
            ThrowPile = new List<Card>();
        }

        /// <summary>
        /// Generates players with random limits and sets property Players to the generated players
        /// </summary>
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

        /// <summary>
        /// Loops all players and deals one card each from DrawPile
        /// </summary>
        public void DealOneCardEach()
        {
            foreach (Player player in Players)
            {
                Card drawnCard = DrawPile.Draw();
                player.Cards.Add(drawnCard);
            }
        }

        /// <summary>
        /// Merges ThrowPile into Drawpile and sets ThrowPile to and empty list
        /// </summary>
        public void MergeDrawThrow()
        {
            DrawPile.Cards = DrawPile.Cards.Concat(ThrowPile).ToList();
            ThrowPile = new List<Card>();
        }

        /// <summary>
        /// Plays one "round" for either a player or the dealer
        /// </summary>
        /// <param name="playerOrDealer">Player or dealer that should play the "round"</param>
        public void PlayRound(Player playerOrDealer)
        {
            if (DrawPile.Cards.Count == 1)
            {
                MergeDrawThrow();
                DrawPile.Shuffle();
            }

            Card drawnCard = DrawPile.Draw();
            playerOrDealer.Cards.Add(drawnCard);
            playerOrDealer.AddUpHand();
        }

        /// <summary>
        /// Merges("throws") the given player or dealers hand of cards into ThrowPile
        /// </summary>
        /// <param name="playerOrDealer">Player or dealer for which to throw hand of cards</param>
        public void ThrowHand(Player playerOrDealer)
        {
            ThrowPile = ThrowPile.Concat(playerOrDealer.Cards).ToList();
        }

        /// <summary>
        /// Prints the result of a full round
        /// </summary>
        /// <param name="playerWin">Boolean value representing player win</param>
        /// <param name="player">Player to print result for</param>
        /// <param name="dealer">Dealer to print result for</param>
        public static void PrintResult(bool playerWin, Player player, Player dealer)
        {
            string output = playerWin ? $"Player Wins!\n{player.ToString()}\n{dealer.ToString()}" : $"Dealer Wins!\n{player.ToString()}\n{dealer.ToString()}";
            Console.WriteLine(output);
            Console.WriteLine();
        }

        /// <summary>
        /// Play the game
        /// </summary>
        public void Play()
        {
            DrawPile.Shuffle();
            GeneratePlayers();
            DealOneCardEach();

            foreach (Player player in Players)
            {
                while (player.SumOfHand < player.Limit)
                {
                    PlayRound(player);
                }

                if (player.SumOfHand > 21)
                {
                    Player dummyDealer = new Dealer();
                    PrintResult(false, player, dummyDealer);
                }
                else if (player.SumOfHand == 21 || player.Cards.Count == 5)
                {
                    Player dummyDealer = new Dealer();
                    PrintResult(true, player, dummyDealer);
                }
                else
                {
                    Dealer dealer = new Dealer(player.SumOfHand);

                    while (dealer.SumOfHand < dealer.Limit)
                    {
                        PlayRound(dealer);
                    }

                    if ((dealer.SumOfHand > player.SumOfHand && dealer.SumOfHand <= 21) || dealer.SumOfHand == player.SumOfHand)
                    {
                        PrintResult(false, player, dealer);
                    }
                    else
                    {
                        PrintResult(true, player, dealer);
                    }

                    ThrowHand(dealer);
                }

                ThrowHand(player);
            }
        }
    }
}