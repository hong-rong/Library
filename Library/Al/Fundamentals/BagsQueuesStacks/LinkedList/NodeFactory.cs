using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.LinkedList
{
    public class NodeFactory
    {
        public static Node<T> Create<T>(int size)
        {
            Node<T> first = new Node<T>(0);
            Node<T> current = first;
            for (int i = 1; i < size; i++)
            {
                current.Next = new Node<T>(i);
                current = current.Next;
            }

            return first;
        }

        public static void Print<T>(Node<T> node)
        {
            while (node != null)
            {
                Debug.Write(string.Format("{0}  ", node.Id));
                node = node.Next;
            }
            Debug.WriteLine("");
        }
    }
}
