using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task1.NUnitTest {

    [TestFixture]
    public class JaggedArraySortTest {
        //RowSum: 16, 0, null, null, 27, 26
        //MaxAbsElement: 10, 0, null, null, 8, 95
        readonly int[][] m_Array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, null, null, new[] { 4, 3, 8, 5, 7 }, new []{45, 7, -95, 21, -1, 0, 37, 12} };

        public IEnumerable<TestCaseData>TestDatas {
            get {
                yield return new TestCaseData(new[] {new [] {0}, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 45, 7, -95, 21, -1, 0, 37, 12 }, new[] { 4, 3, 8, 5, 7 }, null, null}, new SumArrayRowComparator(), true);
                yield return new TestCaseData(new[] { new[] { 0 }, new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 45, 7, -95, 21, -1, 0, 37, 12 }, null, null }, new MaxAbsArrayElementComparator(), true);

                yield return new TestCaseData(new[] { null, null, new[] { 4, 3, 8, 5, 7 }, new[] { 45, 7, -95, 21, -1, 0, 37, 12 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 } }, new SumArrayRowComparator(), false);
                yield return new TestCaseData(new[] {null, null, new[] { 45, 7, -95, 21, -1, 0, 37, 12 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 4, 3, 8, 5, 7 }, new[] { 0 } }, new MaxAbsArrayElementComparator(), false);
            }
        }

        [Test, TestCaseSource(nameof(TestDatas))]
        public void SortArray_Test(int[][] sortedArray, IArrayComporator<int> comparator, bool asc) {

            int[][] expectedArray = JaggedArraySort.Sort(m_Array, comparator);
            if(!asc)
                expectedArray = expectedArray.Reverse().ToArray();
            
            CollectionAssert.AreEqual(expectedArray, sortedArray);
        }

    }
}