using System;
using System.Collections.Generic;
using MathExtension;
using NUnit.Framework;

namespace MathExtensionUnitTest
{
    [TestFixture]
    class PolynomUnitTest
    {
        #region Test Methods
        [Test, TestCaseSource(typeof(PolynomFactoryClass), "SumTestCaseDatas")]
        public Polynom PolynomsSumTest(double[] leftCoeff, double[] rightCoeff)
        {
            Polynom left = leftCoeff;
            Polynom right = rightCoeff;
            return left + right;
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "DifferenceTestCaseDatas")]
        public Polynom PolynomsDifferenceTest(double[] leftCoeff, double[] rightCoeff)
        {
            Polynom left = leftCoeff;
            Polynom right = rightCoeff;
            return left - right;
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "MultiplyTestCaseDatas")]
        public Polynom PolynomsMultiplyTest(double[] leftCoeff, double[] rightCoeff)
        {
            Polynom left = leftCoeff;
            Polynom right = rightCoeff;
            if (leftCoeff.Length == 1)
            {
                return leftCoeff[0] * right;
            }
            if (rightCoeff.Length == 1)
            {
                return left * rightCoeff[0];
            }
            return left * right;
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "DivideTestCaseDatas")]
        public Polynom PolynomsDivideTest(Polynom left, Polynom right)
        {
            return left / right;
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "ModTestCaseDatas")]
        public Polynom PolynomsModTest(Polynom left, Polynom right)
        {
            return left % right;
        }
        
        [Test, TestCaseSource(typeof(PolynomFactoryClass), "EqualityTestCaseDatas")]
        public bool PolynomsEqualityTest(Polynom left, Polynom right)
        {
            return left == right;
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "EqualityTestCaseDatas")]
        public bool PolynomsInequalityTest(Polynom left, Polynom right)
        {
            return !(left != right);
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "InverseTestCaseDatas")]
        public Polynom InversePolynomTest(Polynom polynom)
        {
            return -polynom;
        }

        [Test, TestCaseSource(typeof(PolynomFactoryClass), "CalculateValueTestCaseDatas")]
        public double CalculateValuePolynomTest(Polynom polynom, double value)
        {
            return polynom.Calculate(value);
        }
        #endregion
    }

    public class PolynomFactoryClass
    {
        #region Test Case Datas
        public IEnumerable<TestCaseData> SumTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(new[] { 1, 0, 3, 0.5 }, new[] { 0, 2.5, 1, 2 }).Returns(new Polynom(1, 2.5, 4, 2.5));
                yield return new TestCaseData(new[] { 1.0, 0 }, new[] { 0, 2.5, 1, 2 }).Returns(new Polynom(1, 2.5, 1, 2));
                yield return new TestCaseData(new[] { 1.0, 2 }, new[] { 5, 6555.8 }).Returns(new Polynom(6, 6557.8));
                yield return new TestCaseData(null, new[] { 0, 1.0 }).Throws(typeof(ArgumentNullException));
            }
        }

        public IEnumerable<TestCaseData> DifferenceTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(new[] { 1, 0, 3, 0.5 }, new[] { 0, 2.5, 1, 2 }).Returns(new Polynom(1, -2.5, 2, -1.5));
                yield return new TestCaseData(new[] { 1.0, 2 }, new[] { 5, 6555.8 }).Returns(new Polynom(-4, -6553.8));
                yield return new TestCaseData(null, new[] { 0, 1.0 }).Throws(typeof(ArgumentNullException));
            }
        }

        public IEnumerable<TestCaseData> MultiplyTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(new[] { 1, 0.5 }, new[] { 0, 2.0 }).Returns(new Polynom(0, 2, 1));
                yield return new TestCaseData(new[] { 1.0 }, new[] { 5, 6555.8 }).Returns(new Polynom(5, 6555.8));
                yield return new TestCaseData(new[] { 0.1 }, new[] { 0, 2.0 }).Returns(new Polynom(0, 0.2));
                yield return new TestCaseData(new[] { 1.0, 3 }, new[] { 2.0 }).Returns(new Polynom(2.0, 6));
                yield return new TestCaseData(null, new[] { 0, 1.0 }).Throws(typeof(ArgumentNullException));
            }
        }

        public IEnumerable<TestCaseData> EqualityTestCaseDatas
        {
            get
            {
                yield return new TestCaseData((Polynom)new[] { 1, 0.5 }, (Polynom)new[] { 0, 2.0 }).Returns(false);
                yield return new TestCaseData((Polynom)new[] { 1.0, 3.0 }, (Polynom)new[] { 1.0, 3.0 }).Returns(true);
                yield return new TestCaseData(null, (Polynom)new[] { 1.0, 3.0 }).Returns(false);
            }
        }

        public IEnumerable<TestCaseData> InverseTestCaseDatas
        {
            get
            {
                yield return new TestCaseData((Polynom) new[] {1, 0.5}).Returns(new Polynom(-1, -0.5));
                yield return new TestCaseData((Polynom) new[] {-1.0, -3.0}).Returns(new Polynom(1, 3));
                yield return new TestCaseData(null).Throws(typeof (ArgumentNullException));
            }
        }

        public IEnumerable<TestCaseData> DivideTestCaseDatas
        {
            get
            {
                yield return new TestCaseData((Polynom)new[] { 0, 0, 3.0 }, (Polynom)new[] { 0, 1.0 }).Returns(new Polynom(0, 3.0));
                yield return new TestCaseData((Polynom)new[] { 0, 0, 15.0 }, (Polynom)new[] { 3.0 }).Returns(new Polynom(0, 0, 5.0));
                yield return new TestCaseData((Polynom)new[] { 0, 0, 6.0 }, (Polynom)new[] { 0, 2.0 }).Returns(new Polynom(0, 3.0));
                yield return new TestCaseData(null, (Polynom)new[] { 0, 2, 4.0 }).Throws(typeof(ArgumentNullException));
            }
        }
        
        public IEnumerable<TestCaseData> ModTestCaseDatas
        {
            get
            {
                yield return new TestCaseData((Polynom)new[] { 0, 0, 3.0 }, (Polynom)new[] { 0, 1.0 }).Returns(new Polynom(0));
                yield return new TestCaseData((Polynom)new[] { -42, 0, -12, 1.0 }, (Polynom)new[] { -3, 1.0}).Returns(new Polynom(-123));
                yield return new TestCaseData((Polynom)new[] { 0, 2, 4.0 }, (Polynom)new[] { 1, 1.0 }).Returns(new Polynom(2.0));
                yield return new TestCaseData(null, (Polynom)new[] { 0, 2, 4.0 }).Throws(typeof(ArgumentNullException));
            }
        }

        public IEnumerable<TestCaseData> CalculateValueTestCaseDatas
        {
            get
            {
                yield return new TestCaseData((Polynom)new[] {0, 2.0}, 3).Returns(6.0);
                yield return new TestCaseData((Polynom)new[] {1, 1.0, 4.0}, 2).Returns(19.0);
                yield return new TestCaseData(null, 2).Throws(typeof(NullReferenceException));
            }
        }
        #endregion
    }
}