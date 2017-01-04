using Lib.Common.Ds.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lib.Common.Test.Ds
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Push_Test()
        {
            var stack = CreateStack();
            stack.Push(9);

            Assert.AreEqual(3, stack.Size());
            Assert.AreEqual(9, stack.Peek());
        }

        [TestMethod]
        public void Push_First_Null_Test()
        {
            var stack = new Stack<int>();
            stack.Push(9);

            Assert.AreEqual(1, stack.Size());
            Assert.AreEqual(9, stack.Peek());
        }

        [TestMethod]
        public void Pop_Test()
        {
            var stack = CreateStack();
            var item = stack.Pop();

            Assert.AreEqual(1, stack.Size());
            Assert.AreEqual(2, item);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_Empty_Exception_Test()
        {
            var stack = new Stack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void Peek_Test()
        {
            var stack = CreateStack();
            var item = stack.Peek();

            Assert.AreEqual(2, stack.Size());
            Assert.AreEqual(2, item);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_Empty_Exception_Test()
        {
            var stack = new Stack<int>();
            stack.Peek();
        }

        [TestMethod]
        public void IsEmpty_True_Test()
        {
            var stack = new Stack<int>();

            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_False_Test()
        {
            var stack = CreateStack();

            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void Size_Test()
        {
            var stack = CreateStack();

            Assert.AreEqual(2, stack.Size());
        }

        [TestMethod]
        public void Size_Zero_Test()
        {
            var stack = new Stack<int>();

            Assert.AreEqual(0, stack.Size());
        }

        [TestMethod]
        public void ToString_Test()
        {
            var stack = CreateStack();
            stack.Push(3);

            Assert.AreEqual("3 2 1 ", stack.ToString());
        }

        private Stack<int> CreateStack()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            return stack;
        }
    }
}