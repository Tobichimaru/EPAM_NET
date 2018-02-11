namespace University.Interfaces
{
    /// <summary>
    /// Defines a provider for push-based notification.
    /// </summary>
    /// <typeparam name="T">The object that provides notification information.</typeparam>
    public interface IObservable<T> 
    {
        #region Public Methods
        /// <summary>
        /// Adds an observer to receive notifications.
        /// </summary>
        /// <param name="o">observer to be added</param>
        void AddObserver(IObserver<T> o);

        /// <summary>
        /// Removes an observer to receive notifications.
        /// </summary>
        /// <param name="o">observer to be removed</param>
        void RemoveObserver(IObserver<T> o);


        /// <summary>
        /// Notifies all observers 
        /// </summary>
        /// <param name="info">info to be send</param>
        void NotifyObservers(T info); 
        #endregion
    }
}
