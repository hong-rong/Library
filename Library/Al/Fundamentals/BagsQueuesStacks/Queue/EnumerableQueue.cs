using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.Queue
{
    public class EnumerableQueue<T> : QueueBase<T>, IEnumerator<T>, IEnumerable<T>
    {
        private int _curPos;

        public EnumerableQueue(int size)
            : base(size)
        {
            _curPos = Front - 1;
        }

        public T Current
        {
            get { return Queue[_curPos]; }
        }

        public void Dispose()
        {

        }

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            int next = (_curPos + 1) % Queue.Length;

            if (next == End)
                return false;

            _curPos = next;

            return true;
        }

        public void Reset()
        {
            _curPos = Front - 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Reset();

            while (MoveNext())
            {
                yield return Current;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
