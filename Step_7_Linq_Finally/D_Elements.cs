using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class D_Elements
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public IEnumerable<Person> GetPeople()
        {
            yield return new Person() { Name = "Bob", Age = 40 };
            yield return new Person() { Name = "Alice", Age = 29 };
            yield return new Person() { Name = "Chuck", Age = 25 };
        }

        [TestMethod]
        public void AnExampleOfSingle()
        {
            var people = GetPeople();
            var expected = 25;

            var Chuck = people.Single(x => x.Name == "Chuck");
            var result = Chuck.Age;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AnExampleOfSingleWithoutAMatch()
        {
            var people = GetPeople();

            var Dean = people.Single(x => x.Name == "Dean");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AnotherExampleOfSingleWithTwoMatches()
        {
            var people = GetPeople().ToList();
            people.Add(new Person() { Name = "Alice", Age = 29 });

            var Alice = people.Single(x => x.Name == "Alice");
        }

        [TestMethod]
        public void AnExampleOfSingleOrDefault()
        {
            var people = GetPeople();
            var expected = 65;

            var Dean = people.SingleOrDefault(x => x.Name == "Dean");

            if (Dean != null)
            {
                var result = Dean.Age;
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void AnExampleOfFirst()
        {
            var people = GetPeople();
            var expected = 40;

            var someone = people.First();
            var result = someone.Age;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AnotherExampleOfFirst()
        {
            var people = GetPeople();
            var expected = "Alice";

            var someone = people.First(x => x.Age == 29);
            var result = someone.Name;

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FirstOrDefaultWithoutAnybodyInTheList()
        {
            var people = Enumerable.Empty<Person>();

            var someone = people.First();
        }

        [TestMethod]
        public void AnExampleOfFirstOrDefault()
        {
            var people = Enumerable.Empty<Person>();

            var someone = people.FirstOrDefault();

            if (someone != null)
            {
                Assert.AreEqual("Something", someone.Name);
            }
        }

        //[TestMethod]
        //public void HowOldIsAlice()
        //{
        //    var people = GetPeople();
        //    var expected = 29;

            

        //    Assert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void MakeItPassWithEitherLineOfCode()
        //{
        //    var people = GetPeople();
        //    //var people = Enumerable.Empty<Person>();

        //    var expected = "Bob";



        //    if (result != null)
        //    {
        //        Assert.AreEqual(expected, result);
        //    }
        //}

        //[TestMethod]
        //public void WhatToDoWhenWeKnowThereIsMoreThenOne()
        //{
        //    var people = GetPeople().ToList();
        //    people.Add(new Person() { Name = "Alice", Age = 29 });
        //    var expected = 29;



        //    Assert.AreEqual(expected, result);

        //}
    }
}
