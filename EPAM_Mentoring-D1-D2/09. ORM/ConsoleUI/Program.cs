using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Common;
using ORM;
using ORM.Entities;

namespace ConsoleUI
{
    internal class Program
    {
        private static DbNorthwind _context;

        private static void Main(string[] args)
        {
            Configuration.Linq.AllowMultipleQuery = true;
            _context = new DbNorthwind();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1 - a list of products with a category and supplier");
                Console.WriteLine("2 - a list of employees with a region which they are responsible for");
                Console.WriteLine("other - exit");
                Console.Write("Enter key: ");
                var key = Console.ReadLine();
                Console.WriteLine();

                int intKey;
                int.TryParse(key, out intKey);

                switch (intKey)
                {
                    case 1:
                        var allProducts = _context.Product.Take(10);
                        PrintProducts(allProducts);
                        break;
                    case 2:
                        var employees = _context.Employee.Take(10);
                        PrintEmployees(employees);
                        break;
                    default:
                        exit = true;
                        break;
                }

                Console.WriteLine();
            }
        }
        

        private static void PrintProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.ProductName}");
                Console.WriteLine(product.Category == null ? "\tNo category" : $"\tCategory: {product.Category.Id} - {product.Category.Name}");
                Console.WriteLine(product.Supplier == null ? "\tNo supplier" : $"\tSupplier: {product.Supplier.Id} - {product.Supplier.CompanyName}");
            }
        }

        private static void PrintEmployees(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}");

                foreach (var territory in employee.EmployeeTerritories)
                {
                    Console.WriteLine($"\tRegion: {territory.Territory.Region.Description} \tTerritory Id: {territory.Territory.Id}, Description: {territory.Territory.Description}");
                }
            }
        }
    }
}