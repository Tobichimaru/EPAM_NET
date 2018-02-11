using System.Collections.Generic;

namespace QueueLib
{
    /// <summary>
    ///     Describes methods for FIFO collections
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueue<T> : IEnumerable<T>
    {
        /// <summary>
        ///     Gets the number of elements contained in the Queue.
        /// </summary>
        int Count { get; }

        /// <summary>
        ///     Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <returns>The object that is removed from the beginning of the Queue</returns>
        T Dequeue();

        /// <summary>
        ///     Adds an object to the end of the Queue.
        /// </summary>
        /// <param name="key">The object to add to the Queue.The value can be null for reference types.</param>
        void Enqueue(T key);

        /// <summary>
        ///     Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        /// <returns>The object at the beginning of the Queue</returns>
        T Peek();

        /// <summary>
        ///     Checks whether is collection empty or not
        /// </summary>
        /// <returns>true - if collection os empty, otherwise - false</returns>
        bool IsEmpty();

        /// <summary>
        ///     Removes all objects from the Queue.
        /// </summary>
        void Clear();
    }
}