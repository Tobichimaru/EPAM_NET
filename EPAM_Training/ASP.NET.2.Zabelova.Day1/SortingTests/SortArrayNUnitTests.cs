using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Sorting;

namespace SortingTests
{
    [TestFixture]
    public class SortArrayNUnitTests
    {
        #region Public Functions
        [Test, TestCaseSource(typeof(MyFactoryClass), "SumTestData")]
        public bool SumSortTest(int[][] a, int[][] expected)
        {
            SortArray.Sort(a, new SumComparer());
            return CompareArrays(a, expected);
        }

        [Test, TestCaseSource(typeof(MyFactoryClass), "MinTestData")]
        public bool MinSortTest(int[][] a, int[][] expected)
        {
            SortArray.Sort(a, new MinComparer());
            return CompareArrays(a, expected);
        }

        [Test, TestCaseSource(typeof(MyFactoryClass), "MaxTestData")]
        public bool MaxSortTest(int[][] a, int[][] expected)
        {
            SortArray.Sort(a, new MaxComparer());
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

        private bool CompareArrays(int[][] a, int[][] b)
        {
            PrintArray(a);
            PrintArray(b);

            if (a.GetLength(0) != b.GetLength(0)) return false;
            bool equal = true;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (ReferenceEquals(a[i], null) || ReferenceEquals(b[i], null))
                {
                    if (!(ReferenceEquals(a[i], null) && ReferenceEquals(b[i], null)))
                    {
                        equal = false;
                        break;
                    }
                    continue;;
                }
                if (a[i].Length != b[i].Length)
                {
                    equal = false;
                    break;
                }
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (a[i][j].CompareTo(b[i][j]) != 0)
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