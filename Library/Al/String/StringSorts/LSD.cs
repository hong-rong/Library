using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.String.StringSorts
{
    public class LSD
    {
        public static void Sort(string[] a)
        {
            int w = 7;
            int N = a.Length;
            int R = 256;
            string[] aux = new string[N];

            for (int d = w - 1; d >= 0; d--)
            {
                int[] count = new int[R + 1];

                for (int i = 0; i < N; i++)
                    count[a[i][d] + 1]++;

                for (int r = 0; r < R; r++)
                    count[r + 1] += count[r];

                for (int i = 0; i < N; i++)
                    aux[count[a[i][d]]++] = a[i];

                for (int i = 0; i < N; i++)
                    a[i] = aux[i];
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
