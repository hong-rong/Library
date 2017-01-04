using Lib.Common.Ds.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Enqueue_Test()
        {
            var queue = CreateQueue();
            queue.Enqueue(9);

            Assert.AreEqual(3, queue.Size());
            Assert.AreEqual(9, queue.Peek());
        }

        [TestMethod]
        public void Enqueue_Header_Null_Test()
        {
            var queue = new Queue<int>();

            queue.Enqueue(9);
            Assert.AreEqual(1, queue.Size());
            Assert.AreEqual(9, queue.Peek());

            queue.Enqueue(11);
            Assert.AreEqual(2, queue.Size());
            Assert.AreEqual(11, queue.Peek());
        }

        [TestMethod]
        public void Dequeue_Test()
        {
            var queue = CreateQueue();
            var data = queue.Dequeue();

            Assert.AreEqual(1, queue.Size());
            Assert.AreEqual(1, data);
        }

        [TestMethod]
        public void Dequeue_One_Item_Test()
        {
            var queue = new Queue<int>();
            queue.Enqueue(9);

            var item = queue.Dequeue();

            Assert.AreEqual(0, queue.Size());
            Assert.AreEqual(9, item);
        }

        [TestMethod]
        public void Peek_Test()
        {
            var queue = CreateQueue();
            var item = queue.Peek();

            Assert.AreEqual(2, item);
        }

        [TestMethod]
        public void IsEmpty_False_Test()
        {
            var queue = CreateQueue();

            Assert.IsFalse(queue.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_True_Test()
        {
            var queue = new Queue<int>();

            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void Size_Test()
        {
            var queue = CreateQueue();

            Assert.AreEqual(2, queue.Size());
        }

        [TestMethod]
        public void Size_Zero_Test()
        {
            var queue = new Queue<int>();

            Assert.AreEqual(0, queue.Size());
        }

        [TestMethod]
        public void ToString_Test()
        {
            var queue = CreateQueue();

            Assert.AreEqual("1 2 ", queue.ToString());
        }

        #region IEnumerable

        [TestMethod]
        public void IEnumerable_Test()
        {
            var q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            int i = 0;
            foreach (var item in q)
            {
                Assert.AreEqual(++i, item);
            }

            i = 0;
            foreach (var item in q)
            {
                Assert.AreEqual(++i, item);
            }
        }

        #endregion

        private Queue<int> CreateQueue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            return queue;
        }
    }
}