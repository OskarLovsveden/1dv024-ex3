using System;
using System.Collections.Generic;
using System.Linq;

namespace examination_3
{
    /// <summary>
    /// Class representing a deck of cards
    /// </summary>
    class Deck
    {
        private List<Card> _cards = new List<Card>();
        public List<Card> Cards { get => _cards; set => _cards = value; }

        /// <summary>
        /// Public constructor for creating a new deck of cards
        /// </summary>
        public Deck()
        {
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
                            _cards.Add(new Card(suit, rank, 11));
                            break;
                        case CardRank.Queen:
                            _cards.Add(new Card(suit, rank, 12));
                            break;
                        case CardRank.King:
                            _cards.Add(new Card(suit, rank, 13));
                            break;
                        case CardRank.Ace:
                            _cards.Add(new Card(suit, rank, 14));
                            break;
                        default:
                            _cards.Add(new Card(suit, rank, value[index]));
                            break;
                    }
                    index++;
                }
            }
        }

        /// <summary>
        /// Shuffles the deck of cards
        /// </summary>
        public void Shuffle()
        {
            Random r = new Random();

            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }
        }

        /// <summary>
        /// Returns the top card of the deck
        /// </summary>
        /// <returns>The top card</returns>
        public Card Draw()
        {
            Card drawnCard = Cards.First();
            Cards.Remove(drawnCard);

            return drawnCard;
        }

        /// <summary>
        /// Returns mutiple top cards of the deck
        /// </summary>
        /// <param name="count">Amount of cards to draw</param>
        /// <returns>The top cards matching the amount of count</returns>
        public List<Card> Draw(int count)
        {
            List<Card> drawnCards = Cards.Take(count).ToList();
            Cards.RemoveAll(x => drawnCards.Contains(x));

            return drawnCards;
        }
    }
}