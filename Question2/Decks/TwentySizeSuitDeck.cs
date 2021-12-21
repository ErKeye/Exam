using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2.Decks
{
    public class TwentySizeSuitDeck: Deck
    {
        private TwentySizeSuitDeck() 
        {
            DeckName = "20SuitSize";
            SuitSize = 20;
            Suits = new string[] { "Clubs", "Hearts", "Spades", "Diamonds" };           
            Build();
        }

        public static CardHeap GetGameCardHeap(int decks_amount)
        {
            if (decks_amount < 1)
                throw new Exception(GetDeckFail);
            Deck[] Decks = new Deck[decks_amount];
            for (int i = 0; i < decks_amount; i++)
                Decks[i] = new TwentySizeSuitDeck();
            return new CardHeap(Decks);
        }
    }
}
