using Lib.Common.Ds.Bs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lib.Common.Test.Ds.Bs
{
    [TestClass]
    public class BinarySearchSTTests
    {
        #region put

        [TestMethod]
        public void Put_AddNewInTheEnd_Test()
        {
            var st = CreateBinarySearchST();
            st.Put("z", 9);

            Assert.AreEqual(9, st.Get("z"));
            Assert.AreEqual(6, st.Size());
        }

        [TestMethod]
        public void Put_AddNewInTheMiddle_Test()
        {
            var st = CreateBinarySearchST();
            st.Put("d", 9);

            Assert.AreEqual(9, st.Get("d"));
            Assert.AreEqual(6, st.Size());
        }

        [TestMethod]
        public void Put_UpdateExisting_Test()
        {
            var st = CreateBinarySearchST();
            st.Put("a", 9);

            Assert.AreEqual(9, st.Get("a"));
            Assert.AreEqual(5, st.Size());
        }

        [TestMethod]
        public void Put_DeleteExisting_Test()
        {
            var st = CreateBinarySearchST();

            st.Put("c", null);

            Assert.AreEqual(4, st.Size());
            Assert.IsNull(st.Get("c"));
        }

        [TestMethod]
        public void Put_DeleteNotExisting_Test()
        {
            var st = CreateBinarySearchST();

            st.Put("z", null);

            Assert.AreEqual(5, st.Size());
            Assert.IsNull(st.Get("z"));
        }

        #endregion

        #region get

        [TestMethod]
        public void Get_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual(0, st.Get("a"));
            Assert.AreEqual(2, st.Get("c"));
            Assert.AreEqual(4, st.Get("f"));
        }

        [TestMethod]
        public void Get_Empty_Test()
        {
            var st = new BinarySearchST<string, string>();

            Assert.IsNull(st.Get("a"));
        }

        #endregion

        #region delete

        [TestMethod]
        public void Delete_Test()
        {
            var st = CreateBinarySearchST();
            st.Delete("a");

            Assert.AreEqual(4, st.Size());
            Assert.IsNull(st.Get("a"));
        }

        [TestMethod]
        public void Delete_Key_Not_In_Test()
        {
            var st = CreateBinarySearchST();
            st.Delete("z");

            Assert.AreEqual(5, st.Size());
        }

        [TestMethod]
        public void Delete_Olny_One_Node_List_Test()
        {
            var st = new BinarySearchST<string, int?>(new string[] { "a" }, new int?[] { 0 });
            st.Delete("a");

            Assert.AreEqual(0, st.Size());
        }

        [TestMethod]
        public void DeleteMin_Test()
        {
            var st = CreateBinarySearchST();

            st.DeleteMin();

            Assert.AreEqual(4, st.Size());
            Assert.AreEqual("b", st.Min());
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void DeleteMin_Empty_Test()
        {
            var st = new BinarySearchST<string, string>();
            st.DeleteMin();
        }

        [TestMethod]
        public void DeleteMax_Test()
        {
            var st = CreateBinarySearchST();

            st.DeleteMax();

            Assert.AreEqual(4, st.Size());
            Assert.AreEqual("e", st.Max());
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void DeleteMax_Empty_Test()
        {
            var st = new BinarySearchST<string, string>();
            st.DeleteMax();
        }

        #endregion

        #region size

        [TestMethod]
        public void Size_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual(5, st.Size());
        }

        [TestMethod]
        public void Size_Zero_Test()
        {
            var st = new BinarySearchST<string, string>();

            Assert.AreEqual(0, st.Size());
        }

        #endregion

        #region contains

        [TestMethod]
        public void Contains_True_Test()
        {
            var st = CreateBinarySearchST();

            Assert.IsTrue(st.Contains("f"));
        }

        [TestMethod]
        public void Contains_False_Test()
        {
            var st = CreateBinarySearchST();

            Assert.IsFalse(st.Contains("z"));
        }

        #endregion

        #region floor, ceiling, select

        [TestMethod]
        public void Min_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual("a", st.Min());
        }

        [TestMethod]
        public void Max_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual("f", st.Max());
        }

        [TestMethod]
        public void Floor_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual("c", st.Floor("d"));
        }

        [TestMethod]
        public void Floor_Null_Test()
        {
            var st = CreateBinarySearchST();

            Assert.IsNull(st.Floor("a"));
        }

        [TestMethod]
        public void Floor_Max_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual("f", st.Floor("z"));
        }

        [TestMethod]
        public void Ceiling_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual("e", st.Ceiling("d"));
        }

        [TestMethod]
        public void Ceiling_Null_Test()
        {
            var st = CreateBinarySearchST();

            Assert.IsNull(st.Ceiling("z"));
        }

        [TestMethod]
        public void Ceiling_Min_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual("a", st.Ceiling("a"));
        }

        [TestMethod]
        public void Select_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual("c", st.Select(2));
        }

        [TestMethod]
        public void Select_Null_Test()
        {
            var st = CreateBinarySearchST();

            Assert.IsNull(st.Select(10));
        }

        [TestMethod]
        public void Select_IntNull_Test()
        {
            var st = new BinarySearchST<int, int?>(new int[] { 1, 2, 3 }, new int?[] { 10, 11, 12 });

            var val = st.Select(-1);
        }

        #endregion

        #region rank

        [TestMethod]
        public void Rank_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual(0, st.Rank("a"));
            Assert.AreEqual(1, st.Rank("b"));
            Assert.AreEqual(2, st.Rank("c"));
            Assert.AreEqual(3, st.Rank("e"));
            Assert.AreEqual(4, st.Rank("f"));

            Assert.AreEqual(5, st.Rank("z"));
        }

        [TestMethod]
        public void Rank_Recersive_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual(0, st.Rank_Recursive("a"));
            Assert.AreEqual(1, st.Rank_Recursive("b"));
            Assert.AreEqual(2, st.Rank_Recursive("c"));
            Assert.AreEqual(3, st.Rank_Recursive("e"));
            Assert.AreEqual(4, st.Rank_Recursive("f"));

            Assert.AreEqual(5, st.Rank_Recursive("z"));
        }

        [TestMethod]
        public void Rank_KeyNotExists_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual(3, st.Rank("d"));
        }

        [TestMethod]
        public void Rank_GreaterThanAllExistings_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual(5, st.Rank("z"));
        }

        [TestMethod]
        public void Rank_Zero_Test()
        {
            var st = CreateBinarySearchST();

            Assert.AreEqual(0, st.Rank("1"));
        }

        #endregion
        
        private BinarySearchST<string, int?> CreateBinarySearchST()
        {
            return new BinarySearchST<string, int?>(
                new string[]
                    {
                        "a",
                        "b",
                        "c",
                        "e",
                        "f"
                    },
                    new int?[]
                    {
                         0,
                         1,
                         2,
                         3,
                         4,
                    }
                );
        }
    }
}