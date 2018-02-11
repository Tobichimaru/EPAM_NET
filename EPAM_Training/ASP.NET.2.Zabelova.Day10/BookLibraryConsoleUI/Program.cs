using System;
using BookLibrary.Classes;

namespace BookLibraryConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Book[] books =
            {
                new Book("1", "Rowling", 461),
                new Book("2", "sir", 230),
                new Book("3", "weasley", 604),
                new Book("4", "harry", 380),
                new Book("5", "me", 815)
            };
            var library = new Library<Book>(books);
            library.SaveLibrary("///");

            library.SortItemsByTag((a, b) => String.Compare(a.Author, b.Author, StringComparison.Ordinal));

            Console.WriteLine("Books of otherLibrary after Sorting:");
            foreach (var book in library)
            {
                Console.WriteLine(book.ToString());
            }

            Book foundedBook = library.FindByTag((a) => a.NumberOfPages > 390);
            Console.WriteLine("\nBook founded by specifed criteria");
            Console.WriteLine(foundedBook.ToString());

            library.LoadLibrary(library.DefaultPath);

            Console.WriteLine("\nBooks of otherLibrary after Loading:");
            foreach (var book in library)
            {
                Console.WriteLine(book.ToString());
            }

            Console.ReadLine();
        }
    }
}