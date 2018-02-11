using System;
using System.Collections.Generic;
using System.Diagnostics;
using Matrix.Event;
using Matrix.Exception;
using Matrix.Extension;
using Matrix.Matrices;
using NUnit.Framework;

namespace MatrixUnitTests
{
    [TestFixture]
    public class MatrixTest
    {
        [TestCase(new[] {3, 3, 5}, Result = 3)]
        [TestCase(new[] {1}, Result = 1)]
        [TestCase(null, ExpectedException = typeof (ArgumentNullException))]
        public int DiagonalMatrix_Create_Test(int[] data)
        {
            var diagonalMatrix = new DiagonalMatrix<int>(data);
            Debug.WriteLine(diagonalMatrix.ToString());
            return diagonalMatrix.Height;
        }

        [TestCase(3)]
        [TestCase(0, ExpectedException = typeof (ArgumentOutOfRangeException))]
        public void DiagonalMatrix_Indexator_Test(int n)
        {
            var symmetricMatrix = new SymmetricMatrix<string>(n);
            Debug.WriteLine(symmetricMatrix.ToString());
            symmetricMatrix.ElementChanged += MatrixElemChanged;
            symmetricMatrix[1, 0] = "aaa";
            symmetricMatrix[2, 0] = "bbb";
            Debug.WriteLine(symmetricMatrix.ToString());
        }

        [TestCase(1, 1)]
        [TestCase(0, 1, ExpectedException = typeof (ArgumentException))]
        public void DiagonalMatrix_Indexator_Test(int i, int j)
        {
            var diagonalMatrix = new DiagonalMatrix<SymmetricMatrix<double>>(3);
            Debug.WriteLine(diagonalMatrix.ToString());
            diagonalMatrix.ElementChanged += MatrixElemChanged;
            diagonalMatrix[i, j] = new SymmetricMatrix<double>(new double[,] {{1, 2}, {2, 1}});
            Debug.WriteLine(diagonalMatrix.ToString());
        }


        private static void MatrixElemChanged(object sender, MatrixEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        [Test, TestCaseSource(typeof (LogicFactoryClass), "SumMatrixCaseDatas")]
        public Matrix<int> MatrixAddition_Test(int[,] elem1, int[,] elem2)
        {
            var matrix1 = new Matrix<int>(elem1);
            var matrix2 = new Matrix<int>(elem2);
            var result = MatrixAdditionExtension.Add(matrix1, matrix2);
            Debug.WriteLine(result.ToString());
            return (Matrix<int>) result;
        }

        [Test, TestCaseSource(typeof (LogicFactoryClass), "SymmetricMatrixCaseDatas")]
        public int SymmetricMatrix_Create_Test(double[,] data)
        {
            var symmetricMatrix = new SymmetricMatrix<double>(data);
            Debug.WriteLine(symmetricMatrix.ToString());
            return symmetricMatrix.Height;
        }

        [Test, TestCaseSource(typeof (LogicFactoryClass), "SymmetricMatrixChangeCaseDatas")]
        public bool SymmetricMatrix_Indexator_Test(char[,] data, int i, int j)
        {
            var symmetricMatrix = new SymmetricMatrix<char>(data);
            Debug.WriteLine(symmetricMatrix.ToString());
            symmetricMatrix[i, j] = 'x';
            return symmetricMatrix[i, j] == symmetricMatrix[j, i];
        }
    }

    public class LogicFactoryClass
    {
        #region Property

        public IEnumerable<TestCaseData> SymmetricMatrixCaseDatas
        {
            get
            {
                yield return new TestCaseData(new[,] {{1.0, 2}, {2, 1}}).Returns(2);
                yield return new TestCaseData(new[,] {{1.0}}).Returns(1);
                yield return new TestCaseData(new[,] {{1, 1.1}, {2, 1}}).Throws(typeof (ArgumentException));
                yield return new TestCaseData(null).Throws(typeof (ArgumentNullException));
            }
        }


        public IEnumerable<TestCaseData> SymmetricMatrixChangeCaseDatas
        {
            get
            {
                yield return new TestCaseData(new[,] {{'a', '2'}, {'2', 'a'}}, 0, 1).Returns(true);
                yield return
                    new TestCaseData(new[,] {{'a', 'a', 'f'}, {'a', 'a', '2'}, {'f', '2', 'a'}}, 2, 1).Returns(true);
                yield return
                    new TestCaseData(new[,] {{'a', '2'}, {'2', 'a'}}, 2, 2).Throws(typeof (ArgumentOutOfRangeException))
                    ;
            }
        }

        public IEnumerable<TestCaseData> SumMatrixCaseDatas
        {
            get
            {
                yield return
                    new TestCaseData(new[,] {{1, 2, 3}, {2, 0, 1}}, new[,] {{2, -1, 0}, {-2, 4, -1}}).Returns(
                        new Matrix<int>(new[,] {{3, 1, 3}, {0, 4, 0}}));
                yield return
                    new TestCaseData(new[,] {{1, 2}, {1, 2}}, new[,] {{1, 0}, {0, 1}}).Returns(
                        new Matrix<int>(new[,] {{2, 2}, {1, 3}}));
                yield return
                    new TestCaseData(new[,] {{1, 2}, {2, 0}}, new[,] {{2, -1, 0}, {-2, 4, -1}}).Throws(
                        typeof (DimensionsMismatchException<int>));
            }
        }

        #endregion
    }
}