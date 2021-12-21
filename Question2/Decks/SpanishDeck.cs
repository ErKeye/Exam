using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2.Decks
{
    public class SpanishDeck : Deck
    {
        private static Dictionary<int, string> AliasHash = null;
        private SpanishDeck()
        {
            if (AliasHash == null)
                FillAliasHash();
            DeckName = "Spanish";
            SuitSize = 12;
            Suits = new string[] { "Oros", "Copas", "Bastos", "Espadas" };
            Build(AliasHash);
        }

        public static CardHeap GetGameCardHeap(int decks_amount)
        {
            if (decks_amount < 1)
                throw new Exception(GetDeckFail);
            Deck[] Decks = new Deck[decks_amount];
            for (int i = 0; i < decks_amount; i++)
                Decks[i] = new SpanishDeck();
            return new CardHeap(Decks);
        }

        private static void FillAliasHash()
        {
            AliasHash = new Dictionary<int, string>();
            AliasHash.Add(10, "Sota");
            AliasHash.Add(11, "Caballo");
            AliasHash.Add(12, "Rey");
        }
    }
}
