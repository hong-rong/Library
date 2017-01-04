using System;

namespace Algorithm.Sorting.MergeSort
{
    public class MergeSortBottomUp : MergeSortBase
    {
        public override void Sort(IComparable[] a)
        {
            int N = a.Length;
            Aux = new IComparable[N];

            Print(a);

            for (int sz = 1; sz < N; sz = sz + sz)
            {
                for (int lo = 0; lo < N - sz; lo += sz + sz)
                {
                    Merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
                }
            }
        }
    }
}
