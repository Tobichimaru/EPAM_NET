using Matrix.Matrices;

namespace Matrix.Exception
{
    /// <summary>
    ///     An exception that indicates a mismatch between the dimension of two matrices.
    /// </summary>
    /// <typeparam name="T">The data type of the matrices.</typeparam>
    public class DimensionsMismatchException<T> : System.Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DimensionsMismatchException{T}" /> class.
        /// </summary>
        /// <param name="left">The first matrix.</param>
        /// <param name="right">The second matrix.</param>
        public DimensionsMismatchException(AbstractMatrix<T> left, AbstractMatrix<T> right)
            : base("The matrices have have different dimensions (left{" + left.Height + "}x{" + left.Width + "};"
                   + " right {" + right.Height + "}x{" + right.Width + "}).")
        {
        }
    }
}