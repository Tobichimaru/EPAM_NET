using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(CalculatorService.CalculatorService)))
            {
                host.Open();

                Console.WriteLine("Service started");
                Console.ReadLine();

                host.Close();

                Console.WriteLine("Service stopped");
            }
        }
    }
}
