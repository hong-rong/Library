using Algorithm.Sorting.ElementarySorts;
using Lib.Common.UnitTest.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Al.Test.S
{
    [TestClass]
    public class IsTest
    {
        [TestMethod]
        public void S_Test()
        {
            SortingTestHelper.SortAssert(new InsertionSort().Sort);
        }
    }
}