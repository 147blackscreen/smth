using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace hw3_06._06_
{
    class Deck
    {
        private Card[] deck;
        private int MinRank = 6;
        private int MaxRank = 14;
        private int CountCards;
        private Random rng = new Random();
        private int index;

        public Deck() {
            deck = new Card[36];
            CountCards = (MaxRank - MinRank + 1) * 4;
            index = 0;
            setCards();
        }

        public Card GetNextCard()
        {
            return deck[index++];
        }
        // 1
        private void setCards()
        {

            for (int i = MinRank, c = 0; i <= MaxRank; i++)
            {
                for(int j = 1; j <= 4; j++, c++)
                {
                    deck[c] = new Card(i,(Suits)j);
                }
            }
        }

        public string ToSymbol(Suits suit)
        {
            switch ((int)suit)
            {
                case 1: 
                    return "♣";
                case 2: 
                    return "♠";
                case 3:
                    return "♥";
                case 4:
                    return "♦";
            }
            return "";
        }
        public string ToRankSymbol(int rank)
        {
            switch (rank)
            {
                case 10:
                    return "10";
                case 11:
                    return " J";
                case 12:
                    return " Q";
                case 13:
                    return " K";
                case 14:
                    return " A";
            }
            return " "+rank.ToString();
        }
        public void OutDeck()
        {
            for (int i = 0, c = 0; i < 4; i++)
            {
                Console.WriteLine();
                for (int j = MinRank; j <= MaxRank; j++, c++)
                {
                    Console.Write($" |{ToRankSymbol(deck[c].Rank)} {ToSymbol(deck[c].Suit)}| ");
                }
            }
        }
        // 2
        public void Shuffle()
        {
            this.index = 0;
            Card tmp = new Card();
            int index = 0;
            Console.WriteLine("Shuffle...");
            for (int i = 0; i < deck.Length; i++)
            {
                index = rng.Next(0, CountCards);
                deck[i].SwapCard(deck[index]);
            }
        }
        // 3
        public void Aces()
        {
            Console.WriteLine("Searching Aces...");
            int count = 0;
            for (int i = 0; i < CountCards; i++)
            {
                if (deck[i].Rank == 14)
                {
                    count++;
                    Console.WriteLine($"{count} ACE index = {i}");
                }
                if(count==4)
                {
                    break;
                }
            }
        }

        // 4
        public void SetSuitAtStart(Suits suit)
        {
            int count = MaxRank - MinRank + 1;
            int set = 0;
            Console.WriteLine($"Set all {suit} at start of deck...");
            for (int i = 0; i < CountCards; i++)
            {
                if (deck[i].Suit == suit)
                {
                    deck[i].SwapCard(deck[set]);
                    set++;
                }
                if(set == count - 1)
                {
                    break;
                }
            }
        }
        // 5
        public void SortDeck()
        {
            Console.WriteLine("Sorting DECK...");
            int lastpoint = 0;
            int SuitDifference = 0;
            int count = MaxRank - MinRank + 1;
            for (int i = 1; i <= 4; i++)
            {
                SuitDifference = (i - 1) * count;
                lastpoint = 0 + SuitDifference;
                for (int j = 0; j < count; j++)
                {
                    for (int c = lastpoint; c < CountCards; c++)
                    {
                        if (deck[c].Suit == (Suits)i)
                        {
                            //lastpoint = c;
                            if (deck[c].Rank == MinRank+j)
                            {
                                deck[c].SwapCard(deck[SuitDifference + j]);
                                //lastpoint++;
                                break;
                            }
                        }
                    }
                }
            }

        }
    }
}
