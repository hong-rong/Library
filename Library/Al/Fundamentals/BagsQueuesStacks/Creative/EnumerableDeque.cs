using Algorithm.Fundamentals.BagsQueuesStacks.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.Creative
{
    public class EnumerableDeque<T> : Deque<T>//, IEnumerator<T>
    {
        protected DoubleNode<T> _current;

        public EnumerableDeque()
        {
            _current = _first;
        }

        //public T Current
        //{
        //    get { return _current; }
        //}

        public void Dispose()
        { }

        //object System.Collections.IEnumerator.Current
        //{
        //    get { return Current; }
        //}

        public bool MoveNext()
        {
            while (_current.Next != null)
            {
                _current = _current.Next;

                return true;
            }

            return false;
        }

        public void Reset()
        {
            _current = _first;
        }
    }
}
