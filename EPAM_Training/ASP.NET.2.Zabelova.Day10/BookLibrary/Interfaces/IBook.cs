namespace BookLibrary.Interfaces
{
    /// <summary>
    ///     Defines methods and properties for Books
    /// </summary>
    public interface IBook
    {
        #region Public Methods

        /// <summary>
        ///     The title of the book
        /// </summary>
        string Title { get; }

        /// <summary>
        ///     The author of the book
        /// </summary>
        string Author { get; }

        /// <summary>
        ///     The number of pages of the book
        /// </summary>
        int NumberOfPages { get; }

        #endregion
    }
}