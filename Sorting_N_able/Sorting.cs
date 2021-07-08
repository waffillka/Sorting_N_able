using System;
using System.Collections.Generic;
using System.Linq;

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

        public static IList<T> BubbleSort<T>(IList<T> collection)
            where T : IComparable<T>
        {
            for (int i = 0; i + 1 < collection.Count; ++i)
            {
                for (int j = 0; j + 1 < collection.Count - i; ++j)
                {
                    if (collection[j + 1].CompareTo(collection[j]) == -1)
                    {
                        T temp = collection[j + 1];
                        collection[j + 1] = collection[j];
                        collection[j] = temp;
                    }
                }
            }
            return collection;
        }
    }
}
