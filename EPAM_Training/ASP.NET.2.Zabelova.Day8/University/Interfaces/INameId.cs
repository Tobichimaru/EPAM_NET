
namespace University.Interfaces
{
    /// <summary>
    /// Provides name and Id for each descendant
    /// </summary>
    public interface INameId
    {
        #region Public Methods
        /// <summary>
        /// Name of the instance
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Unique Id for each instance
        /// </summary>
        int Id { get; }
        #endregion
    }
}
