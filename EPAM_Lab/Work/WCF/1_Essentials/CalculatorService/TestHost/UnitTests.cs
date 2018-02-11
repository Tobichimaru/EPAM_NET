using System;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHost
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod()
        {
            using (var client = new ServiceReference.CalculatorServiceClient())
            {
                Console.WriteLine(client.Add(5,6));
                //Console.WriteLine(client.Divide(3, 0));
            }
        }
    }
}
