using Algorithm.Fundamentals.BagsQueuesStacks.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.Creative
{
    public class Deque<T>
    {
        protected DoubleNode<T> _first;
        protected DoubleNode<T> _last;

        public Deque()
        {
            _first = new DoubleNode<T>(0);
            _last = new DoubleNode<T>(-1);
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
                DoubleNode<T> current = _first;
                while (current.Next != null)
                {
                    count++;
                    current = current.Next;
                };

                return count;
            }
        }

        public void PushLeft(DoubleNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            if (IsEmpty())
            {
                PushFirstNode(node);

                return;
            }

            node.Previous = null;
            _first.Next.Previous = node;
            node.Next = _first.Next;
            _first.Next = node;
        }

        public void PushRight(DoubleNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            if (IsEmpty())
            {
                PushFirstNode(node);

                return;
            }

            node.Next = null;
            node.Previous = _last.Next;
            _last.Next.Next = node;
            _last.Next = node;
        }

        DoubleNode<T> PopLeft()
        {
            if (IsEmpty())
                throw new InvalidOperationException("empty");

            DoubleNode<T> temp;

            if (_first.Next.Next == null)
            {
                return PopLastNode(out temp);
            }

            temp = _first.Next;

            _first.Next = _first.Next.Next;
            _first.Next.Previous = null;

            temp.Next = null;

            return temp;
        }

        DoubleNode<T> PopRight()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            DoubleNode<T> temp;

            if (_last.Next.Previous == null)
            {
                return PopLastNode(out temp);
            }

            temp = _last.Next;

            _last.Next = _last.Next.Previous;
            _last.Next.Next = null;

            temp.Previous = null;

            return temp;
        }

        private DoubleNode<T> PopLastNode(out DoubleNode<T> temp)
        {
            temp = _first.Next;
            _first.Next = null;
            _last.Next = null;

            return temp;
        }

        private void PushFirstNode(DoubleNode<T> node)
        {
            _first.Next = node;
            node.Previous = null;
            node.Next = null;
            _last.Next = node;
        }
    }
}
