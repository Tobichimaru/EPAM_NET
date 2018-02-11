using System;
using FileSystemVisitorHelper;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemVisitor visitor = new FileSystemVisitor();
            var files = visitor.EnumerateFiles("D:\\study\\D1-D2");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            Console.Read();
        }
    }
}
