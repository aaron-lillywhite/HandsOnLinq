using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class K_Expressions_And_Providers
    {
        [TestMethod]
        public void ExpressionsWrapFuncsAndActions()
        {
            // An expression is metadata about a delegate
            Expression<Func<int, string>> isItOne = x => x == 1 ? "One" : "Not One";

            Assert.AreEqual(isItOne.Parameters.First().Name, "x");
            Assert.AreEqual(isItOne.Body.Type, typeof(string));

            //This metadata is used by various providers to transform your query, for example Entity Framework transforms LINQ statements to SQL statements.
        }
    }
}
