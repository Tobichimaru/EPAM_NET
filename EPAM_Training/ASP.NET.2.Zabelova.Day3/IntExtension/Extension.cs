using System;
using System.Text;

namespace IntExtension
{
    /// <summary>
    /// Extension for integers
    /// </summary>
    public static class Extension
    {
        #region Fields and Constants
        private const string ALPH = "0123456789abcdef";
        #endregion

        #region Public Methods
        /// <summary>
        /// Extension method calculate hex representation of integer
        /// <returns>string representation of hex number</returns>
        /// </summary>
        public static string ToHex(this int value)
        {
            StringBuilder s = new StringBuilder();
            bool negative = (value < 0);
            value = Math.Abs(value);
            
            while (value != 0)
            {
                s.Append(ALPH[value%16]);
                value /= 16;
            }

            if (negative) s.Append("-");
            return Reverse(s.ToString());
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Reverse elements of string
        /// </summary>
        /// <param name="s">string for reversing</param>
        /// <returns>reversed string</returns>
        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        #endregion
    }
}
