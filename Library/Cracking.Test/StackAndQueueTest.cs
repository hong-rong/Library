﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cracking.Test
{
    [TestClass]
    public class StackAndQueueTest
    {
        #region test

        #region S test

        [TestMethod]
        public void PuTest()
        {
            S<int> s = new S<int>();
            s.Push(1);
            Assert.AreEqual(1, s.Top.Data);
        }

        [TestMethod]
        public void PoNullTest()
        {
            S<int> s = new S<int>();
            s.Invoking(x => x.Pop()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void PoTest()
        {
            S<int> s = new S<int>();
            s.Push(1);
            s.Push(2);
            var exp = s.Pop();
            Assert.AreEqual(2, exp);
            exp = s.Pop();
            Assert.AreEqual(1, exp);
        }

        [TestMethod]
        public void PeNullTest()
        {
            S<int> s = new S<int>();
            s.Invoking(x => x.Peek()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void PeTest()
        {
            S<int> s = new S<int>();
            s.Push(1);
            s.Push(2);
            var exp = s.Peek();
            Assert.AreEqual(2, exp);
            exp = s.Peek();
            Assert.AreEqual(2, exp);
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            S<int> s = new S<int>();
            Assert.IsTrue(s.IsEmpty());
            s.Push(1);
            Assert.IsFalse(s.IsEmpty());
        }

        [TestMethod]
        public void TopTest()
        {
            S<int> s = new S<int>();
            Assert.IsNull(s.Top);
            s.Push(1);
            Assert.AreEqual(1, s.Top.Data);
            s.Push(2);
            Assert.AreEqual(2, s.Top.Data);
            s.Pop();
            Assert.AreEqual(1, s.Top.Data);
            s.Pop();
            Assert.IsNull(s.Top);
        }

        #endregion

        #region Q test

        [TestMethod]
        public void AddTest()
        {
            Q<int> q = new Q<int>();
            q.Add(1);
            Assert.AreEqual(1, q.First.Data);
            Assert.AreEqual(1, q.Last.Data);
            q.Add(2);
            Assert.AreEqual(1, q.First.Data);
            Assert.AreEqual(2, q.Last.Data);
        }

        [TestMethod]
        public void RemoveNullTest()
        {
            Q<int> q = new Q<int>();
            q.Invoking(x => x.Remove()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void RemoveTest()
        {
            Q<int> q = new Q<int>();
            q.Add(1);
            q.Add(2);
            var exp = q.Remove();
            Assert.AreEqual(1, exp);
            Assert.AreEqual(2, q.First.Data);
            Assert.AreEqual(2, q.Last.Data);
            exp = q.Remove();
            Assert.AreEqual(2, exp);
            Assert.IsNull(q.First);
            Assert.IsNull(q.Last);
        }

        [TestMethod]
        public void QPeNullTest()
        {
            Q<int> q = new Q<int>();
            q.Invoking(x => x.Peek()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void QPeTest()
        {
            Q<int> q = new Q<int>();
            q.Add(1);
            q.Add(2);
            var exp = q.Peek();
            Assert.AreEqual(1, exp);
            Assert.AreEqual(1, q.First.Data);
            Assert.AreEqual(2, q.Last.Data);
            exp = q.Peek();
            Assert.AreEqual(1, exp);
            Assert.AreEqual(1, q.First.Data);
            Assert.AreEqual(2, q.Last.Data);
        }

        [TestMethod]
        public void QIsEmptyTest()
        {
            Q<int> q = new Q<int>();
            Assert.IsTrue(q.IsEmpty());
            q.Add(1);
            Assert.IsFalse(q.IsEmpty());
        }

        #endregion

        [TestMethod]
        public void SMinTest()
        {
            StackAndQueue.SWithNodeMin s = new StackAndQueue.SWithNodeMin();
            s.Push(3);
            Assert.AreEqual(3, s.Min);
            s.Push(1);
            Assert.AreEqual(1, s.Min);
            s.Push(1);
            Assert.AreEqual(1, s.Min);
            s.Push(2);
            Assert.AreEqual(1, s.Min);
            s.Pop();//2
            Assert.AreEqual(1, s.Min);
            s.Pop();//1
            Assert.AreEqual(1, s.Min);
            s.Pop();//1
            Assert.AreEqual(3, s.Min);
        }

        [TestMethod]
        public void SwithStackMinTest()
        {
            StackAndQueue.SwithStackMin s = new StackAndQueue.SwithStackMin();
            s.Push(3);
            Assert.AreEqual(3, s.Min);
            s.Push(1);
            Assert.AreEqual(1, s.Min);
            s.Push(1);
            Assert.AreEqual(1, s.Min);
            s.Push(2);
            Assert.AreEqual(1, s.Min);
            s.Pop();//2
            Assert.AreEqual(1, s.Min);
            s.Pop();//1
            Assert.AreEqual(1, s.Min);
            s.Pop();//1
            Assert.AreEqual(3, s.Min);
        }

        #region set of s

        #region SWithA

        [TestMethod]
        public void SWithAPuTest()
        {
            StackAndQueue.SWithA<int> s = new StackAndQueue.SWithA<int>();
            s.Push(1);
            Assert.AreEqual(1, s.Peek());
        }

        [TestMethod]
        public void SWithAPuFullExTest()
        {
            StackAndQueue.SWithA<int> s = new StackAndQueue.SWithA<int>();
            s.Push(1);
            s.Push(1);
            s.Push(1);
            s.Push(1);
            s.Invoking(x => x.Push(1)).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void SWithAPoNullTest()
        {
            StackAndQueue.SWithA<int> s = new StackAndQueue.SWithA<int>();
            s.Invoking(x => x.Pop()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void SWithAPoTest()
        {
            StackAndQueue.SWithA<int> s = new StackAndQueue.SWithA<int>();
            s.Push(1);
            s.Push(2);
            var exp = s.Pop();
            Assert.AreEqual(2, exp);
            exp = s.Pop();
            Assert.AreEqual(1, exp);
        }

        [TestMethod]
        public void SWithAPeNullTest()
        {
            StackAndQueue.SWithA<int> s = new StackAndQueue.SWithA<int>();
            s.Invoking(x => x.Peek()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void SWithAPeTest()
        {
            StackAndQueue.SWithA<int> s = new StackAndQueue.SWithA<int>();
            s.Push(1);
            s.Push(2);
            var exp = s.Peek();
            Assert.AreEqual(2, exp);
            exp = s.Peek();
            Assert.AreEqual(2, exp);
        }

        [TestMethod]
        public void SWithAIsEmptyTest()
        {
            StackAndQueue.SWithA<int> s = new StackAndQueue.SWithA<int>();
            Assert.IsTrue(s.IsEmpty());
            s.Push(1);
            Assert.IsFalse(s.IsEmpty());
        }

        [TestMethod]
        public void SWithAIsFullTest()
        {
            StackAndQueue.SWithA<int> s = new StackAndQueue.SWithA<int>();
            s.Push(1);
            Assert.IsFalse(s.IsFull());
            s.Push(1);
            Assert.IsFalse(s.IsFull());
            s.Push(1);
            Assert.IsFalse(s.IsFull());
            s.Push(1);
            Assert.IsTrue(s.IsFull());
        }

        #endregion

        [TestMethod]
        public void SetOfSAPuTest()
        {
            StackAndQueue.SetOfS<int> s = new StackAndQueue.SetOfS<int>();
            s.Push(1);
            Assert.AreEqual(1, s.Peek());
        }

        [TestMethod]
        public void SetOfSPuFullTest()
        {
            StackAndQueue.SetOfS<int> s = new StackAndQueue.SetOfS<int>();
            for (int i = 0; i < StackAndQueue.SWithA<int>.Capacity * 2 + 1; i++)
            {
                s.Push(i);
            }
        }

        [TestMethod]
        public void SetOfSPoNullTest()
        {
            StackAndQueue.SetOfS<int> s = new StackAndQueue.SetOfS<int>();
            s.Invoking(x => x.Pop()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void SetOfSPoTest()
        {
            StackAndQueue.SetOfS<int> s = new StackAndQueue.SetOfS<int>();
            s.Push(1);
            s.Push(2);
            var exp = s.Pop();
            Assert.AreEqual(2, exp);
            exp = s.Pop();
            Assert.AreEqual(1, exp);
        }

        [TestMethod]
        public void SetOfSPuEmptyTest()
        {
            StackAndQueue.SetOfS<int> s = new StackAndQueue.SetOfS<int>();
            int count = StackAndQueue.SWithA<int>.Capacity * 2 + 1;
            for (int i = 0; i < count; i++)
            {
                s.Push(i);
            }
            int index = count;
            for (int i = 0; i < count; i++)
            {
                var exp = s.Pop();
                Assert.AreEqual(--index, exp);
            }
            Assert.IsTrue(s.IsEmpty());
        }

        [TestMethod]
        public void SetOfSPeNullTest()
        {
            StackAndQueue.SetOfS<int> s = new StackAndQueue.SetOfS<int>();
            s.Invoking(x => x.Peek()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void SetOfSPeTest()
        {
            StackAndQueue.SetOfS<int> s = new StackAndQueue.SetOfS<int>();
            s.Push(1);
            s.Push(2);
            var exp = s.Peek();
            Assert.AreEqual(2, exp);
            exp = s.Peek();
            Assert.AreEqual(2, exp);
        }

        [TestMethod]
        public void SetOfSIsEmptyTest()
        {
            StackAndQueue.SetOfS<int> s = new StackAndQueue.SetOfS<int>();
            Assert.IsTrue(s.IsEmpty());
            s.Push(1);
            Assert.IsFalse(s.IsEmpty());
        }

        #endregion

        #region q with s

        [TestMethod]
        public void QWithSAddTest()
        {
            StackAndQueue.QWithS<int> q = new StackAndQueue.QWithS<int>();
            q.Add(1);
            Assert.AreEqual(1, q.First);
            Assert.AreEqual(1, q.Last);
            q.Add(2);
            Assert.AreEqual(1, q.First);
            Assert.AreEqual(2, q.Last);
        }

        [TestMethod]
        public void QWithSRemoveNullTest()
        {
            StackAndQueue.QWithS<int> q = new StackAndQueue.QWithS<int>();
            q.Invoking(x => x.Remove()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void QWithSRemoveTest()
        {
            StackAndQueue.QWithS<int> q = new StackAndQueue.QWithS<int>();
            q.Add(1);
            q.Add(2);
            var exp = q.Remove();
            Assert.AreEqual(1, exp);
            Assert.AreEqual(2, q.First);
            Assert.AreEqual(2, q.Last);
            exp = q.Remove();
            Assert.AreEqual(2, exp);
            Assert.IsTrue(q.IsEmpty());
        }

        [TestMethod]
        public void QWithSFirstEmptyExTest()
        {
            StackAndQueue.QWithS<int> q = new StackAndQueue.QWithS<int>();
            q.Invoking(x => { var f = x.First; }).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void QWithSFirstTest()
        {
            StackAndQueue.QWithS<int> q = new StackAndQueue.QWithS<int>();
            q.Add(1);
            Assert.AreEqual(1, q.First);
            q.Add(2);
            Assert.AreEqual(1, q.First);
        }

        [TestMethod]
        public void QWithSLastEmptyExTest()
        {
            StackAndQueue.QWithS<int> q = new StackAndQueue.QWithS<int>();
            q.Invoking(x => { var f = x.Last; }).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void QWithSLastTest()
        {
            StackAndQueue.QWithS<int> q = new StackAndQueue.QWithS<int>();
            q.Add(1);
            Assert.AreEqual(1, q.Last);
            q.Add(2);
            Assert.AreEqual(2, q.Last);
        }

        [TestMethod]
        public void QWithSQIsEmptyTest()
        {
            StackAndQueue.QWithS<int> q = new StackAndQueue.QWithS<int>();
            Assert.IsTrue(q.IsEmpty());
            q.Add(1);
            Assert.IsFalse(q.IsEmpty());
        }

        #endregion

        #region sort s

        [TestMethod]
        public void SortSPuTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            s.Push(1);
            Assert.AreEqual(1, s.Top.Data);
        }

        [TestMethod]
        public void SortSPuOrderTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            s.Push(3);
            Assert.AreEqual(3, s.Peek());
            s.Push(2);
            Assert.AreEqual(2, s.Peek());
            s.Push(3);
            Assert.AreEqual(2, s.Peek());
            s.Push(4);
            Assert.AreEqual(2, s.Peek());
            s.Push(1);
            Assert.AreEqual(1, s.Peek());
        }

        [TestMethod]
        public void SortSPoNullTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            s.Invoking(x => x.Pop()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void SortSPoTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            s.Push(1);
            s.Push(2);
            var exp = s.Pop();
            Assert.AreEqual(1, exp);
            exp = s.Pop();
            Assert.AreEqual(2, exp);
        }

        [TestMethod]
        public void SortSPoOrderTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            s.Push(3);
            s.Push(2);
            s.Push(1);
            var exp = s.Pop();
            Assert.AreEqual(1, exp);
            exp = s.Pop();
            Assert.AreEqual(2, exp);
            exp = s.Pop();
            Assert.AreEqual(3, exp);
        }

        [TestMethod]
        public void SortSPeNullTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            s.Invoking(x => x.Peek()).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void SortSPeTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            s.Push(1);
            s.Push(2);
            var exp = s.Peek();
            Assert.AreEqual(1, exp);
            exp = s.Peek();
            Assert.AreEqual(1, exp);
        }

        [TestMethod]
        public void SortSPeOrderTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            s.Push(2);
            s.Push(2);
            s.Push(1);
            var exp = s.Peek();
            Assert.AreEqual(1, exp);
            exp = s.Peek();
            Assert.AreEqual(1, exp);
        }

        [TestMethod]
        public void SortSIsEmptyTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            Assert.IsTrue(s.IsEmpty());
            s.Push(1);
            Assert.IsFalse(s.IsEmpty());
        }

        [TestMethod]
        public void SortSTopTest()
        {
            StackAndQueue.SortS s = new StackAndQueue.SortS();
            s.Push(1);
            Assert.AreEqual(1, s.Top.Data);
            s.Push(2);
            Assert.AreEqual(1, s.Top.Data);
            s.Pop();
            Assert.AreEqual(2, s.Top.Data);
        }

        #endregion

        #endregion
    }
}