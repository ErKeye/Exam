using System;
using System.Text;

namespace Question2
{
    class Program
    {
        static string[] Suits;
        static int SuitSize;
        static void Main(string[] args)
        {

            CardHeap card_heap = GetCardHeap();
            Suits = card_heap.Suits;
            SuitSize = card_heap.SuitSize;
            HighCard game = new HighCard(card_heap, GetGameRules());
            ShowResult (game.Play());
            ShowResult(game.Play2());

        }

        private static CardHeap GetCardHeap()
        {
            int deck_type =0, decks_amount=0;
            do
            {
                Console.WriteLine("Please choose deck:");
                Console.WriteLine("      1. Poker deck ");
                Console.WriteLine("      2. 20CardsPerSuit deck ");
                Console.WriteLine("      3. Spanish deck ");
                if (!int.TryParse(Console.ReadLine(), out deck_type) || deck_type < 1 || deck_type > 3)
                    Console.WriteLine("Invalid option...");
            } while (deck_type == 0);
            do
            {
                Console.WriteLine("Please choose how many decks...");
                if (!int.TryParse(Console.ReadLine(), out decks_amount) || decks_amount < 1)
                    Console.WriteLine("Please choose more than 0 decks...");
            } while (decks_amount == 0);

            switch (deck_type)
            {
                case 1:
                    return Decks.PokerDeck.GetGameCardHeap(decks_amount);
                case 2:
                    return Decks.TwentySizeSuitDeck.GetGameCardHeap(decks_amount);
                case 3:
                    return Decks.SpanishDeck.GetGameCardHeap(decks_amount);
                default:
                    return null;
            }
        }

        private static GameRules GetGameRules()
        {            

            return new GameRules(GetSuitsPrecendence(), GetWildCard(), GetBoolOption("Allow Ties?"));
        }

        private static bool GetBoolOption (string Question)
        {
            string allow_ties=null, input;

            do
            {
                Console.WriteLine(Question + " (Y/N) ");
                input = Console.ReadLine().ToUpper();
                if (input == "Y" || input == "N")
                    allow_ties = input;
                else
                    Console.WriteLine("Invalid option...");
            } while (allow_ties== null);
            return allow_ties == "Y";
        }

        private static int[] GetSuitsPrecendence()
        {
            int[] suits_precedence;
            
            if (GetBoolOption("Allow suits precedence?"))
            {
                suits_precedence = new int[Suits.Length];
                for (int i = 0; i < Suits.Length; i++)
                {
                    int precendence=0;
                    bool valid_precedence;

                    do
                    {                        
                        Console.WriteLine("Precedence for {0} ? (1 to {1})",  Suits[i], Suits.Length);
                        valid_precedence = int.TryParse(Console.ReadLine(), out precendence) && precendence > 0 && precendence <= Suits.Length && !UsedPrecedence(suits_precedence, precendence, i - 1);
                        if (!valid_precedence)                         
                            Console.WriteLine("Invalid Value...");       
                        else
                            suits_precedence[i] = precendence;
                    } while (!valid_precedence);
                }
            }
            else
                suits_precedence = null;
            return suits_precedence;
        }

        private static bool UsedPrecedence(int[] precedences, int value_to_find, int max_index)
        {
            for (int i = 0; i <= max_index; i++)
                if (precedences[i] == value_to_find) return true;
            return false;
        }

        private static Card  GetWildCard()
        {
            if (GetBoolOption("Allow wild card?"))
                return new Card(GetWildCardValue(), GetWildCardSuit());
            else          
                return null ;
        }

        private static int GetWildCardSuit()
        {
            int suit_num = 0;
            do
            {
                Console.WriteLine("Choose suit for wild card.");
                for (int i = 0; i < Suits.Length; i++)                
                    Console.WriteLine("     {0}. {1} ", i + 1, Suits[i]);                
                if (!int.TryParse(Console.ReadLine(), out suit_num) || suit_num < 1 || suit_num > Suits.Length)
                    Console.WriteLine("Invalid Value...");
            } while (suit_num == 0);
            return suit_num - 1;
        }

        private static int GetWildCardValue()
        {
            int card_value;
            do
            {
                Console.WriteLine("Choose number of wild card (1 to {0}.)", SuitSize);
                if (!int.TryParse(Console.ReadLine(), out card_value) || card_value < 1 || card_value > SuitSize)
                    Console.WriteLine("Invalid Value...");

            } while (card_value == 0);
            return card_value - 1;
        }



        private static void ShowResult(Result result)
        {
            Console.WriteLine("Playing Game...");
            for (int i = 0; i < result.PlayerOneCards.Count; i++ )
            {
                Console.WriteLine("Hand {0}: ", i+1);
                Console.WriteLine("   Player 1 plays {0}", GetCardString(result.PlayerOneCards[i]));
                Console.WriteLine("   Player 2 plays {0}", GetCardString(result.PlayerTwoCards[i]));               
            }

            Console.WriteLine("Player {0} wins!!!", result.Winner);            
        }

        private static string GetCardString(Card card)
        {
            string card_string;
            if (card == null)
                card_string = "NO CARD";
            else
            {
                if (!string.IsNullOrEmpty(card.Alias))
                    card_string = card.Alias;
                else
                    card_string = (card.Value).ToString();
                card_string += " of " + Suits[card.Suit];
            }
            return card_string;
        }
    }
}
