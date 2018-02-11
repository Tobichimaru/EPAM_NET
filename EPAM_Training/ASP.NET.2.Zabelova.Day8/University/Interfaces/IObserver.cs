namespace University.Interfaces
{
    /// <summary>
    /// Provides a mechanism for receiving push-based notifications.
    /// </summary>
    /// <typeparam name="T">The object that provides notification information.</typeparam>
    public interface IObserver<in T>
    {
        #region Public Methods
        /// <summary>
        /// Recieves information
        /// </summary>
        /// <param name="info">information to be recieved</param>
        void Update(T info);
        #endregion
    }
}
