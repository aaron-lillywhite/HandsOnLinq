using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class F_Ordering
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is Person)
                {
                    var other = (Person)obj;
                    return Name == other.Name && Age == other.Age;
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode()
            {
                return new { Name, Age }.GetHashCode();
            }
        }

        public IEnumerable<Person> GetPeople()
        {
            yield return new Person() { Name = "Bob", Age = 40 };
            yield return new Person() { Name = "Alice", Age = 29 };
            yield return new Person() { Name = "Chuck", Age = 25 };
        }

        [TestMethod]
        public void AnExampleOfOrderBy()
        {
            var people = GetPeople();
            var expected = new [] {"Alice", "Bob", "Chuck"};

            var result = people.OrderBy(x => x.Name).Select(x => x.Name);

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfOrderByDescending()
        {
            var people = GetPeople();
            var expected = new[] { 40, 29, 25 };

            var result = people.OrderByDescending(x => x.Age).Select(x => x.Age);

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfThenBy()
        {
            var people = GetPeople().ToList();
            people.Add(new Person() { Name = "Bob", Age = 5});

            var expected = new[] {  new Person() { Name = "Alice", Age = 29 },
                                    new Person() { Name = "Bob", Age = 5 },
                                    new Person() { Name = "Bob", Age = 40 },
                                    new Person() { Name = "Chuck", Age = 25 }
                                };


            var result = people.OrderBy(x => x.Name).ThenBy(x => x.Age);

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnExampleOfThenByDescending()
        {
            var people = GetPeople().ToList();
            people.Add(new Person() { Name = "Bob", Age = 5 });

            var expected = new[] {  new Person() { Name = "Alice", Age = 29 },
                                    new Person() { Name = "Bob", Age = 40 },
                                    new Person() { Name = "Bob", Age = 5 },
                                    new Person() { Name = "Chuck", Age = 25 }
                                };

            var result = people.OrderBy(x => x.Name).ThenByDescending(x => x.Age);

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhyDoesntThenByShowUp()
        {
            IEnumerable<Person> people = GetPeople();

            //var result = people.ThenBy(x => x.Name);
        }
    }
}
