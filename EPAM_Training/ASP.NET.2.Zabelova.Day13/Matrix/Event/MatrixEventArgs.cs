using System;

namespace Matrix.Event
{
    /// <summary>
    ///     Describes info about event
    /// </summary>
    public class MatrixEventArgs : EventArgs
    {
        #region Constructors

        /// <summary>
        ///     Initializes event with the message
        /// </summary>
        /// <param name="message">message</param>
        public MatrixEventArgs(string message)
        {
            Message = message;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Message of the event
        /// </summary>
        public string Message { get; private set; }

        #endregion
    }
}