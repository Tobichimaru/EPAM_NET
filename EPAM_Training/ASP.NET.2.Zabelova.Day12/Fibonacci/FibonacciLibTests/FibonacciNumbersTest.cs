using System;
using FibonacciLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace FibonacciLibTests
{
    [TestClass]
    public class FibonacciNumbersTest
    {
        [TestCase(4, Result = 2)]
        [TestCase(1, Result = 0)]
        [TestCase(7, Result = 8)]
        [TestCase(11, Result = 55)]
        [TestCase(-1, ExpectedException = typeof (ArgumentException))]
        public int LastFibNumberTest(int k)
        {
            var result = -1;
            foreach (var number in FibonacciNumbers.Fibonacci(k))
                result = number;
            return result;
        }
    }
}