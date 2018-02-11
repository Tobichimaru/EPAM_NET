using System;
using System.Collections.Generic;
using System.Threading;

namespace ReadWrite
{
    public class MyList
    {
        private readonly List<int> _list = new List<int>
        {
            1,
            2,
            3,
            4
        };

        private readonly ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

        ~MyList()
        {
            if (_readerWriterLock != null) _readerWriterLock.Dispose();
        }

        public void Add(int value)
        {
            Console.WriteLine("Write");
            _readerWriterLock.EnterWriteLock();
            try
            {
                _list.Add(value);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public void Remove()
        {
            Console.WriteLine("Write");
            _readerWriterLock.EnterWriteLock();
            try
            {
                if (_list.Count > 0)
                    _list.RemoveAt(0);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public int Get()
        {
            Console.WriteLine("Read");
            _readerWriterLock.EnterReadLock();
            try
            {
                return _list.Count > 0 ? _list[0] : 0;
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
        }
    }
}