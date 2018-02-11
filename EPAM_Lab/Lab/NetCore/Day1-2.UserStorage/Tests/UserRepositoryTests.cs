﻿using System;
using System.Linq;
using DAL;
using DAL.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{ 
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class UserRepositoryTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void AddValidUser_ReturnsUserId()
        {
            DalUser user = new DalUser { FirstName = "Mike", LastName = "Jones" };
            UserRepository repository = new UserRepository();
            int id = repository.Add(user);
            Assert.AreEqual(2, id);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullUser_ThrowsException()
        {
            DalUser user = null;
            UserRepository repository = new UserRepository();
            int id = repository.Add(user);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddInValidUser_ThrowsException()
        {
            DalUser user = new DalUser { FirstName = "Mike" };
            UserRepository repository = new UserRepository();
            int id = repository.Add(user);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void DeleteUser_()
        {
            DalUser user = new DalUser { FirstName = "Mike", LastName = "Jones" };
            UserRepository repository = new UserRepository();
            int id = repository.Add(user);
            repository.Delete(user);
            var ids = repository.GetByPredicate(new Func<DalUser, bool>[] { u => u.Id == id });
            Assert.AreEqual(ids?.Count(), 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteNullUser_ThrowsException()
        {
            UserRepository repository = new UserRepository();
            repository.Delete(null);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetAllUsers_ReturnsAllUsers()
        {
            UserRepository repository = new UserRepository();
            DalUser user = new DalUser { FirstName = "Mike", LastName = "Jones" };
            int id = repository.Add(user);
            var users = repository.GetByPredicate(new Func<DalUser, bool>[] { u => u.FirstName != null });
            int count = users.Count();
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SearchForUsers_ReturnsSingleUserId()
        {
            UserRepository st = new UserRepository(new UserIdIterator(), new SimpleUserValidator());
            DalUser user = new DalUser { FirstName = "Mike", LastName = "Jones" };
            int id = st.Add(user);
            int[] ids = st.GetByPredicate(new Func<DalUser, bool>[] { u => u.Id == id });
            ////Assert.AreEqual(ids[0], 0);
            Assert.AreEqual(ids.Count(), 1);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SearchForUsers_ReturnsMultipleUserId()
        {
            UserRepository st = new UserRepository(new UserIdIterator(), new SimpleUserValidator());
            DalUser user_1 = new DalUser { FirstName = "Mike", LastName = "Jones" };
            DalUser user_2 = new DalUser { FirstName = "Mike", LastName = "Smith" };
            st.Add(user_1);
            st.Add(user_2);
            int[] ids = st.GetByPredicate(new Func<DalUser, bool>[] { u => u.FirstName == "Mike" });
            Assert.AreEqual(ids.Count(), 2);
        }
    }
}
