using System;
using System.Threading;

namespace MutexClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var createdNew = false;
            var mutex = new Mutex(false, "MyMutex", out createdNew);

            Console.WriteLine("MutexClient. Mutex is new? " + createdNew + ". Waiting until mutex will be released.");
            mutex.WaitOne();

            Console.WriteLine("Press any key to release mutex.");
            Console.ReadKey();

            mutex.ReleaseMutex();

            Console.WriteLine("Mutex is released. Press any key to exit.");
            Console.ReadKey();
        }
    }
}