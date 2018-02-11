using System;
using System;
using System.Collections.Generic;
using University.Interfaces;

namespace University.Classes
{
    /// <summary>
    /// Describes archive class which contains all information about students
    /// </summary>
    public class Archive
    {
        #region Constructors
        static Archive()
        {
            LoggerClass.Logger.Trace("static Archive() called");
        }

        private Archive()
        {
            LoggerClass.Logger.Trace("Archive() called");
            recordBook = new Dictionary<IStudent, Dictionary<ICourse, Dictionary<string, int>>>();
        }
#       endregion

        #region Public Properties and Methods
        /// <summary>
        /// Provides instance of the archive
        /// </summary>
        public static Archive Instance
	    {
		    get
		    {
			    return instance;
		    }
	    }
   
        /// <summary>
        /// Store a mark into the archive
        /// </summary>
        /// <param name="student">student</param>
        /// <param name="course">course</param>
        /// <param name="task">graded task</param>
        /// <param name="mark">recieved grade</param>
        internal void RecordMark(IStudent student, ICourse course, IWork task, int mark)
        {
            LoggerClass.Logger.Trace("Archive.RecordMark(student, course, task, mark) called");
            CheckNull(student, course, task);

            if (!recordBook.ContainsKey(student))
            {
                recordBook.Add(student, new Dictionary<ICourse, Dictionary<string, int>>());
                LoggerClass.Logger.Debug("Student was added");
            }
            if (!recordBook[student].ContainsKey(course)) { 
                recordBook[student].Add(course, new Dictionary<string, int>());
                LoggerClass.Logger.Debug("Course was added");
            }
            if (!recordBook[student][course].ContainsKey(task.Title)) { 
                recordBook[student][course].Add(task.Title, mark);
                LoggerClass.Logger.Debug("Task was added");
            }
            LoggerClass.Logger.Trace("Mark recorded");
        }

        /// <summary>
        /// Gets the mark from the archive
        /// </summary>
        /// <param name="student">student</param>
        /// <param name="course">course</param>
        /// <param name="task">graded task if the task was completed, otherwise -1</param>
        public int GetMark(IStudent student, ICourse course, IWork task)
        {
            LoggerClass.Logger.Trace("Archive.GetMark(student, course, task) called");
            CheckNull(student, course, task);

            if (!recordBook.ContainsKey(student))
            {
                LoggerClass.Logger.Warn("Archive doesn't contain Student (ID = {0})", student.Id);
                return -1;
            }

            if (!recordBook[student].ContainsKey(course))
            {
                LoggerClass.Logger.Warn("Archive doesn't contain Course (ID = {0})", course.Id);
                return -1;
            }

            if (!recordBook[student][course].ContainsKey(task.Title))
            {
                LoggerClass.Logger.Warn("Archive doesn't contain Task (Title = \"{0}\")", task.Title);
                return -1;
            }

            return recordBook[student][course][task.Title];
        }

        #endregion

        #region Private Methods

        private void CheckNull(IStudent student, ICourse course, IWork task)
        {
            if (ReferenceEquals(student, null))
            {
                LoggerClass.Logger.Error("Student is null");
                throw new ArgumentNullException("student");
            }
            if (ReferenceEquals(course, null))
            {
                LoggerClass.Logger.Error("course is null");
                throw new ArgumentNullException("course");
            }
            if (ReferenceEquals(task, null))
            {
                LoggerClass.Logger.Error("task is null");
                throw new ArgumentNullException("task");
            }
        }
        #endregion

        #region Private Fields
        private static readonly Archive instance = new Archive();
        private readonly Dictionary<IStudent, Dictionary<ICourse, Dictionary<string, int>>> recordBook;
        #endregion
    }
}
