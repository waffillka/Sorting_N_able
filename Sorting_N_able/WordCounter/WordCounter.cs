using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_N_able.WordCounter
{
    public static class WordCounter
    {
        //private Dictionary<string, int> topWords;
        //private int countTopWord;
        //private string path;

        //public WordCounter()
        //{
        //    this.countTopWord = 0;
        //}

        //public WordCounter(string path, int countTopWord)
        //{
        //    this.countTopWord = countTopWord;
        //    this.path = path;
        //}

        public static void WordIterator(string path)
        {
            StringBuilder tempString = new();
            char tempChar;

            using(StreamReader file = new StreamReader(path))
            {
                while(file.Peek() > -1)
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

        private static void ChengeOrCreateWordFile(string word)
        {
            int count = 1;
            try
            {
                using (FileStream file = new FileStream(word + ".txt", FileMode.CreateNew))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(count.ToString());
                    file.Write(array, 0, array.Length);
                }
            }
            catch(IOException)
            {

                using (FileStream file = new FileStream(word + ".txt", FileMode.Open))
                {
                    byte[] array = new byte[file.Length];
                    file.Read(array, 0, array.Length);
                    count = Convert.ToInt32(System.Text.Encoding.Default.GetString(array));
                    count++;
                    file.Close();
                }

                using (FileStream file = new FileStream(word + ".txt", FileMode.Truncate))
                {
                    var t = System.Text.Encoding.Default.GetBytes(count.ToString());
                    file.Write(t, 0, t.Length);
                    file.Close();
                }
            }
        }
    }
}
