namespace BookLibrary.Interfaces
{
    /// <summary>
    ///     Provides interface for instances that can write data
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        ///     Writes data
        /// </summary>
        /// <param name="str">data</param>
        void Write(string str);
    }
}