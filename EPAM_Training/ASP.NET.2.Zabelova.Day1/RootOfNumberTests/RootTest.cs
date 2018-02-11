using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RootOfNumber;

namespace RootOfNumberTests
{
    [TestClass]
    public class RootTest
    {
        #region Test Methods
        [TestMethod]
        public void Root_PositiveDouble_PositivePower()
        {
            double number = 216;
            int n = 3;
            double expected = 6;

            double actual = Root.NRoot(number, n);

            Assert.IsTrue(Math.Abs(expected - actual) < eps);
        }

        [TestMethod]
        public void Root_NegativeDouble_PositivePower()
        {
            double number = -216;
            int n = 3;
            double expected = Double.NaN;

            double actual = Root.NRoot(number, n);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Root_PositiveDouble_NegativePower()
        {
            double number = 8;
            int n = -3;
            double expected = 0.5;

            double actual = Root.NRoot(number, n);

            Assert.IsTrue(Math.Abs(expected - actual) < eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Root_NaNDouble_PositivePower()
        {
            double number = Double.NaN;
            int n = 3;

            double actual = Root.NRoot(number, n);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Root_PositiveDouble_PositivePower_NegativeEps()
        {
            double number = 8;
            int n = 3;
            double eps = -5;

            double actual = Root.NRoot(number, n, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Root_PositiveDouble_PositivePower_LargeEps()
        {
            double number = 8;
            int n = 3;
            double eps = 5000;

            double actual = Root.NRoot(number, n, eps);
        }

        [TestMethod]
        public void Root_PositiveDouble_PositivePower_SomeEps()
        {
            double number = 8;
            int n = 3;
            double eps = 0.0001;
            double expected = 2;

            double actual = Root.NRoot(number, n, eps);

            Assert.IsTrue(Math.Abs(expected - actual) < eps);
        }
        #endregion

        #region Private Fields
        private readonly double eps = 0.000001;
        #endregion
    }
}
