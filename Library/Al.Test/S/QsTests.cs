using Lib.Common.UnitTest.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm.Sorting.QuickSort;

namespace Al.Test.S
{
    [TestClass]
    public class QsTests
    {
        [TestMethod]
        public void Sort_Test()
        {
            SortingTestHelper.SortAssert(new QuickSort().Sort);
        }

        [TestMethod]
        public void Partition_Test()
        {
            var arr = SortingTestHelper.GetTestCase(0);

            SortingTestHelper.PrintArray(arr);

            new QuickSort().Partition(arr, 0, arr.Length - 1);

            SortingTestHelper.PrintArray(arr);
        }
    }
}