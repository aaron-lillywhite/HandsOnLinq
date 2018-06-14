using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_6_The_Final_Building_Blocks
{
    [TestClass]
    public class A_TypeInference
    {
        [TestMethod]
        public void AnExample()
        {
            var theCompilerKnows = "By looking at this side";

            Assert.AreEqual(typeof(string), theCompilerKnows.GetType());
        }
    }
}
