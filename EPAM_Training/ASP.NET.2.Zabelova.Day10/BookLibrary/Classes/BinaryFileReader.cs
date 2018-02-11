using System;
using System.IO;
using BookLibrary.Interfaces;
using NLog;

namespace BookLibrary.Classes
{
    /// <summary>
    ///     Reads data from binary file
    /// </summary>
    public class BinaryFileReader : IReader
    {
        #region Private Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
       
        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes custom path of the file
        /// </summary>
        /// <param name="path">path of the file</param>
        public BinaryFileReader(string path)
        {
            logger.Trace("BinaryFileReader(\"{0}\") called", path);
            Path = path;
        }

        #endregion

        #region Public Methods and Properties

        /// <summary>
        ///     Path of the file
        /// </summary>
        public string Path { get; private set; }

        public string Read()
        {
            logger.Trace("BinaryFileReader.Read() called");
            string str;
            try
            {
                using (var reader = new BinaryReader(File.Open(Path, FileMode.Open)))
                {
                    str = reader.ReadString();
                }
            }
            catch (IOException e)
            {
                logger.Fatal("An I/O Fatal occurs. " + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Fatal("Fatal error occurs when opening writer. " + e.Message);
                throw;
            }
            catch (ObjectDisposedException e)
            {
                logger.Fatal("Odject of writer was disposed. " + e.Message);
                throw;
            }
            catch (Exception e)
            {
                logger.Fatal("Incorrect file path: " + e.Message);
                throw;
            }
            return str;
        }

        #endregion 
    }
}