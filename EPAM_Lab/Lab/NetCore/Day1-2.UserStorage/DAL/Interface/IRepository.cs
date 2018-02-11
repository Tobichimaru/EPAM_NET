using System;

namespace DAL.Interface
{
    /// <summary>
    ///     Interface for storing entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        ///     Adds entity to repository
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(T entity);

        /// <summary>
        ///     Removes entity from repository
        /// </summary>
        /// <param name="user"></param>
        void Delete(T user);

        /// <summary>
        ///     Search entities by predicates
        /// </summary>
        /// <param name="predicates"></param>
        /// <returns></returns>
        int[] GetByPredicate(Func<T, bool>[] predicates);

        /// <summary>
        ///     Search entities by criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        int[] SearchForUsers(IDalCriterion<T>[] criteria);

        /// <summary>
        ///     Saves entites
        /// </summary>
        void Save();

        /// <summary>
        ///     Loads entites
        /// </summary>
        void Load();
    }
}
