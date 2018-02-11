namespace BookLibrary.Interfaces
{
    /// <summary>
    ///     Provides interface for instances that can read data
    /// </summary>
    public interface IReader
    {
        /// <summary>
        ///     Reads some data
        /// </summary>
        /// <returns>data</returns>
        string Read();
    }
}