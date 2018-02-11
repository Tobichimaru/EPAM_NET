using System;
using System.Collections.Generic;
using NUnit.Framework;
using QueueLib;

namespace UnitTestQueue
{
    [TestFixture]
    public class QueueNUnitTests
    {
        [Test, TestCaseSource(typeof(MyFactoryClass), "FindElemData")]
        public bool FindElemTest(String[] a, String elem)
        {
            CustomQueue<String> queue = new CustomQueue<String>();
            foreach (String item in a)
            {
                queue.Enqueue(item);
            }
            return queue.Contains(elem);
        }

        [Test, TestCaseSource(typeof(MyFactoryClass), "PartialDequeueData")]
        public int[] PartialDequeueTest(int[] a, int toDeleteItems)
        {
            CustomQueue<int> queue = new CustomQueue<int>(a);
            for (int i = 0; i < toDeleteItems; i++)
            {
                queue.Dequeue();
            }

            foreach (int item in a)
            {
                queue.Enqueue(item);
            }
            
            return queue.ToArray();
        }
    }

    public class MyFactoryClass
    {
        public IEnumerable<TestCaseData> FindElemData
        {
            get
            {
                yield return new TestCaseData(new[] { "cat", "dog", "cow" }, "dog").Returns(true);
                yield return new TestCaseData(new[] { "cat", "dog", "cow" }, "kitten").Returns(false);
            }
        }

        public IEnumerable<TestCaseData> PartialDequeueData
        {
            get
            {
                yield return new TestCaseData(new[] { 1, 2, 3 }, 2).Returns(new[] { 3, 1, 2, 3 });
                yield return new TestCaseData(new[] { 1, 2, 3, 4 }, 2).Returns(new[] { 3, 4, 1, 2, 3, 4 });
                yield return new TestCaseData(new[] { 1, 2 }, 4).Throws(typeof(InvalidOperationException));
            }
        }
    }
}