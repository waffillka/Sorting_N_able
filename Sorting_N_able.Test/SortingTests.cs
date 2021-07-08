using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sorting_N_able.Test
{
    public class SortingTests
    {
        //---------------------------SortBySimpleInserts----------------------------------
        [Theory]
        [InlineData(new int[] { }, new int[] { })] //
        [InlineData(new int[] { 1 }, new int[] { 1 })] //
        [InlineData(new int[] { 1, 2 }, new int[] { 1, 2 })] //
        [InlineData(new int[] { 2, 1 }, new int[] { 1, 2 })] //

        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 2, 1, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 2, 3, 1 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]

        [InlineData(new int[] { 3, 2, 1, 3, 2, 1, 3, 2, 1 }, new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 })]
        [InlineData(new int[] { 1, 6, 2, 6, 3, 6, 4, 6, 5, 6, 7, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7 })]
        [InlineData(new int[] { 7, 6, 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void SortBySimpleInsertsIntTests(int[] array, int[] expected)
        {
            array = (int[])Sorting.SortBySimpleInserts(array);
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new string[] { "c", "a", "b", "ab", "ac", "bb", "ca" }, new string[] { "a", "ab", "ac", "b", "bb", "c", "ca" })]
        [InlineData(new string[] { "c", "a", "b" }, new string[] { "a", "b", "c" })]
        public void SortBySimpleInsertsStringTests(string[] array, string[] expected)
        {
            var arrayList = (List<string>)Sorting.SortBySimpleInserts(array.ToList());
            Assert.Equal(expected.ToList(), arrayList);
        }

        [Theory]
        [InlineData(new double[] { 1.5, 1.9, 1.8, 1.1, 1.3, 1.7, 1.6, 1.2, 1.4, 1.0 }, new double[] { 1.0, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9 })]
        [InlineData(new double[] { 1.5, 1.9, 1.8, 1.1, 1.3, }, new double[] { 1.1, 1.3, 1.5, 1.8, 1.9 })]
        public void SortBySimpleInsertsDoubleTests(double[] array, double[] expected)
        {
            array = (double[])Sorting.SortBySimpleInserts(array);
            Assert.Equal(expected, array);
        }

        //---------------------------BubbleSort----------------------------------
        [Theory]
        [InlineData(new int[] { }, new int[] { })] //
        [InlineData(new int[] { 1 }, new int[] { 1 })] //
        [InlineData(new int[] { 1, 2 }, new int[] { 1, 2 })] //
        [InlineData(new int[] { 2, 1 }, new int[] { 1, 2 })] //

        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 2, 1, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 2, 3, 1 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]

        [InlineData(new int[] { 3, 2, 1, 3, 2, 1, 3, 2, 1 }, new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 })]
        [InlineData(new int[] { 1, 6, 2, 6, 3, 6, 4, 6, 5, 6, 7, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7 })]
        [InlineData(new int[] { 7, 6, 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void BubbleSortIntTests(int[] array, int[] expected)
        {
            array = (int[])Sorting.BubbleSort(array);
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new string[] { "c", "a", "b", "ab", "ac", "bb", "ca" }, new string[] { "a", "ab", "ac", "b", "bb", "c", "ca" })]
        [InlineData(new string[] { "c", "a", "b" }, new string[] { "a", "b", "c" })]
        public void BubbleSortStringTests(string[] array, string[] expected)
        {
            var arrayList = (List<string>)Sorting.BubbleSort(array.ToList());
            Assert.Equal(expected.ToList(), arrayList);
        }

        [Theory]
        [InlineData(new double[] { 1.5, 1.9, 1.8, 1.1, 1.3, 1.7, 1.6, 1.2, 1.4, 1.0 }, new double[] { 1.0, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9 })]
        [InlineData(new double[] { 1.5, 1.9, 1.8, 1.1, 1.3, }, new double[] { 1.1, 1.3, 1.5, 1.8, 1.9 })]
        public void BubbleSortDoubleTests(double[] array, double[] expected)
        {
            array = (double[])Sorting.BubbleSort(array);
            Assert.Equal(expected, array);
        }
    }
}
