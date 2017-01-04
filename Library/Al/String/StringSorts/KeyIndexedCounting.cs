using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.String.StringSorts
{
    public class KeyIndexedCounting
    {
        public static void Sort(NameSection[] a)
        {
            for (int i = 0; i < a.Length; i++)
                a[i].Section = a[i].Section - 1;

            int N = a.Length;
            int R = 4;
            NameSection[] aux = new NameSection[N];
            int[] count = new int[R + 1];

            for (int i = 0; i < N; i++)
                count[a[i].Section + 1]++;

            for (int r = 0; r < R; r++)
                count[r + 1] += count[r];

            for (int i = 0; i < N; i++)
                aux[count[a[i].Section]++] = a[i];

            for (int i = 0; i < N; i++)
                a[i] = aux[i];

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("{0} {1}", a[i].Name, a[i].Section);
            }
        }
    }
}
