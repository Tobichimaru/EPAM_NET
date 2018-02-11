using System;
using System.Reflection;
using BLL.Interface;
using BLL.Models;
using DAL.DTO;
using DAL.Interface;

namespace BLL.Mappers
{
    /// <summary>
    ///     Class for mapping IBllCriterion to IDalCriterion and vice versa
    /// </summary>
    public static class CriteriaMappers
    {
        /// <summary>
        ///     Maps IBllCriterion to IDalCriterion
        /// </summary>
        /// <param name="criteria">Criteria to map</param>
        /// <returns>IDalCriterion criterion</returns>
        public static IDalCriterion<DalUser> ToDalCriteria(this IBllCriterion<BllUser> criteria)
        {
            var result = criteria.GetType().ToString();
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var fields = criteria.GetType().GetFields(flags);
            switch (result)
            {
                case "BLL.SearchCriteria.FirstNameCriterion":
                    return new DAL.SearchCriteria.FirstNameCriterion((string)fields[0].GetValue(criteria));
                case "BLL.SearchCriteria.LastNameCriterion":
                    return new DAL.SearchCriteria.LastNameCriterion((string)fields[0].GetValue(criteria));
                case "BLL.SearchCriteria.IdCriterion":
                    return new DAL.SearchCriteria.IdCriterion((int)fields[0].GetValue(criteria), (int)fields[1].GetValue(criteria));
                default:
                    throw new ArgumentException("Wrong criteria!");
            }
        }
    }
}
