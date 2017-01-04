using System;
using Lib.Common.Ds.Common;
using Lib.Common.Ds.Common.Enumeration;

namespace Lib.Common.Ds.Ll
{
    public class LinkedList<T> : LinkedListEnumerable<T>, ILinkedList<T>
    {
        public LinkedList()
        { }

        public LinkedList(LinkNode<T> first)
        {
            if (first == null) throw new ArgumentNullException("first");

            Header = first;
        }

        #region ILinkedList

        public T Get(int index)
        {
            var node = GetNodeByIndex(index);

            return node == null ? default(T) : node.Value;
        }

        private LinkNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 ||
                (index > 0 && index >= Size())) //let index = 0 pass
                throw new IndexOutOfRangeException();

            var i = 0;
            var current = Header;
            while (i != index)
            {
                current = current.Next;
                i++;
            }

            return current;
        }

        public int FirstIndexOf(T t)
        {
            var index = 0;

            if (Header != null && Header.Value.Equals(t)) return index;

            var current = Header;
            while (current.Next != null)
            {
                current = current.Next;
                index++;
                if (current.Value.Equals(t)) return index;
            }

            return -1;
        }

        public bool Contains(T t)
        {
            var b = false;
            var current = Header;

            while (current != null)
            {
                if (current.Value.Equals(t))
                {
                    b = true;
                    break;
                }
                current = current.Next;
            }

            return b;
        }

        public int Size()
        {
            var i = 0;
            var current = Header;
            while (current != null)
            {
                i++;
                current = current.Next;
            }

            return i;
        }

        public void AddFirst(T t)
        {
            if (Header == null)
            {
                Header = new LinkNode<T> { Value = t };
            }
            else
            {
                LinkNode<T> temp = Header;
                Header = new LinkNode<T> { Value = t, Next = temp };
            }
        }

        public void AddLast(T t)
        {
            var item = new LinkNode<T>() { Value = t };
            var current = GetLastNode();

            if (current == null)
                Header = item;
            else
                current.Next = item;
        }

        public void Add(int index, T t)
        {
            var item = new LinkNode<T>() { Value = t };

            var current = GetNodeByIndex(index);
            var next = current.Next;

            current.Next = item;
            item.Next = next;
        }

        public T RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public T RemoveLast()
        {
            throw new NotImplementedException();
        }

        public T Remove(int index)
        {
            if (Header == null) return default(T);

            LinkNode<T> node;
            if (index == 0 && Header != null)
            {
                node = Header;
                Header = Header.Next;
            }
            else
            {
                node = GetNodeByIndex(index - 1);
                var tempNode = node.Next;
                node.Next = tempNode.Next;
                node = tempNode;
            }

            node.Next = null;

            return node.Value;
        }

        public void Clear()
        {
            Header = null;
        }

        private LinkNode<T> GetLastNode()
        {
            if (Header == null) return null;

            var current = Header;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current;
        }

        public T[] ToArray()
        {
            int i = 0;
            var arr = new T[Size()];
            foreach (var item in this)
            {
                arr[i++] = item;
            }

            return arr;
        }

        #endregion
    }
}