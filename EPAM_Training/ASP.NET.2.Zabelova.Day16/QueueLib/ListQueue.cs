using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueLib
{
    /// <summary>
    ///     Represents a first-in, first-out collection of objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListQueue<T> : IQueue<T>
    {
        #region Private Fields

        private Node<T> first;
        private Node<T> last;

        #endregion

        #region Class Node

        private class Node<TNode>
        {
            public TNode key;
            public Node<TNode> next;
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the Queue class that is empty and has the default initial capacity.
        /// </summary>
        public ListQueue()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the Queue class that contains elements copied from the specified collection and has
        ///     sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new Queue.</param>
        public ListQueue(IEnumerable<T> collection)
        {
            if (ReferenceEquals(collection, null)) throw new ArgumentNullException();

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
        private class CustomIterator : IEnumerator<T>
        {
            private readonly Node<T> first;
            private Node<T> current;

            /// <summary>
            ///     Initializes iterator with collection
            /// </summary>
            /// <param name="collection"></param>
            public CustomIterator(ListQueue<T> collection)
            {
                first = collection.first;
                current = first;
            }

            public T Current
            {
                get
                {
                    if (ReferenceEquals(current, null)) throw new InvalidOperationException();
                    return current.key;
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Reset()
            {
                current = first;
            }

            public bool MoveNext()
            {
                if (ReferenceEquals(current.next, null)) return false;
                current = current.next;
                return true;
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

        public void Enqueue(T key)
        {
            var old = last;
            last = new Node<T>
            {
                key = key,
                next = null
            };

            Count++;
            if (IsEmpty()) first = last;
            else old.next = last;
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException();

            var key = first.key;
            first = first.next;
            Count--;

            return key;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException();
            return first.key;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public void Clear()
        {
            first = null;
            last = null;
            Count = 0;
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

        #endregion
    }
}