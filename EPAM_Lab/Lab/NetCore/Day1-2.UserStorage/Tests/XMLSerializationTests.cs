using System.Linq;
using BLL.Interface;
using BLL.Models;
using BLL.SearchCriteria;
using BLL.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class XMLSerializationTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void WriteToXml_()
        {
            MasterUserService service = new MasterUserService();
            BllUser user_1 = new BllUser { FirstName = "Mike", LastName = "Jones" };
            BllUser user_2 = new BllUser { FirstName = "Mike", LastName = "Smith" };
            service.Add(user_1);
            service.Add(user_2);
            service.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ReadFromXml_()
        {
            MasterUserService service_1 = new MasterUserService();
            BllUser user_1 = new BllUser { FirstName = "Mike", LastName = "Jones" };
            BllUser user_2 = new BllUser { FirstName = "Mike", LastName = "Smith" };
            service_1.Add(user_1);
            service_1.Add(user_2);
            service_1.Save();
            MasterUserService service_2 = new MasterUserService();
            service_2.Load();
            Assert.AreEqual(service_2.SearchForUsers(new IBllCriterion<BllUser>[] { new FirstNameCriterion("Mike") }).Count(), 2);
        }
    }
}
