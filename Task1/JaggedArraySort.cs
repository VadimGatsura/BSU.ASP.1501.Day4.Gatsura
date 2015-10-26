using System;

namespace Task1 {

    /// <summary>
    /// Interface for compare two entities
    /// </summary>
    /// <typeparam name="T">The type of entity</typeparam>
    public interface IComporator<T>  {
        /// <summary>
        /// Compare two entities
        /// </summary>
        /// <param name="obj1">The first entity</param>
        /// <param name="obj2">The second entity</param>
        /// <returns>The comparison result</returns>
        int Compare(T obj1, T obj2);
    } 

    /// <summary>
    /// Sorting the jagged array
    /// </summary>
    public static class JaggedArraySort {
        #region Public Methods 

        /// <summary>
        /// Sort jagged array by the <see cref="IComporator{T}"/>
        ///  <remarks>null sub-arrays go to the end of jagged array</remarks> 
        /// </summary>
        /// <typeparam name="T">The type of array elements</typeparam>
        /// <param name="array">Jagged array for sorting</param>
        /// <param name="comparator">Interface, which allow compare two sub-arrays</param>
        public static void Sort<T>(T[] array, IComporator<T> comparator) {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (comparator == null)
                throw new ArgumentNullException(nameof(comparator));

            for (int i = array.Length - 1; i > 0; i--) {
                for (int j = 0; j < i; j++) {
                    if (comparator.Compare(array[j], array[j + 1]) > 0) {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
        #endregion

        #region Private Methods
        private static void Swap<T>(ref T firstArray, ref T secondArray) {
            var bufferArray = firstArray;
            firstArray = secondArray;
            secondArray = bufferArray;
        }
        #endregion
    }
}