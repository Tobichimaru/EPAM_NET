using System;
using NLog;
using TimerLib.Manager;

namespace TimerLib.Listeners
{
    /// <summary>
    ///     Some Listenerm registres to the event through ctor
    /// </summary>
    public sealed class SomeClass
    {
        #region Private Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary>
        ///     Registers this listener to the events of the manager
        /// </summary>
        /// <param name="timer">manager that is generates events</param>
        public SomeClass(TimerManager timer)
        {
            logger.Trace("SomeClass ctor called");
            if (ReferenceEquals(timer, null))
            {
                logger.Error("TimerManager is null");
                throw new ArgumentNullException();
            }
            timer.TimerEvent += GenerateMessage;
            logger.Debug("SomeClass was registered to TimerManager");
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Unegisters this listener from the events of the manager
        /// </summary>
        /// <param name="timer">manager that is generates events</param>
        public void Unregister(TimerManager timer)
        {
            logger.Trace("SomeClass.Unregister called");
            if (ReferenceEquals(timer, null))
            {
                logger.Error("TimerManager is null");
                throw new ArgumentNullException();
            }
            timer.TimerEvent -= GenerateMessage;
            logger.Debug("SomeClass was unregistered to TimerManager");
        }

        #endregion

        #region Private Methods

        private void GenerateMessage(object sender, TimerMessageEventArgs eventArgs)
        {
            logger.Trace("SomeClass.GenerateMessage called, eventArgs.Message: {0}", eventArgs.Message);
            Console.WriteLine("SomeClass message: {0}", eventArgs.Message);
        }

        #endregion
    }
}