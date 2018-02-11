using System;
using BLL.Interface;
using BLL.Models;

namespace BLL.SearchCriteria
{
    /// <summary>
    ///     Search criterion (comparing first name)
    /// </summary>
    [Serializable]
    public class FirstNameCriterion : IBllCriterion<BllUser>
    {
        #region Private Fields

        private readonly string firstName;

        #endregion

        #region Constructors

        /// <summary>
        ///     Parametrized constructor
        /// </summary>
        /// <param name="firstName"></param>
        public FirstNameCriterion(string firstName)
        {
            this.firstName = firstName;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Method to apply criterion
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ApplyCriterion(BllUser user)
        {
            return user.FirstName == firstName;
        }

        #endregion
    }
}