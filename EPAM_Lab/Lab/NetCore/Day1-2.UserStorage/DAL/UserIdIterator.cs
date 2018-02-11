using System;
using System.Collections;
using System.Collections.Generic;

namespace DAL
{
    /// <summary>
    ///     Iterator which generates even numbers
    /// </summary>
    [Serializable]
    public class UserIdIterator : IEnumerator<int>
    {
        #region Constructor
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserIdIterator"/> class and sets current element
        /// </summary>
        public UserIdIterator()
        {
            this.Current = 0;
        }

        /// <summary>
        ///      Initializes a new instance of the <see cref="UserIdIterator"/> class with custom start point
        /// </summary>
        /// <param name="current">start point</param>
        public UserIdIterator(int current)
        {
            this.Current = current;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets Current element
        /// </summary>
        public int Current { get; private set; }

        /// <summary>
        ///     Gets Current element
        /// </summary>
        object IEnumerator.Current => this.Current;

        #endregion

        #region Public Methods

        /// <summary>
        ///     Disposes an object
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        ///     Moves current to the next element
        /// </summary>
        /// <returns>true, if the move was successful, otherwise false</returns>
        public bool MoveNext()
        {
            unchecked
            {
                this.Current += 2;
            }

            return this.Current % 2 == 0;
        }

        /// <summary>
        ///     Resets current element to the start point
        /// </summary>
        public void Reset()
        {
            this.Current = 2;
        }

        #endregion
    }
}