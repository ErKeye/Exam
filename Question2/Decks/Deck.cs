using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public abstract class Deck
    {
        protected static string GetDeckFail = "Card heap needs at least 1 deck.";
        public string DeckName { get; protected set; }
        public int SuitSize { get; protected set; }
        public string[] Suits { get; protected set; }
        public List<Card> Cards;
        //public Card[] NoSuitCards;

        protected virtual void Build( Dictionary<int, string> alias_hash =null)
        {
            Cards = new List<Card>(Suits.Length * SuitSize);
            for (int i = 0; i < Suits.Length; i++)
                for (int j = 0; j < SuitSize; j++)
                {
                    string alias = null;
                    if (alias_hash != null)
                        alias_hash.TryGetValue(j+1, out alias);
                    Cards.Add (new Card(j + 1, i, alias));
                }
        }


    }
}
