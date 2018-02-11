using System;
using System.Collections.Generic;

namespace Matrix.Matrices
{
    /// <summary>
    ///     Represents an Symmetric Matrix data type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
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
                base[i, j] = value;

                if (i != j)
                {
                    base[j, i] = value;
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Empty initialization of the <see cref="SymmetricMatrix{T}" /> for inheritance
        /// </summary>
        protected SymmetricMatrix()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SymmetricMatrix{T}" /> class with a empty array of elements.
        /// </summary>
        /// <param name="n">dimension of the matrix</param>
        public SymmetricMatrix(int n) : base(n)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SymmetricMatrix{T}" /> class with a multidimensional array of
        ///     elements.
        /// </summary>
        /// <param name="elements">The elements of the matrix.</param>
        /// <exception cref="System.ArgumentException">
        ///     Matrix is not symmetric
        /// </exception>
        public SymmetricMatrix(T[,] elements)
            : base(elements)
        {
            for (var i = 0; i < elements.GetLength(0); i++)
            {
                for (var j = 0; j < elements.GetLength(1); j++)
                {
                    if (i != j && !EqualityComparer<T>.Default.Equals(elements[i, j], elements[j, i]))
                        throw new ArgumentException("Inputed matrix is not symmetric");
                }
            }
        }

        #endregion
    }
}