using System;
using BLL.Interface;
using BLL.Models;

namespace BLL.SearchCriteria
{
    /// <summary>
    /// Search criterion (comparing last name)
    /// </summary>
    [Serializable]
    public class LastNameCriterion : IBllCriterion<BllUser>
    {
        #region Private Fields

        private readonly string lastName;

        #endregion

        #region Constructors

        /// <summary>
        ///     Parametrized constructor
        /// </summary>
        /// <param name="lastName"></param>
        public LastNameCriterion(string lastName)
        {
            this.lastName = lastName;
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
            return user.LastName == lastName;
        }

        #endregion
    }
}
