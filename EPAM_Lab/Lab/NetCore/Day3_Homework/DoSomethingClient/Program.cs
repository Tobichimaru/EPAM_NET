﻿using System;
using System.IO;
using System.Reflection;
using MyInterfaces;

namespace DoSomethingClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = new Input
            {
                Users = new[]
                {
                    new User
                    {
                        Id = 1,
                        Name = "Vasily",
                        Age = 23
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Semen",
                        Age = 35
                    },
                    new User
                    {
                        Id = 3,
                        Name = "Pawel",
                        Age = 22
                    }
                }
            };

            Method1(input);
            Method2(input);
        }

        private static void Method1(Input input)
        {
            AppDomain domain = AppDomain.CreateDomain("MyDomain");
            var loader = (DomainAssemblyLoader) domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName,
                        typeof (DomainAssemblyLoader).FullName);
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MyDomain\MyLibrary.dll");
                var result = loader.LoadFile(path, input);

                //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MyDomain\MyLibrary.dll");
                //var result = loader.LoadFrom(path, input);

                Console.WriteLine("Method1: {0}", result.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
            
            AppDomain.Unload(domain);
        }

        private static void Method2(Input input)
        {
            var appDomainSetup = new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyDomain")
            };
            
            AppDomain domain = AppDomain.CreateDomain("MyDomain", null, appDomainSetup);

            var loader =
                (DomainAssemblyLoader) domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName,
                        typeof (DomainAssemblyLoader).FullName);

            try
            {
                var result = loader.Load(
                    "MyLibrary, Version=1.2.3.4, Culture=neutral, PublicKeyToken=f46a87b3d9a80705", input);

                Console.WriteLine("Method2: {0}", result.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
            
            AppDomain.Unload(domain);
        }
    }
}