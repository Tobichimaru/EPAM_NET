using University.Classes;

namespace University.Interfaces
{
    /// <summary>
    /// Describes course interface
    /// </summary>
    public interface ICourse: IObservable<IWork>, INameId
    {
        #region Public Methods
        /// <summary>
        /// Recieves homework from student on specifed task
        /// </summary>
        /// <param name="homeWork">completed homework</param>
        /// <param name="task">performed task</param>
        void GetHomework(HomeWork homeWork, HomeTask task);
        #endregion
    }
}
