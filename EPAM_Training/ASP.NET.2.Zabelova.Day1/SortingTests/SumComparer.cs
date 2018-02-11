using System.Collections.Generic;

namespace SortingTests
{
    public class SumComparer : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            return CompareFunctions.CompareSum(a, b);
        }
    }
}