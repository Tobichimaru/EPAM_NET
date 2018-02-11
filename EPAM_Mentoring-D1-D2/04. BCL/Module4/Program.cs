using System;
using FoldersWatcher;

namespace Module4
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileScanner.Initialize();
            FileScanner.StartListening();
            Console.ReadLine();
        }
    }
}
