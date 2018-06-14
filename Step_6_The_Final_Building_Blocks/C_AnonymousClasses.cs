using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_6_The_Final_Building_Blocks
{
    [TestClass]
    public class C_AnonymousClasses
    {
        [TestMethod]
        public void AnExample()
        {
            var newClass = new { Name = "Testy", Age = 30};

            Assert.AreEqual("Testy", newClass.Name);
            Assert.AreEqual(30, newClass.Age);
        }
    }
}
