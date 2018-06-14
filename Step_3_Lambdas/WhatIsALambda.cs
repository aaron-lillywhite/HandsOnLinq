using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_3_Lambdas
{
    [TestClass]
    public class WhatIsALambda
    {
        [TestMethod]
        public void AnExample()
        {
            //A lambda is just a method without all the extra work
            Func<string, int> MyExample = text => text.Length;
            int result = MyExample("example");

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void ALongerExample()
        {
            //Lambda's can span multiple lines, but you must use brackets and a return statement
            Func<string, int> LongerExample = text =>
            {
                var length = text.Length;
                length += 1;
                return length;
            };

            int result = LongerExample("example");

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void NoParameters()
        {
            Func<string> UseEmpyParensForNoParameters = () => "Some text";

            string result = UseEmpyParensForNoParameters();

            Assert.AreEqual("Some text", result);
        }

        [TestMethod]
        public void MultipleParameters()
        {
            Func<int,int,int, string> AddParensForMultipleParametersToo = (x,y,z) => (x + y + z).ToString();

            string result = AddParensForMultipleParametersToo(1,2,3);

            Assert.AreEqual("6", result);
        }

        [TestMethod]
        public void YouCanUseActionsToo()
        {
            Action<int> AnotherExample = aNumber => Debug.WriteLine("Your number is " + aNumber);
            AnotherExample(3);
        }

        [TestMethod]
        public void AnExampleOfClosures()
        {
            //You can put local variables in a lambda and they go along for the ride.
            Func<int, int> MyFunc = GetAFunction();
            int result = MyFunc(3);

            Assert.AreEqual(6, result);
        }

        // Normally when a function returns, its privately scoped variables are gone, but not if they are used in a lambda
        private Func<int, int> GetAFunction()
        {
            int one = 1;
            int two = 2;

            return x => one + two + x;
        }

        //[TestMethod]
        //public void YourTurn()
        //{

        //    string result = Greeter("World");

        //    Assert.AreEqual("Hello World", result);
        //}

        //[TestMethod]
        //public void ConcateTwoStrings()
        //{

        //    string result = Concat("one", "two");

        //    Assert.AreEqual("onetwo", result);
        //}

        //[TestMethod]
        //public void NoInputNeeded()
        //{

        //    int result = ReturnOne();

        //    Assert.AreEqual(1, result);
        //}

        //[TestMethod]
        //public void LambdasCanBePassedAroundToo()
        //{

        //    string result = ChecksIfYourLambdaIsTrueWhen5IsPassedIn(MyLambda);

        //    Assert.AreEqual("Your lambda returned true", result);
        //}

        private string ChecksIfYourLambdaIsTrueWhen5IsPassedIn(Func<int, bool> YourLambda)
        {
            if (YourLambda(5))
            {
                return "Your lambda returned true";
            }
            else
            {
                return "Your lambda did not return true";
            }
        }
    }
}
