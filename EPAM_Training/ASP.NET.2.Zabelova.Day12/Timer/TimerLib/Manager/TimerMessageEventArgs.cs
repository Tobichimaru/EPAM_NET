using System;
using NLog;

namespace TimerLib.Manager
{
    /// <summary>
    ///     Class describes arguments of the event
    /// </summary>
    public sealed class TimerMessageEventArgs : EventArgs
    {
        #region Private Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes arguments
        /// </summary>
        /// <param name="message">Message to write</param>
        /// <param name="milliseconds">Time to count</param>
        public TimerMessageEventArgs(string message, int milliseconds)
        {
            logger.Trace("TimerMessageEventArgs({0}, {1}) ctor called", message, milliseconds);
            Message = message;
            Milliseconds = milliseconds;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Mwssage that should be written after finishing timers work
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        ///     Time for timer to count
        /// </summary>
        public int Milliseconds { get; private set; }

        #endregion
    }
}