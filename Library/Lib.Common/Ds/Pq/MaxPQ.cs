using System;

namespace Lib.Common.Ds.Pq
{
    public class MaxPQ<TKey> : MinPQ<TKey>
    {
        public MaxPQ()
            : this(1)
        { }

        public MaxPQ(int initCapacity)
            : base(initCapacity)
        { }

        protected override bool Compare(int i, int j)
        {
            if (_comparator == null)
            {
                return ((IComparable<TKey>)_pq[i]).CompareTo(_pq[j]) < 0;
            }

            return _comparator.Compare(_pq[i], _pq[j]) < 0;
        }
    }
}
