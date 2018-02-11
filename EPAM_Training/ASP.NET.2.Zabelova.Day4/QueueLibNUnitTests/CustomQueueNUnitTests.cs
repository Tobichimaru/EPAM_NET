using System;
using NUnit.Framework;
using QueueLib;

namespace QueueLibNUnitTests
{
    [TestFixture]
    public class CustomQueueNUnitTests
    {
        #region Test Methods
        [TestCase(new[] { "cat", "dog", "cow" }, "kitten", Result = false)]
        [TestCase(new[] { "cat", "dog", "cow" }, "dog", Result = true)]
        [TestCase(null, "", ExpectedException = typeof(ArgumentNullException))]
        public bool FindElemTest(String[] a, String elem)
        {
            CustomQueue<String> queue = new CustomQueue<String>(a);
            return queue.Contains(elem);
        }

        [TestCase(new[] {3, 4, 5, 6, 7, 8}, Result = 0)]
        [TestCase(new[] {3, 4 }, Result = 0)]
        public int InitializeAndClearQueueTest(int[] a)
        {
            CustomQueue<int> queue = new CustomQueue<int>(a);
            queue.Clear();
            return queue.Count;
        }

        [TestCase(6, Result = 0)]
        [TestCase(null, Result = 0)]
        [TestCase(-6, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public int InitializeQueueTest(int capacity)
        {
            CustomQueue<int> queue = new CustomQueue<int>(capacity);
            return queue.Count;
        }

        [TestCase(new[] { 3, 4, 5, 6, 7, 8 }, Result = 3)]
        [TestCase(new[] { 8, 4 }, Result = 8)]
        [TestCase(new int[] {}, ExpectedException = typeof(InvalidOperationException))]
        public int PeekElemQueueTest(int[] a)
        {
            CustomQueue<int> queue = new CustomQueue<int>(a);
            return queue.Peek();
        }

        [TestCase(new[] { 3, 4, 5, 6, 7, 8 }, 5, Result = 8)]
        [TestCase(new[] { 8, 4, 100, 15 }, 2, Result = 100)]
        [TestCase(new[] { 1, 2, 3}, 3, ExpectedException = typeof(InvalidOperationException))]
        [TestCase(new[] { 1, 2, 3 }, 4, ExpectedException = typeof(InvalidOperationException))]
        public int DequeElemsQueueTest(int[] a, int number)
        {
            CustomQueue<int> queue = new CustomQueue<int>(a);
            while (number > 0)
            {
                queue.Dequeue();
                number--;
            }
            return queue.Peek();
        }
        #endregion
    }
}