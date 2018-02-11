using System;
using University.Interfaces;

namespace University.Classes
{
    /// <summary>
    /// Describes course task
    /// </summary>
    public class HomeTask : IWork
    {
        #region Constructor
        /// <summary>
        /// Initialize a task
        /// </summary>
        /// <param name="title">name of a task</param>
        /// <param name="text">description of a task</param>
        /// <param name="course">course which provides a task</param>
        public HomeTask(string title, string text, ICourse course) 
        {
            LoggerClass.Logger.Trace("HomeTask(string title, string text, ICourse course) called");
            if (ReferenceEquals(course, null))
            {
                LoggerClass.Logger.Error("Course is null");
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
            InitialCourse = course;
            LoggerClass.Logger.Trace("HomeTask (title = \"" + title + "\") initialized");
        }
        #endregion

        #region Properties
        public string Title { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// The course which provides a task
        /// </summary>
        public ICourse InitialCourse { get; set; }
        #endregion
    }
}
