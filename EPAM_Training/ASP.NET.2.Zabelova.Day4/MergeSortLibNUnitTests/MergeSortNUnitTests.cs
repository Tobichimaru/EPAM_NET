using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using MergeSortLib;

namespace MergeSortLibNUnitTests
{
    [TestFixture]
    public class MergeSortNUnitTests
    {
        #region Public Functions
        [Test, TestCaseSource(typeof(MyFactoryClass), "SumTestData")]
        public bool SumSortDelegateTest(int[][] a, int[][] expected)
        {
            MergeSort.Sort(a, CompareFunctions.CompareSum);
            return CompareArrays(a, expected);
        }

        [Test, TestCaseSource(typeof(MyFactoryClass), "MinTestData")]
        public bool MinSortDelegateTest(int[][] a, int[][] expected)
        {
            MergeSort.Sort(a, CompareFunctions.CompareMin);
            return CompareArrays(a, expected);
        }

        [Test, TestCaseSource(typeof(MyFactoryClass), "MaxTestData")]
        public bool MaxSortDelegateTest(int[][] a, int[][] expected)
        {
            MergeSort.Sort(a, CompareFunctions.CompareMax);
            return CompareArrays(a, expected);
        }

        [Test, TestCaseSource(typeof(MyFactoryClass), "SumTestData")]
        public bool SumSortInterfaceTest(int[][] a, int[][] expected)
        {
            MergeSort.Sort(a, new SumComparer());
            return CompareArrays(a, expected);
        }

        [Test, TestCaseSource(typeof(MyFactoryClass), "MinTestData")]
        public bool MinSortInterfaceTest(int[][] a, int[][] expected)
        {
            MergeSort.Sort(a, new MinComparer());
            return CompareArrays(a, expected);
        }

        [Test, TestCaseSource(typeof(MyFactoryClass), "MaxTestData")]
        public bool MaxSortInterfaceTest(int[][] a, int[][] expected)
        {
            MergeSort.Sort(a, new MaxComparer());
            return CompareArrays(a, expected);
        }

        [Test, TestCaseSource(typeof(MyFactoryClass), "DefaultTestData")]
        public bool DefaultSortTest(int[][] a, int[][] expected)
        {
            MergeSort.Sort(a);
            return CompareArrays(a, expected);
        }
        #endregion

        #region Private Functions
        private void PrintArray(int[][] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (ReferenceEquals(a[i], null))
                    Debug.Write("null");
                else
                {
                    for (int j = 0; j < a[i].Length; j++)
                        Debug.Write(a[i][j] + " ");
                }
                Debug.WriteLine(' ');
            }
            Debug.WriteLine("");
        }

        private bool CompareArrays(int[][] a, int[][] expected)
        {
            Debug.WriteLine("Sorted array:");
            PrintArray(a);
            Debug.WriteLine("Expected array:");
            PrintArray(expected);

            if (a.GetLength(0) != expected.GetLength(0)) return false;
            bool equal = true;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (ReferenceEquals(a[i], null) || ReferenceEquals(expected[i], null))
                {
                    if (!(ReferenceEquals(a[i], null) && ReferenceEquals(expected[i], null)))
                    {
                        equal = false;
                        break;
                    }
                    continue;
                }
                if (a[i].Length != expected[i].Length)
                {
                    equal = false;
                    break;
                }
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (a[i][j].CompareTo(expected[i][j]) != 0)
                    {
                        equal = false;
                        break;
                    }
                }
            }
            return equal;
        }
        #endregion
    }

    public class MyFactoryClass
    {
        #region Properties
        public IEnumerable<TestCaseData> SumTestData
        {
            get
            {
                yield return new TestCaseData(new[]  
                {
                    new[] {1, 2, 1, 2},
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    new[] {-10, 0, 10}
                }, new[]
                {
                    new[] {-10, 0, 10},
                    new[] {3, 1, 0},
                    new[] {1, 2, 1, 2},
                    new[] {5, 4, 7, 2, -2}
                }).Returns(true);

                yield return new TestCaseData(new[]  {
                    new[] {1, 2, 1, 2},
                    null,
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    null,
                    null,
                    new[] {-10, 0, 10}
                }, new[]
                {
                    new[] {-10, 0, 10},
                    new[] {3, 1, 0},
                    new[] {1, 2, 1, 2},
                    new[] {5, 4, 7, 2, -2},
                    null,
                    null,
                    null
                }).Returns(true);
            }
        }

        public IEnumerable<TestCaseData> DefaultTestData
        {
            get
            {
                yield return new TestCaseData(new[]
                {
                    new[] {1, 2, 1, 2},
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    new[] {-10, 0, 10}
                }, new[]
                {
                    new[] {1, 2, 1, 2},
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    new[] {-10, 0, 10}
                }).Returns(true);

                yield return new TestCaseData(new[]
                {
                    new[] {1, 2, 1, 2},
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    new[] {-10, 0, 10}
                }, new[]
                {
                    new[] {1, 2, 1, 2},
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    new[] {-10, 0, 10}
                }).Returns(true);
            }
        }

        public IEnumerable<TestCaseData> MinTestData
        {
            get
            {
                yield return new TestCaseData(new[]  {
                    new[] {1, 2, 1, 2},
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    new[] {-10, 0, 10}
                }, new[]
                {
                    new[] {-10, 0, 10},
                    new[] {5, 4, 7, 2, -2},
                    new[] {3, 1, 0},
                    new[] {1, 2, 1, 2}  
                }).Returns(true);

                yield return new TestCaseData(new[]  {
                    new[] {1, 2, 1, 2},
                    null,
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    null,
                    null,
                    new[] {-10, 0, 10}
                }, new[]
                {
                    new[] {-10, 0, 10},
                    new[] {5, 4, 7, 2, -2},
                    new[] {3, 1, 0},
                    new[] {1, 2, 1, 2},
                    null,
                    null,
                    null
                }).Returns(true);
            }
        }

        public IEnumerable<TestCaseData> MaxTestData
        {
            get
            {
                yield return new TestCaseData(new[]
                {
                    new[] {1, 2, 1, 2},
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    new[] {-10, 0, 10}
                }, new[]
                {
                    new[] {1, 2, 1, 2},
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    new[] {-10, 0, 10}
                }).Returns(true);

                yield return new TestCaseData(new[]
                {
                    new[] {1, 2, 1, 2},
                    null,
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    null,
                    null,
                    new[] {-10, 0, 10}
                }, new[]
                {
                    new[] {1, 2, 1, 2},
                    new[] {3, 1, 0},
                    new[] {5, 4, 7, 2, -2},
                    new[] {-10, 0, 10},
                    null,
                    null,
                    null
                }).Returns(true);
            }
        }
        #endregion
    }
}