using System;
using NUnit.Framework;
using QueueLib;

namespace QueueLibNUnitTests
{
    [TestFixture]
    public class ArrayQueueNUnitTests
    {
        [TestCase(new[] {"cat", "dog", "cow"}, "kitten", Result = false)]
        [TestCase(new[] {"cat", "dog", "cow"}, "dog", Result = true)]
        [TestCase(null, "", ExpectedException = typeof(ArgumentNullException))]
        public bool ArrayQueueFindElemTest(string[] a, string elem)
        {
            var queue = new ArrayQueue<string>(a);
            return queue.Contains(elem);
        }

        [TestCase(new[] {3, 4, 5, 6, 7, 8}, Result = 0)]
        [TestCase(new[] {3, 4}, Result = 0)]
        public int ArrayQueueInitializeAndClearTest(int[] a)
        {
            var queue = new ArrayQueue<int>(a);
            queue.Clear();
            return queue.Count;
        }

        [TestCase(6, Result = 0)]
        [TestCase(null, Result = 0)]
        [TestCase(-6, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public int ArrayQueueInitializeTest(int capacity)
        {
            var queue = new ArrayQueue<int>(capacity);
            return queue.Count;
        }

        [TestCase(new[] {3, 4, 5, 6, 7, 8}, Result = 3)]
        [TestCase(new[] {8, 4}, Result = 8)]
        [TestCase(new int[] {}, ExpectedException = typeof(InvalidOperationException))]
        public int ArrayQueuePeekElemTest(int[] a)
        {
            var queue = new ArrayQueue<int>(a);
            return queue.Peek();
        }

        [TestCase(new[] {3, 4, 5, 6, 7, 8}, 5, Result = 8)]
        [TestCase(new[] {8, 4, 100, 15}, 2, Result = 100)]
        [TestCase(new[] {1, 2, 3}, 3, ExpectedException = typeof(InvalidOperationException))]
        [TestCase(new[] {1, 2, 3}, 4, ExpectedException = typeof(InvalidOperationException))]
        public int ArrayQueueDequeElemsTest(int[] a, int number)
        {
            var queue = new ArrayQueue<int>(a);
            while (number > 0 && !queue.IsEmpty())
            {
                queue.Dequeue();
                number--;
            }
            return queue.Peek();
        }

        [TestCase(new[] {"cat", "dog", "cow"}, "kitten", Result = false)]
        [TestCase(new[] {"cat", "dog", "cow"}, "dog", Result = true)]
        [TestCase(null, "", ExpectedException = typeof(ArgumentNullException))]
        public bool ListQueueFindElemTest(string[] a, string elem)
        {
            var queue = new ListQueue<string>(a);
            return queue.Contains(elem);
        }

        [TestCase(new[] {3, 4, 5, 6, 7, 8}, Result = 0)]
        [TestCase(new[] {3, 4}, Result = 0)]
        public int ListQueueInitializeAndClearTest(int[] a)
        {
            var queue = new ListQueue<int>(a);
            queue.Clear();
            return queue.Count;
        }

        [TestCase(new[] {3, 4, 5, 6, 7, 8}, Result = 3)]
        [TestCase(new[] {8, 4}, Result = 8)]
        [TestCase(new int[] {}, ExpectedException = typeof(InvalidOperationException))]
        public int ListQueuePeekElemTest(int[] a)
        {
            var queue = new ListQueue<int>(a);
            return queue.Peek();
        }

        [TestCase(new[] {3, 4, 5, 6, 7, 8}, 5, Result = 8)]
        [TestCase(new[] {8, 4, 100, 15}, 2, Result = 100)]
        [TestCase(new[] {1, 2, 3}, 3, ExpectedException = typeof(InvalidOperationException))]
        [TestCase(new[] {1, 2, 3}, 4, ExpectedException = typeof(InvalidOperationException))]
        public int ListQueueDequeElemsTest(int[] a, int number)
        {
            var queue = new ListQueue<int>(a);
            while (number > 0)
            {
                queue.Dequeue();
                number--;
            }
            return queue.Peek();
        }
    }
}