using DAL.DTO;

namespace DAL.Interface
{
    /// <summary>
    ///     Repository specified for storing users
    /// </summary>
    public interface IUserRepository : IRepository<DalUser>
    {
    }
}
