using System;

namespace Lib.Common.Ds.Bs
{
    public class BinarySearch
    {
        public virtual int Search(int[] arr, int target)
        {
            if (arr.Length == 0) throw new InvalidOperationException("empty");

            return Search(arr, target, 0, arr.Length - 1);
        }

        private int Search(int[] arr, int target, int low, int high)
        {
            if (low > high) return -1;

            int m = (low + high) / 2;

            if (target < arr[m])
            {
                return Search(arr, target, low, m - 1);
            }

            if (target > arr[m])
            {
                return Search(arr, target, m + 1, high);
            }

            return m;
        }
    }
}