using System;
using System.Text;
using Ds.Queue;
using Lib.Common.Ds.Common;
using Lib.Common.Ds.Common.Enumeration;

namespace Lib.Common.Ds.Queue
{
    public class Queue<T> : QueueEnumerableEntity<T>, IQueue<T>
    {
        private int _n;

        public Queue()
        {
            _n = 0;
            Header = null;
            _last = null;
        }

        #region IQueue

        public void Enqueue(T item)
        {
            var temp = Header;
            Header = new DoubleLinkNode<T> { Value = item, Next = temp };

            if (temp != null) temp.Previous = Header;

            if (_last == null) _last = Header;

            ++_n;
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException();

            var item = _last.Value;

            if (Header.Next == null)
            {
                Header = null;
                _last = null;
            }
            else
            {
                var current = Header;

                while (current.Next != _last)
                {
                    current = current.Next;
                }

                _last = current;
                _last.Next = null;
            }

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
            return Header == null;
        }

        public int Size()
        {
            return _n;
        }

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var n in this)
            {
                sb.Append(n + " ");
            }

            return sb.ToString();
        }
    }
}