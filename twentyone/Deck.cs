using System;
using System.Collections.Generic;

namespace examination_3
{
    class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();

            int[] value = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            int index = 0;

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    switch (rank)
                    {
                        case CardRank.Jack:
                            Cards.Add(new Card()
                            {
                                Suit = suit,
                                Rank = rank,
                                Value = 11
                            });
                            break;
                        case CardRank.Queen:
                            Cards.Add(new Card()
                            {
                                Suit = suit,
                                Rank = rank,
                                Value = 12
                            });
                            break;
                        case CardRank.King:
                            Cards.Add(new Card()
                            {
                                Suit = suit,
                                Rank = rank,
                                Value = 13
                            });
                            break;
                        case CardRank.Ace:
                            Cards.Add(new Card()
                            {
                                Suit = suit,
                                Rank = rank,
                                Value = 14
                            });
                            break;
                        default:
                            Cards.Add(new Card()
                            {
                                Suit = suit,
                                Rank = rank,
                                Value = value[index]
                            });
                            break;
                    }
                    index++;
                }
            }
        }
        // public static Card[] GenerateDeck()
        // {
        //     // var cardValue = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        //     Card[] deck = new Card[52];

        //     int index = 0;

        //     foreach (var suit in suits)
        //     {
        //         for (int i = 0; i < values.Length; i++)
        //         {
        //             (new Card(values[i], (ranks[i] + " of " + suit)));
        //             index++;
        //         }
        //     }

        //     return deck;
        // }

        public void Shuffle()
        {
            Random r = new Random();

            List<Card> cards = Cards;

            for (int n = cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
        }
    }
}