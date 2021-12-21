using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question2;
using Question2.Decks;
using System;
namespace TestQuestion2
{
    [TestClass]
    public class TestHighCard
    {

        [TestMethod]
        public void TestPlayer1Wins()
        {
            int[] precedence = { 1, 2, 3, 4 };
            GameRules rules = new GameRules(precedence, null, true);
            CardHeap heap = PokerDeck.GetGameCardHeap(1);
            HighCard highcard = new HighCard(heap, rules);

            for (int i = 0; i < (heap.SuitSize - 1); i++)
                heap.GetNextCard();
            Assert.IsTrue(highcard.Play(false).Winner == 1);
        }


        [TestMethod]
        public void TestPlayer2Wins()
        {
            int[] precedence = { 1, 2, 3, 4 };
            GameRules rules = new GameRules(precedence, null, true);
            CardHeap heap = PokerDeck.GetGameCardHeap(1);
            HighCard highcard = new HighCard(heap, rules);
            Result result = highcard.Play(false);

            for (int i = 0; i < heap.SuitSize /2 - 1; i++) 
                Assert.IsTrue (highcard.Play(false).Winner == 2);
        }


        [TestMethod]
        public void TestWildCardWins()
        {
            int[] precedence = { 1, 2, 3, 4 };
            Card wild_card = new Card(1, 0);
            GameRules rules = new GameRules(precedence, wild_card, true);
            CardHeap heap = PokerDeck.GetGameCardHeap(1);
            HighCard highcard = new HighCard(heap, rules);                   
            Assert.IsTrue(highcard.Play(false).Winner == 1);
        }


        
    }
}
