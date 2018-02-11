using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueLib;

namespace QueueLibTests
{
    [TestClass]
    public class CustomQueueTests
    {
        #region Test Methods
        [TestMethod]
        public void FindElem_ReturnsFalse_Test()
        {
            CustomQueue<String> queue = new CustomQueue<String>(new[] { "cat", "dog", "cow" });
            Assert.IsFalse(queue.Contains("Kitten"));
        }

        [TestMethod]
        public void FindElem_ReturnsTrue_Test()
        {
            CustomQueue<String> queue = new CustomQueue<String>(new[] { "cat", "dog", "cow" });
            Assert.IsTrue(queue.Contains("dog"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindElem_ReturnsException_Test()
        {
            CustomQueue<String> queue = new CustomQueue<String>(null);
            Assert.IsFalse(queue.Contains("smth"));
        }

        [TestMethod]
        public void InitializeAndClearQueueTest(int[] a)
        {
            CustomQueue<int> queue = new CustomQueue<int>(new[] { 3, 4, 5, 6, 7, 8 });
            queue.Clear();
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void InitializeQueue_PositiveCapacity_Test()
        {
            CustomQueue<int> queue = new CustomQueue<int>(6);
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeQueue_NegativeCapacity_Test()
        {
            CustomQueue<int> queue = new CustomQueue<int>(-6);
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void PeekElem_IntQueue_Test()
        {
            CustomQueue<int> queue = new CustomQueue<int>(new[] { 3, 4, 5, 6, 7, 8 });
            int expected = 3;

            int actual = queue.Peek();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekElem_EmptyQueue_Test()
        {
            CustomQueue<int> queue = new CustomQueue<int>(new int[] {});
            queue.Peek();
        }

        [TestMethod]
        public void DequeElems_IntQueue_Test()
        {
            CustomQueue<int> queue = new CustomQueue<int>(new[] { 3, 4, 5, 6, 7, 8 });
            int number = 5;
            int expected = 8;
            
            while (number > 0)
            {
                queue.Dequeue();
                number--;
            }

            int actual = queue.Peek();

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeElems_IntQueue_ReturnsException_Test()
        {
            CustomQueue<int> queue = new CustomQueue<int>(new[] { 3, 4, 5 });
            int number = 4;

            while (number > 0)
            {
                queue.Dequeue();
                number--;
            }
        }
        #endregion
    }
}
