using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class Result 
    {
        public readonly List<Card> PlayerOneCards;
        public readonly List<Card> PlayerTwoCards;
        public readonly int Winner;
        public Result(List<Card> player_one_cards, List<Card> player_two_cards, int winner)
        {
            PlayerOneCards = player_one_cards;
            PlayerTwoCards = player_two_cards;
            Winner = winner;
        }
    }
    public class HighCard
    {
        private CardHeap card_heap;
        private GameRules rules;
        private List<Card> PlayerOneCards, PlayerTwoCards;
        public string Name { get; private set; } = "High Card";
        public HighCard (CardHeap card_heap_in, GameRules rules_in)
        {
            card_heap = card_heap_in;
            rules = rules_in;
        }

        public Result Play(bool shuffle= true)
        {            
            int max_player_cards = card_heap.HeapSize / 2 + card_heap.HeapSize % 2;
            PlayerOneCards = new List<Card>(max_player_cards);
            PlayerTwoCards = new List<Card>(max_player_cards);
            int winner;

            if (shuffle)
                card_heap.Shuffle();
            
            if (rules.AllowTies)
                winner = PlayHand();
            else
                do
                    winner = PlayHand();
                while (!card_heap.IsEmpty && winner == 0);
            return new Result (PlayerOneCards, PlayerTwoCards, winner);
        }


        private int PlayHand()
        {
            int winner, high_card;
            if (!card_heap.IsEmpty)
            {
                Card Player1Card = card_heap.GetNextCard();
                PlayerOneCards.Add(Player1Card);
                if (!card_heap.IsEmpty)
                {
                    Card Player2Card = card_heap.GetNextCard();
                    PlayerTwoCards.Add(Player2Card);                    
                    high_card = rules.CompareCards(Player1Card, Player2Card);
                    winner = high_card == -1 ? 2 : high_card;
                }
                else
                    winner = 1;
            }
            else
                winner = 0;
            return winner;
        }
    }
}
