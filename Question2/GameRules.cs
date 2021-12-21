using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class GameRules
    {
        private int[] suits_precedence = null;
        private Card wild_card = null;
        public bool AllowTies { get; private set; }
        // public Func<Card, Card, int> CompareCards;

        public GameRules (int[] suits_precedence_in = null , Card wild_card_in = null, bool allow_ties_in = false)
        {
            suits_precedence = suits_precedence_in;
            wild_card = wild_card_in;
            AllowTies = allow_ties_in;
        }
        public int CompareCards (Card card1, Card card2)
        {
            int res;
            if (wild_card != null)
                if (card1.Value == wild_card.Value && card1.Suit == wild_card.Suit)
                    return 1;
                else if (card2.Value == wild_card.Value && card2.Suit == wild_card.Suit)
                    return -1;
            
            res = card1.Value.CompareTo(card2.Value);
            if (res == 0 && suits_precedence != null && suits_precedence.Length > 0)
                res = suits_precedence[card1.Suit].CompareTo(suits_precedence[card2.Suit]);
            return res;
        }

    }
}
