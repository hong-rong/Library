using Algorithm.Fundamentals.BagsQueuesStacks.LinkedList;
using Algorithm.Fundamentals.BagsQueuesStacks.Queue;
using Algorithm.Fundamentals.DataAbstraction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks
{
    [TestClass]
    public class Exercise
    {
        [TestMethod]
        public void E131()
        {
            FixedCapacityStackOfStrings stack = new FixedCapacityStackOfStrings(100);
            //string[] file = File.ReadAllText(@"C:\Users\itmin_000\Dropbox\Code\TestProject\External\Algorithm\BagsQueuesStacks\more tobe.txt").Split(' ');
            string[] file = "it was - the best - of times - - - it was - the - -".Split(' ');

            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] != "-")
                    stack.Push(file[i]);
                else if (!stack.IsEmpty())
                    Debug.WriteLine(stack.Pop() + " ");
            }

            Debug.WriteLine(string.Format("{0} left on stack.", stack.Size));
        }

        [TestMethod]
        public void E134()
        {
            //string input = "[()]{}{[()()]()}";
            string input = "[(])";
            FixedCapacityStackOfStrings stack = new FixedCapacityStackOfStrings(input.Length / 2);
            if (input.Length % 2 != 0)
            {
                Debug.WriteLine("false");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    stack.Push("{");
                }
                else if (input[i] == '[')
                {
                    stack.Push("[");
                }
                else if (input[i] == '(')
                {
                    stack.Push("(");
                }
                else if (input[i] == '}')
                {
                    if (stack.Pop() != "{")
                    {
                        Debug.WriteLine("false");
                        return;
                    }
                }
                else if (input[i] == ']')
                {
                    if (stack.Pop() != "[")
                    {
                        Debug.WriteLine("false");
                        return;
                    }
                }
                else if (input[i] == ')')
                {
                    if (stack.Pop() != "(")
                    {
                        Debug.WriteLine("false");
                        return;
                    }
                }
            }

            Debug.WriteLine("true");
        }

        [TestMethod]
        public void E135()
        {
            //PrintBinaryPresentation(50);
            PrintBinaryPresentationUsingFor(50);
        }

        private static void PrintBinaryPresentation(int number)
        {
            FixCapacityStack<int> stack = new FixCapacityStack<int>(number);
            while (number > 0)
            {
                stack.Push(number % 2);
                number = number / 2;
            }

            while (!stack.IsEmpty())
            {
                Debug.Write(stack.Pop());
            }

            Debug.WriteLine("");
        }

        private static void PrintBinaryPresentationUsingFor(int number)
        {
            string value = "";
            for (int i = number; i > 0; i /= 2)
            {
                value = i % 2 + value;
            }

            Debug.WriteLine(value);
        }

        [TestMethod]
        public void E136()
        {
            //reverse element in the queue
        }

        [TestMethod]
        public void E137()
        { }

        [TestMethod]
        public void E138()
        {
            DoublingStackOfStrings stack = new DoublingStackOfStrings(2);
            string[] file = "it was - the best - of times - - - it was - the - -".Split(' ');

            for (int i = 0; i < file.Length; i++)
            {
                //if (file[i] != "-")
                stack.Push(file[i]);
                //else if (!stack.IsEmpty())
                //    Debug.WriteLine(stack.Pop() + " ");
            }

            Debug.WriteLine(string.Format("{0} left on stack.", stack.Size));

            foreach (var item in stack)
            {
                Debug.WriteLine(item);
            }
        }

        [TestMethod]
        public void E139()
        {
            string[] input = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) )".Split(' ');
            FixedCapacityStackOfStrings exp = new FixedCapacityStackOfStrings(32);
            FixedCapacityStackOfStrings assistStack = new FixedCapacityStackOfStrings(100);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ")")
                {
                    while (!exp.IsEmpty())
                    {
                        assistStack.Push(exp.Pop());
                    }

                    exp.Push("(");
                    while (!assistStack.IsEmpty())
                    {
                        exp.Push(assistStack.Pop());
                    }
                    exp.Push(")");
                }
                else
                {
                    exp.Push(input[i]);
                }
            }

            foreach (var item in exp)
            {
                Debug.Write(item);
            }
        }

        [TestMethod]
        public void E1310()
        {
            //InfixToPostfix
            FixedCapacityStackOfStrings vals = InfixToPostfix();
        }

        private static FixedCapacityStackOfStrings InfixToPostfix()
        {
            FixedCapacityStackOfStrings vals = new FixedCapacityStackOfStrings(100);
            FixedCapacityStackOfStrings ops = new FixedCapacityStackOfStrings(100);
            string[] input = "( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )".Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "(") { }
                else if (input[i] == "+") { ops.Push("+"); }
                else if (input[i] == "-") { ops.Push("-"); }
                else if (input[i] == "*") { ops.Push("*"); }
                else if (input[i] == "/") { ops.Push("/"); }
                else if (input[i] == ")") { vals.Push(ops.Pop()); }
                else { vals.Push(input[i]); }
            }

            return vals;
        }

        [TestMethod]
        public void E1311()
        {
            FixedCapacityStackOfStrings vals = InfixToPostfix();
            FixedCapacityStackOfStrings exp1 = new FixedCapacityStackOfStrings(32);
            FixedCapacityStackOfStrings exp2 = new FixedCapacityStackOfStrings(32);
            //**-65-43+21
            while (!vals.IsEmpty())
            {
                string val = vals.Pop();
                exp1.Push(val);
                Debug.Write(val);
            }

            while (!exp1.IsEmpty())
            {
                string next = exp1.Pop();
                if (next == "+")
                {
                    exp2.Push((int.Parse(exp2.Pop()) + int.Parse(exp2.Pop())).ToString());
                }
                else if (next == "-")
                {
                    int op2 = int.Parse(exp2.Pop());
                    int op1 = int.Parse(exp2.Pop());
                    exp2.Push((op1 - op2).ToString());
                }
                else if (next == "*")
                {
                    exp2.Push((int.Parse(exp2.Pop()) * int.Parse(exp2.Pop())).ToString());
                }
                else if (next == "/")
                {
                    exp2.Push((int.Parse(exp2.Pop()) / int.Parse(exp2.Pop())).ToString());
                }
                else
                {
                    exp2.Push(next);
                }
            }

            Assert.AreEqual("3", exp2.Pop());
        }

        [TestMethod]
        public void E1312()
        {
            //string[] input = "( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )".Split(' ');
            string[] input = "1 2 3 4 5".Split(' ');
            FixedCapacityStackOfStrings stack = new FixedCapacityStackOfStrings(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
                Debug.Write(input[i]);
            }
            Debug.WriteLine("");

            foreach (var item in CopyStack(stack))
            {
                Debug.Write(item);
            }
            Debug.WriteLine("");
        }

        private static FixedCapacityStackOfStrings CopyStack(FixedCapacityStackOfStrings stack)
        {
            FixedCapacityStackOfStrings s = new FixedCapacityStackOfStrings(stack.Size);
            foreach (var item in stack)
            {
                s.Push(item);
                Debug.Write(item);
            }
            Debug.WriteLine("");

            return s;
        }

        [TestMethod]
        public void E131_()
        {
            QueueString queue = new QueueString();
            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");
            queue.Enqueue("4");
            queue.Enqueue("5");
            queue.Enqueue("6");
            queue.Enqueue("7");
            queue.Enqueue("8");
            queue.Enqueue("9");
            queue.Enqueue("10");

            foreach (var item in queue)
            {
                Debug.Write(item);
            }

            while (!queue.IsEmpty())
            {
                queue.Dequeue();
            }

            foreach (var item in queue)
            {
                Debug.Write(item);
            }
        }

        [TestMethod]
        public void E1316()
        {
            foreach (var item in ReadDates())
            {
                Debug.WriteLine(item);
            }
        }

        public static DateTime[] ReadDates()
        {
            FixCapacityStack<DateTime> stack = new FixCapacityStack<DateTime>(32);
            DateTime date = new DateTime(2013, 1, 31);
            for (int i = 30; i >= 0; i--)
            {
                stack.Push(date);
                date = date.AddDays(-1);
            }

            ResizingQueue<DateTime> queue = new ResizingQueue<DateTime>();

            while (!stack.IsEmpty())
                queue.Enqueue(stack.Pop());

            int size = queue.Size;
            DateTime[] dates = new DateTime[size];
            for (int i = 0; i < size; i++)
            {
                dates[i] = queue.Dequeue();
            }

            return dates;
        }

        [TestMethod]
        public void E1317()
        {
            FixCapacityStack<Transaction> stack = new FixCapacityStack<Transaction>(60);
            ResizingQueue<Transaction> queue = new ResizingQueue<Transaction>();

            for (int i = 0; i < 31; i++)
            {
                stack.Push(new Transaction(string.Format("name{0}", i), new Date(2013, 1, i + 1), i));
            }

            while (!stack.IsEmpty())
                queue.Enqueue(stack.Pop());

            int size = queue.Size;
            for (int i = 0; i < size; i++)
            {
                Debug.WriteLine(queue.Dequeue());
            }
        }

        [TestMethod]
        public void E1319()
        {
            Node<string> first = NodeFactory.Create<string>(10);

            NodeFactory.Print<string>(first);

            Node<string> current = Node<string>.DeleteLastNode(first);

            NodeFactory.Print<string>(current);
        }

        [TestMethod]
        public void E1320()
        {
            Node<string> first = NodeFactory.Create<string>(10);
            NodeFactory.Print<string>(first);

            Node<string> current = Node<string>.DeleteKthNode(first, 5);
            NodeFactory.Print<string>(current);
        }

        [TestMethod]
        public void E1321()
        {
            Node<string> first = NodeFactory.Create<string>(10);
            Debug.WriteLine(Node<string>.Find(first, 10));
        }

        [TestMethod]
        public void E1324()
        {
            Node<string> first = NodeFactory.Create<string>(10);
            var currrent = Node<string>.RemoveAfter(first, new Node<string>(10));
            NodeFactory.Print<string>(currrent);
        }

        [TestMethod]
        public void E1325()
        {
            Node<string> first = NodeFactory.Create<string>(10);
            var current = Node<string>.InsertAfter(first, new Node<string>(20));
            NodeFactory.Print<string>(current);
        }

        [TestMethod]
        public void E1326()
        {
            Node<string> first = NodeFactory.Create<string>(10);
            Node<string>.InsertAfter(first, new Node<string>(8));

            var current = Node<string>.Remove(first, 8);
            NodeFactory.Print<string>(current);
        }

        [TestMethod]
        public void E1327()
        {
            Node<string> first = NodeFactory.Create<string>(10);
            Debug.WriteLine(Node<string>.Max(first));
        }

        [TestMethod]
        public void E1328()
        {
            Node<string> first = NodeFactory.Create<string>(10);
            Debug.WriteLine(Node<string>.MaxRecursive(first, 0));
        }

        [TestMethod]
        public void E1329()
        {
            LinkedListQueue<string> queue = new LinkedListQueue<string>();
            Assert.AreEqual(0, queue.Size);
            queue.Enqueue(new Node<string>(1));
            Assert.AreEqual(1, queue.Size);
            queue.Enqueue(new Node<string>(2));
            Assert.AreEqual(2, queue.Size);
            queue.Enqueue(new Node<string>(3));
            Assert.AreEqual(3, queue.Size);

            queue.Dequeue();
            Assert.AreEqual(2, queue.Size);
            queue.Dequeue();
            Assert.AreEqual(1, queue.Size);
            queue.Dequeue();
            Assert.AreEqual(0, queue.Size);
            Assert.IsTrue(queue.IsEmpty());

            try
            {
                queue.Dequeue();
                throw new ApplicationException("Test failed");
            }
            catch (Exception)
            { }
        }

        [TestMethod]
        public void E1330()
        {
            Node<string> first = NodeFactory.Create<string>(10);
            Node<string> reverse = Node<string>.Reverse(first);
            NodeFactory.Print<string>(reverse);
        }

        [TestMethod]
        public void E1331()
        {
            DoubleNode<string> first = DoubleNodeFactory.Create<string>(10);
            DoubleNodeFactory.Print<string>(first);
            DoubleNodeFactory.PrintReverse<string>(first);
        }
    }
}