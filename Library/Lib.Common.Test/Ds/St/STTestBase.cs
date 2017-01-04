using System;
using Ds.Common.SymbolTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds.St
{
    [TestClass]
    public abstract class STTestBase
    {
        #region Size

        [TestMethod]
        public virtual void Size_Test()
        {
            var st = CreateST();

            Assert.AreEqual(10, st.Size());
        }

        [TestMethod]
        public virtual void Size_Zero_Test()
        {
            var st = CreateEmptyST();

            Assert.AreEqual(0, st.Size());
        }

        #endregion

        #region IsEmpty

        [TestMethod]
        public virtual void IsEmpty_True_Test()
        {
            var st = CreateEmptyST();

            Assert.IsTrue(st.IsEmpty());
        }

        [TestMethod]
        public virtual void IsEmpty_False_Test()
        {
            var st = CreateST();

            Assert.IsFalse(st.IsEmpty());
        }

        #endregion

        #region Contains

        [TestMethod]
        public virtual void Contains_True_Test()
        {
            var st = CreateST();

            Assert.IsTrue(st.Contains("S"));
        }

        [TestMethod]
        public virtual void Contains_False_Test()
        {
            var st = CreateST();

            Assert.IsFalse(st.Contains("Z"));
        }

        #endregion

        #region Get

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public virtual void Get_NullException_Test()
        {
            var st = CreateST();

            st.Get(null);
        }

        [TestMethod]
        public virtual void Get_Exists_Test()
        {
            var st = CreateST();

            Assert.AreEqual(0, st.Get("S"));
        }

        [TestMethod]
        public virtual void Get_ExistsWithPutUpdate_Test()
        {
            var st = CreateST();

            Assert.AreEqual(12, st.Get("E"));
        }

        [TestMethod]
        public virtual void Get_NotExists_Test()
        {
            var st = CreateST();

            Assert.IsNull(st.Get("Z"));
        }

        #endregion

        #region Put

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public virtual void Put_NullException_Test()
        {
            var st = CreateST();

            st.Get(null);
        }

        [TestMethod]
        public virtual void Put_Test()
        {
            var st = CreateST();

            st.Put("Z", 99);

            Assert.AreEqual(99, st.Get("Z"));
        }

        [TestMethod]
        public virtual void Put_Update_Test()
        {
            var st = CreateST();

            st.Put("S", 99);

            Assert.AreEqual(99, st.Get("S"));
        }

        [TestMethod]
        public virtual void Put_Delete_Test()
        {
            var st = CreateST();

            st.Put("S", null);

            Assert.IsNull(st.Get("S"));
        }

        #endregion

        #region Delete

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public virtual void Delete_NullException_Test()
        {
            var st = CreateST();

            st.Delete(null);
        }

        [TestMethod]
        public virtual void Delete_Exists_Test()
        {
            var st = CreateST();

            st.Delete("E");

            Assert.IsNull(st.Get("E"));
        }

        [TestMethod]
        public virtual void Delete_NotExists_Test()
        {
            var st = CreateST();

            st.Delete("Z");
        }

        #endregion

        protected abstract ISymbolTable<string, int?> CreateST();

        protected abstract ISymbolTable<string, int?> CreateEmptyST();
    }
}