using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.String.StringSorts
{
    public class Insertion
    {
        public static void Sort(string[] a, int lo, int hi, int d)
        {
            for (int i = lo; i <= hi; i++)
            {
                for (int j = i; j > lo && Less(a[j], a[j - 1], d); j--)
                {
                    Exch(a, j, j - 1);
                }
            }
        }

        private static void Exch(string[] a, int j, int p)
        {
            string temp = a[j];
            a[j] = a[p];
            a[p] = temp;
        }

        private static bool Less(string v, string w, int d)
        {
            return v.Substring(d).CompareTo(w.Substring(d)) < 0;
        }
    }

    public class MSD
    {
        private static int R = 256;
        private static readonly int M = 3;
        private static string[] aux;

        private static int CharAt(string s, int d)
        {
            if (d < s.Length)
            {
                return s[d];
            }
            else
            {
                return -1;
            }
        }

        public static void Sort(string[] a)
        {
            int N = a.Length;
            aux = new string[N];
            Sort(a, 0, N - 1, 0);

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        private static void Sort(string[] a, int lo, int hi, int d)
        {
            if (hi <= lo + M)
            {
                Insertion.Sort(a, lo, hi, d);
                return;
            }

            int[] count = new int[R + 2];
            for (int i = lo; i <= hi; i++)
                count[CharAt(a[i], d) + 2]++;

            for (int r = 0; r < R + 1; r++)
                count[r + 1] += count[r];

            for (int i = lo; i <= hi; i++)
                aux[count[CharAt(a[i], d) + 1]++] = a[i];

            for (int i = lo; i <= hi; i++)
                a[i] = aux[i - lo];

            for (int r = 0; r < R; r++)
                Sort(a, lo + count[r], lo + count[r + 1] - 1, d + 1);
        }
    }
}