using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sorting_N_able.WordCounter
{
    class ConcurrentList<T>: IEnumerable<T>, ICollection<T>
    {
        private List<T> _list = new List<T>();
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

       public int Count
        {
            get
            {
                try
                {
                    _lock.EnterReadLock();
                    return _list.Count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            try
            {
                _lock.EnterReadLock();
                _list.Add(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public ConcurrentList() : this(null) { }

        public ConcurrentList(IEnumerable<T> items)
        {
            _list = items is null ? new List<T>() : new List<T>(items);
            _lock = new ReaderWriterLockSlim();
        }


        private IEnumerable<T> Enumerate()
        {
            try
            {
                _lock.EnterReadLock();
                foreach (T item in _list)
                    yield return item;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Enumerate().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            try
            {
                _lock.EnterReadLock();
                _list.Clear();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool Contains(T item)
        {
            try
            {
                _lock.EnterReadLock();
                return _list.Contains(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            try
            {
                _lock.EnterReadLock();
                _list.CopyTo(array, arrayIndex);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool Remove(T item)
        {
            try
            {
                _lock.EnterReadLock();
                return _list.Remove(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    }
}
