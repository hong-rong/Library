using System;
using Lib.Common.Ds.Common;

namespace Lib.Common.Ds.Ll
{
    public class LinkedListExe<T> : LinkedList<T>
    {
        private LinkNode<T> _root;

        public LinkedListExe(LinkNode<T> root)
            : base(root)
        {
            _root = root;
        }

        public LinkNode<T> Get(int index)
        {
            if (index < 0 || (index > 0 && index >= Size())) throw new IndexOutOfRangeException();

            int i = 0;
            var current = _root;
            while (current != null)
            {
                if (i == index) return current;

                current = current.Next;
                i++;
            }

            return current;
        }

        /// <summary>
        /// first occurrence
        /// </summary>
        public int IndexOf(T t)
        {
            int i = 0;
            var current = _root;

            while (current != null)
            {
                if (current.Value.Equals(t)) return i;

                current = current.Next;
                i++;
            }

            return -1;
        }

        public bool Contains(T t)
        {
            var current = _root;

            while (current != null)
            {
                if (current.Value.Equals(t)) return true;
                current = current.Next;
            }

            return false;
        }

        public int Size()
        {
            int i = 0;
            var current = _root;
            while (current != null)
            {
                current = current.Next;
                i++;
            }

            return i;
        }

        /// <summary>
        /// add item to the end
        /// </summary>
        public void Add(LinkNode<T> item)
        {
            if (_root == null)
            {
                _root = item;
                return;
            }

            var current = _root;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = item;
        }

        public void Add(int index, LinkNode<T> item)
        {
            if (index < 0 || (index > 0 && index >= Size())) throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                item.Next = _root.Next;
                _root = item;
            }

            int i = 0;
            var current = _root;

            while (current != null)
            {
                if (i == index - 1)
                {
                    item.Next = current.Next.Next;
                    current.Next = item;
                }

                current = current.Next;
                i++;
            }
        }

        /// <summary>
        /// remove header
        /// </summary>
        public LinkNode<T> Remove()
        {
            if (_root == null) return null;

            var node = _root;

            _root = _root.Next;

            return node;
        }

        /// <summary>
        /// remove item in position index
        /// </summary>
        public LinkNode<T> Remove(int index)
        {
            if (index < 0 || (index > 0 && index >= Size())) throw new IndexOutOfRangeException();

            if (index == 0)
            {
                return Remove();
            }

            int i = 0;
            var current = _root;

            while (current != null)
            {
                if (i == index - 1)
                {
                    LinkNode<T> deleted = current.Next;
                    current.Next = current.Next.Next;
                    return deleted;
                }

                current = current.Next;
                i++;
            }

            return null;
        }

        public void Clear()
        {
            _root = null;
        }
    }
}