
namespace University.Interfaces
{
    /// <summary>
    /// Describes curator of courses interface
    /// </summary>
    public interface ICurator : INameId
    {
        #region Public Methods and Properties
        /// <summary>
        /// Set mark for the homework
        /// </summary>
        /// <param name="homework">homework to be rated</param>
        /// <returns>mark for the homework</returns>
        int SetMark(IWork homework);
        #endregion

    }
}
