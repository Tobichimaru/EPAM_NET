using System;
using System.Reflection;
using IoCContainer;
using Samples;

namespace ConsoleUI
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            var targetAssembly = Assembly.LoadFrom("Samples.dll");
            container.AddAssembly(targetAssembly);

            container.Register<ISomething, Something>();
            container.Register<ISomeParameter, SomeParameter>();
            var simple = container.Resolve<SomeClass>();
            var simpleWithInterface = container.Resolve<SomeClassWithInterface>();
            var something = container.Resolve<ISomething>();

            Console.ReadKey();
        }
    }
}
