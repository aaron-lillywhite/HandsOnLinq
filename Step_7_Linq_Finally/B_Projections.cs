using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class B_Projections
    {
        List<string> colors = new List<string>() { "Red", "Green", "Blue", "Yellow", "Black" };

        [TestMethod]
        public void WithoutLinq()
        {
            var expected = new List<string>() { "Color: Red", "Color: Green", "Color: Blue", "Color: Yellow", "Color: Black" };

            var result = new List<string>();

            foreach (var color in colors)
            {
                result.Add("Color: " + color);
            }

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExample()
        {
            var expected = new List<string>() { "Color: Red", "Color: Green", "Color: Blue", "Color: Yellow", "Color: Black" };

            var result = colors.Select(color => "Color: " + color);

            BetterAssert.AreEqual(expected, result);
        }

        //[TestMethod]
        //public void GetTheWordLengths()
        //{
        //    var expected = new List<int>() { 3, 5, 4, 6, 5 };



        //    BetterAssert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void ChangeEveryWordToChicken()
        //{
        //    var expected = new List<string>() { "Chicken", "Chicken", "Chicken", "Chicken", "Chicken" };



        //    BetterAssert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void CanAddTheIndexIntoTheWord()
        //{
        //    var expected = new List<string>() { "Red:0", "Green:1", "Blue:2", "Yellow:3", "Black:4" };



        //    BetterAssert.AreEqual(expected, result);
        //}
    }

    //// Uncomment this class to replace the default Linq Select implementation with your own
    //// The first one is provided for you as an example
    //public static class MyLinq
    //{
    //    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> Selector)
    //    {
    //        foreach (var item in source)
    //        {
    //            yield return Selector(item);
    //        }
    //    }

    //    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> Selector)
    //    {

    //    }
    //}
}
