namespace BLL.Interface
{
    /// <summary>
    ///     The Interface for search criteria
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBllCriterion<T>
    {
        /// <summary>
        ///     Applies criterion to entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool ApplyCriterion(T entity);
    }
}