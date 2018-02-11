using System;
using System.Collections.Generic;

namespace MergeSortLib
{
    /// <summary>
    /// Class contains methods for sorting generic array by Merge Sort algorithm
    /// </summary>
    public static class MergeSort
    {
        #region Public Methods
        /// <summary>
        /// This method sorts generic array by merge sort algorithm
        /// </summary>
        /// <typeparam name="T">type of items in the array</typeparam>
        /// <param name="a">array for sorting</param>
        /// <param name="comparisonDelegate">delegate for comparing elemets in the array</param>
        public static void Sort<T>(T[] a, Comparison<T> comparisonDelegate = null)
        {
            if (ReferenceEquals(a, null))
                throw new ArgumentNullException();

            Sort(a, 0, a.Length - 1, comparisonDelegate);
        }

        /// <summary>
        /// This method sorts generic array by merge sort algorithm
        /// </summary>
        /// <typeparam name="T">type of items in the array</typeparam>
        /// <param name="a">array for sorting</param>
        /// <param name="left">start position of sorting</param>
        /// <param name="right">end position of sorting</param>
        /// <param name="comparisonDelegate">delegate for comparing elemets in the array</param>
        public static void Sort<T>(T[] a, int left, int right, Comparison<T> comparisonDelegate = null)
        {
            if (ReferenceEquals(a, null)) throw new ArgumentNullException();

            if (ReferenceEquals(comparisonDelegate, null))
            {
                comparisonDelegate = delegate(T lhs, T rhs)
                {
                    if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null)) return 0;
                    if (ReferenceEquals(lhs, null)) return -1;
                    if (ReferenceEquals(rhs, null)) return 1;
                    return string.Compare(lhs.ToString(), rhs.ToString(), StringComparison.Ordinal);
                };
            }

            if (right <= left) return;

            T[] auxiliary = new T[a.Length];
            left = Math.Max(left, 0);
            right = Math.Min(right, a.Length);

            SortPart(a, auxiliary, comparisonDelegate, left, right);
        }

        /// <summary>
        /// This method sorts generic array by merge sort algorithm
        /// </summary>
        /// <typeparam name="T">type of items in the array</typeparam>
        /// <param name="a">array for sorting</param>
        /// <param name="comparer">interface object for comparing elemets in the array</param>
        public static void Sort<T>(T[] a, IComparer<T> comparer)
        {
            if (ReferenceEquals(a, null))
                throw new ArgumentNullException();

            Sort(a, 0, a.Length - 1, comparer);
        }

        /// <summary>
        /// This method sorts generic array by merge sort algorithm
        /// </summary>
        /// <typeparam name="T">type of items in the array</typeparam>
        /// <param name="a">array for sorting</param>
        /// <param name="left">start position of sorting</param>
        /// <param name="right">end position of sorting</param>
        /// <param name="comparer">interface object for comparing elemets in the array</param>
        public static void Sort<T>(T[] a, int left, int right, IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null))
                Sort(a, left, right);
            else
                Sort(a, left, right, comparer.Compare);
        }
        #endregion

        #region Private Methods
        private static void SortPart<T>(T[] a, T[] auxiliary, Comparison<T> comparisonDelegate, int left, int right)
        {
            if (right <= left) return;
            int middle = left + (right - left) / 2;
            SortPart(a, auxiliary, comparisonDelegate, left, middle);
            SortPart(a, auxiliary, comparisonDelegate, middle + 1, right);
            Merge(a, auxiliary, comparisonDelegate, left, middle, right);
        }

        private static void Merge<T>(T[] a, T[] auxiliary, Comparison<T> comparisonDelegate, int left, int middle, int right)
        {
            for (int k = left; k <= right; k++)
                auxiliary[k] = a[k];

            int lpi = left, rpi = middle + 1;
            for (int k = left; k <= right; k++)
            {
                if (lpi > middle)
                    a[k] = auxiliary[rpi++];
                else if (rpi > right)
                    a[k] = auxiliary[lpi++];
                else a[k] = comparisonDelegate(auxiliary[rpi], auxiliary[lpi]) > 0 ? auxiliary[rpi++] : auxiliary[lpi++];
            }
        }
        #endregion
    }
}