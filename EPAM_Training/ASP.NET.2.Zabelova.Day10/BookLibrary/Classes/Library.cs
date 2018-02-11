using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using BookLibrary.Interfaces;
using NLog;

namespace BookLibrary.Classes
{
    /// <summary>
    ///     Describes collection of Books
    /// </summary>
    public class Library<T> : ILibrary<T>, IEnumerable<T>, IStringConvertable where T : IBook, IStringConvertable
    {
        #region Private Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<T> books;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the Library class that is empty and has the default initial capacity.
        /// </summary>
        public Library()
        {
            logger.Trace("Library() called");
            DefaultPath = "library";
            books = new List<T>();
        }

        /// <summary>
        ///     Initializes a new instance of the Library class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the Library can contain</param>
        public Library(int capacity)
        {
            logger.Trace("Library({0}) called", capacity);
            DefaultPath = "library";
            try
            {
                books = new List<T>(capacity);
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Fatal("capacity is less than 0. " + e.Message);
                throw;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the Library class that contains elements copied from the specified collection
        ///     and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new Library.</param>
        public Library(IEnumerable<T> collection)
        {
            logger.Trace("Library(IEnumerable<T>) called");
            DefaultPath = "library";
            try
            {
                books = new List<T>(collection);
            }
            catch (ArgumentNullException e)
            {
                logger.Fatal("collection is null. " + e.Message);
                throw;
            }
        }

        #endregion

        #region Public Methods and Properties

        /// <summary>
        ///     Default path for storing library collection in binary format
        /// </summary>
        public string DefaultPath { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            logger.Trace("GetEnumerator() called");
            return books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            logger.Trace("IEnumerable.GetEnumerator() called");
            return GetEnumerator();
        }

        public void AddItem(T item)
        {
            logger.Trace("AddItem(T item) called");
            if (ReferenceEquals(item, null))
            {
                logger.Error("Parameter is null");
                return;
            }
            books.Add(item);
        }

        public void RemoveItem(T item)
        {
            logger.Trace("RemoveItem(T item) called");
            if (ReferenceEquals(item, null))
            {
                logger.Error("Parameter is null");
                return;
            }
            books.Remove(item);
        }

        public T FindByTag(Predicate<T> predicate)
        {
            logger.Trace("FindByTag(Predicate<T>) called");
            try
            {
                return books.Find(predicate);
            }
            catch (ArgumentNullException e)
            {
                logger.Fatal("predicate is null. " + e.Message);
                throw;
            }
        }

        public void SortItemsByTag(Comparison<T> comparison)
        {
            logger.Trace("SortItemsByTag(Comparison<T>) called");
            try
            {
                books.Sort(comparison);
            }
            catch (ArgumentNullException e)
            {
                logger.Fatal("comparison is null. " + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Fatal("The implementation of comparison caused an Fatal during the sort. For example, " +
                             "comparison might not return 0 when comparing an item with itself. " + e.Message);
                throw;
            }
        }

        public void SaveLibrary(string path)
        {
            logger.Trace("SaveLibrary(\"{0}\") called", path);

            BinaryFileWriter writer;
            try
            {
                writer = new BinaryFileWriter(path);
            }
            catch (Exception e)
            {
                logger.Warn("Error occurs: " + e.Message);
                logger.Warn("Incorrect path. The path was replaced by default path: \"{0}\"", DefaultPath);
                writer = new BinaryFileWriter(DefaultPath);
            }

            writer.Write(ConvertToString());
        }

        public void LoadLibrary(string path)
        {
            logger.Trace("LoadLibrary(\"{0}\") called", path);
            logger.Info("The library was cleared");
            books.Clear();

            var reader = new BinaryFileReader(path);
            var result = reader.Read();

            ParseFromString(result);
        }

        public string ConvertToString()
        {
            logger.Trace("Library.ConvertToString() called");
            var serializer = new XmlSerializer(typeof (List<T>));
            var stream = new MemoryStream();

            try
            {
                serializer.Serialize(stream, books);
            }
            catch (SerializationException ex)
            {
                logger.Fatal("The object graph could not be converted to string " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.Fatal("An error occurs " + ex.Message);
                throw;
            }
            return Encoding.ASCII.GetString(stream.GetBuffer());
        }

        public void ParseFromString(string str)
        {
            logger.Trace("Library.ParseFromString(string) called");
            var serializer = new XmlSerializer(typeof (List<T>));
            var toBytes = Encoding.ASCII.GetBytes(str);
            var stream = new MemoryStream(toBytes);
            List<T> newBooks;
            try
            {
                newBooks = serializer.Deserialize(stream) as List<T>;
            }
            catch (SerializationException ex)
            {
                logger.Fatal("The object graph could not be parsed from string" + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.Fatal("An error occurs " + ex.Message);
                throw;
            }
            if (!ReferenceEquals(newBooks, null))
                books = new List<T>(newBooks.ToArray());
        }

        #endregion
    }
}