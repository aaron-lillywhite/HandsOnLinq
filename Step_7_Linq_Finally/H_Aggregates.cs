using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class H_Aggregates
    {
        IEnumerable<int> Numbers = new[] { 4, 7, 2, 5, 9 };

        [TestMethod]
        public void AnExampleOfCount()
        {
            var expected = 3;

            var result = Numbers.Count(x => x >= 5);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfMin()
        {
            var expected = 2;

            var result = Numbers.Min();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhatElseCanMinDoForMe()
        {
            var expected = 20;

            var result = Numbers.Min(x => x * 10); //Funcs passed to Min are treated like a Select, this works for Max, Sum and Average too
            var sameResult = Numbers.Select(x => x * 10).Min();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected, sameResult);
        }

        [TestMethod]
        public void AnExampleOfMax()
        {
            var expected = 9;

            var result = Numbers.Max();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfSum()
        {
            var expected = 27;

            var result = Numbers.Sum();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnotherExampleOfSum()
        {
            var expected = 32;

            var result = Numbers.Sum(x => x + 1);

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void AnExampleOfAverage()
        {
            var expected = 5.4;

            var result = Numbers.Average();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfAggregate()
        {
            var expected = 27;

            var result = Numbers.Aggregate((total, nextItem) => total + nextItem);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfZip()
        {
            var letters = new[] { "A", "B", "C", "D", "E" };
            var expected = new[] { "4 = A", "7 = B", "2 = C", "5 = D", "9 = E" };

            var result = Numbers.Zip(letters, (x, y) => x + " = " + y);

            BetterAssert.AreEqual(expected, result);
        }

        //[TestMethod]
        //public void WorstStringJoinEver()
        //{
        //    var text = new[] { "comma", "seperate", "these", "words" };

        //    var expected = "comma, seperate, these, words";



        //    BetterAssert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void AddNumbersGreaterThan5()
        //{
        //    var moreNumbers = new[] { 5, 9, 13, 2, 4, 1, 7 };

        //    var expected = 29;



        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void GetTheMinBetweenEachItem()
        //{
        //    var first = new[] { 5, 9, 13, 2, 4 };
        //    var second = new[] { 1, 10, 3, 6, 2 };

        //    var expected = new[] { 1, 9, 3, 2, 2 };



        //    BetterAssert.AreEqual(expected, result);
        //}
    }
}
