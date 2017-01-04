using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.LinkedList
{
    public class DoubleNodeFactory
    {
        public static DoubleNode<T> Create<T>(int size)
        {
            DoubleNode<T> first = new DoubleNode<T>(0);

            DoubleNode<T> current = first;
            for (int i = 1; i < size; i++)
            {
                DoubleNode<T> temp = new DoubleNode<T>(i);
                current.Next = temp;
                temp.Previous = current;
                current = temp;
            }

            return first;
        }

        public static void Print<T>(DoubleNode<T> first)
        {
            DoubleNode<T> current = first;

            while (current != null)
            {
                Debug.Write(string.Format("{0}  ", current.Id));
                current = current.Next;
            }
            Debug.WriteLine("");
        }

        public static void PrintReverse<T>(DoubleNode<T> first)
        {
            if (first == null)
                return;

            DoubleNode<T> current = first;

            while (current.Next != null)
            {
                current = current.Next;
            }

            while (current != null)
            {
                Debug.Write(string.Format("{0}  ", current.Id));
                current = current.Previous;
            }
        }
    }
}
