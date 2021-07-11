using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sorting_N_able.WordCounter
{
    class ConcurrentDictionary<T, D> : IEnumerable<KeyValuePair<T, D>>, IEnumerable
    {
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private Dictionary<T, D> topWord;
        public int CountTopWord { get; } = 10;

        public ConcurrentDictionary() { }

        public int Count
        {
            get
            {
                try
                {
                    _lock.EnterReadLock();
                    return topWord.Count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        public KeyValuePair<T, D> FirstOrDefault()
        {
            try
            {
                _lock.EnterReadLock();
                return topWord.FirstOrDefault();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool Update(T key, D value)
        {
            try
            {
                _lock.EnterReadLock();
                if (topWord.ContainsKey(key))
                {
                    topWord[key] = value;
                    return true;
                }
                return false;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool IsEmpty()
        {
            try
            {
                _lock.EnterReadLock();
                return topWord.Count == 0;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public D GetValueByKey(T key)
        {
            try
            {
                _lock.EnterReadLock();
                return topWord[key];
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public ConcurrentDictionary(int count)
        {
            CountTopWord = 10;
        }

        public void Add(T key, D value)
        {
            try
            {
                _lock.EnterReadLock();
                topWord.Add(key, value);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void Add(KeyValuePair<T, D> item)
        {
            try
            {
                _lock.EnterReadLock();
                topWord.Add(item.Key, item.Value);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool Contains(KeyValuePair<T, D> item)
        {
            try
            {
                _lock.EnterReadLock();
                return topWord.Contains(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool ContainsKey(T key)
        {
            try
            {
                _lock.EnterReadLock();
                return topWord.ContainsKey(key);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public IEnumerator<KeyValuePair<T, D>> GetEnumerator()
        {
            try
            {
                _lock.EnterReadLock();
                return topWord.GetEnumerator();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public bool Remove(T key)
        {

            try
            {
                _lock.EnterReadLock();
                return topWord.Remove(key);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<KeyValuePair<T, D>> IEnumerable<KeyValuePair<T, D>>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
