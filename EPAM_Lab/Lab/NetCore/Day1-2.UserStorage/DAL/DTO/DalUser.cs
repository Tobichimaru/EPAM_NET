using System;
using System.Collections.Generic;
using DAL.Interface;

namespace DAL.DTO
{
    /// <summary>
    ///     User class in DAL
    /// </summary>
    [Serializable]
    public class DalUser : IEquatable<DalUser>, IEntity
    {
        #region Constructors

        /// <summary>
        ///     Default constructor
        /// </summary>
        public DalUser()
        {
            Cards = new List<DalVisaRecord>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets of sets a Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets of sets a First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets of sets a Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets of sets a Birth Date
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public DalGender Gender { get; set; }

        /// <summary>
        ///     Gets of sets a User's Visa cards
        /// </summary>
        public List<DalVisaRecord> Cards { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Static Equals
        /// </summary>
        /// <param name="lhs">first user</param>
        /// <param name="rhs">second user</param>
        /// <returns>true, if objects are equal, otherwise false</returns>
        public static bool Equals(DalUser lhs, DalUser rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            {
                return false;
            }

            return string.Equals(lhs.FirstName, rhs.FirstName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(lhs.LastName, rhs.LastName, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Instance Equals
        /// </summary>
        /// <param name="other">other user</param>
        /// <returns>true, if objects are equal, otherwise false</returns>
        public bool Equals(DalUser other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return Equals(this, other);
        }

        /// <summary>
        ///     Overriden Equals
        /// </summary>
        /// <param name="obj">other user</param>
        /// <returns>true, if objects are equal, otherwise false</returns>
        public override bool Equals(object obj)
        {
            var other = obj as DalUser;
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return Equals(this, other);
        }

        /// <summary>
        ///     Overriden GetHashCode
        /// </summary>
        /// <returns>hash code of the user</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        ///     Overriden ToString
        /// </summary>
        /// <returns>string representation of the user</returns>
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        #endregion
    }
}
