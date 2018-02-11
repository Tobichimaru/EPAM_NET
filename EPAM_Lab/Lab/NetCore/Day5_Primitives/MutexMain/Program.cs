﻿using System;
using System.Threading;

namespace MutexMain
{
    // How to run this task:
    // Run MutexMain.exe
    // Run 3..4 instances of MutexClient.exe
    // Press a key in MutexMain and see what happens in other applications.
    // Press a key in application that will acquire the mutex next.
    internal class Program
    {
        private static void Main(string[] args)
        {
            var createdNew = false;
            var mutex = new Mutex(true, "MyMutex", out createdNew);

            Console.WriteLine("MutexMain. Is the mutex new? " + createdNew);
            Console.WriteLine("Press any key to release mutex.");
            Console.ReadLine();

            mutex.ReleaseMutex();

            Console.WriteLine("Mutex is release. Press any key to exit.");
            Console.ReadLine();
        }
    }
}