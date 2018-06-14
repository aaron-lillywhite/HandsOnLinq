using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_2_Action_And_Func
{
    [TestClass]
    public class Actions
    {
        [TestMethod]
        public void AnExample()
        {
            // It's like a delegate, but you don't have to create your own
            Action<string> MyExample = DoesSomething;
            MyExample("Actions are for methods that have no return");
        }

        private void DoesSomething(string text)
        {
            Console.WriteLine(text);
        }

        //[TestMethod]
        //public void MakeItSleep()
        //{
        //    // Create an Action called MySleeper that can hold the Sleep method written below

        //    MySleeper(10);
        //}

        private void Sleep(int miliseconds)
        {
            Thread.Sleep(miliseconds);
        }

        //[TestMethod]
        //public void ItDoesntNeedAParameter()
        //{
        //    // Create an Action called Test that can hold NoParamsNeeded

        //    Test();
        //}

        private void NoParamsNeeded()
        {
            Console.WriteLine("Examples are hard");
        }

        //[TestMethod]
        //public void OrItCanHaveALotOfThem()
        //{
        //    // Create an Action called Lots that can hold SomeOtherMethod

        //    Lots("text", 1, DateTime.Now);
        //}

        private void SomeOtherMethod(string someText, int aNumber, DateTime whoKnows)
        {
            //It doesn't need to do anything
        }
    }
}
