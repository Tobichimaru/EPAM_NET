using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueLib
{
    /// <summary>
    ///     Represents a first-in, first-out collection of objects.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class ArrayQueue<T> : IQueue<T>
    {
        #region Private Fields

        private T[] elems;
        private int maxCapacity;
        private int begin;
        private int end;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the Queue class that is empty and has the default initial capacity.
        /// </summary>
        public ArrayQueue()
        {
            Initialize();
        }

        /// <summary>
        ///     Initializes a new instance of the Queue class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the Queue can contain</param>
        public ArrayQueue(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException();
            Initialize(capacity);
        }

        /// <summary>
        ///     Initializes a new instance of the Queue class that contains elements copied from the specified collection and has
        ///     sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new Queue.</param>
        public ArrayQueue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null)) throw new ArgumentNullException();

            var length = 16;

            var collectionLength = collection.Count();
            while (length < collectionLength) length *= 2;

            Initialize(length);

            using (var en = collection.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    Enqueue(en.Current);
                }
            }
        }

        #endregion

        #region Iterator

        /// <summary>
        ///     Inner class Iterator
        /// </summary>
        public class CustomIterator : IEnumerator<T>
        {
            private readonly T[] collection;
            private int currentIndex;

            /// <summary>
            ///     Initializes iterator with collection
            /// </summary>
            /// <param name="collection"></param>
            public CustomIterator(ArrayQueue<T> collection)
            {
                currentIndex = -1;
                this.collection = collection.elems;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.Length)
                    {
                        throw new InvalidOperationException();
                    }
                    return collection[currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Reset()
            {
                currentIndex = -1;
            }
            
            public bool MoveNext()
            {
                return ++currentIndex < collection.Length;
            }

            public void Dispose()
            {
            }
        }

        #endregion

        #region INumerable implementation

        /// <summary>
        ///     Returns an enumerator that iterates through the Queue.
        /// </summary>
        /// <returns>An Enumerator for the Queue.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator(this);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Public Methods and Properties

        public int Count { get; private set; }

        public void Clear()
        {
            if (begin <= end)
            {
                Array.Clear(elems, begin, Count);
            }
            else
            {
                Array.Clear(elems, begin, elems.Length - begin);
                Array.Clear(elems, 0, end + 1);
            }

            Count = 0;
            begin = 0;
            end = -1;
        }

        /// <summary>
        ///     Determines whether an element is in the Queue.
        /// </summary>
        /// <param name="item">The object to locate in the Queue.The value can be null for reference types.</param>
        /// <returns>true if item is found in the Queue; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return Enumerable.Contains(this, item);
        }

        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException();

            Count--;
            var key = elems[begin];
            begin = (begin + 1)%maxCapacity;
            return key;
        }

        public void Enqueue(T key)
        {
            end = (end + 1)%maxCapacity;
            elems[end] = key;
            Count++;

            if (Count == maxCapacity)
            {
                maxCapacity *= 2;
                ResizeQueue(maxCapacity);
            }
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException();
            return elems[begin];
        }

        public bool IsEmpty()
        {
            return Count == 0;
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
            var newElems = new T[size];

            if (size > 0)
            {
                if (begin <= end)
                {
                    Array.Copy(elems, begin, newElems, 0, Count);
                }
                else
                {
                    Array.Copy(elems, begin, newElems, 0, elems.Length - begin);
                    Array.Copy(elems, 0, newElems, elems.Length - begin, end + 1);
                }
            }

            elems = newElems;
        }

        #endregion
    }
}