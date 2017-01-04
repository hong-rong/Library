using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Sorting.MergeSort
{
    [TestClass]
    public class Exercise
    {
        private IComparable[] mergeSortData = new string[] { "A", "E", "Q", "S", "U", "Y", "E", "I", "N", "O", "S", "T" };

        [TestMethod]
        public void E222()
        {
            new SortRunner(new MergeSort()).RunSort(mergeSortData);
        }

        [TestMethod]
        public void E223()
        {
            new SortRunner(new MergeSortBottomUp()).RunSort(mergeSortData);
        }
    }
}
