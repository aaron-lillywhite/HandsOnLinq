using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class I_Sets
    {
        [TestMethod]
        public void AnExampleOfConcat()
        {
            var first = Enumerable.Range(1, 5);
            var second = Enumerable.Range(6, 5);

            var expected = Enumerable.Range(1, 10);

            var result = first.Concat(second);

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfUnion()
        {
            var first = Enumerable.Range(1, 5);
            var second = Enumerable.Range(4, 7);

            var expected = Enumerable.Range(1, 10);

            var result = first.Union(second);

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfIntersect()
        {
            var first = Enumerable.Range(1, 5);
            var second = Enumerable.Range(4, 7);

            var expected = new[] { 4, 5 };

            var result = first.Intersect(second);

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfExcept()
        {
            var first = Enumerable.Range(1, 5);
            var second = Enumerable.Range(4, 7);

            var expected = new[] { 1, 2, 3 };

            var result = first.Except(second);

            BetterAssert.AreEqual(expected, result);
        }

        //[TestMethod]
        //public void TheFirstAndTheSecondWithoutTheThird()
        //{
        //    var first = Enumerable.Range(1, 5);
        //    var second = Enumerable.Range(3, 11);
        //    var third = new[] { 4, 6, 7, 9, 10, 11, 12 };

        //    var expected = new[] { 1, 2, 3, 5, 8, 13 };



        //    BetterAssert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void AllNumbersInBothFirstAndSecondAndThenThrowThirdInAsWell()
        //{
        //    var first = Enumerable.Range(1, 5);
        //    var second = Enumerable.Range(3, 11);
        //    var third = new[] { 4, 6, 7, 9, 10, 11, 12 };

        //    var expected = new[] { 3, 4, 5, 4, 6, 7, 9, 10, 11, 12 };



        //    BetterAssert.AreEqual(expected, result);
        //}
    }
}
