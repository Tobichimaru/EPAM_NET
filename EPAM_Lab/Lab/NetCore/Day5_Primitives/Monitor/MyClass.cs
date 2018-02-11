namespace Monitor
{
    // TODO: Use Monitor (not lock) to protect this structure.
    public class MyClass
    {
        private static readonly object _locker = new object();


        public int Counter { get; set; }

        public void Increase()
        {
            System.Threading.Monitor.Enter(_locker);
            try
            {
                Counter++;
            }
            finally
            {
                System.Threading.Monitor.Exit(_locker);
            }
        }

        public void Decrease()
        {
            System.Threading.Monitor.Enter(_locker);
            try
            {
                Counter--;
            }
            finally
            {
                System.Threading.Monitor.Exit(_locker);
            }
        }
    }
}