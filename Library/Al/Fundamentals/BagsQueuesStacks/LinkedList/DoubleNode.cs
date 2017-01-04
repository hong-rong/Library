using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.LinkedList
{
    public class DoubleNode<T> : NodeBase<T>
    {
        public DoubleNode(int id)
            : base(id)
        { }

        public virtual DoubleNode<T> Previous { get; set; }

        public virtual DoubleNode<T> Next { get; set; }

        public static DoubleNode<T> InsertToHeader(DoubleNode<T> first, DoubleNode<T> node)
        {
            if (first == null || node == null)
                return first;

            node.Next = first;
            first.Previous = node;

            return first;
        }

        public static DoubleNode<T> InsertToTail(DoubleNode<T> first, DoubleNode<T> node)
        {
            if (first == null || node == null)
                return first;

            DoubleNode<T> current = first;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
            node.Previous = current;

            return first;
        }

        public static DoubleNode<T> RemoveBefore(DoubleNode<T> first)
        {
            if (first == null || first.Next == null)
                return null;

            first = first.Next;
            first.Previous = null;

            return first;
        }

        public static DoubleNode<T> RemoveAfter(DoubleNode<T> first)
        {
            if (first == null || first.Next == null)
                return null;

            DoubleNode<T> current = first;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Previous.Next = null;
            current.Previous = null;

            return first;
        }

        public static DoubleNode<T> Remove(DoubleNode<T> first, DoubleNode<T> node)
        {
            if (first == null || node == null)
                return first;

            if (first.Id == node.Id)
            {
                if (first.Next == null)
                {
                    return null;
                }
                node.Previous = null;
                node.Next = first.Next;
                first.Next.Previous = node;

                return node;
            }

            DoubleNode<T> current = first;

            while (current != null)
            {
                if (current.Id == node.Id)
                {
                    if (current.Next == null)
                    {
                        current.Previous.Next = null;
                        current.Previous = null;
                    }

                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;

                    break;
                }

                current = current.Next;
            }

            return first;
        }

        public static DoubleNode<T> InsertBefore(DoubleNode<T> first, DoubleNode<T> node)
        {
            if (first == null || node == null)
                return first;

            if (first.Id == node.Id)
            {
                node.Previous = null;
                node.Next = first;
                first.Previous = node;

                return node;
            }

            DoubleNode<T> current = first.Next;
            while (current != null)
            {
                if (current.Id == node.Id)
                {
                    node.Previous = current.Previous;
                    node.Next = current;
                    current.Previous = node;

                    break;
                }

                current = current.Next;
            }

            return first;
        }

        public DoubleNode<T> InsertAfter(DoubleNode<T> first, DoubleNode<T> node)
        {
            if (node == null)
                return first;

            DoubleNode<T> current = first;

            while (current != null)
            {
                if (current.Id == node.Id)
                {
                    node.Previous = current;
                    node.Next = current.Next;

                    current.Next = node;
                }

                current = current.Next;
            }

            return first;
        }
    }
}
