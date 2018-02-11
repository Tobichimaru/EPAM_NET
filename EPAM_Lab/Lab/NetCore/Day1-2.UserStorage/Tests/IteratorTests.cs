using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class IteratorTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Iterator_CountThree_ReturnsFour()
        {
            var count = 3;
            var expected = 4;

            var result = 0;
            var iterator = new UserIdIterator();
            for (var i = 0; i < count; i++)
            {
                result = iterator.Current;
                iterator.MoveNext();
            }

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Iterator_Reset_ReturnsTwo()
        {
            var expected = 2;

            var iterator = new UserIdIterator();
            iterator.Reset();

            Assert.AreEqual(expected, iterator.Current);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Iterator_FromSix_ReturnsEight()
        {
            var expected = 8;
            var start = 6;

            var iterator = new UserIdIterator(start);
            iterator.MoveNext();

            Assert.AreEqual(expected, iterator.Current);
        }
    }
}
