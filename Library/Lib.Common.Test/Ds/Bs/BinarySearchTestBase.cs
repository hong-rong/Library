using Lib.Common.Ds.Bs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lib.Common.Test.Ds.Bs
{
    [TestClass]
    public abstract class BinarySearchTestBase
    {
        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void Search_EmptyException_Test()
        {
            Create().Search(new int[] { }, 1);
        }


        [TestMethod]
        public void Search_OneElementSearchMiss_Test()
        {
            var result = Create().Search(new int[] { 1 }, 2);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Search_OneElementSearchHit_Test()
        {
            var result = Create().Search(new int[] { 1 }, 1);

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void Search_EvenNumberHitLeftMiddle_Test()
        {
            var result = Create().Search(new int[] { 1, 2, 3, 4 }, 2);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Search_EvenNumberHitRightMiddle_Test()
        {
            var result = Create().Search(new int[] { 1, 2, 3, 4 }, 3);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Search_EvenNumberMiss_Test()
        {
            var result = Create().Search(new int[] { 1, 2, 4, 5 }, 3);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Search_EvenNumberHitMin_Test()
        {
            var result = Create().Search(new int[] { 1, 2, 3, 4 }, 1);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Search_EvenNumberHitMax_Test()
        {
            var result = Create().Search(new int[] { 1, 2, 3, 4 }, 4);

            Assert.AreEqual(3, result);
        }


        [TestMethod]
        public void Search_OddNumberMiddleHit_Test()
        {
            var result = Create().Search(new int[] { 1, 2, 3, 4, 5 }, 3);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Search_OddNumberMiddleMiss_Test()
        {
            var result = Create().Search(new int[] { 1, 2, 4, 5, 6 }, 3);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Search_OddNumberMinHit_Test()
        {
            var result = Create().Search(new int[] { 1, 2, 3, 4, 5 }, 1);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Search_OddNumberMaxHit_Test()
        {
            var result = Create().Search(new int[] { 1, 2, 3, 4, 5 }, 5);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Search_Large_Test()
        {
            var result = Create().Search(new int[] { 1, 4, 6, 7, 12, 13, 15, 18, 19, 20, 22, 24 }, 20);

            Assert.AreEqual(9, result);
        }

        protected abstract BinarySearch Create();
    }
}