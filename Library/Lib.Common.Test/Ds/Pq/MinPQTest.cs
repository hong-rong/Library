using Lib.Common.Al.Graph;
using Lib.Common.Ds.Pq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds.Pq
{
    [TestClass]
    public class MinPQTest
    {
        private MinPQ<Distance> _target;

        [TestInitialize]
        public void Initialize()
        {
            _target = new MinPQ<Distance>();
            _target.Insert(new Distance { V = 0, Dist = 3 });
            _target.Insert(new Distance { V = 1, Dist = 1 });
            _target.Insert(new Distance { V = 2, Dist = 2 });
        }

        [TestMethod]
        public void Insert_Test()
        {
            Assert.AreEqual(1, _target.DelRoot().Dist);
            Assert.AreEqual(2, _target.DelRoot().Dist);
            Assert.AreEqual(3, _target.DelRoot().Dist);
        }
    }
}
