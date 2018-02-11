namespace FileSystemVisitorHelper
{
    public static class FileSystemVisitorEvents
    {
        /// <summary>
        /// Finish the search
        /// </summary>
        public delegate void FinishSearch();

        /// <summary>
        /// Finish the search
        /// </summary>
        public static event FinishSearch Finish;
        
        public static void InvokeFinish()
        {
            Finish?.Invoke();
        }
    }
}
