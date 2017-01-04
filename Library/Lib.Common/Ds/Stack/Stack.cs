using System;
using System.Text;
using Ds.Stack;
using Lib.Common.Ds.Common;
using Lib.Common.Ds.Common.Enumeration;

namespace Lib.Common.Ds.Stack
{
    public class Stack<T> : LinkedListEnumerable<T>, IStack<T>
    {
        private int _n;

        public Stack()
        {
            _n = 0;
            Header = null;
        }

        #region IStack

        public void Push(T item)
        {
            //wrong logic
            //if (_first == null)
            //{
            //    _first = new Node<Item>() { Data = item };
            //    return;
            //}
            //Node<Item> node = new Node<Item>() { Data = item };
            //node.Next = _first.Next;
            //_first = node;

            var temp = Header;
            Header = new LinkNode<T> { Value = item, Next = temp };

            ++_n;
        }

        public T Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException();

            T item = Header.Value;
            Header = Header.Next;

            --_n;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException();

            return Header.Value;
        }

        public bool IsEmpty()
        {
            return _n == 0;
        }

        public int Size()
        {
            return _n;
        }

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var t in this)
            {
                sb.Append(t + " ");
            }

            return sb.ToString();
        }
    }
}