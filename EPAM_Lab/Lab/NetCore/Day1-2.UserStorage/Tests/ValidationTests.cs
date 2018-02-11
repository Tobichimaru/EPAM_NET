using DAL;
using DAL.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ValidationTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserSimpleValidation_ReturnsTrueForValidUser()
        {
            DalUser user = new DalUser { FirstName = "Mike" };
            SimpleUserValidator validator = new SimpleUserValidator();
            bool isValid = validator.Validate(user);
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void UserSimpleValidation_ReturnsFalseForInvalidUser()
        {
            DalUser user = new DalUser { FirstName = "Mike", LastName = "Jones" };
            SimpleUserValidator validator = new SimpleUserValidator();
            bool isValid = validator.Validate(user);
            Assert.IsTrue(isValid);
        }
    }
}
