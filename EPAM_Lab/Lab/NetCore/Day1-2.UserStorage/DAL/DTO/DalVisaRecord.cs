using System;

namespace DAL.DTO
{
    /// <summary>
    ///     Class for Visa card description
    /// </summary>
    [Serializable]
    public struct DalVisaRecord
    {
        /// <summary>
        ///     Gets or sets a Country of card owner
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Gets or sets a Card's Start Date 
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets a Card's Expiry Date 
        /// </summary>
        public DateTime ExpiryDate { get; set; }
    }
}
