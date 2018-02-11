using System;
using System.Collections.Generic;
using NLog;

namespace FibonacciLib
{
    /// <summary>
    ///     provides method for calculating fibonacci number
    /// </summary>
    public static class FibonacciNumbers
    {
        #region Private Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Methods

        /// <summary>
        ///     Iterator that returns k Fibonacci numbers
        /// </summary>
        /// <param name="k">the number of Fibonacci numbers to be returned</param>
        /// <returns>fibonacci number</returns>
        /// <exception cref="ArgumentException">Parameter K should be non-negative.</exception>
        public static IEnumerable<int> Fibonacci(int k)
        {
            logger.Trace("IEnumerable<int> Fibonacci(int {0}) called", k);
            if (k < 0)
            {
                logger.Error("Parameter {0} should be non-negative.", k);
                throw new ArgumentException();
            }
            var prev = -1;
            var next = 1;
            for (var i = 0; i < k; i++)
            {
                int sum;
                try
                {
                    sum = checked(prev + next);
                }
                catch (OverflowException)
                {
                    logger.Warn("Overflow during calculation ({0}-th Fibonacci number)", i);
                    yield break;
                }
                prev = next;
                next = sum;
                yield return sum;
            }
        }

        #endregion
    }
}