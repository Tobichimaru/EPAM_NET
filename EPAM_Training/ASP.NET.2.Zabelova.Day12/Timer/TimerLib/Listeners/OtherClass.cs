using System;
using NLog;
using TimerLib.Manager;

namespace TimerLib.Listeners
{
    /// <summary>
    ///     Other Listener, registers to the event through method
    /// </summary>
    public class OtherClass
    {
        #region Private Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Private Methods

        private void GenerateMessage(object sender, TimerMessageEventArgs eventArgs)
        {
            logger.Trace("OtherClass.GenerateMessage called, eventArgs.Message: {0}", eventArgs.Message);
            Console.WriteLine("OtherClass message: {0}", eventArgs.Message);
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Registers this listener to the events of the manager
        /// </summary>
        /// <param name="timer">manager that is generates events</param>
        public void Register(TimerManager timer)
        {
            logger.Trace("OtherClass.Register called");
            if (ReferenceEquals(timer, null))
            {
                logger.Error("TimerManager is null");
                throw new ArgumentNullException();
            }
            timer.TimerEvent += GenerateMessage;
            logger.Debug("OtherClass was registered to TimerManager");
        }

        /// <summary>
        ///     Unegisters this listener from the events of the manager
        /// </summary>
        /// <param name="timer">manager that is generates events</param>
        public void Unregister(TimerManager timer)
        {
            logger.Trace("OtherClass.Unregister called");
            if (ReferenceEquals(timer, null))
            {
                logger.Error("TimerManager is null");
                throw new ArgumentNullException();
            }
            timer.TimerEvent -= GenerateMessage;
            logger.Debug("OtherClass was unregistered to TimerManager");
        }

        #endregion
    }
}