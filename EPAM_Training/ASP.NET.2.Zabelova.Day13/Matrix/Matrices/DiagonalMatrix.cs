using System;

namespace Matrix.Matrices
{
    /// <summary>
    ///     Represents an Diagonal Matrix data type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Indexator

        /// <summary>
        ///     Gets the element of type T at i and j index.
        /// </summary>
        /// <param name="i">The row index</param>
        /// <param name="j">The column index</param>
        /// <exception cref="System.ArgumentException">
        ///     Impossible to change non-diagonal elements of the matrix
        /// </exception>
        /// <returns>T</returns>
        public override T this[int i, int j]
        {
            get { return base[i, j]; }
            set
            {
                if (i != j)
                {
                    throw new ArgumentException("Impossible to change non-diagonal elements of the matrix");
                }
                base[i, j] = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Empty initialization of the <see cref="DiagonalMatrix{T}" /> for inheritance
        /// </summary>
        protected DiagonalMatrix()
        {
        }

        /// <summary>
        ///     Initializes <see cref="DiagonalMatrix{T}" /> by list of diagonal elements
        /// </summary>
        /// <param name="diagonalEntries">the diagonal elements of the matrix</param>
        public DiagonalMatrix(T[] diagonalEntries)
            : base(diagonalEntries)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiagonalMatrix{T}" /> class with a empty array of elements.
        /// </summary>
        /// <param name="n">dimension of the matrix</param>
        public DiagonalMatrix(int n) : base(n)
        {
        }

        #endregion
    }
}