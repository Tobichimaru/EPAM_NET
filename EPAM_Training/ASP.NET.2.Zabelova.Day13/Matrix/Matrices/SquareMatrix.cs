using System;

namespace Matrix.Matrices
{
    /// <summary>
    ///     Represents an Square Matrix data type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T> : AbstractMatrix<T>
    {
        #region Constructors

        /// <summary>
        ///     Empty initialization of the <see cref="SquareMatrix{T}" /> for inheritance
        /// </summary>
        protected SquareMatrix()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SquareMatrix{T}" /> class with a empty array of elements.
        /// </summary>
        /// <param name="n">the dimension of the matrix</param>
        public SquareMatrix(int n) : base(n, n)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SquareMatrix{T}" /> class with a empty array of elements.
        /// </summary>
        /// <param name="diagonal">the diagonal elements of the matrix</param>
        public SquareMatrix(T[] diagonal)
            : base(diagonal)
        {
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="SquareMatrix{T}" /> class with a multidimensional array of elements.
        /// </summary>
        /// <param name="elements">The elements of the matrix.</param>
        /// <exception cref="System.ArgumentException">
        ///     Matrix is not square-type
        /// </exception>
        public SquareMatrix(T[,] elements)
            : base(elements)
        {
            if (elements.GetLength(0) != elements.GetLength(1))
            {
                throw new ArgumentException("Matrix should have equal number of rows and columns.");
            }
        }

        #endregion
    }
}