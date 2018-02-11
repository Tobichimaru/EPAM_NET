using System;
using System.Text.RegularExpressions;

namespace StringHelper
{
    public static class StringParser
    {
        public static int ToInt(this string str)
        {
            if (str == null)
                throw new NullReferenceException("Input string should not be null.");

            if (str.Length == 0)
                return 0;

            if (!Regex.IsMatch(str, "-?[0-9]+"))
                throw new ArgumentException("Input string should contain only digits.");

            bool isNegative = (str[0] == '-');

            long power = 1;
            int result = 0;
            int start = str.Length - 1;
            int end = (isNegative) ? 1 : 0;
            for (int i = start; i >= end; i--)
            {
                try
                {
                    result += checked((int) (str[i] - '0') * (int) power);
                    power *= 10;
                }
                catch (OverflowException ex)
                {
                    throw new ArgumentException("Input string is too long.");
                }
            }
            return (isNegative)? -result : result;
        } 
    }
}
