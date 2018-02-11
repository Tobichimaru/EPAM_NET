using System;
using System.Collections.Generic;
using NUnit.Framework;
using BinarySearchLib;

namespace BinarySearchLibTests
{
    public class BinarySearchClassTests
    {
        #region Test Methods
        [TestCase(new[] {1, 2, 4, 5, 8, 9}, 5, Result = 3)]
        [TestCase(new[] { 2, 1, 4, 5, 8, 9 }, 5, ExpectedException = typeof(ArgumentException))]
        [TestCase(new[] { -9, -8, -6, -4}, -9, Result = 0)]
        [TestCase(new[] { 1, 2, 4, 5, 8, 9 }, 3, Result = -1)]
        [TestCase(new[] {1}, 1, Result = 0)]
        [TestCase(new int[] { }, -2, Result = -1)]
        [TestCase(null, -2, ExpectedException = typeof(ArgumentNullException))]
        public int BinarySearch_Integers_Test(int[] a, int elem)
        {
            return BinarySearchClass.BinarySearch(a, elem, Comparer<int>.Default.Compare); 
        }

        [TestCase(new[] { "aaa", "bbb", "ccc"}, "ccc", Result = 2)]
        [TestCase(new[] { "abc", "aab" }, "fff", ExpectedException = typeof(ArgumentException))]
        [TestCase(new[] { "aab", "aac", "aad" }, "aa", Result = -1)]
        [TestCase(new[] { null, "aab", "aac", "aad" }, null, Result = 0)]
        public int BinarySearch_Strings_Test(string[] a, string elem)
        {
            return BinarySearchClass.BinarySearch(a, elem, Comparer<string>.Default.Compare);
        }

        [TestCase(new[] { 1.0, 2, 4, 5.3, 8.1, 9 }, 5.3, Result = 3)]
        [TestCase(new[] { -9.6, -8, -6.1, -4 }, -9.6, Result = 0)]
        [TestCase(new[] { -9.6, -8, -6.1, -4 }, -15, Result = -1)]
        public int BinarySearch_Doubles_NullDelegate_Test(double[] a, double elem)
        {
            return BinarySearchClass.BinarySearch(a, elem, null as IComparer<double>);
        }

        [TestCase(new[] { 'a', 'b', 'c' }, 'c', Result = 2)]
        [TestCase(new[] { 'b', 'f', 'z' }, 'b', Result = 0)]
        [TestCase(new[] { 'b' }, 'a', Result = -1)]
        public int BinarySearch_Chars_WithoutDelegate_Test(char[] a, char elem)
        {
            return BinarySearchClass.BinarySearch(a, elem);
        }
        #endregion
    }
}
