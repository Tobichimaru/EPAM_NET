using System;
using DAL.DTO;
using DAL.Interface;

namespace DAL.SearchCriteria
{
    /// <summary>
    ///     Search criterion (comparing first name)
    /// </summary>
    [Serializable]
    public class FirstNameCriterion : IDalCriterion<DalUser>
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
        public bool ApplyCriterion(DalUser user)
        {
            return user.FirstName == firstName;
        }

        #endregion
    }
}