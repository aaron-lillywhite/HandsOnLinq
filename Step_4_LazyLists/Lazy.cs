using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_4_LazyLists
{
    [TestClass]
    public class Lazy
    {
        [TestMethod]
        public void TheOldWay()
        {
            IEnumerable<int> myNumbers = TheOldList();

            foreach (var number in myNumbers)
            {
                Debug.WriteLine("Inside the loop with number " + number);
            }
        }

        private IEnumerable<int> TheOldList()
        {
            Debug.WriteLine("Starting the method");
            var list = new List<int>();
            list.Add(1);
            Debug.WriteLine("Adding numbers to our list");
            list.Add(2);
            list.Add(3);
            Debug.WriteLine("About to return the list");
            return list;
            Debug.WriteLine("We can never get here and even the compiler knows it");
        }

        [TestMethod]
        public void AnExample()
        {
            IEnumerable<int> myNumbers = OneTwoThree();

            foreach (var number in myNumbers)
            {
                Debug.WriteLine("Inside the loop with number " + number);
            }
        }

        private IEnumerable<int> OneTwoThree()
        {
            Debug.WriteLine("Run everyting up to first yield");
            yield return 1;
            Debug.WriteLine("Between 1 and 2");
            yield return 2;
            Debug.WriteLine("Between 2 and 3");
            yield return 3;
            Debug.WriteLine("Run everything afterwards");
        }

        //[TestMethod]
        //public void YourTurn()
        //{
        //    var monkeyList = new List<string>() { "Monkey 0", "Monkey 1", "Monkey 2", "Monkey 3", "Monkey 4", "Monkey 5", "Monkey 6", "Monkey 7", "Monkey 8", "Monkey 9" };
        //    var results = new List<string>();

        //    var counter = 0;
        //    foreach (var monkey in InfiniteMonkeys().Take(10)) // We have to limit how many we get back in an infinite list so we just take 10, we'll talk more about Take later
        //    {
        //        results.Add(monkey + " " + counter);
        //        counter += 1;
        //    }

        //    CollectionAssert.AreEqual(monkeyList, results);
        //}

        //private IEnumerable<string> InfiniteMonkeys()
        //{

        //}
    }
}
