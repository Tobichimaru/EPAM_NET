using System;
using System.Collections.Generic;
using System.Diagnostics;
using MathExtension;
using NUnit.Framework;

namespace MathExtensionNUnitTests
{
    [TestFixture]
    public class MathFunctionsNUnitTests
    {
        #region Test Methods
        [Test, TestCaseSource(typeof(LogicFactoryClass), "TwoParamsTestData")]
        public int GcdEuclid_TwoParams_WithYield(int a, int b)
        {
            return MathFunctions.GcdEuclid(a, b);
        }

        [Test, TestCaseSource(typeof(LogicFactoryClass), "SeveralParamsTestData")]
        public int GcdEuclid_SeveralParams_WithYield(int[] a)
        {
            return MathFunctions.GcdEuclid(a);
        }

        [Test, TestCaseSource(typeof(LogicFactoryClass), "TwoParamsTestData")]
        public int GcdBinary_TwoParams_WithYield(int a, int b)
        {
            return MathFunctions.GcdBinary(a, b);
        }

        [Test, TestCaseSource(typeof(LogicFactoryClass), "SeveralParamsTestData")]
        public int GcdBinary_SeveralParams_WithYield(int[] a)
        {
            return MathFunctions.GcdBinary(a);
        }

        [Test, TestCaseSource(typeof(LogicFactoryClass), "TwoParamsTestData")]
        public int GcdCustom_TwoParams_WithYield(int a, int b)
        {
            return MathFunctions.GcdDelegate(CustomGcd, a, b);
        }

        [Test, TestCaseSource(typeof(LogicFactoryClass), "SeveralParamsTestData")]
        public int GcdCustom_SeveralParams_WithYield(int[] a)
        {
            return MathFunctions.GcdDelegate(CustomGcd, a);
        }

        [Test, TestCaseSource(typeof(LogicFactoryClass), "SeveralParamsTestData")]
        public int GcdCustom_SeveralParams_Time_WithYield(int[] a)
        {
            double time;
            int actual = MathFunctions.GcdDelegate(out time, CustomGcd, a);

            Debug.WriteLine(time);
            return actual;
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

    public class LogicFactoryClass
    {
        #region Property
        public IEnumerable<TestCaseData> TwoParamsTestData
        {
            get
            {
                yield return new TestCaseData(10, 3).Returns(1);
                yield return new TestCaseData(250, 40).Returns(10);
                yield return new TestCaseData(12, -4).Returns(4);
                yield return new TestCaseData(-8, -2).Returns(2);
                yield return new TestCaseData(0, 6).Returns(6);
            }
        }

        public IEnumerable<TestCaseData> SeveralParamsTestData
        {
            get
            {
                yield return new TestCaseData(new[] { 0, 15, 9, 18, 0, 6 }).Returns(3);
                yield return new TestCaseData(new[] { 4, 16, 80, 8, 88, 32 }).Returns(4);
                yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            }
        }
        #endregion
    }
}
