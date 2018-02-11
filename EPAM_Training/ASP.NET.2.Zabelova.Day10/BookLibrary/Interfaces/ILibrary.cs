using System;

namespace BookLibrary.Interfaces
{
    /// <summary>
    ///     Defines methods for managing instances of type T in the Library
    /// </summary>
    public interface ILibrary<T>
    {
        #region Public Methods

        /// <summary>
        ///     Adds the item in the Library, if there is no such item there, otherwise throws exception
        /// </summary>
        /// <param name="item">Item to be added in the Library</param>
        void AddItem(T item);

        /// <summary>
        ///     Removes the item from the Library, if Library contains this item, otherwise throws exception
        /// </summary>
        /// <param name="item">Item to be removed from the Library</param>
        void RemoveItem(T item);

        /// <summary>
        ///     Searches for an element that matches the conditions defined by the specified predicate,
        ///     and returns the first occurrence within the entire Library
        /// </summary>
        /// <param name="predicate">Criteria for comparing the items</param>
        /// <returns>the first occurrence of the element within the entire Library</returns>
        T FindByTag(Predicate<T> predicate);

        /// <summary>
        ///     Sorts the elements of the Library by specified criteria
        /// </summary>
        /// <param name="comparison">Criteria for comparing the elements</param>
        void SortItemsByTag(Comparison<T> comparison);

        /// <summary>
        ///     Saves library collection into the binary file in the specified path. If there is no file, it creates the file.
        /// </summary>
        /// <param name="path">The path to the file</param>
        void SaveLibrary(string path);

        /// <summary>
        ///     Loads library from binary file from specified path
        /// </summary>
        /// <param name="path">The path of the file</param>
        void LoadLibrary(string path);

        #endregion
    }
}