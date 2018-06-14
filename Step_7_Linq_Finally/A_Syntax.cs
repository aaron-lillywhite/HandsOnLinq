using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class A_Syntax
    {
        IEnumerable<int> numbers = Enumerable.Range(1, 10);

        [TestMethod]
        public void QuerySyntax()
        {
            var expected = new List<int>() { 1, 2, 3, 4, 5 };

            var result = from number in numbers 
                         where number <= 5
                         select number;

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MethodSyntax()
        {
            var expected = new List<int>() { 1, 2, 3, 4, 5 };

            // This would more accurately match the above query, but the Select is redundant if you're writing it yourself
            //var result = numbers.Where(number => number <= 5).Select(number => number);

            var result = numbers.Where(number => number <= 5);

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhichOneShouldIUse()
        {
            var methodResult = GetStudents().SelectMany(kid => kid.Subjects, (kid, subject) => kid.Name + " has " + subject);

            var queryResult = from kid in GetStudents()
                              from subject in kid.Subjects
                              select kid.Name + " has " + subject;

            // They are the same, so write the one that is easier to read!
            BetterAssert.AreEqual(methodResult, queryResult);
        }

        private List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student() {Name = "Alice", Subjects = new List<string>() {"Reading", "Math", "Gym"}},
                new Student() {Name = "Bob", Subjects = new List<string>() {"Reading", "Math", "Biology"}},
                new Student() {Name = "Chuck", Subjects = new List<string>() {"Gym", "Math", "Biology"}},
            };
        }

        private class Student
        {
            public string Name { get; set; }
            public IEnumerable<string> Subjects { get; set; }
        }
    }
}
