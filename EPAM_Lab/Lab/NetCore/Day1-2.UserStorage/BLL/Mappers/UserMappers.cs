using System.Linq;
using BLL.Models;
using DAL.DTO;

namespace BLL.Mappers
{
    /// <summary>
    ///     Class for mapping BllUser to DalUser and vice versa
    /// </summary>
    public static class UserMappers
    {
        /// <summary>
        ///     Maps DalUser to BllUser
        /// </summary>
        /// <param name="user">DalUser object</param>
        /// <returns>BllUser object</returns>
        public static BllUser ToBllUser(this DalUser user)
        {
            return new BllUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = (BllGender)user.Gender,
                Cards = user.Cards?.Select(card => new BllVisaRecord
                {
                    Country = card.Country,
                    ExpiryDate = card.ExpiryDate,
                    StartDate = card.StartDate
                })?.ToList()
            };
        }

        /// <summary>
        ///     Maps BllUser to DalUser
        /// </summary>
        /// <param name="user">DalUser object</param>
        /// <returns>BllUser object</returns>
        public static DalUser ToDalUser(this BllUser user)
        {
            return new DalUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = (DalGender)user.Gender,
                Cards = user.Cards?.Select(card => new DalVisaRecord
                {
                    Country = card.Country,
                    ExpiryDate = card.ExpiryDate,
                    StartDate = card.StartDate
                })?.ToList()
            };
        }
    }
}
