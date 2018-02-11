using System;
using System.IO;
using BookLibrary.Interfaces;
using NLog;

namespace BookLibrary.Classes
{
    /// <summary>
    ///     Writes data to the binary file
    /// </summary>
    public class BinaryFileWriter : IWriter
    {
        #region Private Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes custom path of file
        /// </summary>
        /// <param name="path">path of file</param>
        public BinaryFileWriter(string path)
        {
            logger.Trace("BinaryFileWriter(\"{0}\") called", path);
            Path = path;
            var stream = File.Open(path, FileMode.Create);
            stream.Close();
        }

        #endregion

        #region Public Methods and Properties

        /// <summary>
        ///     Path of the file
        /// </summary>
        public string Path { get; private set; }

        public void Write(string str)
        {
            logger.Trace("BinaryFileWriter.Write(string) called");
            try
            {
                using (var writer = new BinaryWriter(File.Open(Path, FileMode.Create)))
                {
                    writer.Write(str);
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
        }

        #endregion
    }
}