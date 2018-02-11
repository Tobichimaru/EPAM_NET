using System;
using University.Interfaces;

namespace University.Classes
{
    /// <summary>
    /// Describes student
    /// </summary>
    public class Student : IStudent
    {
        #region Constructors
        static Student()
        {
            LoggerClass.Logger.Trace("static Student() called");
            counter = 0;
        }

        /// <summary>
        /// Initialize student instance
        /// </summary>
        /// <param name="name">name of student</param>
        public Student(string name)
        {
            LoggerClass.Logger.Trace("public Student(string name) called");
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
            Name = name;
            Id = counter;
            LoggerClass.Logger.Trace("Student (ID = {0}, name = \"{1}\") initialized", Id, Name);
        }
        #endregion
        
        #region Public Methods and Properties
        public void Update(HomeTask task)
        {
            LoggerClass.Logger.Trace("Student.Update(HomeTask task) called");
            if (ReferenceEquals(task, null))
            {
                LoggerClass.Logger.Error("Task is null");
                throw new ArgumentNullException();
            }
            LoggerClass.Logger.Info("Hometask from Course (ID = {0}) was recieved by Student (Id = {1})", task.InitialCourse.Id, Id);
            LoggerClass.Logger.Debug("Hometask (title = \"{0}\") from Course (name = \"{1}\") was recieved by Student (name = \"{2}\")",
                task.Title, task.InitialCourse.Name, Name);

            task.InitialCourse.GetHomework(DoHomeWork(task), task);
        }

        public string Name { get; private set; }
        public int Id { get; private set; } 
        #endregion

        #region Private Methods
        private HomeWork DoHomeWork(HomeTask task)
        {
            LoggerClass.Logger.Trace("Student.DoHomeWork(HomeTask task) called");
            HomeWork homework = new HomeWork(task.Title + " done!", task.Description, this);

            LoggerClass.Logger.Info("Hometask from Course (ID = {0}) was done by Student (Id = {1})", task.InitialCourse.Id, Id);
            LoggerClass.Logger.Debug("Hometask (title = \"{0}\") from Course (name = \"{1}\") was done by Student (name = \"{2}\"). " +
                                     "Homework (title = \"{3}\")", task.Title, task.InitialCourse.Name, Name, homework.Title);
            return homework;
        }
        #endregion

        #region Private Fields
        private static int counter;
        #endregion

    }
}
