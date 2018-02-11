using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private List<User> userListFirst = new List<User>
        {
            new User
            {
                Age = 21,
                Gender = Gender.Man,
                Name = "User1",
                Salary = 21000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 18,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 19000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Ann",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            }
        };

        private List<User> userListSecond = new List<User>
        {
            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            },
            new User
            {
                Age = 28,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 21000
            }
        };

        [TestMethod]
        public void SortByName()
        {
            var actualDataFirstList = new List<User>();
            var expectedData = userListFirst[4];

            actualDataFirstList = userListFirst.OrderBy(user => user.Name).ToList();

            Assert.IsTrue(actualDataFirstList[0].Equals(expectedData));
        }

        [TestMethod]
        public void SortByNameDescending()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = userListSecond[0];

            actualDataSecondList = userListSecond.OrderByDescending(user => user.Name).ToList();

            Assert.IsTrue(actualDataSecondList[0].Equals(expectedData));
            
        }

        [TestMethod]
        public void SortByNameAndAge()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = userListSecond[4];

            actualDataSecondList = userListSecond.OrderBy(user => user.Name).ThenBy(user => user.Age).ToList();

            Assert.IsTrue(actualDataSecondList[0].Equals(expectedData));
        }

        [TestMethod]
        public void RemovesDuplicate()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = new List<User> {userListSecond[0], userListSecond[1], userListSecond[3], userListSecond[4],userListSecond[5]};

            actualDataSecondList = userListSecond.Distinct().ToList();

            CollectionAssert.AreEqual(expectedData, actualDataSecondList);
        }

        [TestMethod]
        public void ReturnsDifferenceFromFirstList()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { userListFirst[0], userListFirst[2], userListFirst[3] };

            actualData = userListFirst.Where(u => !userListSecond.Intersect(userListFirst).Contains(u)).ToList();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void SelectsValuesByNameMax()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { userListSecond[0], userListSecond[2] };

            actualData =
                userListSecond.Where(user => user.Name == userListSecond.OrderBy(u => u.Name).Last().Name).ToList();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void ContainOrNotContainName()
        {
            var isContain = false;

            //name max 
            isContain = userListSecond.FirstOrDefault(user => user.Name == "Max") != null;
            Assert.IsTrue(isContain);

            // name obama
            isContain = userListSecond.FirstOrDefault(user => user.Name == "Obama") != null;
            Assert.IsFalse(isContain);
        }

        [TestMethod]
        public void AllListWithName()
        {
            var isAll = true;

            //name max 
            isAll = userListSecond.All(user => user.Name == "Max");

            Assert.IsFalse(isAll);
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameMax()
        {
            var actualData = new User();
            try
            {
                actualData = userListSecond.Single(u => u.Name == "Max");
                Assert.Fail();
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains more than one matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameNotOnList()
        {
            var actualData = new User();
            try
            {
                actualData = userListSecond.Single(u => u.Name == "Ldfsdfsfd");
                //name Ldfsdfsfd
                Assert.Fail();
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains no matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
           
        }

        [TestMethod]
        public void ReturnsOnlyElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();
            actualData = userListSecond.FirstOrDefault(u => u.Name == "Ldfsdfsfd");
            //name Ldfsdfsfd

            Assert.IsTrue(actualData == null);
        }


        [TestMethod]
        public void ReturnsTheFirstElementByNameNotOnList()
        {
            var actualData = new User();

            try
            {
                actualData = userListSecond.First(u => u.Name == "Ldfsdfsfd");
                Assert.Fail();
                //name Ldfsdfsfd
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains no matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
            
        }

        [TestMethod]
        public void ReturnsTheFirstElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();

            actualData = userListSecond.FirstOrDefault(u => u.Name == "Ldfsdfsfd");
            //name Ldfsdfsfd

            Assert.IsTrue(actualData == null);
        }

        [TestMethod]
        public void GetMaxSalaryFromFirst()
        {
            var expectedData = 54000;
            var actualData = new User();

            actualData = userListFirst.OrderBy(u => u.Salary).Last();

            Assert.IsTrue(expectedData == actualData.Salary);
        }

        [TestMethod]
        public void GetCountUserWithNameMaxFromSecond()
        {
            var expectedData = 2;
            var actualData = 0;

            actualData = userListSecond.Count(user => user.Name == "Max");

            Assert.IsTrue(expectedData == actualData);
        }

        [TestMethod]
        public void Join()
        {
            var NameInfo = new[]
            {
                new {name = "Max", Info = "info about Max"},
                new {name = "Alan", Info = "About Alan"},
                new {name = "Alex", Info = "About Alex"}
            }.ToList();

            var expectedData = 3;
            var actualData = -1;

            //ToDo Add code for second list
            actualData = userListSecond.Join(NameInfo, u => u.Name, user => user.name, 
                (u1, u2) => String.Compare(u1.Name, u2.name, StringComparison.Ordinal)).Count();

            Assert.IsTrue(expectedData == actualData);
        }

        [TestMethod]
        public void JoinWithCollections()
        {
            var NameInfo = new[]
            {
                new {name = "Max", Info = "info about Max"},
                new {name = "Alan", Info = "About Alan"},
                new {name = "Alex", Info = "About Alex"}
            }.ToList();

            var actualData = userListSecond.Join(NameInfo, u => u.Name, user => user.name, (u, user) => new
            {
                Name = u.Name,
                Age = u.Age,
                Salary = (decimal)u.Salary,
                Gender = u.Gender,
                Info = user.Info
            }).ToList();

            var expectedData = new[]
            {
                new {Name = "Max", Age = 23, Salary = 24000m, Gender = Gender.Man, Info = "info about Max"},
                new {Name = "Max", Age = 23, Salary = 24000m, Gender = Gender.Man, Info = "info about Max"},
                new {Name = "Alex", Age = 45, Salary = 54000m, Gender = Gender.Man, Info = "About Alex"},

            }.ToList();

            CollectionAssert.AreEqual(actualData, expectedData);
        }

    }
}
