using System;
using University.Interfaces;

namespace University.Classes
{
    /// <summary>
    /// Describes professor 
    /// </summary>
    public class Professor : ICurator
    {
        #region Constructor
        static Professor()
        {
            LoggerClass.Logger.Trace("static Professor() called");
            counter = 0;
        }

        /// <summary>
        /// Initialize professor instance
        /// </summary>
        /// <param name="name">name of the professor</param>
        public Professor(string name)
        {
            LoggerClass.Logger.Trace("public Professor(string name) called");
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
            LoggerClass.Logger.Trace("Professor (ID = {0}, name = \"{1}\") initialized", Id, Name);
        }
        #endregion

        #region Public Methods and Properties
        public int SetMark(IWork homeWork)
        {
            LoggerClass.Logger.Trace("Professor.SetMark(IWork homeWork) called");
            Random rnd = new Random();
            int mark = rnd.Next(3, 9);
            
            LoggerClass.Logger.Info("Homework was recieved mark = " + mark);
            LoggerClass.Logger.Debug("Homework (title = \"{0}\") was graded by Curator (ID = {1}, name = \"{2}\") with mark = {3}",
                homeWork.Title, Id, Name, mark);
            return mark;
        }

        public string Name { get; private set; }
        public int Id { get; private set; }

        #endregion

        #region Private Fields
        private static int counter;
        #endregion
    }
}
