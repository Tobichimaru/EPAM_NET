using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileSystemVisitorHelper
{
    public class FileSystemVisitor
    {
        private readonly Func<string, bool> _filterPattern;
        private readonly CancellationTokenSource _cancelTokenSource;

        #region Events

        /// <summary>
        /// Trigger the start of the search
        /// </summary>
        /// <returns>an enumerable collection of file names</returns>
        public delegate IEnumerable<string> StartSearch(string path);
       
        /// <summary>
        /// Triggered when file or directory finded
        /// </summary>
        public delegate void FileOrDirectoryFinded();

        /// <summary>
        /// rigger the start of the search
        /// </summary>
        public event StartSearch Start;

        /// <summary>
        /// Triggered when file finded
        /// </summary>
        public event FileOrDirectoryFinded FileFinded;

        /// <summary>
        /// Triggered when directory finded
        /// </summary>
        public event FileOrDirectoryFinded DirectoryFinded;

        /// <summary>
        /// Triggered when filtered file finded
        /// </summary>
        public event FileOrDirectoryFinded FilteredFileFinded;

        /// <summary>
        /// Triggered when filtered directory finded
        /// </summary>
        public event FileOrDirectoryFinded FilteredDirectoryFinded;
        #endregion

        public FileSystemVisitor() : this(s => true) { }
        
        public FileSystemVisitor(Func<string, bool> filterPattern)
        {
            _filterPattern = filterPattern;
            _cancelTokenSource = new CancellationTokenSource();
            FileSystemVisitorEvents.Finish += () => { _cancelTokenSource.Cancel(); };
        }

        /// <summary>
        /// Returns an enumerable collection of file information that matches a search pattern.
        /// </summary>
        /// <returns>an enumerable collection of file names</returns>
        public IEnumerable<string> EnumerateFiles()
        {
            return EnumerateFiles(Directory.GetCurrentDirectory());
        }

        /// <summary>
        /// Returns an enumerable collection of file information that matches a search pattern.
        /// </summary>
        /// <param name="targetDirectory">initial folder</param>
        /// <returns>an enumerable collection of file names</returns>
        public IEnumerable<string> EnumerateFiles(string targetDirectory)
        {
            if (String.IsNullOrEmpty(targetDirectory))
                throw new NullReferenceException("The target directory should not be null.");

            return EnumerateFilesInFolder(targetDirectory).TakeWhile(file => !_cancelTokenSource.IsCancellationRequested).ToList();
        }

        private IEnumerable<string> EnumerateFilesInFolder(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (var file in fileEntries)
            {
                FileFinded?.Invoke();
                if (_filterPattern.Invoke(file))
                    FilteredFileFinded?.Invoke();

                yield return file;
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryFinded?.Invoke();
                if (_filterPattern.Invoke(subdirectory))
                    FilteredDirectoryFinded?.Invoke();

                foreach (var file in EnumerateFiles(subdirectory))
                {
                    yield return file;
                }
            }
        }
    }
}
