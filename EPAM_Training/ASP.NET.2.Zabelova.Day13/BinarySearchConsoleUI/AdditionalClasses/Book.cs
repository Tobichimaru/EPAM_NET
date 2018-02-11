using System;

namespace BinarySearchConsoleUI.AdditionalClasses
{
    internal class Book : IComparable<Book>
    {
        #region Constructor

        public Book(string title, string author, int numberOfPages)
        {
            NumberOfPages = numberOfPages;
            Author = author;
            Title = title;
        }

        #endregion

        #region Properties

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int NumberOfPages { get; private set; }

        #endregion

        #region Public Methods

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null)) return 1;
            return string.Compare(Title, other.Title, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return "{" + Title + " " + Author + " " + NumberOfPages + "}";
        }

        #endregion
    }
}