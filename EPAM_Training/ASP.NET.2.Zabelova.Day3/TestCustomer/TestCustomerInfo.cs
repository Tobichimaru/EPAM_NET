using System;
using CustomerInfo;

namespace TestCustomer
{
    /// <summary>
    /// Class for testing Customer class
    /// </summary>
    class TestCustomerInfo
    {
        /// <summary>
        /// SetUp method
        /// </summary>
        /// <param name="args">arguments of command prompt</param>
        static void Main(string[] args)
        {
            Customer customer = new Customer("Bob", "+123 678 90 90", 565656);
            Console.WriteLine(customer.ToString("G"));
            Console.WriteLine(customer.ToString("NPR"));
            Console.WriteLine(customer.ToString("N"));
            Console.WriteLine(customer.ToString("PR"));
            Console.WriteLine(customer.ToString("NR"));

            Console.WriteLine();

            Customer otherCustomer = new Customer("Lena", "555 777 8787", 302);
            OtherFormatProvider formatProvider = new OtherFormatProvider();
            Console.WriteLine(otherCustomer.ToString("G", formatProvider));
            Console.WriteLine(otherCustomer.ToString("NPR", formatProvider));
            Console.WriteLine(otherCustomer.ToString("N", formatProvider));
            Console.WriteLine(otherCustomer.ToString("PR", formatProvider));
            Console.WriteLine(otherCustomer.ToString("NR", formatProvider));

            Console.ReadLine();
        }
    }
}
