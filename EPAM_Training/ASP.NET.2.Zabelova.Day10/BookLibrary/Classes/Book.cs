using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using BookLibrary.Interfaces;
using NLog;

namespace BookLibrary.Classes
{
    /// <summary>
    ///     Describes abstraction of Book
    /// </summary>
    public class Book : IBook, IStringConvertable
    {
        #region Private Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes empty Book
        /// </summary>
        public Book()
        {
            logger.Trace("Book() called");
        }

        /// <summary>
        ///     Initializes Book with specified data
        /// </summary>
        /// <param name="title">the title of the book</param>
        /// <param name="author">the author of the book</param>
        /// <param name="pages">the pages of the book</param>
        public Book(string title, string author, int pages)
        {
            logger.Trace("Book(\"{0}\", \"{1}\", {3}) called", title, author, pages.ToString());
            Title = title;
            Author = author;
            NumberOfPages = pages;
        }

        #endregion

        #region Public Properties

        public string Title { get; set; }

        public string Author { get; set; }

        public int NumberOfPages { get; set; }

        #endregion

        #region Public Methods

        public string ConvertToString()
        {
            logger.Trace("Book.ConvertToString() called");
            var serializer = new XmlSerializer(typeof (Book));
            var stream = new MemoryStream();
            try
            {
                serializer.Serialize(stream, this);
            }
            catch (SerializationException ex)
            {
                logger.Fatal("The object graph could not be converted to string. " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.Fatal("An error occurs. " + ex.Message);
                throw;
            }
            return Encoding.ASCII.GetString(stream.GetBuffer());
        }

        public void ParseFromString(string str)
        {
            logger.Trace("Book.ParseFromString() called");
            var serializer = new XmlSerializer(typeof (Book));
            var toBytes = Encoding.ASCII.GetBytes(str);
            var stream = new MemoryStream(toBytes);
            Book book;
            try
            {
                book = serializer.Deserialize(stream) as Book;
            }
            catch (SerializationException ex)
            {
                logger.Fatal("The object graph could not be parsed from string. " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.Fatal("An error occurs. " + ex.Message);
                throw;
            }

            if (!ReferenceEquals(book, null))
            {
                Title = book.Title;
                Author = book.Author;
                NumberOfPages = book.NumberOfPages;
            }
        }

        public override string ToString()
        {
            logger.Trace("Book.ToString() called");
            return "Title: \"" + Title + "\", Author: \"" + Author + "\", NumberOfPages: \"" + NumberOfPages.ToString() + "\"";
        }

        #endregion
    }
}