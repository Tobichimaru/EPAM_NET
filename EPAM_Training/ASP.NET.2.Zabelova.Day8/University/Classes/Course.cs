using System;
using System.Collections.Generic;
using University.Interfaces;

namespace University.Classes
{
    /// <summary>
    /// Desribes course 
    /// </summary>
    public class Course : ICourse
    {
        #region Constructors
        static Course()
        {
            LoggerClass.Logger.Trace("static Course() called");
            counter = 0;
        }

        /// <summary>
        /// Initializes course with custom name and curator
        /// </summary>
        /// <param name="name">name of the course</param>
        /// <param name="curator">curator of the course</param>
        public Course(string name, ICurator curator)
        {
            LoggerClass.Logger.Trace("Course(string name, ICurator curator) called");
            if (ReferenceEquals(curator, null))
            {
                LoggerClass.Logger.Error("Curator is null");
                throw new ArgumentNullException();
            }
            if (ReferenceEquals(name, null))
            {
                LoggerClass.Logger.Error("Name is null");
                throw new ArgumentNullException();
            }
            if (name.Length == 0)
            {
                LoggerClass.Logger.Error("Name is empty");
                throw new ArgumentException();
            }

            counter++;
            Id = counter;

            Name = name;
            this.curator = curator;
            students = new List<IStudent>();

            LoggerClass.Logger.Trace("Course (ID = {0}, name = \"{1}\") initialized", Id, name);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add student to the Course
        /// </summary>
        /// <param name="student">student</param>
        public void AddObserver(IStudent student)
        {
            LoggerClass.Logger.Trace("Course.AddObserver(IStudent student) called");
            if (ReferenceEquals(student, null))
            {
                LoggerClass.Logger.Error("Student is null");
                throw new ArgumentNullException("student");
            }

            LoggerClass.Logger.Trace("Course.AddObserver(IStudent student) called");
            LoggerClass.Logger.Info("Course (ID = {0}) adds observer (ID = {1})", Id, student.Id);
            LoggerClass.Logger.Debug("Course (name = \"{0}\") adds observer (name = \"{1}\")", Name, student);

            if (!students.Contains(student))
                students.Add(student);
            else
                LoggerClass.Logger.Warn("Course already contains this Student");
        }

        public void AddObserver(Interfaces.IObserver<IWork> o)
        {
            LoggerClass.Logger.Trace("Course.AddObserver(IObserver<IWork> o) called");
            IStudent student = CheckReference(o);
            AddObserver(student);
        }

        /// <summary>
        /// remove student from the course
        /// </summary>
        /// <param name="student">student</param>
        public void RemoveObserver(IStudent student)
        {
            LoggerClass.Logger.Trace("Course.RemoveObserver(IStudent student) called");
            LoggerClass.Logger.Info("Course (ID = {0}) removes observer (ID = {1})", Id, student.Id);
            LoggerClass.Logger.Debug("Course (name = \"{0}\") removes observer (name = \"{1}\")", Name, student.Name);

            if (!students.Contains(student))
                students.Remove(student);
            else
                LoggerClass.Logger.Warn("Course doesn't contains this Student");
        }

        public void RemoveObserver(Interfaces.IObserver<IWork> o)
        {
            LoggerClass.Logger.Trace("Course.RemoveObserver(IObserver<IWork> o) called");
            IStudent student = CheckReference(o);
            RemoveObserver(student);
        }

        public void NotifyObservers(IWork info)
        {
            LoggerClass.Logger.Trace("Course.NotifyObservers(IWork info) called");
            LoggerClass.Logger.Info("Course (ID = {0}) notifies observers with task", Id);
            LoggerClass.Logger.Debug("Course (name = \"{0}\") notifies observers with task (name = \"{1}\")", Name, info.Title);
            
            foreach (var student in students)
            {
                student.Update(new HomeTask(info.Title, info.Description, this));
            }
        }

        public void GetHomework(HomeWork homeWork, HomeTask task)
        {
            LoggerClass.Logger.Trace("Course GetHomework(HomeWork homeWork, HomeTask task) called");
            if (ReferenceEquals(homeWork, null))
            {
                LoggerClass.Logger.Error("Homework is null");
                throw new ArgumentNullException("homework");
            }
            if (ReferenceEquals(task, null))
            {
                LoggerClass.Logger.Error("task is null");
                throw new ArgumentNullException("task");
            }

            LoggerClass.Logger.Info("Homework on Task from Author (Id = {0}) was recieved by Course (Id = {1})", homeWork.StudentAuthor.Id, Id);
            LoggerClass.Logger.Debug("Homework (title = \"{0}\") on Task (title =\"{1}\") from Author (name = \"{2}\") was recieved " +
                                     "by Course (name = \"{3}\")", homeWork.Title, task.Title, homeWork.StudentAuthor.Name, Name);

            int mark = curator.SetMark(homeWork);
            Archive.Instance.RecordMark(homeWork.StudentAuthor, this, task, mark);
        }
        #endregion

        #region Public Properties
        public string Name { get; private set; }
        public int Id { get; private set; }
        #endregion

        #region Private Methods
        private IStudent CheckReference(Interfaces.IObserver<HomeWork> o)
        {
            IStudent student = o as IStudent;
            if (student == null)
            {
                LoggerClass.Logger.Error("Inputed interface is not IStudent. Course ID = " + Id);
                throw new ArgumentNullException();
            }

            return student;
        }
        #endregion

        #region Private Fields
        private static int counter;
        private readonly List<IStudent> students;
        private readonly ICurator curator;
        #endregion

    } 
}
