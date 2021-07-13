using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sorting_N_able.WordCounter
{
    public class WordCounter
    {
        private ConcurrentDictionary<string, int> topWord;
        static Mutex _lock = new Mutex();

        public WordCounter(int count)
        {
            topWord = new ConcurrentDictionary<string, int>(count);
        }

        private void ChengeOrAddItem(string nameFile, int count)
        {
            try
            {
                _lock.WaitOne();
                if (topWord.Count < topWord.CountTopWord)
                {
                    topWord.Add(nameFile, count);
                }
                else
                {
                    if (!topWord.IsEmpty())
                    {
                        if (!topWord.Update(nameFile, count))
                        {
                            string key = topWord.FirstOrDefault().Key;
                            int i = topWord.FirstOrDefault().Value;

                            foreach (var item in topWord)
                            {
                                if (item.Value < i)
                                {
                                    key = item.Key;
                                    i = item.Value;
                                }
                            }

                            if (count > i)
                            {
                                topWord.Remove(key);
                                topWord.Add(nameFile, count);
                            }
                        }
                    }
                }
            }
            finally
            {
               _lock.ReleaseMutex();
            }

        }

        public void WordIteratorParallel(string[] paths)
        {
            List<Thread> threads = new List<Thread>();
            foreach (var item in paths)
            {
                var t = new Thread(new ThreadStart(() => WordIterator(item)));
                t.Start();
                threads.Add(t);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        private void WordIterator(string path)
        {
            StringBuilder tempString = new();
            char tempChar;

            using (StreamReader file = new StreamReader(path))
            {
                while (file.Peek() > -1)
                {
                    tempChar = char.ToLower((char)file.Read());
                    if (char.IsLetter(tempChar))
                    {
                        tempString.Append(tempChar);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(tempString.ToString()))
                        {
                            //method create or update word's file
                            ChengeOrCreateWordFile(tempString.ToString());
                            tempString.Clear();

                        }
                    }
                }

                file.Close(); // I don't know its right or not. becouse USING call IDisposable
            }
        }

        private void ChengeOrCreateWordFile(string word)
        {

            int count = 1;
            try
            {
                _lock.WaitOne();
                try
                {

                    using (FileStream file = new FileStream(word + ".txt", FileMode.CreateNew))
                    {
                        lock (file)
                        {
                            byte[] array = System.Text.Encoding.Default.GetBytes(count.ToString());
                            file.Write(array, 0, array.Length);
                        }
                    }
                }
                catch (IOException)
                {

                    using (FileStream file = new FileStream(word + ".txt", FileMode.Open))
                    {
                        lock (file)
                        {
                            byte[] array = new byte[file.Length];
                            file.Read(array, 0, array.Length);
                            count = Convert.ToInt32(System.Text.Encoding.Default.GetString(array));
                            count++;
                            file.Close();
                        }
                    }

                    using (FileStream file = new FileStream(word + ".txt", FileMode.Truncate))
                    {
                        lock (file)
                        {
                            var t = System.Text.Encoding.Default.GetBytes(count.ToString());
                            file.Write(t, 0, t.Length);
                            file.Close();
                        }
                    }

                }
                //ChengeOrAddItem(word, count);
            }
            finally
            {
                _lock.ReleaseMutex();
            }

            ChengeOrAddItem(word, count);
        }

        public Dictionary<string, int> GetDirectory()
        {
            return topWord.GetDictionary();
        }
    }
}
