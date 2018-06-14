using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class C_Restrictions
    {
        IEnumerable<int> numbers = Enumerable.Range(1, 10);

        [TestMethod]
        public void WhereWithoutLinq()
        {
            var expected = new List<int>() { 1, 2, 3, 4, 5 };

            var result = new List<int>();
            foreach (var number in numbers)
            {
                if (number < 6)
                {
                    result.Add(number);
                }
            }

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExample()
        {
            var expected = new List<int>() { 1, 2, 3, 4, 5 };

            var result = numbers.Where(number => number < 6);

            BetterAssert.AreEqual(expected, result);
        }

        //[TestMethod]
        //public void CanGetEvenNumbers()
        //{
        //    var expected = new List<int>() { 2, 4, 6, 8, 10 };



        //    BetterAssert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void CanGetAllTheNumbers()
        //{
        //    var expected = Enumerable.Range(1, 10).ToList();



        //    BetterAssert.AreEqual(expected, result);
        //}
    }

    //public static class MyLinq2
    //{
    //    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> Source, Func<TSource, bool> Filter)
    //    {

    //    }
    //}
}
