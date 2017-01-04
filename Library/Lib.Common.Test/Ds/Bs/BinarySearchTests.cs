using Lib.Common.Ds.Bs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds.Bs
{
    [TestClass]
    public class BinarySearchTests : BinarySearchTestBase
    {
        protected override BinarySearch Create()
        {
            return new BinarySearchMock();
        }
    }
}