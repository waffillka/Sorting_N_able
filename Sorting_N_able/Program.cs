using System;
using System.Collections.Generic;

namespace Sorting_N_able
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var arr = new int[] { 2, 4, 5, 6, 7, 7 };
            var list = new List<string>() { "c", "a", "b", "ab", "ac", "bb", "ca"}; //{ 3, 2, 1, 3, 2, 1, 3, 2, 1 };
            list = (List<string>)Sorting.SortBySimpleInserts(list);

            foreach (var t in list)
                Console.WriteLine(t);
        }
    }
}
