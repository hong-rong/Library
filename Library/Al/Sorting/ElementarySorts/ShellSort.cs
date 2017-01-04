using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Sorting.ElementarySorts
{
    public class ShellSort : SortBase
    {
        public override void Sort(IComparable[] a)
        {
            Debug.WriteLine("Element number: {0}", a.Length);
            PrintColumnNum(a.Length);
            Print(a);

            int N = a.Length;

            int[] hs = new int[N / 9 + 1];
            hs[0] = 1;
            for (int i = 1; i < hs.Length; i++)
            {
                hs[i] = 3 * hs[i - 1] + 1;
            }

            for (int k = hs.Length - 1; k >= 0; k--)
            {
                SortSubSequence(a, N, hs[k]);
            }
            
            //int h = 1;
            //while (h < N / 3)
            //    h = 3 * h + 1;
            //while (h >= 1)
            //{
            //    SortSubSequence(a, N, h);
            //    h = h / 3;
            //}
        }

        private void SortSubSequence(IComparable[] a, int N, int h)
        {
            Debug.WriteLine("h = {0}", h);
            for (int i = h; i < N; i++)
            {
                for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                {
                    Exchange(a, j, j - h);
                }

                Print(a);
            }
        }
    }
}
