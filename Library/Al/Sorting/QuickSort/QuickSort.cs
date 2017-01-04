using System;

namespace Algorithm.Sorting.QuickSort
{
    public class QuickSort : SortBase
    {
        public override void Sort(IComparable[] a)
        {
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;

            int j = Partition(a, lo, hi);

            Sort(a, lo, j - 1);

            Sort(a, j + 1, hi);
        }

        public int Partition(IComparable[] a, int lo, int hi)
        {
            int left = lo;
            int right = hi;

            IComparable value = a[lo];

            while (true)
            {
                while (Less(a[left], value))
                    left++;

                while (Less(value, a[right]))
                    right--;

                if (left < right)
                    Exchange(a, left, right);
                else
                    return right;
            }
        }

        private int Partition_Version_One(IComparable[] a, int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;
            IComparable value = a[lo];

            while (true)
            {
                while (Less(a[++i], value))
                {
                    if (i == hi) break;
                }

                while (Less(value, a[--j]))
                {
                    if (j == lo) break;
                }

                if (i >= j)
                {
                    break;
                }

                Exchange(a, i, j);
            }

            Exchange(a, lo, j);

            return j;
        }
    }
}