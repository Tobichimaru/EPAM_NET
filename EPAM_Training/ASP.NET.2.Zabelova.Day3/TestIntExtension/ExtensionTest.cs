using System;
using System.Collections.Generic;
using NUnit.Framework;
using IntExtension;

namespace TestIntExtension
{
    /// <summary>
    /// Class for testing IntExtension methods
    /// </summary>
    [TestFixture]
    public class ExtensionTest
    {
        #region Public Methods
        /// <summary>
        /// This method checks the correctness of calculation of hex representation of given integer
        /// </summary>
        [Test, TestCaseSource(typeof(ExtensionFactoryClass), "TestCaseDatas")]
        public string ConvertIntegerToHexTest(int value)
        {
            return value.ToHex();
        }
        #endregion
    }

    /// <summary>
    /// Class for generating test case data
    /// </summary>
    class ExtensionFactoryClass
    {
        #region Property
        /// <summary>
        /// Property contains test case datas for creating hex representation of integer
        /// </summary>
        public static IEnumerable<TestCaseData> TestCaseDatas
        {
            get
            {
                Random random = new Random();
                int x;
                for (int i = 0; i < 10; i++)
                {
                    x = random.Next(0, Int32.MaxValue);
                    yield return new TestCaseData(x).Returns(Convert.ToString(x, 16));
                }
                for (int i = 0; i < 10; i++)
                {
                    x = random.Next(Int32.MinValue, -1);
                    yield return new TestCaseData(x).Returns("-" + Convert.ToString(Math.Abs(x), 16));
                }
            }
        }
        #endregion
    }
}
