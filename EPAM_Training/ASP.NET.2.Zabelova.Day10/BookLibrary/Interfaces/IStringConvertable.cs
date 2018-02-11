namespace BookLibrary.Interfaces
{
    /// <summary>
    ///     Provides interface for classes that can be converted to sting and vice versa
    /// </summary>
    public interface IStringConvertable
    {
        #region Public Methods

        /// <summary>
        ///     Converts instance to string
        /// </summary>
        /// <returns>converted instance to string</returns>
        string ConvertToString();

        /// <summary>
        ///     Parses instance from string
        /// </summary>
        /// <param name="str">string to be parsed</param>
        void ParseFromString(string str);

        #endregion
    }
}