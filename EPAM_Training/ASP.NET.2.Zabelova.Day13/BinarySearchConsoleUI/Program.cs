using System;
using BinarySearchConsoleUI.AdditionalClasses;
using BinarySearchTreeLib;

namespace BinarySearchConsoleUI
{
    internal class Program
    {
        private static void PrintInfo<T>(T[] array, Comparison<T> comparision = null)
        {
            var tree = new BinaryTree<T>(array, comparision);

            var preorder = tree.PreOrderIterator();
            Console.Write("Preorder: ");
            foreach (var item in preorder)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            var inorder = tree.InOrderIterator();
            Console.Write("Inorder: ");
            foreach (var item in inorder)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            var postorder = tree.PostOrderIterator();
            Console.Write("Postorder: ");
            foreach (var item in postorder)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
        }

        private static void Main(string[] args)
        {
            PrintInfo(new[] {4, 6, 1, 4, 7, 8, 0});
            PrintInfo(new[] {4, 6, 1, 4, 7, 8, 0}, CompareFunctions.CompareInts);

            PrintInfo(new[] {"aa", "bfb", "bg", "cgc", "adv", "aaa"});
            PrintInfo(new[] {"aa", "bfb", "bg", "cgc", "adv", "aaa"}, CompareFunctions.CompareStrings);

            PrintInfo(new[]
            {
                new Book("AAA", "aaa", 30),
                new Book("BBB", "ccc", 50),
                new Book("CCC", "bbb", 40)
            });
            PrintInfo(new[]
            {
                new Book("AAA", "aaa", 30),
                new Book("BBB", "ccc", 50),
                new Book("CCC", "bbb", 40)
            }, CompareFunctions.CompareBooks);

            try
            {
                PrintInfo(new[]
                {
                    new Point2D(2.0, 1.0),
                    new Point2D(1.0, 1.0),
                    new Point2D(0.0, 1.0)
                });
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            PrintInfo(new[]
            {
                new Point2D(2.0, 1.0),
                new Point2D(1.0, 1.0),
                new Point2D(0.0, 1.0)
            }, CompareFunctions.ComparePoints);

            Console.ReadLine();
        }
    }
}