using System;
using System.Collections.Generic;

namespace examination_3
{
    class Deck
    {
        public static List<Card> GenerateDeck()
        {
            string[] suits = { "Hearts", "Spades", "Clubs", "Diamonds" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            List<Card> deck = new List<Card>();

            foreach (var suit in suits)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    deck.Add(new Card(values[i], (ranks[i] + " of " + suit)));
                }
            }

            return deck;
        }

        public static void ShuffleDeck(List<Card> deck)
        {
            int n = deck.ToArray().Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + new Random().Next(n - i);
                Card t = deck[r];
                deck[r] = deck[i];
                deck[i] = t;
            }
        }
    }
}