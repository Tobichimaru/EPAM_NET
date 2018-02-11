// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using SampleSupport;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
    [Title("LINQ Module")]
    [Prefix("Linq")]
    public class LinqSamples : SampleHarness
    {

        private DataSource dataSource = new DataSource();

        [Category("Samples")]
        [Title("Where - Task 1")]
        [Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
        public void Linq1()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var lowNums =
                from num in numbers
                where num < 5
                select num;

            Console.WriteLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        [Category("Samples")]
        [Title("Where - Task 2")]
        [Description("This sample return return all presented in market products")]

        public void Linq2()
        {
            var products =
                from p in dataSource.Products
                where p.UnitsInStock > 0
                select p;

            foreach (var p in products)
            {
                ObjectDumper.Write(p);
            }
        }

        [Category("Homework")]
        [Title("Task 1")]
        [Description("Get the list of clients whose total turnover (sum of all orders) are greater than X.")]
        public void Linq3()
        {
            int x = 5000;

            var clents =
                from c in dataSource.Customers
                where c.Orders.Sum(o => o.Total) > x
                select c;

            foreach (var c in clents)
            {
                Console.WriteLine($"Customer ID={c.CustomerID}, Total={c.Orders.Sum(o => o.Total)}");
            }
        }

        [Category("Homework")]
        [Title("Task 2")]
        [Description("For each client return a list of suppliers located in the same country and in the same city")]
        public void Linq4()
        {
            foreach (var c in dataSource.Customers)
            {
                var suppliers = dataSource.Suppliers.Where(s =>
                    string.CompareOrdinal(s.Country, c.Country) == 0 && string.CompareOrdinal(s.City, c.City) == 0);

                Console.WriteLine($"Customer ID={c.CustomerID}, Country={c.Country}, City={c.City}");
                foreach (var sup in suppliers)
                {
                    Console.WriteLine($"Supplier Name={sup.SupplierName}, Country={sup.Country}, City={c.City}");
                }
                Console.WriteLine();
            }
        }

        [Category("Homework")]
        [Title("Task 3")]
        [Description("Find all customers who have orders with total greater than X")]
        public void Linq5()
        {
            int x = 600;
            var clents =
                from c in dataSource.Customers
                where c.Orders?.Select(o => o.Total).DefaultIfEmpty()?.Min() > x
                select c;

            foreach (var c in clents)
            {
                Console.WriteLine($"Customer ID={c.CustomerID}");
                foreach (var o in c.Orders)
                {
                    Console.WriteLine($"Order total = {o.Total}");
                }
                Console.WriteLine();
            }
        }

        [Category("Homework")]
        [Title("Task 4")]
        [Description(
            "Get a list of customers indicating which month of the year they became clients (take for the month and year of the very first order)"
        )]
        public void Linq6()
        {
            var data = dataSource.Customers.Select(c => new
            {
                Customer = c,
                OrderDate = c.Orders.OrderBy(y => y.OrderDate).FirstOrDefault()?.OrderDate
            });
            foreach (var item in data)
            {
                Console.WriteLine($"Customer id = {item.Customer.CustomerID}, date = {item.OrderDate}");
            }
        }

        [Category("Homework")]
        [Title("Task 5")]
        [Description(
            "Get a list of customers indicating which month of the year they became clients (take for the month and year of the very first order)," +
            " sorted by year, month, customer turnover (from the maximum to the minimum) and the client's name")]
        public void Linq7()
        {
            var data = dataSource.Customers.Select(c => new
                {
                    Customer = c,
                    OrdersTotal = c.Orders.Sum(y => y.Total),
                    OrderDate = c.Orders.OrderBy(y => y.OrderDate).FirstOrDefault()?.OrderDate
                }).OrderBy(x => x.OrderDate?.Year)
                .ThenBy(x => x.OrderDate?.Month)
                .ThenByDescending(x => x.OrdersTotal)
                .ThenBy(x => x.Customer.CustomerID);

            foreach (var item in data)
            {
                Console.WriteLine(
                    $"Customer id = {item.Customer.CustomerID}, date = {item.OrderDate}, sum = {item.OrdersTotal}");
            }
        }

        [Category("Homework")]
        [Title("Task 6")]
        [Description(
            "Specify all customers who have a non-digital postal code or a region that is not filled or the operator\'s code is not specified in the phone" +
            " (for simplicity, consider that this means \"there are no round brackets at the beginning\").")]
        public void Linq8()
        {
            var data = dataSource.Customers.Where(
                c => Regex.IsMatch(c.PostalCode ?? "", @"^\d$") ||
                     string.IsNullOrEmpty(c.Region) ||
                     !Regex.IsMatch(c.Phone ?? "", @"\(.+\).+"));

            foreach (var item in data)
            {
                Console.WriteLine(
                    $"Customer id = {item.CustomerID}, PostalCode = {item.PostalCode}, Region = {item.Region}, Phone = {item.Phone}");
            }
        }

        [Category("Homework")]
        [Title("Task 7")]
        [Description("Group all products by category, inside - by stock, within the last group sort by cost")]
        public void Linq9()
        {
            var data = dataSource.Products
                .GroupBy(x => x.Category,
                    (category, products) => new
                    {
                        Category = category,
                        Stock = products.GroupBy(y => y.UnitsInStock,
                            (stock, units) => new
                            {
                                UnitsInStock = stock,
                                Products = units.OrderBy(z => z.UnitPrice)
                            })
                    });

            foreach (var x in data)
            {
                Console.WriteLine($"Category = {x.Category}");
                foreach (var y in x.Stock)
                {
                    Console.WriteLine($"\tIn Stock = {y.UnitsInStock}");
                    foreach (var z in y.Products)
                    {
                        Console.WriteLine($"\t\t Product = {z.ProductName}");
                    }
                }
                Console.WriteLine();
            }
        }

        [Category("Homework")]
        [Title("Task 8")]
        [Description(
            "Group the goods into groups \"cheap\", \"average price\", \"expensive\". The boundaries of each group ask yourself"
        )]
        public void Linq10()
        {
            Func<decimal, string> classify = x =>
            {
                if (x < 20) return "cheap";
                if (x < 70) return "average";
                return "expensive";
            };

            var data = dataSource.Products
                .GroupBy(x => classify(x.UnitPrice), (x, y) => new
                {
                    Group = x,
                    Products = y
                });

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Group} products");
                foreach (var product in item.Products)
                {
                    ObjectDumper.Write(product);
                }
                Console.WriteLine();
            }
        }

        [Category("Homework")]
        [Title("Task 9")]
        [Description(
            "Calculate the average profitability of each city (the average amount of the order for all customers from a given city) and the average intensity" +
            " (the average number of orders per customer from each city)"
        )]
        public void Linq11()
        {
            var data = dataSource.Customers
                .GroupBy(x => x.City, (x, y) => new
                {
                    City = x,
                    AverageAmount = y.Average(c => c.Orders.Select(o => o.Total).DefaultIfEmpty().Average()),
                    AverageCountOfOrders = y.Select(c => c.Orders?.Length).DefaultIfEmpty().Average()
                });

            foreach (var item in data)
            {
                Console.WriteLine(
                    $"{item.City}: average profitability = {item.AverageAmount}, average intensity = {item.AverageCountOfOrders}");
            }
        }

        [Category("Homework")]
        [Title("Task 10")]
        [Description(
            "Make average annual activity statistics of clients by months (without taking into account the year), statistics by years, by years and by months (that is, when one month in different years has its value)."
        )]
        public void Linq12()
        {
            #region Monthly report
            var data = dataSource.Customers.
                SelectMany(x => x.Orders, (customer, order) => new
            {
                Month = order.OrderDate.Month,
                Order = order
            }).GroupBy(x => x.Month, (month, enumerable) => new
                {
                    Month = month,
                    OrdersCount = enumerable.Count()
             })
            .OrderBy(x => x.Month);

            Console.WriteLine("Monthly report");
            foreach (var item in data)
            {
                Console.WriteLine($"Month: {item.Month}, number of orders: {item.OrdersCount}");
            }
            Console.WriteLine("--------------------------");
            #endregion

            #region Annual report
            var data2 = dataSource.Customers.
                SelectMany(x => x.Orders, (customer, order) => new
                {
                    Year = order.OrderDate.Year,
                    Order = order
                }).GroupBy(x => x.Year, (year, enumerable) => new
                {
                    Year = year,
                    OrdersCount = enumerable.Count()
                })
            .OrderBy(x => x.Year);

            Console.WriteLine("Annual report");
            foreach (var item in data2)
            {
                Console.WriteLine($"Month: {item.Year}, number of orders: {item.OrdersCount}");
            }
            Console.WriteLine("--------------------------");
            #endregion

            #region Annual/Monthly report
            var data3 = dataSource.Customers.
                SelectMany(x => x.Orders, (customer, order) => new
                {
                    Year = order.OrderDate.Year,
                    Month = order.OrderDate.Month,
                    Order = order
                }).GroupBy(x => x.Year, (year, enumerable) => new
                {
                    Year = year,
                    OrdersCount = enumerable.GroupBy(y => y.Month, (month, orders) => new
                    {
                        Month = month,
                        OrdersAmount = orders.Count()
                    })
                    .OrderBy(x => x.Month)
                })
            .OrderBy(x => x.Year);

            Console.WriteLine("Annual/Monthly report");
            foreach (var item in data3)
            {
                Console.WriteLine($"Year: {item.Year}");
                foreach (var orderStat in item.OrdersCount)
                {
                    Console.WriteLine($"Month: {orderStat.Month}, number of orders: {orderStat.OrdersAmount}");
                }
            }
            Console.WriteLine();
            #endregion
        }
    }
}
