using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2.Decks
{
    public class PokerDeck: Deck
    {
        private static Dictionary<int, string> AliasHash = null;
        private PokerDeck()
        {
            if (AliasHash == null)
                FillAliasHash();
            DeckName = "Poker";
            SuitSize = 13;
            Suits = new string[] { "Clubs", "Hearts", "Spades", "Diamonds" };
            Build(AliasHash);
        }

        public static CardHeap GetGameCardHeap(int decks_amount)
        {
            if (decks_amount < 1)
                throw new Exception(GetDeckFail);
            Deck[] Decks = new Deck[decks_amount];
            for (int i = 0; i < decks_amount; i++)
                Decks[i] = new PokerDeck();
            return new CardHeap(Decks);
        }

        private static void FillAliasHash()
        {
            AliasHash = new Dictionary<int, string>();
            AliasHash.Add(11, "J");
            AliasHash.Add(12, "Q");
            AliasHash.Add(13, "K");
        }
    }
}
