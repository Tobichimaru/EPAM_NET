using System;
using System.Threading;
using NLog;

namespace TimerLib.Manager
{
    /// <summary>
    ///     Class managing countdown timer
    /// </summary>
    public class TimerManager
    {
        #region Private Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Protected method

        /// <summary>
        ///     Methods that handle the event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">Arguments of the event</param>
        protected virtual void OnTimerEvent(object sender, TimerMessageEventArgs e)
        {
            logger.Trace("TimerManager.OnTimerEvent called. Args: {0}, {1}", e.Message, e.Milliseconds);
            if (ReferenceEquals(TimerEvent, null))
            {
                logger.Warn("TimerEvent is null");
                return;
            }
            TimerEvent(sender, e);
        }

        #endregion

        #region EventHandler

        /// <summary>
        ///     Custom EventHandler
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Arguments of the event</param>
        public delegate void TimerMessageEventHandler(object sender, TimerMessageEventArgs e);

        /// <summary>
        ///     Some custom event
        /// </summary>
        public event TimerMessageEventHandler TimerEvent;

        #endregion

        #region Public Methods

        /// <summary>
        ///     Starts the work of countdown timer
        /// </summary>
        /// <param name="milliseconds">Time to count</param>
        public void Start(int milliseconds)
        {
            logger.Trace("Start({0}) called", milliseconds);
            if (milliseconds < 0)
            {
                logger.Error("Time should be positive number");
                throw new ArgumentException();
            }
            Thread.Sleep(milliseconds);
            OnTimerEvent(this, new TimerMessageEventArgs("Time is over!", milliseconds));
        }

        /// <summary>
        ///     Simulates some work
        /// </summary>
        /// <param name="message">Message to write</param>
        /// <param name="milliseconds">Time to count</param>
        public void SimulateNewTimer(string message, int milliseconds)
        {
            logger.Trace("Start({0}, {1}) called", message, milliseconds);
            if (milliseconds < 0)
            {
                logger.Error("Time should be positive number");
                throw new ArgumentException();
            }
            OnTimerEvent(this, new TimerMessageEventArgs(message, milliseconds));
        }

        #endregion
    }
}