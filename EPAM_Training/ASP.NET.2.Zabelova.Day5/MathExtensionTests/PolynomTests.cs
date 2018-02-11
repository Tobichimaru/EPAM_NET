using System;
using MathExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathExtensionTests
{
    [TestClass]
    public class PolynomTests
    {
        #region Test Methods

        #region Sum Method Tests
        [TestMethod]
        public void Polynom_Sum_Test()
        {
            Polynom left = new[] { 1, 0, 3, 0.5 };
            Polynom right = new[] { 0, 2.5, 1, 2 };
            Polynom expected = new[] {1, 2.5, 4, 2.5};

            Polynom actual = left + right;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Polynom_Sum_OneNull_Test()
        {
            Polynom left = null;
            Polynom right = new[] { 0, 2.5, 1, 2 };
            Polynom actual = left + right;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Polynom_Add_OneNull_Test()
        {
            Polynom left = new[] { 0, 2.5, 1, 2 };
            Polynom right = null;
            Polynom actual = left.Add(right);
        }
        #endregion

        #region Subtract Method Test
        [TestMethod]
        public void Polynom_Difference_Test()
        {
            Polynom left = new[] { 1, 0, 3, 0.5 };
            Polynom right = new[] { 0, 2.5, 1, 2 };
            Polynom expected = new[] {1, -2.5, 2, -1.5};

            Polynom actual = left - right;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Polynom_Difference_OneNull_Test()
        {
            Polynom left = null;
            Polynom right = new[] { 0, 2.5, 1, 2 };
            Polynom actual = left - right;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Polynom_Subtract_OneNull_Test()
        {
            Polynom left = new[] { 0, 2.5, 1, 2 };
            Polynom right = null;
            Polynom actual = left.Subtract(right);
        }
        #endregion

        #region Multiply Method Test
        [TestMethod]
        public void Polynom_Multiply_Test()
        {
            Polynom left = new[] { 1, 0.5 };
            Polynom right = new[] { 0, 2.0 };
            Polynom expected = new[] {0, 2.0, 1};

            Polynom actual = left * right;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Polynom_Multiply_OneNull_Test()
        {
            Polynom left = null;
            Polynom right = new[] { 0, 2.5, 1, 2 };
            Polynom actual = left * right;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Polynom_Multiplication_OneNull_Test()
        {
            Polynom left = new[] { 0, 2.5, 1, 2 };
            Polynom right = null;
            Polynom actual = left.Multiply(right);
        }
        #endregion

        #region Equality Methods Test
        [TestMethod]
        public void Polynom_Inequality_Test()
        {
            Polynom left = new[] { 1, 0.5 };
            Polynom right = new[] { 0, 2.0 };

            Assert.IsTrue(left != right);
        }

        [TestMethod]
        public void Polynom_Equality_Test()
        {
            Polynom left = new[] { 1, 0.5 };
            Polynom right = new[] { 1, 0.5 };

            Assert.IsTrue(left == right);
        }

        [TestMethod]
        public void Polynom_NullEquality_Test()
        {
            Polynom left = new[] { 1, 0.5 };
            Polynom right =  null;

            Assert.IsFalse(left == right);
        }
        #endregion

        #region Divide Method Test
        [TestMethod]
        public void Polynom_Divide_Test()
        {
            Polynom left = new[] { 0, 0, 3.0 };
            Polynom right = new[] { 0, 1.0 };
            Polynom expected = new[] { 0, 3.0};

            Polynom actual = left / right;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Polynom_Divide_OneNull_Test()
        {
            Polynom left = null;
            Polynom right = new[] { 0, 2.5, 1, 2 };
            Polynom actual = left / right;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Polynom_Division_OneNull_Test()
        {
            Polynom left = new[] { 0, 2.5, 1, 2 };
            Polynom right = null;
            Polynom actual = left.Divide(right);
        }

        [TestMethod]
        public void Polynom_Mod_Test()
        {
            Polynom left = new[] { -42, 0, -12, 1.0 };
            Polynom right = new[] { -3, 1.0 };
            Polynom expected = -123;

            Polynom actual = left % right;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Calculate Value Method Test
        [TestMethod]
        public void Polynom_CalculateValue_Test()
        {
            Polynom polynom = new[] { 1, 1.0, 4.0 };
            double value = 2.0;
            double expected = 19.0;

            Polynom actual = polynom.Calculate(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Polynom_CalculateNegativeValue_Test()
        {
            Polynom polynom = new[] { 0, 2.0 };
            double value = -3.0;
            double expected = -6.0;

            Polynom actual = polynom.Calculate(value);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #endregion
    }
}
