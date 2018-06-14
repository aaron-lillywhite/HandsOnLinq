using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class G_Paging
    {
        [TestMethod]
        public void AnExampleOfSkip()
        {
            var numbers = new[] { 2, 4, 6, 8, 10 };
            var expected = new[] { 8, 10 };

            var result = numbers.Skip(3);

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfTake()
        {
            var numbers = Enumerable.Range(1, 100);
            var expected = Enumerable.Range(1, 10);

            var result = numbers.Take(10);

            BetterAssert.AreEqual(expected, result);
        }

        //[TestMethod]
        //public void YourTurn()
        //{
        //    var numbers = Enumerable.Range(1, 100);
        //    var expected = Enumerable.Range(50, 25);



        //    BetterAssert.AreEqual(expected, result);
        //}
    }
}
