using System.Threading;

namespace Monitor
{
    // TODO: Use SpinLock to protect this structure.
    public class AnotherClass
    {
        private static SpinLock _locker = new SpinLock();

        public int Counter { get; set; }

        public void Increase()
        {
            var lockTaken = false;
            try
            {
                if (!_locker.IsHeldByCurrentThread)
                    _locker.Enter(ref lockTaken);
                Counter++;
            }
            finally
            {
                if (lockTaken)
                    _locker.Exit();
            }
        }

        public void Decrease()
        {
            var lockTaken = false;
            try
            {
                if (!_locker.IsHeldByCurrentThread)
                    _locker.Enter(ref lockTaken);
                Counter--;
            }
            finally
            {
                if (lockTaken)
                    _locker.Exit();
            }
        }
    }
}