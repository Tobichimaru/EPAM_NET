﻿namespace DAL.Interface
{
    /// <summary>
    ///     Interface for search criterion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDalCriterion<T>
    {
        /// <summary>
        ///     Applies criterion to entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool ApplyCriterion(T entity);
    }
}
