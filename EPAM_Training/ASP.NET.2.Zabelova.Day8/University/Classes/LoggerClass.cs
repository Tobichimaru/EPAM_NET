using NLog;

namespace University.Classes
{
    /// <summary>
    /// Provides logger instance
    /// </summary>
    public class LoggerClass
    {
        #region Constructors
        static LoggerClass()
        {
        }

        private LoggerClass()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the logger instance
        /// </summary>
        public static Logger Logger
        {
            get
            {
                return logger;
            }
        }
        #endregion 

        #region Private Fields
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion
    }
}
