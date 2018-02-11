﻿using DAL.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class DalUserTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserEqualityForEqualUsers_ReturnsTrue()
        {
            DalUser user_1 = new DalUser { FirstName = "Mike", LastName = "Jones" };
            DalUser user_2 = new DalUser { FirstName = "Mike", LastName = "Jones" };
            Assert.IsTrue(user_1.Equals(user_2));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserEqualityForNonEqualUsers_ReturnsFalse()
        {
            DalUser user_1 = new DalUser { FirstName = "Mike", LastName = "Jones" };
            DalUser user_2 = new DalUser { FirstName = "Mike", LastName = "White" };
            Assert.IsFalse(user_1.Equals(user_2));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserHashCode_ReturnsSameValuesForSameUsers()
        {
            DalUser user_1 = new DalUser { Id = 0, FirstName = "Mike", LastName = "Jones" };
            DalUser user_2 = user_1;
            Assert.AreEqual(user_1.GetHashCode(), user_2.GetHashCode());
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserHashCode_ReturnsDifferentValuesForDifferentUsers()
        {
            DalUser user_1 = new DalUser { Id = 0, FirstName = "Mike", LastName = "Jones" };
            DalUser user_2 = new DalUser { Id = 2, FirstName = "Mike", LastName = "Jones" };
            Assert.AreNotEqual(user_1.GetHashCode(), user_2.GetHashCode());
        }
    }
}
