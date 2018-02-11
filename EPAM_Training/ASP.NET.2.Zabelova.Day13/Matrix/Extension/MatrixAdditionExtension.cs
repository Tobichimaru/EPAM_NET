using System;
using Matrix.Exception;
using Matrix.Matrices;

namespace Matrix.Extension
{
    /// <summary>
    ///     Provides extension for matrix addition
    /// </summary>
    public static class MatrixAdditionExtension
    {
        #region Public Methods

        /// <summary>
        ///     Sums the two matrices without any check regarding the dimensions.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        /// <returns>The return value is the sum of the two matrices..</returns>
        public static AbstractMatrix<T> Add<T>(this AbstractMatrix<T> left, AbstractMatrix<T> right)
        {
            if (ReferenceEquals(right, null)) throw new ArgumentNullException("right", "Matrix is null");
            if (ReferenceEquals(left, null)) throw new ArgumentNullException("left", "Matrix is null");
            if (left.Height != right.Height) throw new DimensionsMismatchException<T>(left, right);
            if (left.Width != right.Width) throw new DimensionsMismatchException<T>(left, right);
            
            var result = new Matrix<T>(left.Height, right.Width);

            for (var i = 0; i < left.Height; i++)
            {
                for (var j = 0; j < left.Width; j++)
                {
                    result[i, j] = (dynamic) left[i, j] + (dynamic)right[i, j];
                }
            }
            return result;
        }

        #endregion
    }
}