using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathExtension;

namespace MathExtesionTests
{
    [TestClass]
    public class MathFunctionsTests
    {
        #region Test Methods
        [TestMethod]
        public void DCG_Euclid_TwoPositiveNumbers()
        {
            int a = 250, b = 40, expected = 10;

            int actual = MathFunctions.GcdEuclid(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Euclid_OneNegative_OnePositive_Numbers()
        {
            int a = 250, b = -40, expected = 10;

            int actual = MathFunctions.GcdEuclid(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Euclid_SixPositiveNumbers_Time()
        {
            int[] data = new[] { 4, 16, 80, 8, 88, 32 };
            int expected = 4;
            double time;

            int actual = MathFunctions.GcdEuclid(out time, data);

            Debug.WriteLine(time);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Euclid_TwoNegativeNumbers()
        {
            int a = -250, b = -40, expected = 10;

            int actual = MathFunctions.GcdEuclid(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Euclid_SixPositiveNumbers()
        {
            int[] data = new[] {4, 16, 80, 8, 88, 32};
            int expected = 4;

            int actual = MathFunctions.GcdEuclid(data);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Binary_TwoPositiveNumbers()
        {
            int a = 250, b = 40, expected = 10;

            int actual = MathFunctions.GcdBinary(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Binary_OneNegative_OnePositive_Numbers()
        {
            int a = 250, b = -40, expected = 10;

            int actual = MathFunctions.GcdBinary(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Binary_TwoNegativeNumbers()
        {
            int a = -250, b = -40, expected = 10;

            int actual = MathFunctions.GcdBinary(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Binary_SixPositiveNumbers()
        {
            int[] data = new[] { 4, 16, 80, 8, 88, 32 };
            int expected = 4;

            int actual = MathFunctions.GcdBinary(data);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Binary_SixPositiveNumbers_Time()
        {
            int[] data = new[] { 4, 16, 80, 8, 88, 32 };
            int expected = 4;
            double time;

            int actual = MathFunctions.GcdBinary(out time, data);

            Debug.WriteLine(time);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Custom_TwoPositiveNumbers()
        {
            int a = 250, b = 40, expected = 10;

            int actual = MathFunctions.GcdDelegate(CustomGcd, a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Custom_OneNegative_OnePositive_Numbers()
        {
            int a = 250, b = -40, expected = 10;

            int actual = MathFunctions.GcdDelegate(CustomGcd, a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Custom_TwoNegativeNumbers()
        {
            int a = -250, b = -40, expected = 10;

            int actual = MathFunctions.GcdDelegate(CustomGcd, a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Custom_SixPositiveNumbers()
        {
            int[] data = new[] { 4, 16, 80, 8, 88, 32 };
            int expected = 4;

            int actual = MathFunctions.GcdDelegate(CustomGcd, data);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Custom_SixPositiveNumbers_Time()
        {
            int[] data = new[] { 4, 16, 80, 8, 88, 32 };
            int expected = 4;
            double time;

            int actual = MathFunctions.GcdDelegate(out time, CustomGcd, data);

            Debug.WriteLine(time);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_CustomNull_SixPositiveNumbers()
        {
            int[] data = new[] { 4, 16, 80, 8, 88, 32 };
            int expected = 4;

            int actual = MathFunctions.GcdDelegate(null, data);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DCG_Custom_NullNumbers()
        {
            MathFunctions.GcdDelegate(CustomGcd, null);
        }

        #endregion 

        #region Private Delegate

        private readonly MathFunctions.CalculateGcd CustomGcd = delegate(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0 && a != 0)
            {
                if (a > b) a -= b;
                else b -= a;
            }
            return b == 0 ? a : b;
        };

        #endregion
    }
}
