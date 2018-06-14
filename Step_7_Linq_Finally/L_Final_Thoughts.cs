using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class L_Final_Thoughts
    {
        [TestMethod]
        public void AQueryIsNotTheResults()
        {
            var query = DoesntRunWhenTheQueryIsCreated().Where(x => x > 2);

            Assert.IsFalse(methodHasRan);

            var results = query.ToList(); //The query does not run until you foreach, ToList or look at the results in some way

            Assert.IsTrue(methodHasRan);
        }

        private bool methodHasRan = false;

        private IEnumerable<int> DoesntRunWhenTheQueryIsCreated()
        {
            methodHasRan = true;

            yield return 1;
            yield return 2;
            yield return 3;
        }

        [TestMethod]
        public void DontUseQueriesToMakeChanges()
        {
            var query = Enumerable.Range(1, 3).Select(x => ThisChangesStuff(x));

            var result = query.ToList();

            Assert.AreEqual(6, SomeOtherData);

            var anotherResult = query.ToList();

            Assert.AreEqual(12, SomeOtherData);
        }

        private int SomeOtherData = 0;

        private int ThisChangesStuff(int x)
        {
            SomeOtherData += x;

            return x;
        }
    }
}
