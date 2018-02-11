using System;
using DAL.DTO;
using DAL.Interface;

namespace DAL.SearchCriteria
{
    /// <summary>
    ///     Search criterion (comparing Id)
    /// </summary>
    [Serializable]
    public class IdCriterion : IDalCriterion<DalUser>
    {
        #region Private Fields

        private readonly int minId;
        private readonly int maxId;

        #endregion

        #region Constructors

        /// <summary>
        ///     Parametrized constructor
        /// </summary>
        /// <param name="minId"></param>
        /// <param name="maxId"></param>
        public IdCriterion(int minId, int maxId)
        {
            this.minId = minId;
            this.maxId = maxId;
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
            return user.Id >= minId && user.Id <= maxId;
        }

        #endregion
    }
}