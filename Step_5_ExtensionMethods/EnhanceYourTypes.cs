using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_5_ExtensionMethods
{
    [TestClass]
    public class EnhanceYourTypes
    {
        [TestMethod]
        public void AnExample()
        {
            var result = "This is a test".LengthWithoutSpaces();

            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void AnotherExample()
        {
            var result = 1.Chicken();

            Assert.AreEqual("Chicken", result);
        }

        //[TestMethod]
        //public void YourTurn()
        //{
        //    var rightNow = DateTime.Now;

        //    var expected = rightNow.AddYears(10);
            
        //    var result = rightNow.AddADecade();

        //    Assert.IsTrue((expected - result).TotalMilliseconds < 10);
        //}
    }

    public static class Extensions //Your extension method class must be static
    {
        public static int LengthWithoutSpaces(this string text) //The extension methods themselves must be static and the first paramater needs the 'this' keyword to mark it as the type to extend.
        {
            return text.Replace(" ", String.Empty).Length;
        }

        public static string Chicken(this object anything)
        {
            return "Chicken";
        }
    }
}
