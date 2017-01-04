using System;

namespace Lib.Common.Ds.Pq
{
    public class IndexMinPQ<TKey> where TKey : IComparable<TKey>
    {
        private readonly int _maxN;
        protected readonly int[] _pq;//internal heap structure 1-based indices
        private readonly int[] _qp;//inverse of _pq[], _qp[i] gives the position of i in _pq, (index j such that _pq[j] is i)
        protected readonly TKey[] _keys;//key values, _keys[i] stands for priority of i
        private int N;

        /// <summary>
        /// Create priority queue of capacity maxN+1
        /// </summary>
        public IndexMinPQ(int maxN)
        {
            _maxN = maxN + 1;
            N = 0;
            _pq = new int[maxN + 1];
            _qp = new int[maxN + 1];
            _keys = new TKey[maxN + 1];
            for (var i = 0; i < maxN; i++)
            {
                _qp[i] = -1;
            }
        }

        /// <summary>
        /// Insert item, associate with index i
        /// </summary>
        /// <param name="i">index i</param>
        /// <param name="t">item associate index i</param>
        public void Insert(int i, TKey t)
        {
            if (i < 0 || i >= _maxN) throw new IndexOutOfRangeException();
            if (Contains(i)) throw new InvalidOperationException(string.Format("Index {0} already exists", i));

            _keys[i] = t;
            N++;
            _qp[i] = N;
            _pq[N] = i;
            Swim(N);
        }

        /// <summary>
        /// move up smaller keys
        /// </summary>
        /// <param name="i">heap structure index</param>
        private void Swim(int i)
        {
            while (i > 1 && Compare(i, i / 2))
            {
                Exchange(i, i / 2);
                i = i / 2;
            }
        }

        /// <summary>
        /// check if heap index i is less than j
        /// </summary>
        /// <param name="i">heap structure index</param>
        /// <param name="j">heap structure index</param>
        /// <returns></returns>
        protected virtual bool Compare(int i, int j)
        {
            return _keys[_pq[i]].CompareTo(_keys[_pq[j]]) < 0;
        }

        /// <summary>
        /// Swap heap structure i and j 
        /// </summary>
        /// <param name="i">heap structure index</param>
        /// <param name="j">heap structure index</param>
        private void Exchange(int i, int j)
        {
            var swap = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = swap;
            _qp[_pq[i]] = i;
            _qp[_pq[j]] = j;
        }

        /// <summary>
        /// Change the item associated with i to t
        /// </summary>
        /// <param name="i">inde i</param>
        /// <param name="t">item associate with i</param>
        public void ChangeKey(int i, TKey t)
        {
            if (i < 0 || i >= _maxN) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException(string.Format("Index {0} does not exist", i));

            _keys[i] = t;
            Swim(_qp[i]);
            Sink(_qp[i]);
        }

        /// <summary>
        /// Remove a minimal item and return its index
        /// </summary>
        /// <returns>index of removed minimal item</returns>
        public int DelRoot()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");
            var min = _pq[1];
            Exchange(1, N);
            N--;//before Sink
            Sink(1);

            _keys[_pq[N + 1]] = default(TKey);
            _qp[min] = -1;
            //_pq[N+1] = -1;//can be removed?
            return min;
        }

        /// <summary>
        /// Remove i and its associated item
        /// </summary>
        /// <param name="i">index i associated with item</param>
        public void Delete(int i)
        {
            if (i < 0 || i >= _maxN) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException(string.Format("Index {0} does not exist", i));
            var k = _pq[i];
            Exchange(k, N);
            N--;//before swim and sink
            Swim(k);
            Sink(k);

            _keys[i] = default(TKey);
            _qp[i] = -1;
            _pq[N + 1] = -1;
        }

        /// <summary>
        /// move down larger keys
        /// </summary>
        /// <param name="i">heap structure index</param>
        private void Sink(int i)
        {
            while (i * 2 <= N)
            {
                var j = i * 2;
                if (j < N && Compare(j + 1, j))
                {
                    j++;
                }
                if (!Compare(j, i)) break;
                {
                    Exchange(j, i);
                }

                i = j;
            }
        }

        /// <summary>
        /// Return a minimal item
        /// </summary>
        public virtual TKey Root()
        {
            return _keys[_pq[1]];
        }

        /// <summary>
        /// Return a minimal item's index
        /// </summary>
        public virtual int RootIndex()
        {
            return _pq[1];
        }

        /// <summary>
        /// Is k associated with some item
        /// </summary>
        /// <param name="i">index i associated with item</param>
        /// <returns></returns>
        public bool Contains(int i)
        {
            return _qp[i] != -1;
        }

        /// <summary>
        /// Is the priority queue empty
        /// </summary>
        public bool IsEmpty()
        {
            return N == 0;
        }

        /// <summary>
        /// Number of items in the priority queue
        /// </summary>
        public int Size()
        {
            return N;
        }
    }
}