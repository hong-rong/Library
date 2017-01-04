using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.LinkedList
{
    public class LinkedListQueue<T>
    {
        protected Node<T> _last;

        public LinkedListQueue()
        {
            _last = new Node<T>(-1);
        }

        public void Enqueue(Node<T> node)
        {
            if (node == null)
                throw new ArgumentException("node");

            if (IsEmpty())
            {
                _last.Next = node;
                node.Next = _last.Next;

                return;
            }

            Node<T> tail = GetTailNode();

            tail.Next = node;
            node.Next = _last.Next;
        }

        public Node<T> Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("empty");

            Node<T> temp;
            if (Size == 1)
            {
                temp = _last.Next;
                _last.Next = null;
            }
            else
            {
                Node<T> tail = GetTailNode();

                tail.Next = tail.Next.Next;

                temp = _last.Next;
                _last.Next = tail.Next;
            }

            return temp;
        }

        private Node<T> GetTailNode()
        {
            Node<T> current = _last.Next;

            while (current.Next != _last.Next)
            {
                current = current.Next;
            }

            return current;
        }

        public bool IsEmpty()
        {
            return _last.Next == null;
        }

        public bool IsFull()
        {
            return Size == int.MaxValue;
        }

        public int Size
        {
            get
            {
                int count = 0;

                if (IsEmpty())
                    return count;

                Node<T> current = _last.Next;

                count++;

                if (current.Next == _last.Next)
                    return count;

                do
                {
                    count++;
                    current = current.Next;
                } while (current.Next != _last.Next);

                return count;
            }
        }

        public void Print()
        {
            if (IsEmpty())
                return;

            if (Size == 1)
                Debug.WriteLine(_last.Next.Id);

            Node<T> current = _last;
            while (current.Next != _last.Next)
            {
                Debug.Write(current.Next.Id);
                current = current.Next;
            }
            Debug.WriteLine("");
        }
    }
}
