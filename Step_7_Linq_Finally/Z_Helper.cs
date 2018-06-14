using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    public static class BetterAssert
    {
        public static void AreEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            CollectionAssert.AreEqual(expected.ToList(), actual.ToList(), $"Expected {string.Join(",", expected)}, but got {string.Join(",", actual)}");
        }
    }
}
