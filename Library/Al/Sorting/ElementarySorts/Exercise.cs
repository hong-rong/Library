using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Sorting.ElementarySorts
{
    [TestClass]
    public class Exercise
    {
        private IComparable[] selectInsertData = new string[] { "E", "A", "S", "Y", "Q", "U", "E", "S", "T", "I", "O", "N" };
        private IComparable[] shellData = new string[] { "E", "A", "S", "Y", "S", "H", "E", "L", "L", "S", "O", "R", "T", "Q", "U", "E", "S", "T", "I", "O", "N" };

        [TestMethod]
        public void E211()
        {
            new SortRunner(new SelectionSort()).RunSort(selectInsertData);
        }

        [TestMethod]
        public void E214()
        {
            new SortRunner(new InsertionSort()).RunSort(selectInsertData);
        }

        [TestMethod]
        public void E216()
        {
            new SortRunner(new ShellSort()).RunSort(shellData);
        }
    }
}
