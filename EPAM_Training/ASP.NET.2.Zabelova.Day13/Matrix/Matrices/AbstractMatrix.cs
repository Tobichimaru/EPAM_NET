using System;
using System.Collections.Generic;
using System.Text;
using Matrix.Event;
using Matrix.Extension;

namespace Matrix.Matrices
{
    /// <summary>
    ///     Represents an AbstractMatrix type.
    /// </summary>
    public abstract class AbstractMatrix<T>
    {
        #region Private Fields

        /// <summary>
        ///     The elements of the AbstractMatrix.
        /// </summary>
        private readonly T[,] array;

        #endregion

        #region Constructors

        /// <summary>
        ///     Empty initialization of the <see cref="AbstractMatrix{T}" /> for inheritance
        /// </summary>
        protected AbstractMatrix()
        {
            array = new T[1, 1];
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AbstractMatrix{T}" /> class with a empty array of elements.
        /// </summary>
        /// <param name="n">number of rows</param>
        /// <param name="m">number of columns</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     AbstractMatrix dimensions is non positive
        /// </exception>
        protected AbstractMatrix(int n, int m)
        {
            if (n < 1) throw new ArgumentOutOfRangeException("n", "AbstractMatrix dimensions should be positive!");
            if (m < 1) throw new ArgumentOutOfRangeException("m", "AbstractMatrix dimensions should be positive!");
            Height = n;
            Width = m;
            array = new T[n, m];
        }

        /// <summary>
        ///     Initializes <see cref="AbstractMatrix{T}" /> by list of diagonal elements
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        ///     elements is null
        /// </exception>
        /// <param name="diagonalEntries"></param>
        protected AbstractMatrix(T[] diagonalEntries)
        {
            if (ReferenceEquals(diagonalEntries, null))
                throw new ArgumentNullException("diagonalEntries", "diagonalEntries elements is null");
            Height = diagonalEntries.Length;
            Width = diagonalEntries.Length;
            array = new T[Height, Width];
            for (var i = 0; i < diagonalEntries.Length; i++)
            {
                try
                {
                    array[i, i] = this.DeepClone(diagonalEntries[i]);
                }
                catch (ArgumentException)
                {
                    array[i, i] = diagonalEntries[i];
                }
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AbstractMatrix{T}" /> class with a multidimensional array of elements.
        /// </summary>
        /// <param name="elements">The elements of the AbstractMatrix.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     The AbstractMatrix cannot be empty.
        ///     or
        ///     The structure of the AbstractMatrix is unbalanced.
        /// </exception>
        protected AbstractMatrix(T[,] elements)
        {
            if (ReferenceEquals(elements,null)) throw new ArgumentNullException("elements");
            if (elements.Length == 0)
                throw new ArgumentOutOfRangeException("elements", "The Matrix cannot be empty.");
            Height = elements.GetLength(0);
            Width = elements.GetLength(1);
            array = new T[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    try
                    {
                        array[i, j] = this.DeepClone(elements[i, j]);
                    }
                    catch (ArgumentException)
                    {
                        array[i, i] = elements[i, j];
                    }
                }
            }
        }

        #endregion

        #region Event Logic

        #region Event

        /// <summary>
        ///     Event provides information on changing some element of the AbstractMatrix
        /// </summary>
        public event EventHandler<MatrixEventArgs> ElementChanged;

        #endregion

        #region Protected Methods

        /// <summary>
        ///     Determines if some element of the AbstractMatrix was changed
        /// </summary>
        /// <param name="e">event info</param>
        protected virtual void OnElementChanged(MatrixEventArgs e)
        {
            if (!ReferenceEquals(ElementChanged, null))
                ElementChanged.Invoke(this, e);
        }

        #endregion

        #endregion

        #region Public Properties

        /// <summary>
        ///     Number of rows
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        ///     Number of columns
        /// </summary>
        public int Width { get; private set; }

        #region Indexator

        /// <summary>
        ///     Gets the element of type T at i and j index.
        /// </summary>
        /// <param name="i">The row index</param>
        /// <param name="j">The column index</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     Index out of bounds of the AbstractMatrix
        /// </exception>
        /// <returns>T</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                if (IsRowOutOfBounds(i)) throw new ArgumentOutOfRangeException("i", "Index out of bounds.");
                if (IsColumnOutOfBounds(j)) throw new ArgumentOutOfRangeException("j", "Index out of bounds.");

                T item;
                try
                {
                    item = this.DeepClone(array[i, j]);
                }
                catch (System.Exception)
                {
                    item = array[i, j];
                }
                return item;
            }
            set
            {
                if (IsRowOutOfBounds(i)) throw new ArgumentOutOfRangeException("i", "Index out of bounds.");
                if (IsColumnOutOfBounds(j)) throw new ArgumentOutOfRangeException("j", "Index out of bounds.");

                if (EqualityComparer<T>.Default.Equals(array[i, j], value)) return;

                OnElementChanged(new MatrixEventArgs("Element [" + i + ", " + j + "] has been changed"));

                T item;
                try
                {
                    item = this.DeepClone(value);
                }
                catch (System.Exception)
                {
                    item = value;
                }

                array[i, j] =  item;
            }
        }

        #endregion

        #endregion

        #region Public Methods

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((AbstractMatrix<T>) obj);
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        public bool Equals(AbstractMatrix<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return AreValuesOfMatricesEqual(this, other);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            if (ReferenceEquals(array, null)) return 0;
            return array.GetHashCode();
        }

        /// <summary>
        /// Generates string representation of the matrix
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString()
        {
            if (ReferenceEquals(array, null))
            {
                return "";
            }
            var result = new StringBuilder();
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (ReferenceEquals(array[i, j], null)) result.Append("null ");
                    else result.Append(array[i, j] + " ");
                }
                result.Append("\n");
            }
            return result.ToString();
        }

        #endregion

        #region Private Methods

        private bool IsRowOutOfBounds(int i)
        {
            return i < 0 || i >= Height;
        }

        private bool IsColumnOutOfBounds(int j)
        {
            return j < 0 || j >= Width;
        }

        private bool AreValuesOfMatricesEqual(AbstractMatrix<T> left, AbstractMatrix<T> right)
        {
            if (left.Width != right.Width) return false;
            if (left.Height != right.Height) return false;

            for (var i = 0; i < left.Height; i++)
            {
                for (var j = 0; j < left.Width; j++)
                {
                    if (!EqualityComparer<T>.Default.Equals(left[i, j], right[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}