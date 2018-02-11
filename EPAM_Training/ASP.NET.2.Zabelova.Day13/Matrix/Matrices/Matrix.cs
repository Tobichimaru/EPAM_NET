namespace Matrix.Matrices
{
    /// <summary>
    ///     Represents an Matrix data type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Matrix<T> : AbstractMatrix<T>
    {
        #region Constructors

        /// <summary>
        ///     Empty initialization of the <see cref="Matrix{T}" /> for inheritance
        /// </summary>
        protected Matrix()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Matrix{T}" /> class with a empty array of elements.
        /// </summary>
        /// <param name="n">number of rows</param>
        /// <param name="m">number of columns</param>
        public Matrix(int n, int m) : base(n, m)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Matrix{T}" /> class with a multidimensional array of elements.
        /// </summary>
        /// <param name="diagonal">The diagonal elements of the matrix.</param>
        public Matrix(T[] diagonal)
            : base(diagonal)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Matrix{T}" /> class with a multidimensional array of elements.
        /// </summary>
        /// <param name="elements">The elements of the matrix.</param>
        public Matrix(T[,] elements) : base(elements)
        {
        }

        #endregion
    }
}