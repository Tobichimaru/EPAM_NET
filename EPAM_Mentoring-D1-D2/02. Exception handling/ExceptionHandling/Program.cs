using System;

namespace ExceptionHandling
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("Input is empty");
            
            Console.WriteLine(input[0]);
            Console.Read();
        }
    }
}
