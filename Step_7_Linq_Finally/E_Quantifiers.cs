using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class E_Quantifiers
    {
        [TestMethod]
        public void AnExampleOfAny()
        {
            var numbers = Enumerable.Range(1, 10);

            var isNotEmpty = numbers.Any();

            Assert.IsTrue(isNotEmpty);
        }

        [TestMethod]
        public void AnotherExampleOfAny()
        {
            var numbers = Enumerable.Range(1, 10);

            var hasAnyEvenNumbers = numbers.Any(x => x % 2 == 0);

            Assert.IsTrue(hasAnyEvenNumbers);
        }

        [TestMethod]
        public void AnExampleOfAll()
        {
            var numbers = new[] { 2, 4, 6, 8, 10 };

            var hasOnlyEvenNumbers = numbers.All(x => x % 2 == 0);

            Assert.IsTrue(hasOnlyEvenNumbers);
        }

        [TestMethod]
        public void AnExampleOfContains()
        {
            var numbers = Enumerable.Range(1, 10);

            var hasAFive = numbers.Contains(5);

            Assert.IsTrue(hasAFive);
        }

        //[TestMethod]
        //public void AreAnyDivisibleBy3and5()
        //{
        //    var numbers = Enumerable.Range(1, 20);



        //    Assert.IsTrue(divisibleBy3and5);
        //}
    }
}
