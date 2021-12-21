using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class Card
    {
        public readonly int Value;
        public readonly int Suit;
        public readonly string Alias;
        public Card(int value_in, int suit_in, string alias_in = null)
        {
            Value = value_in;
            Suit = suit_in;
            Alias = alias_in;
        }
    }
}
