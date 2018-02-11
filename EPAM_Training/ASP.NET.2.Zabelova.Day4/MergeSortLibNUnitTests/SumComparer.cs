using System.Collections.Generic;

namespace MergeSortLibNUnitTests
{
    public class SumComparer : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            return CompareFunctions.CompareSum(a, b);
        }
    }
}