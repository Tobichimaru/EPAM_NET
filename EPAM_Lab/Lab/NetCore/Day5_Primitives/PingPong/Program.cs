using System;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new ManualResetEventSlim(false);
            var pingEvent = new AutoResetEvent(false);
            var pongEvent = new AutoResetEvent(false);

            CancellationTokenSource cts = new CancellationTokenSource(); 
            CancellationToken token = cts.Token;

            Action ping = () =>
            {
                Console.WriteLine("ping: Waiting for start.");
                start.Wait();

                bool continueRunning = true;

                while (continueRunning)
                {
                    Console.WriteLine("ping!");
                    pingEvent.Set();
                    pongEvent.WaitOne();
                    Thread.Sleep(1000);

                    continueRunning = !token.IsCancellationRequested;
                }

                pongEvent.Reset();
                Console.WriteLine("ping: done");
            };

            Action pong = () =>
            {
                Console.WriteLine("pong: Waiting for start.");
                start.Wait();

                bool continueRunning = true;

                while (continueRunning)
                {
                    pingEvent.WaitOne();
                    Thread.Sleep(1000);
                    Console.WriteLine("pong!");
                    pongEvent.Set();
                    continueRunning = !token.IsCancellationRequested;
                }
                pingEvent.Reset();
                Console.WriteLine("pong: done");
            };


            var pingTask = Task.Run(ping);
            var pongTask = Task.Run(pong);

            Console.WriteLine("Press any key to start.");
            Console.WriteLine("After ping-pong game started, press any key to exit.");
            Console.ReadKey();
            start.Set();

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
