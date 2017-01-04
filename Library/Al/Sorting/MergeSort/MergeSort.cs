using System;

namespace Algorithm.Sorting.MergeSort
{
    public class MergeSort : MergeSortBase
    {
        public override void Sort(IComparable[] a)
        {
            Aux = new IComparable[a.Length];

            //Print(a);

            Sort(a, 0, a.Length - 1);

            //Print(a);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = (hi + lo) / 2;

            Sort(a, lo, mid);
            Sort(a, mid + 1, hi);

            Merge(a, lo, mid, hi);
        }
    }
}
