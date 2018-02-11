using System;
using System.Globalization;
using System.Text;

namespace CustomerInfo
{
    /// <summary>
    /// Providing custom formatter for Customer class
    /// </summary>
    class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        /// <summary>
        /// Creates string representation of inputed object due provided format
        /// </summary>
        /// <param name="format">format for string representation</param>
        /// <param name="arg">object for formating</param>
        /// <param name="formatProvider">format for string representation</param>
        /// <returns>string representation of an object</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof (Customer))
            {
                throw new FormatException(String.Format("The format of '{0}' is invalid.", format));
            }

            Customer customer = (Customer) arg;

            format = format.ToUpperInvariant();
            StringBuilder result = new StringBuilder("Customer record: ");

            if (format == "G") format = "NPR";
            if (format.Contains("N")) result.Append(customer.Name.ToString() + "; ");
            if (format.Contains("P")) result.Append(customer.ContactPhone.ToString() + "; ");
            if (format.Contains("R")) result.Append(customer.Revenue.ToString(CultureInfo.CurrentCulture) + "; ");

            return result.ToString();
        }
    }
}
