using System;
using System.Diagnostics;

namespace MathExtension
{
    /// <summary>
    /// Class for calculating GCD
    /// </summary>
    public static class MathFunctions
    {
        #region Delegate
        /// <summary>
        /// Delegate describes method of calculation of GCD of two integers.
        /// </summary>
        /// <param name="x">first integer</param>
        /// <param name="y">second integer</param>
        /// <returns>greatest common divisor</returns>
        public delegate int CalculateGcd(int x, int y);
        #endregion

        #region Public Methods
        /// <summary>
        /// Method for calculating GCD by Euclid approach
        /// </summary>
        /// <param name="a">array of integers</param>
        /// <returns>greatest common divisor</returns>
        public static int GcdEuclid(params int[] a)
        {
            double time;
            return GcdDelegate(out time, GcdEuclid, a);
        }

        /// <summary>
        /// Method for calculating GCD by Euclid approach
        /// </summary>
        /// <param name="time">time of calculation GCD</param>
        /// <param name="a">array of integers</param>
        /// <returns>greatest common divisor</returns>
        public static int GcdEuclid(out double time, params int[] a)
        {
            return GcdDelegate(out time, GcdEuclid, a);
        }

        /// <summary>
        /// Method for calculating GCD by Shtein approach
        /// </summary>
        /// <param name="a">array of integers</param>
        /// <returns>greatest common divisor</returns>
        public static int GcdBinary(params int[] a)
        {
            double time;
            return GcdDelegate(out time, GcdBinary, a);
        }

        /// <summary>
        /// Method for calculating GCD by Shtein approach
        /// </summary>
        /// <param name="time">time of calculation GCD</param>
        /// <param name="a">array of integers</param>
        /// <returns>greatest common divisor</returns>
        public static int GcdBinary(out double time, params int[] a)
        {
            return GcdDelegate(out time, GcdBinary, a);
        }

        /// <summary>
        /// Method for calculating GCD by custom algorithm
        /// </summary>
        /// <param name="calculate">delegate describing method of calculation GCD</param>
        /// <param name="a">array of integers</param>
        /// <returns>greatest common divisor</returns>
        public static int GcdDelegate(CalculateGcd calculate, params int[] a)
        {
            double time;
            return GcdDelegate(out time, calculate, a);
        }

        /// <summary>
        /// Method for calculating GCD by custom algorithm
        /// </summary>
        /// <param name="time">time of calculation GCD</param>
        /// <param name="calculate">delegate describing method of calculation GCD</param>
        /// <param name="a">array of integers</param>
        /// <returns>greatest common divisor</returns>
        public static int GcdDelegate(out double time, CalculateGcd calculate, params int[] a)
        {
            if (ReferenceEquals(a, null)) throw new ArgumentNullException();
            if (ReferenceEquals(calculate, null)) calculate = GcdEuclid;

            var timer = Stopwatch.StartNew();
            if (a.Length == 0)
            {
                timer.Stop();
                time = timer.Elapsed.TotalMilliseconds;
                return 0;
            }

            var gcd = a[0];
            for (var i = 1; i < a.Length; i++)
            {
                gcd = calculate(a[i], gcd);
            }

            timer.Stop();
            time = timer.Elapsed.TotalMilliseconds;

            return gcd;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method for swaping two itegers
        /// </summary>
        /// <param name="a">first integer</param>
        /// <param name="b">second integer</param>
        private static void Swap(ref int a, ref int b)
        {
            var t = b;
            b = a;
            a = t;
        }

        /// <summary>
        /// Method for calculating GCD for two integers by Euclid approach
        /// </summary>
        /// <param name="a">first integer</param>
        /// <param name="b">second integer</param>
        /// <returns>greatest common divisor</returns>
        private static int GcdEuclid(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0 && a != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }
            return b == 0 ? a : b;
        }

        /// <summary>
        /// Method for calculating GCD for two integers by Shtein approach
        /// </summary>
        /// <param name="a">first integer</param>
        /// <param name="b">second integer</param>
        /// <returns>greatest common divisor</returns>
        private static int GcdBinary(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0 || b == 0)
            {
                if (a == 0) return b;
                if (b == 0) return a;
            }

            int shift;
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0) a >>= 1;
            do
            {
                while ((b & 1) == 0) b >>= 1;
                if (a > b) Swap(ref a, ref b);
                b -= a;
            } while (b != 0);

            return a << shift;
        }
        #endregion
    }
}
