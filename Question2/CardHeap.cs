using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class CardHeap 
    {
        private List<Card> Cards;       
        private int playing_card_index;
        public readonly int HeapSize;
        public string[] Suits => Decks[0].Suits;
        public int SuitSize => Decks[0].SuitSize;
        private Random rnd = new Random();
        private Deck[] Decks;
        public bool IsEmpty => playing_card_index == HeapSize;

        public CardHeap (Deck[] decks_in) 
        {
            Decks = decks_in;
            HeapSize = 0;
            for (int i = 0; i < Decks.Length; i++)
                HeapSize += Decks[i].Cards.Count;
            Cards = new List<Card>(HeapSize);
            for (int i = 0; i < Decks.Length; i++)
                Cards.AddRange(Decks[i].Cards);
        }

        public void Shuffle (int times = 1)
        {
            List<Card> PlayedCards = Cards;
            Cards = new List<Card>(HeapSize);

            while  (PlayedCards.Count > 0)
            {
                int card_index = rnd.Next() % PlayedCards.Count;
                Cards.Add (PlayedCards[card_index]);
                PlayedCards.RemoveAt(card_index);
            }
            playing_card_index = 0;
        }

        public Card GetNextCard()
        {
            if (playing_card_index < HeapSize)
                return Cards[playing_card_index++];
            else
                return null;
        }

    }
}
