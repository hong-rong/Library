using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks
{
    public class EnumerableFixCapacityStack<T> : FixCapacityStack<T>, IEnumerator<T>, IEnumerable<T>
    {
        protected int _enumberatorIndex;

        public EnumerableFixCapacityStack(int n)
            : base(n)
        {
            _enumberatorIndex = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Reset();

            while (MoveNext())
                yield return Current;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Current
        {
            get { return _a[_enumberatorIndex]; }
        }

        public void Dispose()
        { }

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (_enumberatorIndex == _a.Length - 1)
                return false;

            _enumberatorIndex++;

            return true;
        }

        public void Reset()
        {
            _enumberatorIndex = -1;
        }
    }
}
