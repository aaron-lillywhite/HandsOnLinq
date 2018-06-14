using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Step_7_Linq_Finally
{
    [TestClass]
    public class J_Grouping_And_Joining
    {
        [TestMethod]
        public void AnExampleOfSelectManyWithoutLinq()
        {
            var list = new[] { "1,2,3", "4,5", "6,7,8" };
            var expected = new[] { "1", "2", "3", "4", "5", "6", "7", "8" };

            var result = new List<string>();

            foreach (var item in list)
            {
                foreach (var number in item.Split(','))
                {
                    result.Add(number);
                }
            }

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TheSameExampleOfSelectManyInMethodSyntax()
        {
            var list = new[] { "1,2,3", "4,5", "6,7,8" };
            var expected = new[] { "1", "2", "3", "4", "5", "6", "7", "8" };

            var result = list.SelectMany(item => item.Split(','));

            BetterAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TheSameExampleOfSelectManyInQuerySyntax()
        {
            var list = new[] { "1,2,3", "4,5", "6,7,8" };
            var expected = new[] { "1", "2", "3", "4", "5", "6", "7", "8" };

            var result = from item in list
                         from number in item.Split(',')
                         select number;

            BetterAssert.AreEqual(expected, result);
        }

        //[TestMethod]
        //public void SplitEveryonesNameAndAlphabetizeThem()
        //{
        //    var list = new[] { "amy", "bob", "carl" };
        //    var expected = new[] { 'a','a', 'b', 'b', 'c', 'l','m','o','r','y' };

        //    BetterAssert.AreEqual(expected, result);
        //}

        public class Course
        {
            public string CourseName { get; set; }
            public int SemesterId { get; set; }
            public List<string> Students { get; set; }
        }

        public class Semester
        {
            public int SemesterId { get; set; }
            public string SemesterName { get; set; }
        }

        public IEnumerable<Course> GetCourses()
        {
            yield return new Course() { CourseName = "Math", SemesterId = 1, Students = new List<string>() { "Abe", "Bob", "Charlene" } };
            yield return new Course() { CourseName = "History", SemesterId = 1, Students = new List<string>() { "Dean", "Ethan", "Frank" } };
            yield return new Course() { CourseName = "Math", SemesterId = 2, Students = new List<string>() { "Dean", "Ethan", "Frank" } };
            yield return new Course() { CourseName = "Geography", SemesterId = 2, Students = new List<string>() { "Abe", "Bob", "Charlene" } };
        }

        public IEnumerable<Semester> GetMarkingPeriods()
        {
            yield return new Semester() { SemesterId = 1, SemesterName = "Fall" };
            yield return new Semester() { SemesterId = 2, SemesterName = "Spring" };
        }

        [TestMethod]
        public void AnExampleOfGroupBy()
        {
            var courses = GetCourses();

            var result = courses.GroupBy(x => x.CourseName);

            var expectedGroups = 3;
            Assert.AreEqual(expectedGroups, result.Count());

            var expectedKeys = new [] {"Math", "History", "Geography"};
            BetterAssert.AreEqual(expectedKeys, result.Select(x => x.Key));

            var expectedItemsInMathtGroup = 2;
            Assert.AreEqual(expectedItemsInMathtGroup, result.Single(x => x.Key == "Math").Count());
        }

        [TestMethod]
        public void GroupingOnMultipleProperties()
        {
            var courses = GetCourses();
            var expectedGroups = 4;

            var result = courses.GroupBy(x => new { x.CourseName, MarkingPeriodId = x.SemesterId });

            Assert.AreEqual(expectedGroups, result.Count());
        }

        //[TestMethod]
        //public void GetAllTheStudentsWhoHaveTakenMath()
        //{
        //    var courses = GetCourses();
        //    var expected = new[] { "Abe", "Bob", "Charlene", "Dean", "Ethan", "Frank" };



        //    BetterAssert.AreEqual(expected, result);
        //}

        [TestMethod]
        public void AnExampleOfJoin()
        {
            var expected = new [] { new {CourseName = "Math", PeriodName ="Fall"}, 
                                    new {CourseName = "History", PeriodName ="Fall"},
                                    new {CourseName = "Math", PeriodName ="Spring"}, 
                                    new {CourseName = "Geography", PeriodName ="Spring"} 
                                  };

            var results = from course in GetCourses()
                           join period in GetMarkingPeriods()
                           on course.SemesterId equals period.SemesterId
                           select new {course.CourseName, PeriodName = period.SemesterName};

            BetterAssert.AreEqual(expected, results);
        }

        [TestMethod]
        public void TheSameExampleOfJoinWithMethodSyntax()
        {
            var expected = new[] { new {CourseName = "Math", PeriodName ="Fall"}, 
                                    new {CourseName = "History", PeriodName ="Fall"},
                                    new {CourseName = "Math", PeriodName ="Spring"}, 
                                    new {CourseName = "Geography", PeriodName ="Spring"} 
                                  };

            var results = GetCourses().Join(GetMarkingPeriods(), course => course.SemesterId, 
                                                                 period => period.SemesterId, 
                                                                 (course, period) => new { course.CourseName, PeriodName = period.SemesterName }
                                           );

            BetterAssert.AreEqual(expected, results);
        }

        //[TestMethod]
        //public void AllStudentsTakingClassesInTheSpringSemester()
        //{
        //    var expected = new[] {  new {Student = "Abe", CourseName = "Geography"}, 
        //                            new {Student = "Bob", CourseName = "Geography"},
        //                            new {Student = "Charlene", CourseName = "Geography"}, 
        //                            new {Student = "Dean", CourseName = "Math"},
        //                            new {Student = "Ethan", CourseName = "Math"}, 
        //                            new {Student = "Frank", CourseName = "Math"},
        //                          };

        //    var selectedSemester = "Spring";

        //    BetterAssert.AreEqual(expected, results);

        //}
    }
}
