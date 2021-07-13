using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sorting_N_able.WordCounter
{
    class ConcurrentDictionary<T, D> : IEnumerable<KeyValuePair<T, D>>, IEnumerable
    {
        static Mutex _lock = new Mutex();
        private Dictionary<T, D> topWord;
        public int CountTopWord { get; } = 10;

        public ConcurrentDictionary() { }
        public Dictionary<T, D> GetDictionary()
        {
            return topWord;
        }
        public int Count
        {
            get
            {
                try
                {
                   // _lock.WaitOne();
                    return topWord.Count;
                }
                finally
                {
                   // _lock.ReleaseMutex();
                }
            }
        }

        public KeyValuePair<T, D> FirstOrDefault()
        {
            try
            {
               // _lock.WaitOne();
                return topWord.FirstOrDefault();
            }
            finally
            {
                //_lock.ReleaseMutex();
            }
        }

        public bool Update(T key, D value)
        {
            try
            {
                //_lock.WaitOne();
                if (topWord.ContainsKey(key))
                {
                    topWord[key] = value;
                    return true;
                }
                return false;
            }
            finally
            {
               // _lock.ReleaseMutex();
            }
        }

        public bool IsEmpty()
        {
            try
            {
                //_lock.WaitOne();
                return topWord.Count == 0;
            }
            finally
            {
               // _lock.ReleaseMutex();
            }
        }

        public D GetValueByKey(T key)
        {
            try
            {
                //_lock.WaitOne();
                return topWord[key];
            }
            finally
            {
               // _lock.ReleaseMutex();
            }
        }

        public ConcurrentDictionary(int count)
        {
            CountTopWord = count;
            topWord = new Dictionary<T, D>();
        }

        public void Add(T key, D value)
        {
            try
            {
                //_lock.WaitOne();
                if (!topWord.ContainsKey(key))
                {
                    topWord.Add(key, value);
                }
            }
            finally
            {
               // _lock.ReleaseMutex();
            }
        }

        public void Add(KeyValuePair<T, D> item)
        {
            try
            {
               // _lock.WaitOne();
                topWord.Add(item.Key, item.Value);
            }
            finally
            {
                //_lock.ReleaseMutex();
            }
        }

        public bool Contains(KeyValuePair<T, D> item)
        {
            try
            {
                //_lock.WaitOne();
                return topWord.Contains(item);
            }
            finally
            {
               // _lock.ReleaseMutex();
            }
        }

        public bool ContainsKey(T key)
        {
            try
            {
               // _lock.WaitOne();
                return topWord.ContainsKey(key);
            }
            finally
            {
                //_lock.ReleaseMutex();
            }
        }

        public IEnumerator<KeyValuePair<T, D>> GetEnumerator()
        {
            try
            {
                _lock.WaitOne();
                return topWord.GetEnumerator();
            }
            finally
            {
                _lock.ReleaseMutex();
            }
        }

        public bool Remove(T key)
        {

            try
            {
                _lock.WaitOne();
                return topWord.Remove(key);
            }
            finally
            {
                _lock.ReleaseMutex();
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
