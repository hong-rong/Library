using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cracking.Test
{
    [TestClass]
    public class LinkedListsTest
    {
        #region init
        private readonly LinkedLists _target;

        public LinkedListsTest()
        {
            _target = new LinkedLists();
        }
        #endregion

        #region tests
        #region test RemoveDuplicates
        [TestMethod]
        public void RemoveDuplicates_NoDuplicats_Test()
        {
            LinkedLists.Entity entity = new LinkedLists.Entity(1);
            entity.Append(2);
            entity.Append(3);
            entity.Append(4);
            entity.Append(5);
            _target.RemoveDuplicats(entity);
            int index = 0;
            do
            {
                Assert.AreEqual(++index, entity.Data);
                entity = entity.Next;
            } while (entity != null);
        }
        [TestMethod]
        public void RemoveDuplicates_TwoElementsOneDuplicat_Test()
        {
            LinkedLists.Entity entity = new LinkedLists.Entity(1);
            entity.Append(1);
            _target.RemoveDuplicats(entity);
            int index = 0;
            do
            {
                Assert.AreEqual(++index, entity.Data);
                entity = entity.Next;
            } while (entity != null);
        }
        [TestMethod]
        public void RemoveDuplicates_MultipleElementsOneDuplicat_Test()
        {
            LinkedLists.Entity entity = new LinkedLists.Entity(1);
            entity.Append(2);
            entity.Append(3);
            entity.Append(4);
            entity.Append(4);
            entity.Append(5);
            _target.RemoveDuplicats(entity);
            int index = 0;
            do
            {
                Assert.AreEqual(++index, entity.Data);
                entity = entity.Next;
            } while (entity != null);
        }
        [TestMethod]
        public void RemoveDuplicates_MultipleElementsMultipleDuplicats_Test()
        {
            LinkedLists.Entity entity = new LinkedLists.Entity(1);
            entity.Append(1);
            entity.Append(2);
            entity.Append(2);
            entity.Append(3);
            entity.Append(3);
            entity.Append(4);
            entity.Append(4);
            entity.Append(5);
            entity.Append(5);
            _target.RemoveDuplicats(entity);
            int index = 0;
            do
            {
                Assert.AreEqual(++index, entity.Data);
                entity = entity.Next;
            } while (entity != null);
        }
        [TestMethod]
        public void RemoveDuplicates_AllDuplicats_Test()
        {
            LinkedLists.Entity entity = new LinkedLists.Entity(1);
            entity.Append(1);
            entity.Append(1);
            entity.Append(1);
            entity.Append(1);
            entity.Append(1);
            _target.RemoveDuplicats(entity);
            int index = 0;
            do
            {
                Assert.AreEqual(++index, entity.Data);
                entity = entity.Next;
            } while (entity != null);
        }
        #endregion

        #region check k elements
        [TestMethod]
        public void GetkElementTest()
        {
            LinkedLists.Entity entity = new LinkedLists.Entity(1);
            Assert.AreEqual(1, _target.GetkElement(entity, 1).Data);

            entity = new LinkedLists.Entity(1);
            entity.Append(2);
            entity.Append(3);
            entity.Append(4);
            entity.Append(5);
            Assert.AreEqual(5, _target.GetkElement(entity, 1).Data);
            Assert.AreEqual(4, _target.GetkElement(entity, 2).Data);
            Assert.AreEqual(3, _target.GetkElement(entity, 3).Data);
            Assert.AreEqual(2, _target.GetkElement(entity, 4).Data);
            Assert.AreEqual(1, _target.GetkElement(entity, 5).Data);
            Assert.IsNull(_target.GetkElement(entity, 6));
        }

        [TestMethod]
        public void GetkElement_Iterative_Test()
        {
            LinkedLists.Entity entity = new LinkedLists.Entity(1);
            Assert.AreEqual(1, _target.GetkElement_Iterative(entity, 1).Data);

            entity = new LinkedLists.Entity(1);
            entity.Append(2);
            entity.Append(3);
            entity.Append(4);
            entity.Append(5);
            Assert.AreEqual(5, _target.GetkElement(entity, 1).Data);
            Assert.AreEqual(4, _target.GetkElement(entity, 2).Data);
            Assert.AreEqual(3, _target.GetkElement(entity, 3).Data);
            Assert.AreEqual(2, _target.GetkElement(entity, 4).Data);
            Assert.AreEqual(1, _target.GetkElement(entity, 5).Data);
            Assert.IsNull(_target.GetkElement(entity, 6));
        }
        #endregion

        [TestMethod]
        public void DeleteMiddle_Test()
        {
            LinkedLists.Entity middle = new LinkedLists.Entity(3);
            LinkedLists.Entity entity = new LinkedLists.Entity(1);
            entity.Append(new LinkedLists.Entity(2));
            entity.Append(middle);
            entity.Append(new LinkedLists.Entity(4));
            entity.Append(new LinkedLists.Entity(5));
            Assert.IsTrue(_target.DeleteMiddle(entity, middle));

            int index = 0;
            LinkedLists.Entity temp = entity;
            while (temp != null)
            {
                if (index == 2)
                {
                    index++;
                    continue;
                }
                Assert.AreEqual(++index, temp.Data);
                temp = temp.Next;
            }
        }

        [TestMethod]
        public void PartitionTest()
        {
            LinkedLists.Entity n;
            LinkedLists.Entity entity = new LinkedLists.Entity(2);
            entity.Append(1);
            n = _target.Partition(entity, 2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(2, n.Data);
            n = n.Next;
            Assert.IsNull(n);

            entity = new LinkedLists.Entity(5);
            entity.Append(4);
            entity.Append(3);
            entity.Append(2);
            entity.Append(1);
            n = _target.Partition(entity, 3);
            Assert.AreEqual(2, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(5, n.Data);
            n = n.Next;
            Assert.AreEqual(4, n.Data);
            n = n.Next;
            Assert.AreEqual(3, n.Data);
            n = n.Next;
            Assert.IsNull(n);

            entity = new LinkedLists.Entity(1);
            entity.Append(2);
            entity.Append(3);
            entity.Append(4);
            entity.Append(5);
            n = _target.Partition(entity, 2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(2, n.Data);
            n = n.Next;
            Assert.AreEqual(3, n.Data);
            n = n.Next;
            Assert.AreEqual(4, n.Data);
            n = n.Next;
            Assert.AreEqual(5, n.Data);
            n = n.Next;
            Assert.IsNull(n);
        }

        [TestMethod]
        public void SumReverseOrderTest()
        {
            //1
            //2
            LinkedLists.Entity n1 = new LinkedLists.Entity(1);
            LinkedLists.Entity n2 = new LinkedLists.Entity(2);
            var n = _target.SumReverseOrder(n1, n2);
            Assert.AreEqual(3, n.Data);
            Assert.IsNull(n.Next);

            //1
            //9
            n1 = new LinkedLists.Entity(1);
            n2 = new LinkedLists.Entity(9);
            n = _target.SumReverseOrder(n1, n2);
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);

            //716
            //592
            n1 = new LinkedLists.Entity(7);
            n1.Append(1);
            n1.Append(6);
            n2 = new LinkedLists.Entity(5);
            n2.Append(9);
            n2.Append(2);
            n = _target.SumReverseOrder(n1, n2);
            Assert.AreEqual(2, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(9, n.Data);
            Assert.IsNull(n.Next);

            //516
            //583
            n1 = new LinkedLists.Entity(5);
            n1.Append(1);
            n1.Append(6);
            n2 = new LinkedLists.Entity(5);
            n2.Append(8);
            n2.Append(3);
            n = _target.SumReverseOrder(n1, n2);
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);

            //1
            //999
            n1 = new LinkedLists.Entity(1);
            n2 = new LinkedLists.Entity(9);
            n2.Append(9);
            n2.Append(9);
            n = _target.SumReverseOrder(n1, n2);
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);

            //999
            //1
            n1 = new LinkedLists.Entity(9);
            n1.Append(9);
            n1.Append(9);
            n2 = new LinkedLists.Entity(1);
            n = _target.SumReverseOrder(n1, n2);
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);

            //879
            //586
            n1 = new LinkedLists.Entity(9);
            n1.Append(7);
            n1.Append(8);
            n2 = new LinkedLists.Entity(6);
            n2.Append(8);
            n2.Append(5);
            n = _target.SumReverseOrder(n1, n2);
            //1465
            Assert.AreEqual(5, n.Data);
            n = n.Next;
            Assert.AreEqual(6, n.Data);
            n = n.Next;
            Assert.AreEqual(4, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);
        }
        [TestMethod]
        public void ReverseTest()
        {
            LinkedLists.Entity n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            var actual = _target.Reverse(n);
            Assert.AreEqual(3, actual.Data);
            actual = actual.Next;
            Assert.AreEqual(2, actual.Data);
            actual = actual.Next;
            Assert.AreEqual(1, actual.Data);
            Assert.IsNull(actual.Next);
        }

        [TestMethod]
        public void SumForwardOrderTest()
        {
            //1
            //2
            LinkedLists.Entity n1 = new LinkedLists.Entity(1);
            LinkedLists.Entity n2 = new LinkedLists.Entity(2);
            var n = _target.SumForwardOrder(n1, n2);
            Assert.AreEqual(3, n.Data);
            Assert.IsNull(n.Next);

            //1
            //9
            n1 = new LinkedLists.Entity(1);
            n2 = new LinkedLists.Entity(9);
            n = _target.SumForwardOrder(n1, n2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            Assert.IsNull(n.Next);

            //716
            //592
            n1 = new LinkedLists.Entity(6);
            n1.Append(1);
            n1.Append(7);
            n2 = new LinkedLists.Entity(2);
            n2.Append(9);
            n2.Append(5);
            n = _target.SumForwardOrder(n1, n2);
            Assert.AreEqual(9, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(2, n.Data);
            Assert.IsNull(n.Next);

            //516
            //583
            n1 = new LinkedLists.Entity(6);
            n1.Append(1);
            n1.Append(5);
            n2 = new LinkedLists.Entity(3);
            n2.Append(8);
            n2.Append(5);
            n = _target.SumForwardOrder(n1, n2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            Assert.IsNull(n.Next);

            //1
            //999
            n1 = new LinkedLists.Entity(1);
            n2 = new LinkedLists.Entity(9);
            n2.Append(9);
            n2.Append(9);
            n = _target.SumForwardOrder(n1, n2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            Assert.IsNull(n.Next);

            //999
            //1
            n1 = new LinkedLists.Entity(9);
            n1.Append(9);
            n1.Append(9);
            n2 = new LinkedLists.Entity(1);
            n = _target.SumForwardOrder(n1, n2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            Assert.IsNull(n.Next);

            //879
            //586
            n1 = new LinkedLists.Entity(8);
            n1.Append(7);
            n1.Append(9);
            n2 = new LinkedLists.Entity(5);
            n2.Append(8);
            n2.Append(6);
            n = _target.SumForwardOrder(n1, n2);
            //1465
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(4, n.Data);
            n = n.Next;
            Assert.AreEqual(6, n.Data);
            n = n.Next;
            Assert.AreEqual(5, n.Data);
            Assert.IsNull(n.Next);
        }
        [TestMethod]
        public void SumReverseOrderRecTest()
        {
            //1
            //2
            LinkedLists.Entity n1 = new LinkedLists.Entity(1);
            LinkedLists.Entity n2 = new LinkedLists.Entity(2);
            var n = _target.SumReverseOrderRec(n1, n2);
            Assert.AreEqual(3, n.Data);
            Assert.IsNull(n.Next);

            //1
            //9
            n1 = new LinkedLists.Entity(1);
            n2 = new LinkedLists.Entity(9);
            n = _target.SumReverseOrderRec(n1, n2);
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);

            //716
            //592
            n1 = new LinkedLists.Entity(7);
            n1.Append(1);
            n1.Append(6);
            n2 = new LinkedLists.Entity(5);
            n2.Append(9);
            n2.Append(2);
            n = _target.SumReverseOrderRec(n1, n2);
            Assert.AreEqual(2, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(9, n.Data);
            Assert.IsNull(n.Next);

            //516
            //583
            n1 = new LinkedLists.Entity(5);
            n1.Append(1);
            n1.Append(6);
            n2 = new LinkedLists.Entity(5);
            n2.Append(8);
            n2.Append(3);
            n = _target.SumReverseOrderRec(n1, n2);
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);

            //1
            //999
            n1 = new LinkedLists.Entity(1);
            n2 = new LinkedLists.Entity(9);
            n2.Append(9);
            n2.Append(9);
            n = _target.SumReverseOrderRec(n1, n2);
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);

            //999
            //1
            n1 = new LinkedLists.Entity(9);
            n1.Append(9);
            n1.Append(9);
            n2 = new LinkedLists.Entity(1);
            n = _target.SumReverseOrderRec(n1, n2);
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);

            //879
            //586
            n1 = new LinkedLists.Entity(9);
            n1.Append(7);
            n1.Append(8);
            n2 = new LinkedLists.Entity(6);
            n2.Append(8);
            n2.Append(5);
            n = _target.SumReverseOrderRec(n1, n2);
            //1465
            Assert.AreEqual(5, n.Data);
            n = n.Next;
            Assert.AreEqual(6, n.Data);
            n = n.Next;
            Assert.AreEqual(4, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            Assert.IsNull(n.Next);
        }

        [TestMethod]
        public void SumForwardOrderRecTest()
        {
            //1
            //2
            LinkedLists.Entity n1 = new LinkedLists.Entity(1);
            LinkedLists.Entity n2 = new LinkedLists.Entity(2);
            var n = _target.SumForwardOrderRec(n1, n2);
            Assert.AreEqual(3, n.Data);
            Assert.IsNull(n.Next);

            //1
            //9
            n1 = new LinkedLists.Entity(1);
            n2 = new LinkedLists.Entity(9);
            n = _target.SumForwardOrderRec(n1, n2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            Assert.IsNull(n.Next);

            //716
            //592
            n1 = new LinkedLists.Entity(6);
            n1.Append(1);
            n1.Append(7);
            n2 = new LinkedLists.Entity(2);
            n2.Append(9);
            n2.Append(5);
            n = _target.SumForwardOrderRec(n1, n2);
            Assert.AreEqual(9, n.Data);
            n = n.Next;
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(2, n.Data);
            Assert.IsNull(n.Next);

            //516
            //583
            n1 = new LinkedLists.Entity(6);
            n1.Append(1);
            n1.Append(5);
            n2 = new LinkedLists.Entity(3);
            n2.Append(8);
            n2.Append(5);
            n = _target.SumForwardOrderRec(n1, n2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            Assert.IsNull(n.Next);

            //1
            //999
            n1 = new LinkedLists.Entity(1);
            n2 = new LinkedLists.Entity(9);
            n2.Append(9);
            n2.Append(9);
            n = _target.SumForwardOrderRec(n1, n2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            Assert.IsNull(n.Next);

            //999
            //1
            n1 = new LinkedLists.Entity(9);
            n1.Append(9);
            n1.Append(9);
            n2 = new LinkedLists.Entity(1);
            n = _target.SumForwardOrderRec(n1, n2);
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            n = n.Next;
            Assert.AreEqual(0, n.Data);
            Assert.IsNull(n.Next);

            //879
            //586
            n1 = new LinkedLists.Entity(8);
            n1.Append(7);
            n1.Append(9);
            n2 = new LinkedLists.Entity(5);
            n2.Append(8);
            n2.Append(6);
            n = _target.SumForwardOrderRec(n1, n2);
            //1465
            Assert.AreEqual(1, n.Data);
            n = n.Next;
            Assert.AreEqual(4, n.Data);
            n = n.Next;
            Assert.AreEqual(6, n.Data);
            n = n.Next;
            Assert.AreEqual(5, n.Data);
            Assert.IsNull(n.Next);
        }

        [TestMethod]
        public void ReverseAndCopyTest()
        {
            LinkedLists.Entity n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            n.Append(4);
            var actual = _target.Reverse(n);
            Assert.AreEqual(4, actual.Data);
            actual = actual.Next;
            Assert.AreEqual(3, actual.Data);
            actual = actual.Next;
            Assert.AreEqual(2, actual.Data);
            actual = actual.Next;
            Assert.AreEqual(1, actual.Data);
            Assert.IsNull(actual.Next);
        }
        [TestMethod]
        public void IsPalinTest()
        {
            LinkedLists.Entity n = new LinkedLists.Entity(1);
            Assert.IsTrue(_target.IsPalin(n));

            n = new LinkedLists.Entity(1);
            n.Append(1);
            n.Append(1);
            Assert.IsTrue(_target.IsPalin(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalin(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalin(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            n.Append(4);
            n.Append(5);
            n.Append(4);
            n.Append(3);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalin(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            Assert.IsFalse(_target.IsPalin(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            Assert.IsFalse(_target.IsPalin(n));
        }

        [TestMethod]
        public void IsPalinIterativeStackTest()
        {
            LinkedLists.Entity n = new LinkedLists.Entity(1);
            Assert.IsTrue(_target.IsPalinIterativeStack(n));

            n = new LinkedLists.Entity(1);
            n.Append(1);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinIterativeStack(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinIterativeStack(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinIterativeStack(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            n.Append(4);
            n.Append(5);
            n.Append(4);
            n.Append(3);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinIterativeStack(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            Assert.IsFalse(_target.IsPalinIterativeStack(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            Assert.IsFalse(_target.IsPalinIterativeStack(n));
        }

        [TestMethod]
        public void IsPalinIterativeStackRefinedTest()
        {
            LinkedLists.Entity n = new LinkedLists.Entity(1);
            Assert.IsTrue(_target.IsPalinIterativeStackRefined(n));

            n = new LinkedLists.Entity(1);
            n.Append(1);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinIterativeStackRefined(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinIterativeStackRefined(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinIterativeStackRefined(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            n.Append(4);
            n.Append(5);
            n.Append(4);
            n.Append(3);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinIterativeStackRefined(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            Assert.IsFalse(_target.IsPalinIterativeStackRefined(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            Assert.IsFalse(_target.IsPalinIterativeStackRefined(n));
        }

        [TestMethod]
        public void IsPlineRecTest()
        {
            LinkedLists.Entity n = new LinkedLists.Entity(1);
            Assert.IsTrue(_target.IsPalinRec(n));

            n = new LinkedLists.Entity(1);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinRec(n));

            n = new LinkedLists.Entity(1);
            n.Append(1);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinRec(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinRec(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinRec(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            n.Append(4);
            n.Append(5);
            n.Append(4);
            n.Append(3);
            n.Append(2);
            n.Append(1);
            Assert.IsTrue(_target.IsPalinRec(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            Assert.IsFalse(_target.IsPalinRec(n));

            n = new LinkedLists.Entity(1);
            n.Append(2);
            n.Append(3);
            Assert.IsFalse(_target.IsPalinRec(n));
        }


        [TestMethod]
        public void IntersectionTest()
        {
            LinkedLists.Entity temp = new LinkedLists.Entity(1);
            LinkedLists.Entity n1 = temp;
            LinkedLists.Entity n2 = temp;
            var r = _target.Intersection(n1, n2);
            Assert.AreEqual(temp, r);
            Assert.AreEqual(1, r.Data);

            n1 = new LinkedLists.Entity(1);
            n1.Append(2);
            temp = new LinkedLists.Entity(3);
            n1.Append(temp);
            n2 = temp;
            r = _target.Intersection(n1, n2);
            Assert.AreEqual(temp, r);
            Assert.AreEqual(3, r.Data);

            n1 = new LinkedLists.Entity(1);
            n2 = new LinkedLists.Entity(1);
            temp = new LinkedLists.Entity(2);
            n1.Append(temp);
            n2.Append(temp);
            temp.Append(3);
            r = _target.Intersection(n1, n2);
            Assert.AreEqual(temp, r);
            Assert.AreEqual(2, r.Data);

            n1 = new LinkedLists.Entity(1);
            n1.Append(2);
            n2 = new LinkedLists.Entity(1);
            temp = new LinkedLists.Entity(3);
            n1.Append(temp);
            n2.Append(temp);
            temp.Append(4);
            r = _target.Intersection(n1, n2);
            Assert.AreEqual(temp, r);
            Assert.AreEqual(3, r.Data);

            n1 = new LinkedLists.Entity(1);
            n1.Append(2);
            n1.Append(3);
            n1.Append(4);
            n2.Append(1);
            n2.Append(2);
            n2.Append(3);
            r = _target.Intersection(n1, n2);
            Assert.IsNull(r);
        }
        #endregion
    }
}
