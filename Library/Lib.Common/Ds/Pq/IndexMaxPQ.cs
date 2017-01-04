using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Common.Ds.Pq
{
    public class IndexMaxPQ<TKey> : IndexMinPQ<TKey> where TKey : IComparable<TKey>
    {
        public IndexMaxPQ(int maxN)
            : base(maxN)
        { }

        protected override bool Compare(int i, int j)
        {
            return _keys[_pq[i]].CompareTo(_keys[_pq[j]]) > 0;
        }
    }
}
