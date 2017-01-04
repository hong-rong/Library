using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.LinkedList
{
    public class Node<T> : NodeBase<T>
    {
        public Node(int id)
            : base(id)
        { }

        public virtual Node<T> Next { get; set; }

        public static Node<T> DeleteLastNode(Node<T> first)
        {
            if (first == null || first.Next == null)
                return null;

            Node<T> current = first;

            while (current.Next != null)
            {
                if (current.Next.Next == null)
                {
                    current.Next = null;
                    break;
                }

                current = current.Next;
            }

            return first;
        }

        public static Node<T> DeleteKthNode(Node<T> first, int k)
        {
            if (k <= 0) throw new ArgumentException();

            if (first == null)
                return null;

            if (k == 1)
                first = first.Next;

            Node<T> current = first;
            int count = 1;

            while (current.Next != null)
            {
                if (count == k - 1)
                {
                    current.Next = current.Next.Next;
                    break;
                }

                current = current.Next;
                count++;
            }

            return first;
        }

        public static bool Find(Node<T> first, int key)
        {
            while (first != null)
            {
                if (first.Id == key)
                    return true;
                else
                    first = first.Next;
            }

            return false;
        }

        public static Node<T> RemoveAfter(Node<T> first, Node<T> startNode)
        {
            if (startNode == null)
                return first;

            Node<T> current = first;

            while (current != null)
            {
                if (current.Id == startNode.Id)
                {
                    current.Next = null;
                    return first;
                }

                current = current.Next;
            }

            return first;
        }

        public static Node<T> InsertAfter(Node<T> first, Node<T> second)
        {
            if (first == null || second == null)
                return first;

            Node<T> current = first;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = second;

            return first;
        }

        public static Node<T> Remove(Node<T> first, int key)
        {
            if (first == null)
                return first;

            if (first.Id == key)
                first = first.Next;

            Node<T> current = first;
            while (current != null)
            {
                if (current.Next != null && current.Next.Id == key)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }

            return first;
        }

        public static int Max(Node<T> first)
        {
            int max = 0;

            if (first == null)
                return max;

            Node<T> current = first;

            while (current != null)
            {
                if (current.Id > max)
                    max = current.Id;

                current = current.Next;
            }

            return max;
        }

        public static int MaxRecursive(Node<T> first, int max)
        {
            if (first == null)
                return max;

            if (first.Id > max)
                max = first.Id;

            first = first.Next;

            return MaxRecursive(first, max);
        }

        public static Node<T> Reverse(Node<T> first)
        {
            if (first == null || first.Next == null)
                return first;

            Node<T> previous = first;
            Node<T> current = first.Next;
            Node<T> next = current.Next;
            first.Next = null;
            do
            {
                current.Next = previous;

                if (next == null)
                    break;

                previous = current;
                current = next;
                next = next.Next;
            } while (true);

            return current;
        }
    }
}