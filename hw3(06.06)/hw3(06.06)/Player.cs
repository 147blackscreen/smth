using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hw3_06._06_
{
    class Player
    {
        private List<Card> cards;
        public List<Card> Cards { get { return cards; } }

        private int wins;
        public int Wins { get { return wins; } }

        private int loses;
        public int Loses { get { return loses; } }

        public string Name;
        private bool Bot;
        public Player()
        {
            Bot = true;
            wins = 0;
            loses = 0;
            cards = new List<Card>();
            Name = "BOT";

        }
        public Player(string name)
        {
            wins = 0;
            loses = 0;
            Bot = false;
            cards = new List<Card>();
            Name = name;
        }

        public bool BringAdditionalCard()
        {
            if (Bot)
            {
                if (GetPoints() < 14)
                {
                    Console.WriteLine($"{this.Name} bring additional card...");
                    Thread.Sleep(500);
                    return true;
                }
                else
                    return false;
            }
            else
            {
                Console.WriteLine("Do you wanna bring one more card?...");
                bool ch = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                if (ch)
                {
                    Console.WriteLine($"{this.Name} bring additional card...");
                    Thread.Sleep(500);
                }
                return ch;
            }
        }
        public int GetPoints()
        {
            int points = 0;
            foreach(Card card in Cards)
            {
                if (card.Rank <= 10)
                    points += card.Rank;
                else
                {
                    switch(card.Rank)
                    {
                        case 14:
                            points += 11;
                            break;
                        case 13:
                            points += 4;
                            break;
                        case 12:
                            points += 3;
                            break;
                        case 11:
                            points += 2;
                            break;
                    }
                }
            }
            return points;
        }
        public void RoundWin()
        {
            wins++;
        }
        public void RoundLose()
        {
            loses++;
        }
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public void NewCards(params Card[] newCards)
        {
            cards.Clear();
            foreach (var card in newCards)
            {
                cards.Add(card);
            }
        }
    }
}
