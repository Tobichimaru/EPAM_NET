using System;
using University.Interfaces;

namespace University.Classes
{
    /// <summary>
    /// Describes student homework
    /// </summary>
    public class HomeWork : IWork
    {
        #region Constructor
        /// <summary>
        /// Initialize homework
        /// </summary>
        /// <param name="title">title of the homework</param>
        /// <param name="text">text of the homework</param>
        /// <param name="author">author of the homework</param>
        public HomeWork(string title, string text, IStudent author)
        {
            LoggerClass.Logger.Trace("HomeWork(string title, string text, IStudent author) called");
            if (ReferenceEquals(author, null))
            {
                LoggerClass.Logger.Error("Author is null");
                throw new ArgumentNullException();
            }
            if (ReferenceEquals(title, null))
            {
                LoggerClass.Logger.Error("Title is null");
                throw new ArgumentNullException();
            }
            if (ReferenceEquals(text, null))
            {
                LoggerClass.Logger.Error("Text is null");
                throw new ArgumentNullException();
            }
            if (title.Length == 0)
            {
                LoggerClass.Logger.Error("Title is empty");
                throw new ArgumentException();
            }
            if (text.Length == 0)
            {
                LoggerClass.Logger.Error("Text is empty");
                throw new ArgumentException();
            }


            Title = title;
            Description = text;
            StudentAuthor = author;

            LoggerClass.Logger.Trace("HomeWork (title = \"" + title + "\") initialized");
        }
        #endregion

        #region Properties
        public string Title { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Author of the homework
        /// </summary>
        public IStudent StudentAuthor { get; set; }
        #endregion
    }
}
