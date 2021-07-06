using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_N_able
{
    public static class Sorting
    {
        public static IList<T> SortBySimpleInserts<T>(IList<T> collection)
            where T : IComparable<T>
        {
            int j;
            
            for (int i = 1; i < collection.Count(); ++i)
            {
                j = i;
                var key = collection[i];
                while (j > 0 && collection[j - 1].CompareTo(key) == 1)
                {
                    collection[j] = collection[j - 1];
                    --j;
                }
                collection[j] = key;
            }

            return collection;
        }
    }
}
