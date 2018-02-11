using System;
using DAL.DTO;
using DAL.Interface;

namespace DAL.SearchCriteria
{
    /// <summary>
    /// Search criterion (comparing last name)
    /// </summary>
    [Serializable]
    public class LastNameCriterion : IDalCriterion<DalUser>
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
        public bool ApplyCriterion(DalUser user)
        {
            return user.LastName == this.lastName;
        }

        #endregion
    }
}
