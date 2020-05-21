using System;
using System.Collections.Generic;
using System.Linq;

namespace examination_3
{
    class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();

            int[] value = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int index = 0;

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                index = 0;

                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    switch (rank)
                    {
                        case CardRank.Jack:
                            Cards.Add(new Card(suit, rank, 11));
                            break;
                        case CardRank.Queen:
                            Cards.Add(new Card(suit, rank, 12));
                            break;
                        case CardRank.King:
                            Cards.Add(new Card(suit, rank, 13));
                            break;
                        case CardRank.Ace:
                            Cards.Add(new Card(suit, rank, 14));
                            break;
                        default:
                            Cards.Add(new Card(suit, rank, value[index]));
                            break;
                    }
                    index++;
                }
            }
        }

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

        public List<Card> Draw(int count)
        {
            var drawnCards = Cards.Take(count).ToList();
            Cards.RemoveAll(x => drawnCards.Contains(x));

            return drawnCards;
        }
    }
}