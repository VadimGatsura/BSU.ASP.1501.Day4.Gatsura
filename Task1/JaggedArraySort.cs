using System;

namespace Task1 {

    /// <summary>
    /// Interface for compare two arrays
    /// </summary>
    /// <typeparam name="T">The type of array elements</typeparam>
    public interface IArrayComporator<T>  {
        /// <summary>
        /// Compare two arrays
        /// </summary>
        /// <param name="array1">The first array</param>
        /// <param name="array2">The second array</param>
        /// <returns>The comparison result</returns>
        int Compare(T[] array1, T[] array2);
    } 

    /// <summary>
    /// Sorting the jagged array
    /// </summary>
    public static class JaggedArraySort {
        #region Public Methods 

        /// <summary>
        /// Sort jagged array by the <see cref="IArrayComporator"/>
        ///  <remarks>null sub-arrays go to the end of jagged array</remarks> 
        /// </summary>
        /// <typeparam name="T">The type of array elements</typeparam>
        /// <param name="array">Jagged array for sorting</param>
        /// <param name="comparator">Interface, which allow compare two sub-arrays</param>
        public static T[][] Sort<T>(T[][] array, IArrayComporator<T> comparator) {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (comparator == null)
                throw new ArgumentNullException(nameof(comparator));

            T[][] tempArray = CopyArray(array);
            SortArray(tempArray, comparator); 
            return tempArray;
        }
        #endregion

        #region Private Methods
        private static void Swap<T>(ref T[] firstArray, ref T[] secondArray) {
            var bufferArray = firstArray;
            firstArray = secondArray;
            secondArray = bufferArray;
        }

        private static T[][] CopyArray<T>(T[][] array) {
            T[][] tempArray = new T[array.Length][];
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == null) {
                    tempArray[i] = null;
                    continue;
                }
                tempArray[i] = new T[array[i].Length];
                for (int j = 0; j < array[i].Length; j++) {
                    tempArray[i][j] = array[i][j];
                }

            }
            return tempArray;
        }

        private static void SortArray<T>(T[][] array, IArrayComporator<T> comparator) {
            for (int i = array.Length - 1; i > 0; i--) {
                for (int j = 0; j < i; j++) {
                    if (comparator.Compare(array[j], array[j + 1]) > 0) {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        } 
        #endregion
    }
}