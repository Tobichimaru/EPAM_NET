using System;
using NUnit.Framework;
using RootOfNumber;

namespace RootOfNumberNUnutTests
{
    [TestFixture]
    public class RootTest
    {
        #region Test Methods
        [TestCase(216, 3, Result = 6)]
        [TestCase(-216, 3, Result = Double.NaN)]
        [TestCase(8, -3, Result = 0.5)]
        [TestCase(Double.NaN, 3, ExpectedException = typeof(ArgumentException))]
        public double NRootOfNumber_DefaultEps_Test(double number, int n)
        {
            double actual = Root.NRoot(number, n, eps);
            return Math.Round(actual, 6);
        }

        [TestCase(8, 3, 0.001, 4, Result = 2)]
        [TestCase(27, 3, 0.01, 3, Result = 3)]
        [TestCase(8, 3, -5, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase(8, 3, 5, 0, ExpectedException = typeof(ArgumentException))]
        public double NRootOfNumber_CustomEps_Test(double number, int n, double epsilon, int digits)
        {
            double actual = Root.NRoot(number, n, epsilon);
            return Math.Round(actual, digits);
        }
        #endregion

        #region Private Fields
        private const double eps = 0.000001;
        #endregion
    }
}
