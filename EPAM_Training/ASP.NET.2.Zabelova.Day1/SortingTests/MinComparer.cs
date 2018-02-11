using System.Collections.Generic;

namespace SortingTests
{
    public class MinComparer : IComparer<int[]>
    {   
        public int Compare(int[] a, int[] b)
        {
            return CompareFunctions.CompareMin(a, b);
        }
    }
}