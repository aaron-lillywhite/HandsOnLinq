using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_2_Action_And_Func
{
    [TestClass]
    public class Funcs
    {
        [TestMethod]
        public void AnExample()
        {
            // The last parameter is always the return type, all the preceding ones are input parameters
            Func<string, int> MyExample = CountTheText;
            int result = MyExample("example");

            Assert.AreEqual(7, result);
        }

        private int CountTheText(string text)
        {
            return text.Length;
        }

        //[TestMethod]
        //public void YourTurn()
        //{
        //    // Write a Func called maker that can hold MakeSomeText

        //    string result = maker(1, "Number");

        //    Assert.AreEqual("1) Number", result);
        //}

        private string MakeSomeText(int number, string text)
        {
            return String.Format("{0}) {1}", number, text);
        }

        //[TestMethod]
        //public void YouAlwaysNeedAReturnType()
        //{

        //    string result = GetText();

        //    Assert.AreEqual("A return type is what seperates a Func from an Action", result);
        //}

        private string HaveSomeText()
        {
            return "A return type is what seperates a Func from an Action";
        }

        //[TestMethod]
        //public void NotJustForLocalVariables()
        //{

        //    string result = TakesAFunc(Appendix);

        //    Assert.AreEqual("Methods can be passed around", result);
        //}

        private string AppendText(string text)
        {
            return "Methods can be " + text;
        }

        private string TakesAFunc(Func<string, string> Message)
        {
            return Message("passed around");
        }

        //[TestMethod]
        //public void FuncsCanBeNested()
        //{

        //    Assert.AreEqual("This is nested", result);
        //}

        private Func<string, Func<string, string>> GetAFunction()
        {
            return x => y => $"{x} {y} nested";
        }
    }
}
