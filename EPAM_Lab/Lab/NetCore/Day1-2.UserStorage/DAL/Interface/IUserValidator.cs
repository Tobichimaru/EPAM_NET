using DAL.DTO;

namespace DAL.Interface
{
    /// <summary>
    ///     Interface for users validation
    /// </summary>
    public interface IUserValidator
    {
        /// <summary>
        ///     Validates user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Validate(DalUser user);
    }
}
