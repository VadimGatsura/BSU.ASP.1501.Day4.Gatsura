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
        int[][] m_Array = { new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 }, null, null, new[] { 4, 3, 8, 5, 7 }, new []{45, 7, -95, 21, -1, 0, 37, 12} };

        public IEnumerable<TestCaseData>TestDatas {
            get {
                yield return new TestCaseData(new[] {new [] {0}, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 45, 7, -95, 21, -1, 0, 37, 12 }, new[] { 4, 3, 8, 5, 7 }, null, null}, new SumRowComparator(), true);
                yield return new TestCaseData(new[] { new[] { 0 }, new[] { 4, 3, 8, 5, 7 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 45, 7, -95, 21, -1, 0, 37, 12 }, null, null }, new MaxAbsElementComparator(), true);

                yield return new TestCaseData(new[] { null, null, new[] { 4, 3, 8, 5, 7 }, new[] { 45, 7, -95, 21, -1, 0, 37, 12 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 0 } }, new SumRowComparator(), false);
                yield return new TestCaseData(new[] {null, null, new[] { 45, 7, -95, 21, -1, 0, 37, 12 }, new[] { 4, 2, -1, 9, -8, 10 }, new[] { 4, 3, 8, 5, 7 }, new[] { 0 } }, new MaxAbsElementComparator(), false);
            }
        }

        [Test, TestCaseSource(nameof(TestDatas))]
        public void SortArray_Test(int[][] sortedArray, IComporator<int[]> comparator, bool asc) {

            JaggedArraySort.Sort(m_Array, comparator);
            if(!asc)
                m_Array = m_Array.Reverse().ToArray();
            
            CollectionAssert.AreEqual(m_Array, sortedArray);
        }

    }
}