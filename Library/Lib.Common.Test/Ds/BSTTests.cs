using System;
using System.Linq;
using Lib.Common.Ds.Bst;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds
{
    [TestClass]
    public class BSTTests
    {
        #region put

        [TestMethod]
        public void Put_AddNewInTheEnd_Test()
        {
            var bst = CreateBST();
            bst.Put("Z", 'Z');

            Assert.AreEqual('Z', bst.Get("Z"));
            Assert.AreEqual(9, bst.Size());
        }

        [TestMethod]
        public void Put_AddNewInTheMiddle_Test()
        {
            var bst = CreateBST();
            bst.Put("L", 'L');

            Assert.AreEqual('L', bst.Get("L"));
            Assert.AreEqual(9, bst.Size());
        }

        [TestMethod]
        public void Put_UpdateExisting_Test()
        {
            var bst = CreateBST();
            bst.Put("E", 'F');

            Assert.AreEqual('F', bst.Get("E"));
            Assert.AreEqual(8, bst.Size());
        }

        [TestMethod]
        public void Put_DeleteExisting_Test()
        {
            var bst = CreateBST();

            bst.Put("E", null);

            Assert.AreEqual(7, bst.Size());
            Assert.IsNull(bst.Get("E"));
        }

        [TestMethod]
        public void Put_DeleteNotExisting_Test()
        {
            var bst = CreateBST();

            bst.Put("Z", null);

            Assert.AreEqual(8, bst.Size());
            Assert.IsNull(bst.Get("Z"));
        }

        #endregion

        #region get

        [TestMethod]
        public void Get_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual('S', bst.Get("S"));
            Assert.AreEqual('X', bst.Get("X"));
            Assert.AreEqual('C', bst.Get("C"));
            Assert.AreEqual('A', bst.Get("A"));
            Assert.AreEqual('M', bst.Get("M"));
        }

        [TestMethod]
        public void Get_Empty_Test()
        {
            var bst = new BST<string, int?>();

            Assert.IsNull(bst.Get("Z"));
        }

        #endregion

        #region delete

        [TestMethod]
        public void Delete_Test()
        {
            var bst = CreateBST();
            bst.Delete("E");

            Assert.AreEqual(7, bst.Size());
            Assert.IsNull(bst.Get("E"));
        }

        [TestMethod]
        public void Delete_Key_Not_In_Test()
        {
            var bst = CreateBST();
            bst.Delete("Z");

            Assert.AreEqual(8, bst.Size());
        }

        [TestMethod]
        public void Delete_Olny_One_Node_List_Test()
        {
            var bst = new BST<string, int?>(new BSTNode<string, int?>() { Count = 1, Key = "A", Value = 'A' });
            bst.Delete("A");

            Assert.AreEqual(0, bst.Size());
        }


        [TestMethod]
        public void DeleteMin_Test()
        {
            var bst = CreateBST();

            bst.DeleteMin();

            Assert.AreEqual(7, bst.Size());
            Assert.AreEqual("C", bst.Min());
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void DeleteMin_Empty_Test()
        {
            var bst = new BST<string, int?>();
            bst.DeleteMin();
        }

        [TestMethod]
        public void DeleteMax_Test()
        {
            var bst = CreateBST();

            bst.DeleteMax();

            Assert.AreEqual(7, bst.Size());
            Assert.AreEqual("S", bst.Max());
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void DeleteMax_Empty_Test()
        {
            var bst = new BST<string, int?>();
            bst.DeleteMax();
        }

        #endregion

        #region size

        [TestMethod]
        public void Size_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual(8, bst.Size());
        }

        [TestMethod]
        public void Size_Zero_Test()
        {
            var bst = new BST<string, string>();

            Assert.AreEqual(0, bst.Size());
        }

        #endregion

        #region floor, ceiling, select

        [TestMethod]
        public void Min_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual("A", bst.Min());
        }

        [TestMethod]
        public void Max_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual("X", bst.Max());
        }

        [TestMethod]
        public void Floor_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual("E", bst.Floor("E"));
        }

        [TestMethod]
        public void Floor_Null_Test()
        {
            var bst = CreateBST();

            Assert.IsNull(bst.Floor("1"));
        }

        [TestMethod]
        public void Floor_Max_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual("X", bst.Floor("z"));
        }

        [TestMethod]
        public void Ceiling_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual("S", bst.Ceiling("S"));
        }

        [TestMethod]
        public void Ceiling_Null_Test()
        {
            var bst = CreateBST();

            Assert.IsNull(bst.Ceiling("Z"));
        }

        [TestMethod]
        public void Ceiling_Min_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual("A", bst.Ceiling("A"));
        }

        [TestMethod]
        public void Select_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual("S", bst.Select(6));
        }

        [TestMethod]
        public void Select_Null_Test()
        {
            var bst = CreateBST();

            Assert.IsNull(bst.Select(10));
        }

        #endregion

        #region rank

        [TestMethod]
        public void Rank_Test()
        {
            var st = CreateBST();

            Assert.AreEqual(0, st.Rank("A"));
            Assert.AreEqual(1, st.Rank("C"));
            Assert.AreEqual(2, st.Rank("E"));
            Assert.AreEqual(3, st.Rank("H"));
            Assert.AreEqual(4, st.Rank("M"));
            Assert.AreEqual(5, st.Rank("R"));
            Assert.AreEqual(6, st.Rank("S"));
            Assert.AreEqual(7, st.Rank("X"));
        }

        [TestMethod]
        public void Rank_KeyNotExists_Test()
        {
            var st = CreateBST();

            Assert.AreEqual(3, st.Rank("F"));
        }

        [TestMethod]
        public void Rank_GreaterThanAllExistings_Test()
        {
            var st = CreateBST();

            Assert.AreEqual(8, st.Rank("Z"));
        }

        [TestMethod]
        public void Rank_Zero_Test()
        {
            var st = CreateBST();

            Assert.AreEqual(0, st.Rank("1"));
        }

        #endregion

        #region enumberable

        [TestMethod]
        public void Keys_Test()
        {
            var keys = CreateBST().Keys().ToList();

            Assert.AreEqual("A", keys[0]);
            Assert.AreEqual("C", keys[1]);
            Assert.AreEqual("E", keys[2]);
            Assert.AreEqual("H", keys[3]);
            Assert.AreEqual("M", keys[4]);
            Assert.AreEqual("R", keys[5]);
            Assert.AreEqual("S", keys[6]);
            Assert.AreEqual("X", keys[7]);
        }

        [TestMethod]
        public void Keys_Range_Test()
        {
            var keys = CreateBST().Keys("E", "S").ToList();

            Assert.AreEqual("E", keys[0]);
            Assert.AreEqual("H", keys[1]);
            Assert.AreEqual("M", keys[2]);
            Assert.AreEqual("R", keys[3]);
            Assert.AreEqual("S", keys[4]);
        }

        #endregion

        #region height

        [TestMethod]
        public void Height_Test()
        {
            var bst = CreateBST();

            Assert.AreEqual(4, bst.Height());
        }

        #endregion

        #region level order

        [TestMethod]
        public void LevelOrder_Test()
        {
            var keys = CreateBST().Keys().ToList();

            Assert.AreEqual("A", keys[0]);
            Assert.AreEqual("C", keys[1]);
            Assert.AreEqual("E", keys[2]);
            Assert.AreEqual("H", keys[3]);
            Assert.AreEqual("M", keys[4]);
            Assert.AreEqual("R", keys[5]);
            Assert.AreEqual("S", keys[6]);
            Assert.AreEqual("X", keys[7]);
        }

        #endregion

        private BST<string, int?> CreateBST()
        {
            var c = new BSTNode<string, int?>() { Count = 1, Key = "C", Value = 'C' };
            var a = new BSTNode<string, int?>() { Count = 2, Key = "A", Value = 'A', Right = c };

            var m = new BSTNode<string, int?>() { Count = 1, Key = "M", Value = 'M' };
            var h = new BSTNode<string, int?>() { Count = 2, Key = "H", Value = 'H', Right = m };

            var r = new BSTNode<string, int?>() { Count = 3, Key = "R", Value = 'R', Left = h };
            var e = new BSTNode<string, int?>() { Count = 6, Key = "E", Value = 'E', Left = a, Right = r };

            var x = new BSTNode<string, int?>() { Count = 1, Key = "X", Value = 'X' };
            var s = new BSTNode<string, int?>() { Count = 8, Key = "S", Value = 'S', Left = e, Right = x };

            var bst = new BST<string, int?>(s);

            return bst;
        }
    }
}
