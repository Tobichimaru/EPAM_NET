using System;

namespace RootOfNumber
{
    /// <summary>
    /// Class for calculating n-th root of a real number
    /// </summary>
    public static class Root
    {
        #region Public Methods
        /// <summary>
        /// Method for calculating n-th root of a real number with given precision
        /// </summary>
        /// <param name="a">number from which the root is removed</param>
        /// <param name="n">degree of the root</param>
        /// <param name="eps">precision</param>
        /// <returns>n-th root of the real number</returns>
        public static double NRoot(double a, int n, double eps = 0.000001)
        {
            if (Double.IsNaN(a) || eps < 0 || eps > 1) throw new ArgumentException();
            if (a < 0) return Double.NaN;
            
            bool negative = (n < 1);
            n = Math.Abs(n);
            double ans = 1, p = 1, m = n;

            do
            {
                ans = (1 / m) * ((m - 1) * ans + a / p);
                p = BinPower(ans, n - 1);
            } while (Math.Abs(a - p * ans) > eps);

            return (negative) ? 1/ans: ans;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method for calculating n-th degree of a real number
        /// </summary>
        /// <param name="a">number raised to the power</param>
        /// <param name="n">degree of the number</param>
        /// <returns>n-th degree of the number a</returns>
        private static double BinPower(double a, int n)
        {
            if (n == 0)
		        return 1;
	        if (n % 2 == 1)
		        return BinPower(a, n-1) * a;

            double b = BinPower(a, n/2);

            return b * b;
        }   
        #endregion
    }
}