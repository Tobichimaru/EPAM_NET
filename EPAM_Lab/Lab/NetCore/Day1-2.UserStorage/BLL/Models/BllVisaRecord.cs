using System;

namespace BLL.Models
{
    /// <summary>
    ///     Class for Visa card description
    /// </summary>
    [Serializable]
    public class BllVisaRecord
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///      Gets or sets the start date of visa operation
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date of visa operation
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        #endregion
    }
}
