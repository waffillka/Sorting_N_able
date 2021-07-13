using System.Collections.Generic;
using Sorting_N_able.TaskReaderWriter;
using System.Threading;

namespace Sorting_N_able
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Console.WriteLine("Hello World!");
            ////var arr = new int[] { 2, 4, 5, 6, 7, 7 };
            //var list = new List<string>() { "c", "a", "b", "ab", "ac", "bb", "ca"}; //{ 3, 2, 1, 3, 2, 1, 3, 2, 1 };
            //list = (List<string>)Sorting.SortBySimpleInserts(list);

            //foreach (var t in list)
            //    Console.WriteLine(t);

            //var list = new CustomList<int>();
            //for (int i = 0; i < 6; i++)
            //{
            //    list.Push_front(i);
            //}

            //foreach (var t in list.ToList())
            //{
            //    Console.WriteLine(t);
            //}
            //Console.WriteLine("dsdsds" + list[0]);

            //list.Push_back(333);
            //foreach (var t in list.ToList())
            //{
            //    Console.WriteLine(t);
            //}


            //var t = new WordCounter.WordCounter(3);
            //t.WordIteratorParallel(new string[] {
            //    "d:\\EPAM\\N-able\\Lessons\\FirstLessonSorting\\Sorting_N_able\\Sorting_N_able\\WordCounter\\TestText.txt",
            //    "d:\\EPAM\\N-able\\Lessons\\FirstLessonSorting\\Sorting_N_able\\Sorting_N_able\\WordCounter\\TestText_1.txt"
            //});

            //foreach (var item in t.GetDirectory())
            //{
            //    System.Console.WriteLine(item.Key + ": " + item.Value);
            //}

           var _pool = new Semaphore(0, 3);
            List<Thread> threads = new();
            var task = new TaskReaderWriter.TaskReaderWriter<int>();

            for(int i = 0; i < 10; ++i)
            {
                var t = new Thread(new ThreadStart(() => task.Write(i)));
                var r = new Thread(new ThreadStart(() => task.Read(i)));
                threads.Add(t);
                threads.Add(r);
                t.Start();
                r.Start();
            }

            foreach(var thread in threads)
            {
                thread.Join();
            }
            var u  = task;
        }
    }


}
