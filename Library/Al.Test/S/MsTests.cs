using Algorithm.Sorting.MergeSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Al.Test.S
{
    [TestClass]
    public class MsTests
    {
        [TestMethod]
        public void Sort_Test()
        {
            //Lib.Common.UnitTest.Sorting.SortingTestHelper.SortAssert(new MergeSort().Sort);
            IComparable[] a = new IComparable[] { 10, 2, 5, 3, 7, 13, 1, 6 };
            new MergeSortV2().Sort(a);
        }
    }
}