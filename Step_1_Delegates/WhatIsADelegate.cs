using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Step_1_Delegates
{

    [TestClass]
    public class WhatIsADelegate
    {
        // The delegate defines the method signature
        private delegate int LengthCalculatorDelegate(string text);

        [TestMethod]
        public void AnExample()
        {
            // You can now save a method into a variable
            LengthCalculatorDelegate myCalculator = new LengthCalculatorDelegate(LengthCalculator);
            
            //You call a delegate just like any other method
            int result = myCalculator("testing");

            Assert.AreEqual(7, result);

            // You can take advantage of the implicit cast from method to delegate and just assign it a method name, it will create the delegate for you
            myCalculator = ReturnsOne;

            // Now the variable points to a different method
            int newResult = myCalculator("testing");

            Assert.AreEqual(1, newResult);

            //Uncomment the below line to see that this does not compile
            //myCalculator = ThisWillNotWork;
        }

        private int LengthCalculator(string text)
        {
            return text.Length;
        }

        private int ReturnsOne(string text)
        {
            return 1;
        }

        private string ThisWillNotWork(string text)
        {
            return "The signature doesn't match the delegate";
        }

        delegate string NumberDel(int number);

        //[TestMethod]
        //public void YourTurn()
        //{
        //    // Create a delegate instance called myDelegate and point it to the GetNumber method

        //    string myNumber = myDelegate(2);
        //    Assert.AreEqual("Two", myNumber);

        //    // Now change the variable to point to the GetColor method

        //    string myColor = myDelegate(0);
        //    Assert.AreEqual("Red", myColor);
        //}

        private string GetNumber(int number)
        {
            var list = new List<string>() { "Zero", "One", "Two" };
            return list[number];
        }

        private string GetColor(int number)
        {
            var list = new List<string>() { "Red", "Blue", "Green" };
            return list[number];
        }
    }
}
