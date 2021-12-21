using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question2;
using Question2.Decks;
using System;
namespace TestQuestion2
{
    [TestClass]
    public class TestRules
    { 
        [TestMethod]
        public void TestCardValue1()
        {
            int[] precedence = { 1, 2, 3, 4 };
            GameRules rules = new GameRules(precedence, null, true);
            Card card1 = new Card(2, 0);
            Card card2 = new Card(1, 0);
            Assert.IsTrue(rules.CompareCards(card1, card2) == 1);
        }

        public void TestCardValue2()
        {
            int[] precedence = { 1, 2, 3, 4 };
            GameRules rules = new GameRules(precedence, null, true);
            Card card1 = new Card(1, 0);
            Card card2 = new Card(2, 0);
            Assert.IsTrue(rules.CompareCards(card1, card2) == 2);
        }

        public void TestCardPrecedence1()
        {
            int[] precedence = { 1, 2, 3, 4 };
            GameRules rules = new GameRules(precedence, null, false);
            Card card1 = new Card(1, 0);
            Card card2 = new Card(1, 1);
            Assert.IsTrue(rules.CompareCards(card1, card2) == 2);
        }

        public void TestCardPrecedence2()
        {
            int[] precedence = { 1, 2, 3, 4 };
            GameRules rules = new GameRules(precedence, null, false);
            Card card1 = new Card(1, 1);
            Card card2 = new Card(1, 0);
            Assert.IsTrue(rules.CompareCards(card1, card2) == 1);
        }

        public void TestCardTies()
        {
            int[] precedence = { 1, 2, 3, 4 };
            GameRules rules = new GameRules(precedence, null, true);
            Card card1 = new Card(1, 0);
            Card card2 = new Card(1, 0);
            Assert.IsTrue(rules.CompareCards(card1, card2) == 0);
        }







    }
}
