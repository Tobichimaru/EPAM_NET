using System;
using System.Collections.Generic;

namespace BinarySearchConsoleUI.AdditionalClasses
{
    internal class CompareFunctions
    {
        #region Public Functions

        public static int CompareBooks(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null)) return 0;
            if (ReferenceEquals(lhs, null)) return -1;
            if (ReferenceEquals(rhs, null)) return 1;
            return string.Compare(lhs.Author, rhs.Author, StringComparison.Ordinal);
        }

        public static int ComparePoints(Point2D lhs, Point2D rhs)
        {
            if (lhs.X + lhs.Y < rhs.X + rhs.Y) return -1;
            if (lhs.X + lhs.Y > rhs.X + rhs.Y) return 1;
            return 0;
        }

        public static int CompareStrings(string lhs, string rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null)) return 0;
            if (ReferenceEquals(lhs, null)) return -1;
            if (ReferenceEquals(rhs, null)) return 1;
            return -string.Compare(lhs, rhs, StringComparison.Ordinal);
        }

        public static int CompareInts(int lhs, int rhs)
        {
            return -Comparer<int>.Default.Compare(lhs, rhs);
        }

        #endregion
    }
}