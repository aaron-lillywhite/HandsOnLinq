using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_6_The_Final_Building_Blocks
{
    [TestClass]
    public class B_Object_Initializers
    {
        [TestMethod]
        public void AnExample()
        {
            ExampleClass example = new ExampleClass() { Name = "Testy", Age = 30 };

            Assert.AreEqual("Testy", example.Name);
            Assert.AreEqual(30, example.Age);
        }

        private class ExampleClass
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
