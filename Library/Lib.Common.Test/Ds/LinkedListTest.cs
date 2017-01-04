using Lib.Common.Ds.Common;
using Lib.Common.Ds.Ll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lib.Common.Test.Ds
{
    [TestClass]
    public class LinkedListTest
    {
        #region ctor

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Creat_Empty_Exception()
        {
            var ll = new LinkedList<int>(null);
        }

        #endregion

        #region Get

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_IndexOutOfRangeException_Test()
        {
            CreateLinkedList().Get(4);
        }

        [TestMethod]
        public void Get_EmptyGetNull_Test()
        {
            var value = CreateEmptyLinkedList().Get(0);

            Assert.AreEqual(default(int), value);
        }

        [TestMethod]
        public void Get_Index_Test()
        {
            var value = CreateLinkedList().Get(1);

            Assert.AreEqual(1, value);
        }

        [TestMethod]
        public void Get_Index_First_Test()
        {
            var value = CreateLinkedList().Get(0);

            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void Get_Index_Last_Test()
        {
            var value = CreateLinkedList().Get(3);

            Assert.AreEqual(4, value);
        }

        #endregion

        #region IndexOf

        [TestMethod]
        public void IndexOf_Test()
        {
            Assert.AreEqual(0, CreateLinkedList().FirstIndexOf(0));
            Assert.AreEqual(1, CreateLinkedList().FirstIndexOf(1));
            Assert.AreEqual(2, CreateLinkedList().FirstIndexOf(2));
        }

        [TestMethod]
        public void IndexOf_No_Test()
        {
            Assert.AreEqual(-1, CreateLinkedList().FirstIndexOf(3));
        }

        #endregion

        #region Contains

        [TestMethod]
        public void Contains_True_Test()
        {
            Assert.IsTrue(CreateLinkedList().Contains(1));
        }

        [TestMethod]
        public void Contains_False_Test()
        {
            Assert.IsFalse(CreateLinkedList().Contains(-1));
        }

        #endregion

        #region Size

        [TestMethod]
        public void SizeTest()
        {
            Assert.AreEqual(4, CreateLinkedList().Size());
        }

        #endregion

        #region AddFirst

        [TestMethod]
        public void AddFirst_Test()
        {
            var list = CreateLinkedList();
            list.AddFirst(9);

            Assert.AreNotEqual(9, list.Get(list.Size() - 1));
            Assert.AreEqual(9, list.Get(0));
            Assert.AreEqual(5, list.Size());
        }

        [TestMethod]
        public void AddFirst_Header_Null_Test()
        {
            var linkedList = CreateEmptyLinkedList();

            linkedList.AddFirst(9);
            Assert.AreEqual(9, linkedList.Get(0));

            linkedList.AddFirst(11);
            Assert.AreEqual(11, linkedList.Get(0));
            Assert.AreEqual(9, linkedList.Get(1));
        }

        #endregion

        #region AddLast

        [TestMethod]
        public void AddLast_Test()
        {
            var list = CreateLinkedList();
            list.AddLast(9);

            Assert.AreEqual(9, list.Get(list.Size() - 1));
            Assert.AreEqual(5, list.Size());

            list.AddLast(11);
            Assert.AreEqual(11, list.Get(list.Size() - 1));
            Assert.AreEqual(6, list.Size());
        }

        [TestMethod]
        public void AddLast_Header_Null_Test()
        {
            var linkedList = CreateEmptyLinkedList();

            linkedList.AddLast(9);
            Assert.AreEqual(9, linkedList.Get(0));

            linkedList.AddLast(11);
            Assert.AreEqual(9, linkedList.Get(0));
            Assert.AreEqual(11, linkedList.Get(1));
        }

        #endregion

        #region Add with Index

        [TestMethod]
        public void Add_Index_Test()
        {
            var list = CreateLinkedList();

            list.Add(1, 9);

            Assert.AreEqual(9, list.Get(2));
            Assert.AreEqual(5, list.Size());
        }

        #endregion

        #region Remove First

        [Ignore]
        [TestMethod]
        public void RemoveFirst_Test()
        {
            var list = CreateLinkedList();
            var removed = list.RemoveFirst();

            Assert.AreEqual(0, removed);
            Assert.AreEqual(default(int), list.Get(0));
        }

        #endregion

        #region Remove with Index

        [TestMethod]
        public void Remove_Index_Test()
        {
            var list = CreateLinkedList();
            list.Remove(2);

            Assert.AreEqual(3, list.Size());
            Assert.AreEqual(4, list.Get(list.Size() - 1));
        }

        [TestMethod]
        public void Remove_Index_Header_Null_Test()
        {
            var list = CreateEmptyLinkedList();
            var removed = list.Remove(3);

            Assert.AreEqual(default(int), removed);
        }

        [TestMethod]
        public void Remove_Index_Zero_Test()
        {
            var list = CreateLinkedList();
            var removed = list.Remove(0);

            Assert.AreEqual(3, list.Size());
            Assert.AreEqual(0, removed);
        }

        #endregion

        #region Clear

        [TestMethod]
        public void Clear_Test()
        {
            var list = CreateLinkedList();
            list.Clear();

            Assert.AreEqual(0, list.Size());
        }

        #endregion

        #region IEnumerable

        [TestMethod]
        public void EnumerableTest()
        {
            var list = CreateLinkedList();

            var k = 0;
            foreach (var item in list)
            {
                if (k == 0) Assert.AreEqual(0, item);
                if (k == 1) Assert.AreEqual(1, item);
                if (k == 2) Assert.AreEqual(2, item);
                if (k == 3) Assert.AreEqual(4, item);
                k++;
            }
        }

        [TestMethod]
        public void Enumerable_Multipile_Test()
        {
            var list = CreateLinkedList();

            for (var i = 0; i < 3; i++)
            {
                var k = 0;
                foreach (var item in list)
                {
                    if (k == 0) Assert.AreEqual(0, item);
                    if (k == 1) Assert.AreEqual(1, item);
                    if (k == 2) Assert.AreEqual(2, item);
                    if (k == 3) Assert.AreEqual(4, item);
                    k++;
                }
            }
        }

        #endregion

        #region ToArray

        [TestMethod]
        public void ToArrayTest()
        {
            var list = CreateLinkedList();
            var arr = list.ToArray();

            Assert.AreEqual(0, arr[0]);
            Assert.AreEqual(1, arr[1]);
            Assert.AreEqual(2, arr[2]);
            Assert.AreEqual(4, arr[3]);
        }

        #endregion

        protected LinkNode<int> CreateNodeHeader()
        {
            var first = new LinkNode<int> { Value = 0 };
            var second = new LinkNode<int>() { Value = 1 };
            var third = new LinkNode<int>() { Value = 2 };
            var fourth = new LinkNode<int>() { Value = 4 };

            first.Next = second;
            second.Next = third;
            third.Next = fourth;

            return first;
        }

        protected virtual LinkedList<int> CreateLinkedList()
        {
            var first = CreateNodeHeader();

            return new LinkedList<int>(first);
        }

        protected virtual LinkedList<int> CreateEmptyLinkedList()
        {
            return new LinkedList<int>();
        }
    }
}