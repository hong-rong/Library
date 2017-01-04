using Lib.Common.Al.Graph;
using Lib.Common.Ds.Pq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds.Pq
{
    [TestClass]
    public class IndexMaxPQTest
    {
        private IndexMaxPQ<Distance> _target;

        [TestInitialize]
        public void Initialize()
        {
            _target = new IndexMaxPQ<Distance>(4);
            _target.Insert(2, new Distance { V = 2, Dist = 1 });
            _target.Insert(1, new Distance { V = 1, Dist = 3 });
            _target.Insert(0, new Distance { V = 0, Dist = 2 });
        }

        [TestMethod]
        public void Insert_Test()
        {
            Assert.AreEqual(3, _target.Size());
            Assert.AreEqual(1, _target.RootIndex());
            Assert.AreEqual(3, _target.Root().Dist);
        }

        [TestMethod]
        public void ChangeKey_Test()
        {
            _target.ChangeKey(1, new Distance { V = 1, Dist = 0 });
            Assert.AreEqual(0, _target.RootIndex());
            Assert.AreEqual(2, _target.Root().Dist);
        }

        [TestMethod]
        public void DeleteMax_Test()
        {
            var index = _target.DelRoot();
            Assert.AreEqual(1, index);
            Assert.AreEqual(2, _target.Size());
            Assert.AreEqual(0, _target.RootIndex());
            Assert.AreEqual(2, _target.Root().Dist);
        }

        [TestMethod]
        public void Delete_Test()
        {
            _target.Delete(1);
            Assert.AreEqual(2, _target.Size());
            Assert.AreEqual(0, _target.RootIndex());
            Assert.AreEqual(2, _target.Root().Dist);
        }

        [TestMethod]
        public void Max_Test()
        {
            var tKey = _target.Root();
            Assert.AreEqual(3, tKey.Dist);
        }

        [TestMethod]
        public void MaxIndex_Test()
        {
            var index = _target.RootIndex();
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void Contains_Test()
        {
            Assert.IsTrue(_target.Contains(0));
            Assert.IsFalse(_target.Contains(3));
        }

        [TestMethod]
        public void IsEmpty_Test()
        {
            Assert.IsFalse(_target.IsEmpty());
            _target.DelRoot();
            _target.DelRoot();
            _target.DelRoot();
            Assert.IsTrue(_target.IsEmpty());
        }

        [TestMethod]
        public void Size_Test()
        {
            Assert.AreEqual(3, _target.Size());
        }
    }
}