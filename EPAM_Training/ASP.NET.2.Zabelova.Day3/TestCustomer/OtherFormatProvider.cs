using System;
using System.Globalization;
using System.Text;
using CustomerInfo;

namespace TestCustomer
{
    /// <summary>
    /// Providing other formating for Customer class
    /// </summary>
    class OtherFormatProvider : IFormatProvider, ICustomFormatter
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
            if (arg.GetType() != typeof(Customer))
            {
                throw new FormatException(String.Format("The format of '{0}' is invalid.", format));
            }

            Customer customer = (Customer)arg;

            format = format.ToUpperInvariant();
            StringBuilder result = new StringBuilder("Attention! ");

            if (format == "G") format = "NPR";
            if (format.Contains("N")) result.Append("Customer named " + customer.Name.ToString() + "! ");
            if (format.Contains("R")) result.Append("You won " + customer.Revenue.ToString(CultureInfo.CurrentCulture) + " dollars!!! ");
            if (format.Contains("P")) result.Append("Please, contact " + customer.ContactPhone.ToString() + ".");

            return result.ToString();
        }
    }
}
