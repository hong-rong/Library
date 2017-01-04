using Lib.Common.Ds.Bs;
using Lib.Common.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lib.Common.Test.Ds
{
    [TestClass]
    public class SequentialSearchSTTests
    {
        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void SequentialSearchST_Not_Nullable_Exception_Test()
        {
            var st = new SequentialSearchST<string, int>();
        }

        [TestMethod]
        public void SequentialSearchST_Test()
        {
            var st = new SequentialSearchST<string, int?>();
        }

        #region put

        [TestMethod]
        public void Put_Add_New_Test()
        {
            var st = CreateST();
            st.Put("d", "3");

            Assert.AreEqual(4, st.Size());
            Assert.AreEqual("3", st.Get("d"));
        }

        [TestMethod]
        public void Put_Update_Existing_Test()
        {
            var st = CreateST();
            st.Put("b", "9");

            Assert.AreEqual(3, st.Size());
            Assert.AreEqual("9", st.Get("b"));
        }

        [TestMethod]
        public void Put_Delete_Existing_Test()
        {
            var st = CreateST();

            st.Put("b", null);

            Assert.AreEqual(2, st.Size());
            Assert.IsNull(st.Get("b"));
        }

        #endregion

        #region delete

        [TestMethod]
        public void Delete_Test()
        {
            var st = CreateST();
            st.Delete("a");

            Assert.AreEqual(2, st.Size());
            Assert.IsNull(st.Get("a"));
        }

        [TestMethod]
        public void Delete_Key_Not_In_Test()
        {
            var st = CreateST();
            st.Delete("z");

            Assert.AreEqual(3, st.Size());
        }

        [TestMethod]
        public void Delete_Olny_One_Node_List_Test()
        {
            var st = new SequentialSearchST<string, string>();
            st.Put("a", "0");

            st.Delete("a");
            Assert.AreEqual(0, st.Size());
        }

        #endregion

        #region get

        [TestMethod]
        public void Get_Test()
        {
            var st = CreateST();
            var value = st.Get("a");

            Assert.AreEqual("0", value);
            Assert.AreEqual(3, st.Size());
        }

        [TestMethod]
        public void Get_Not_In_Test()
        {
            var st = CreateST();
            var value = st.Get("z");

            Assert.IsNull(value);
        }

        [TestMethod]
        public void Get_Not_In_With_Value_Type_Test()
        {
            var st = CreateSTWithNullableValueType();
            var value = st.Get("z");

            Assert.AreEqual(null, value);
        }

        #endregion

        #region contains, empty

        [TestMethod]
        public void Contains_True_Test()
        {
            var st = CreateST();

            Assert.IsTrue(st.Contains("b"));
        }

        [TestMethod]
        public void Contains_False_Test()
        {
            var st = CreateST();

            Assert.IsFalse(st.Contains("z"));
        }

        [TestMethod]
        public void IsEmpty_True_Test()
        {
            var st = new SequentialSearchST<string, string>();

            Assert.IsTrue(st.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_False_Test()
        {
            var st = CreateST();

            Assert.IsFalse(st.IsEmpty());
        }

        #endregion

        [TestMethod]
        public void ToString_Test()
        {
            var st = CreateST();

            Assert.AreEqual("c 2 b 1 a 0 ", st.ToString());
        }

        private SequentialSearchST<string, string> CreateST()
        {
            var st = new SequentialSearchST<string, string>();
            st.Put("a", "0");
            st.Put("b", "1");
            st.Put("c", "2");

            return st;
        }

        private SequentialSearchST<string, int?> CreateSTWithNullableValueType()
        {
            var st = new SequentialSearchST<string, int?>();
            st.Put("a", 0);
            st.Put("b", 1);
            st.Put("c", 2);

            return st;
        }

        /// <summary>
        /// test performance for fun
        /// recursive way suffers when there are more than 10000 nodes
        /// </summary>
        [Ignore]
        [TestMethod]
        public void Delete_Performance_Test()
        {
            int size = 9000;
            var st = new SequentialSearchST<int, string>();
            for (int i = 0; i < size; i++)
            {
                st.Put(i, i.ToString());
            }

            using (new PerformanceWatch(new CDriveLocationLogger(), "recursive"))
            {
                for (int i = 0; i < size; i++)
                {
                    st.Delete_Recursive(i);
                }
            }

            var st2 = new SequentialSearchST<int, string>();
            for (int i = 0; i < size; i++)
            {
                st2.Put(i, i.ToString());
            }

            using (new PerformanceWatch(new CDriveLocationLogger(), "non recursive"))
            {
                for (int i = 0; i < size; i++)
                {
                    st2.Delete(i);
                }
            }
        }
    }
}