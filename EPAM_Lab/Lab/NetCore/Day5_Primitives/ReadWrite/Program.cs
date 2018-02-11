using System;
using System.Collections.Generic;
using System.Threading;

namespace ReadWrite
{
    internal class Program
    {
        private static IList<Thread> CreateWorkers(ManualResetEventSlim mres, Action action, int threadsNum, int cycles)
        {
            var threads = new Thread[threadsNum];
            for (var i = 0; i < threadsNum; i++)
            {
                Action d = () =>
                {
                    mres.Wait();
                    for (var j = 0; j < cycles; j++)
                    {
                        action();
                    }
                };

                var operation = new ParameterizedThreadStart(obj => d());
                var thread = new Thread(operation);

                threads[i] = thread;
            }

            return threads;
        }

        private static void Main(string[] args)
        {
            var list = new MyList();
            var mres = new ManualResetEventSlim(false);
            var threads = new List<Thread>();

            threads.AddRange(CreateWorkers(mres, () => { list.Add(1); }, 10, 100));
            threads.AddRange(CreateWorkers(mres, () => { list.Get(); }, 10, 100));
            threads.AddRange(CreateWorkers(mres, () => { list.Remove(); }, 10, 100));

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.WriteLine("Press any key to run unblock working threads.");
            Console.ReadKey();

            // NOTE: When an user presses the key all waiting worker threads should begin their work.
            mres.Set();

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
    }
}