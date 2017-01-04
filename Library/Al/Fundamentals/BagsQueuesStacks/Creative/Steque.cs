using Algorithm.Fundamentals.BagsQueuesStacks.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.Creative
{
    public class Steque<T>
    {
        protected Node<T> _first;

        public Steque()
        {
            _first = new Node<T>(0);
        }

        public void Push(Node<T> node)
        {
            if (node == null)
                throw new ArgumentException("node");

            Node<T> last = GetLastNode();

            last.Next = node;
            node.Next = null;
        }

        public Node<T> Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("empty");

            Node<T> temp;

            if (_first.Next.Next == null)
            {
                temp = _first.Next;
                _first.Next = null;

                return temp;
            }

            Node<T> current = _first.Next;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            temp = current.Next;

            current.Next = null;

            return temp;
        }

        public void Enqueue(Node<T> node)
        {
            if (node == null)
                throw new ArgumentException();

            if (IsEmpty())
            {
                _first.Next = node;
            }

            node.Next = _first.Next;
            _first.Next = node;
        }

        public bool IsEmpty()
        {
            return _first.Next == null;
        }

        public int Size
        {
            get
            {
                int count = 0;

                Node<T> current = _first.Next;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                };

                return count;
            }
        }

        private Node<T> GetLastNode()
        {
            Node<T> current = _first;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }
    }
}
