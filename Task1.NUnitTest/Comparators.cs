using System;
using System.Linq;

namespace Task1.NUnitTest {

    /// <summary>
    /// Compare two arrays by the sum
    /// </summary>
    public class SumRowComparator : IComporator<int[]> {

        public int Compare(int[] array1, int[] array2)  {
            if (array1 == null && array2 == null)
                return 0;
            if (array1 == null)
                return 1;
            if (array2 == null)
                return -1;
            int firstSum = array1.Sum(), secondSum = array2.Sum();
            if (firstSum == secondSum)
                return 0;
            if (firstSum > secondSum)
                return 1;
            return -1;
        }
    }

    /// <summary>
    /// Compare two arrays by the maximum module in array
    /// </summary>
    public class MaxAbsElementComparator : IComporator<int[]> {
        public int Compare(int[] array1, int[] array2) {
            if (array1 == null && array2 == null)
                return 0;
            if (array1 == null)
                return 1;
            if (array2 == null)
                return -1;
            int[] tempArray1 = array1.Select(Math.Abs).ToArray();
            int[] tempArray2 = array2.Select(Math.Abs).ToArray();
            int firstMax = tempArray1.Max(), secondMax = tempArray2.Max();
            if (firstMax == secondMax)
                return 0;
            if (firstMax > secondMax)
                return 1;
            return -1;
        }
    }
}
