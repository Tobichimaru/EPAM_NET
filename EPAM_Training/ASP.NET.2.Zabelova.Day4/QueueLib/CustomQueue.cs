using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueLib
{
    /// <summary>
    /// Represents a first-in, first-out collection of objects.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class CustomQueue<T> : IEnumerable<T>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Queue class that is empty and has the default initial capacity.
        /// </summary>
        public CustomQueue()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the Queue class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the Queue can contain</param>
        public CustomQueue(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException();
            Initialize(capacity);
        }

        /// <summary>
        /// Initializes a new instance of the Queue class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new Queue.</param>
        public CustomQueue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null)) throw new ArgumentNullException();
           
            int length = 16;
            IEnumerable<T> enumerable = collection as IList<T> ?? collection.ToList();

            int collectionLength = enumerable.Count();
            while (length < collectionLength) length *= 2;

            Initialize(length);

            foreach (T elem in enumerable)
            {
                Enqueue(elem);
            }
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets the number of elements contained in the Queue.
        /// </summary>
        public int Count { get; private set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Removes all objects from the Queue.
        /// </summary>
        public void Clear()
        {
            Count = 0;
            begin = 0;
            end = -1;
        }

        /// <summary>
        /// Determines whether an element is in the Queue.
        /// </summary>
        /// <param name="item">The object to locate in the Queue.The value can be null for reference types.</param>
        /// <returns>true if item is found in the Queue; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return Enumerable.Contains(this, item);
        }

       /// <summary>
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <returns>The object that is removed from the beginning of the Queue</returns>
        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException();

            Count--;
            T key = elems[begin];
            begin = (begin + 1) % maxCapacity;
            return key;
        }

        /// <summary>
        /// Adds an object to the end of the Queue.
        /// </summary>
        /// <param name="key">The object to add to the Queue.The value can be null for reference types.</param>
        public void Enqueue(T key)
        {
            end = (end + 1) % maxCapacity;
            elems[end] = key;
            Count++;

            if (Count == maxCapacity)
            {
                maxCapacity *= 2;
                ResizeQueue(maxCapacity);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the Queue.
        /// </summary>
        /// <returns>An Enumerator for the Queue.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (Count == 0)
                yield break;

            if (begin < end)
            {
                for (int i = begin; i <= end; i++)
                    yield return elems[i];
            }
            else
            {
                for (int i = begin; i < maxCapacity; i++)
                    yield return elems[i];
                for (int i = 0; i <= end; i++)
                    yield return elems[i];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        /// <returns>The object at the beginning of the Queue</returns>
        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException();
            return elems[begin];
        }
        #endregion

        #region Private Methods
        private void Initialize(int initialLength = 16)
        {
            maxCapacity = initialLength;
            elems = new T[maxCapacity];
            Count = 0;
            begin = 0;
            end = -1;
        }

        private void ResizeQueue(int size)
        {
            T[] newElems = new T[size];

            if (begin <= end)
            {
                Array.Copy(elems, begin, newElems, 0, Count);
            }
            else
            {
                Array.Copy(elems, begin, newElems, 0, elems.Length - begin);
                Array.Copy(elems, 0, newElems, elems.Length - begin, end + 1);
            }

            elems = newElems;
        }
        #endregion

        #region Fields
        private T[] elems;
        private int maxCapacity;
        private int begin;
        private int end;
        #endregion
    }
}