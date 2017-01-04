using Lib.Common.Al.Dp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class LongestIncreasingSequenceTest
    {
        [TestMethod]
        public void GetLongest_Test()
        {
            LongestIncreasingSequence.GetLongest(new[] { 5, 2, 8, 6, 3, 6, 9, 7 });
        }
    }
}
