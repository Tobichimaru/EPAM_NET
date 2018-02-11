
namespace University.Interfaces
{
    /// <summary>
    /// Describes Interface for different types of courses assignments
    /// </summary>
    public interface IWork
    {
        #region Public Properties

        /// <summary>
        /// Description of the assignment
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The Title of the assignment
        /// </summary>
        string Title { get; }

        #endregion
    }
}
