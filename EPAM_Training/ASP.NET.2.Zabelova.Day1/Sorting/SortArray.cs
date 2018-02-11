using System;
using System.Collections.Generic;

namespace Sorting
{
    /// <summary>
    /// Class for sorting arrays
    /// </summary>
    public static class SortArray
    {
        #region Public Method
        /// <summary>
        /// Method for sorting array
        /// </summary>
        /// <param name="a">array for sorting</param>
        /// <param name="comparisonDelegate">delegate for sorting</param>
        public static void Sort<T>(T[] a, Comparison<T> comparisonDelegate)
        {
            if (ReferenceEquals(a, null))
            {
                throw new ArgumentNullException();
            }

            if (ReferenceEquals(comparisonDelegate, null))
            {
                comparisonDelegate = delegate(T lhs, T rhs)
                {
                    if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null)) return 0;
                    if (ReferenceEquals(lhs, null)) return -1;
                    if (ReferenceEquals(rhs, null)) return 1;
                    if (lhs.GetHashCode() < rhs.GetHashCode())
                        return 1;
                    if (lhs.GetHashCode() > rhs.GetHashCode())
                        return -1;
                    return 0;
                };
            }

            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (comparisonDelegate(a[i], a[j]) < 0)
                    {
                        Swap(ref a[i], ref a[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Method for sorting array
        /// </summary>
        /// <param name="a">array for sorting</param>
        /// <param name="comparer">interface for sorting</param>
        public static void Sort<T>(T[] a, IComparer<T> comparer)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException();
            }
            Sort(a, comparer.Compare);
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Method for swaping two items
        /// </summary>
        /// <param name="a">first item</param>
        /// <param name="b">second item</param>
        private static void Swap<T>(ref T a, ref T b)
        {
            T varArr = a;
            a = b;
            b = varArr;
        }
        #endregion
    }
}