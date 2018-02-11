using System;

namespace wget
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new WebParser("http://e-maxx.ru/algo/euler_function", "local");
            parser.Parse(1);
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }
    }
}