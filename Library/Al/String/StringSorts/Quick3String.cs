using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.String.StringSorts
{
    public class Quick3String
    {
        private static int CharAt(string s, int d)
        {
            if (d < s.Length)
                return s[d];
            else
                return -1;
        }

        public static void Sort(string[] a)
        {
            Sort(a, 0, a.Length - 1, 0);

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        private static void Sort(string[] a, int lo, int hi, int d)
        {
            if (hi <= lo) return;

            int lt = lo, gt = hi;
            int v = CharAt(a[lo], d);
            int i = lo + 1;
            while (i <= gt)
            {
                int t = CharAt(a[i], d);
                if (t < v) Exch(a, lt++, i++);
                else if (t > v) Exch(a, i, gt--);
                else i++;
            }

            //a[lo..lt-1] < v < a[lt..gt] < a[gt+1..hi]

            Sort(a, lo, lt - 1, d);
            if (v >= 0) Sort(a, lt, gt, d + 1);
            Sort(a, gt + 1, hi, d);
        }

        private static void Exch(string[] a, int p1, int p2)
        {
            string temp = a[p1];
            a[p1] = a[p2];
            a[p2] = temp;
        }
    }
}
