using System;
using System.Collections.Generic;

namespace BinarySearchLib
{
    /// <summary>
    /// Class contains methods for searching elements in generic array
    /// </summary>
    public class BinarySearchClass
    {
        /// <summary>
        /// Searches the sorted generic array for an element using the custom comparer and returns the zero-based index of the element.
        /// </summary>
        /// <typeparam name="T">type of elements in the array</typeparam>
        /// <param name="a">sorted array to be searched</param>
        /// <param name="elem">element to find in the array</param>
        /// <param name="comparer">custom comparer</param>
        /// <returns>The zero-based index of item in the sorted array, if item is found; otherwise, a negative number -1</returns>
        #region Public Methods
        public static int BinarySearch<T>(T[] a, T elem, IComparer<T> comparer)
        {
            return ReferenceEquals(comparer, null) ? BinarySearch(a, elem, null as Comparison<T>) : 
                BinarySearch(a, elem, comparer.Compare);
        }

        /// <summary>
        /// Searches the sorted generic array for an element using the custom comparision delegate and returns the zero-based index of the element.
        /// </summary>
        /// <typeparam name="T">type of elements in the array</typeparam>
        /// <param name="a">sorted array to be searched</param>
        /// <param name="elem">element to find in the array</param>
        /// <param name="comparisonDelegate">custom comparision delegate</param>
        /// <returns>The zero-based index of item in the sorted array, if item is found; otherwise, a negative number -1</returns>
        public static int BinarySearch<T>(T[] a, T elem, Comparison<T> comparisonDelegate = null)
        {
            if (ReferenceEquals(a, null)) throw new ArgumentNullException();
            
            if (ReferenceEquals(comparisonDelegate, null))
            {
                comparisonDelegate = Comparer<T>.Default.Compare;
            }

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (comparisonDelegate(a[i], a[i+1]) > 0) throw new ArgumentException("The array must be sorted.");
            }

            int l = 0, r = a.Length;
            while (l < r)
            {
                int i = (l + r)/2;
                if (comparisonDelegate(a[i], elem) < 0)
                     l = i + 1;
                else if (comparisonDelegate(a[i], elem) > 0)
                     r = i;
                else return i;
            }
            
            return -1;
        }
        #endregion
    }
}
