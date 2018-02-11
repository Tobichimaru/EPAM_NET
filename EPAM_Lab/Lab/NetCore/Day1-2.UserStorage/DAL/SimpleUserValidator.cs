using System;
using DAL.DTO;
using DAL.Interface;

namespace DAL
{
    /// <summary>
    /// Class for users validation
    /// </summary>
    [Serializable]
    public class SimpleUserValidator : IUserValidator
    {
        /// <summary>
        /// Validates user according to its first name and last name
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Validate(DalUser user)
        {
            if (object.ReferenceEquals(user, null))
            {
                throw new ArgumentNullException();
            }

            return !string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName);
        }
    }
}
