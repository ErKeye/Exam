using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question2;
using Question2.Decks;
using System;
namespace TestQuestion2
{
    [TestClass]
    public class TestDeckHeap
    {

        [TestMethod]
        public void TestPokerGetHeap()
        {
            Assert.IsTrue(TestPokerGetHeapSize0());
            Assert.IsTrue(TestGetHeapSize(PokerDeck.GetGameCardHeap(1), 1));
            Assert.IsTrue(TestGetHeapSize(PokerDeck.GetGameCardHeap(3), 3));
        }

        [TestMethod]
        public void TestSpanishGetHeap()
        {
            Assert.IsTrue(TestSpanishGetHeapSize0());
            Assert.IsTrue(TestGetHeapSize(SpanishDeck.GetGameCardHeap(1), 1));
            Assert.IsTrue(TestGetHeapSize(SpanishDeck.GetGameCardHeap(3), 3));
        }

        [TestMethod]
        public void TestTwentySizeSuitGetHeap()
        {
            Assert.IsTrue(TestTwentySizeSuitGetHeapSize0());
            Assert.IsTrue(TestGetHeapSize(SpanishDeck.GetGameCardHeap(1), 1));
            Assert.IsTrue(TestGetHeapSize(SpanishDeck.GetGameCardHeap(3), 3));
        }

        [TestMethod]
        public void TestShuffle()
        {
            CardHeap heap = PokerDeck.GetGameCardHeap(2);
            int[] order1 = new int[heap.HeapSize];
            int[] order2 = new int[heap.HeapSize];

            int i;
            for (i = 0; !heap.IsEmpty; i++)
                order1[i] = heap.GetNextCard().Value;
            heap.Shuffle();
            for (i = 0; !heap.IsEmpty; i++)
                order2[i] = heap.GetNextCard().Value;
            Assert.AreNotEqual(order1, order2);
        }


        public bool TestPokerGetHeapSize0()
        {
            try
            {
                CardHeap heap = PokerDeck.GetGameCardHeap(0);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Card heap needs at least 1 deck.");
                return true;
            }
            return false;
        }

        
        public bool TestSpanishGetHeapSize0()
        {
            try
            {
                CardHeap heap = SpanishDeck.GetGameCardHeap(0);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Card heap needs at least 1 deck.");
                return true;
            }
            return false;
        }

        public bool TestTwentySizeSuitGetHeapSize0()
        {
            try
            {
                CardHeap heap = TwentySizeSuitDeck.GetGameCardHeap(0);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Card heap needs at least 1 deck.");
                return true;
            }
            return false;
        }




        private bool TestGetHeapSize(CardHeap heap, int desk_amount)
        {
            int i;
            for (i=0; !heap.IsEmpty; i++)                
                heap.GetNextCard();
            return heap.HeapSize == i && heap.HeapSize == desk_amount * heap.SuitSize * heap.Suits.Length;                
        }
        
    }
}
