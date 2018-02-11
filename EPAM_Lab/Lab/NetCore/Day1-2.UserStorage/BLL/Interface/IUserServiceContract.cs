using System.ServiceModel;
using BLL.Models;
using BLL.SearchCriteria;

namespace BLL.Interface
{
    /// <summary>
    ///     Contract for WCF service
    /// </summary>
    [ServiceContract]
    [ServiceKnownType(typeof(FirstNameCriterion))]
    [ServiceKnownType(typeof(LastNameCriterion))]
    [ServiceKnownType(typeof(IdCriterion))]
    public interface IUserServiceContract
    {
        /// <summary>
        ///     Adds user
        /// </summary>
        /// <param name="user">user to add</param>
        /// <returns>id of the user</returns>
        [OperationContract]
        int Add(BllUser user);

        /// <summary>
        ///     Deletes user
        /// </summary>
        /// <param name="user">user to delete</param>
        [OperationContract]
        void Delete(BllUser user);

        /// <summary>
        ///     Search the user according to criteria
        /// </summary>
        /// <param name="criteria">criteria for search</param>
        /// <returns>id of the user</returns>
        [OperationContract]
        int[] SearchForUsers(IBllCriterion<BllUser>[] criteria);

        /// <summary>
        ///     Saves users to xml
        /// </summary>
        [OperationContract]
        void Save();

        /// <summary>
        ///     Load users from xml
        /// </summary>
        [OperationContract]
        void Load();
    }
}
