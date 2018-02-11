using System;
using TimerLib.Listeners;
using TimerLib.Manager;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var manager = new TimerManager();
            var someClass = new SomeClass(manager);
            var otherClass = new OtherClass();

            otherClass.Register(manager);
            manager.SimulateNewTimer("1-st timer simulation", 1000);

            otherClass.Unregister(manager);
            manager.SimulateNewTimer("2-nd timer simulation", 1000);

            otherClass.Unregister(manager);
            manager.SimulateNewTimer("3-nd timer simulation", 1000);

            otherClass.Register(manager);
            manager.Start(300);
            Console.ReadKey();
        }
    }
}