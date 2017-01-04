using System;
using System.Diagnostics;

namespace Algorithm.Sorting.MergeSort
{
    public abstract class MergeSortBase : SortBase
    {
        protected static IComparable[] Aux;

        protected void Merge(IComparable[] a, int lo, int mid, int hi)
        {
            for (int k = lo; k <= hi; k++)
            {
                Aux[k] = a[k];
            }

            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = Aux[j++];
                else if (j > hi) a[k] = Aux[i++];
                else if (Less(Aux[j], Aux[i])) a[k] = Aux[j++];
                else a[k] = Aux[i++];
            }

            //Debug.WriteLine(string.Format("lo: {0}, mid: {1}, hi: {2}", lo, mid, hi));
            //Print(a);
            //Debug.WriteLine("");
        }
    }
}
