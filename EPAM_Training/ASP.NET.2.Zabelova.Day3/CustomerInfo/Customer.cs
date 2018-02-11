using System;
using System.Text;

namespace CustomerInfo {

    /// <summary>
    ///  Class for storing information about customer
    /// </summary>
    public class Customer : IFormattable
    {
        #region Fields and Constants
        private string phone;
        private string name;
        private readonly int PHONE_LENGTH = 10;
        #endregion

        #region Property
        /// <summary>
        /// get: allows to get the phone number of a customer
        /// set: checks and format input data to appropriate phone number format
        /// </summary>
        public string ContactPhone
        {
            get { return phone; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                value = ToDigits(value);

                if (value.Length != PHONE_LENGTH)
                {
                    throw new ArgumentException();
                }

                phone = String.Format("{0:(###) ###-####}", Convert.ToInt64(value));
            }
        }

        /// <summary>
        /// get: allows to get the name of a customer
        /// set: checks and format input data to appropriate name format
        /// </summary>
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                value = ToLetters(value);

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                name = value;
            }
            
        }

        /// <summary>
        /// Auto-generated property for the revenue amount of a customer
        /// </summary>
        public decimal Revenue { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize all information of the customer
        /// </summary>
        /// <param name="name">Name of the customer</param>
        /// <param name="phone">Phone Number of the customer</param>
        /// <param name="revenue">Revenue amount of the customer</param>
        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns string representation of a class customer
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString()
        {
            return ToString("G", new CustomerFormatProvider());
        }
 
        /// <summary>
        /// Returns string representation of a class customer
        /// </summary>
        /// <param name="format">format for string representation</param>
        /// <returns>string representation</returns>
        public string ToString(string format)
        {
            return ToString(format, new CustomerFormatProvider());
        }

        /// <summary>
        /// Returns string representation of a class customer
        /// </summary>
        /// <param name="formatProvider">formatProvider for string representation</param>
        /// <returns>string representation</returns>
        public string ToString(IFormatProvider formatProvider)
        {
            return ToString("G", formatProvider);
        }

        /// <summary>
        /// Returns string representation of a class customer
        /// </summary>
        /// <param name="format">format for string representation</param>
        /// <param name="formatProvider">formatProvider for string representation</param>
        /// <returns>string representation</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (formatProvider == null) formatProvider = new CustomerFormatProvider();

            return String.Format(formatProvider, "{0:" + format + "}", this);
        }
        #endregion

        #region Private Methods
        private string ToDigits(string s)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        private string ToLetters(string s)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsLetter(c))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
        #endregion
    }
}
