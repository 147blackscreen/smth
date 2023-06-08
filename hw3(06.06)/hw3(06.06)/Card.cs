using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3_06._06_
{
    class Card
    {
        public int Rank { get; set; }
        public Suits Suit { get; set; }

        public Card() { }
        public Card(int r, Suits s) {
            Rank = r;
            Suit = s;
        }
        public Card(Card other)
        {
            Rank = other.Rank;
            Suit = other.Suit;
        }
        
        public void SwapCard(Card other)
        {
            if(other != this)
            {
                Card tmp = new Card(other);
                other.Rank = this.Rank;
                other.Suit = this.Suit;
                this.Rank = tmp.Rank;
                this.Suit = tmp.Suit;
            }
        }
    }
}
