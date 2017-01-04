using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BasicProgrammingModel
{
    [TestClass]
    public class Exercise
    {
        [TestMethod]
        public void E111()
        {
            Debug.WriteLine((0 + 15) / 2);
            Debug.WriteLine(2.0e-6 * 100000000.1);
            Debug.WriteLine(true && false || true && true);
        }

        [TestMethod]
        public void E112()
        {
            Debug.WriteLine((1 + 2.236) / 2);
            Debug.WriteLine(1 + 4.0);//strange
            Debug.WriteLine(4.1 >= 4);
            Debug.WriteLine(1 + 2 + "3");
        }

        [TestMethod]
        public void E113()
        {
            int i1 = GetInputNumber("first");
            int i2 = GetInputNumber("second");
            int i3 = GetInputNumber("third");

            if (i1 == i2 && i2 == i3)
                Debug.WriteLine("equal");
            else
                Debug.WriteLine("not");
        }

        private static int GetInputNumber(string order)
        {
            Debug.WriteLine("Please input {0} integer:", order);

            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// good exercie
        /// </summary>
        [TestMethod]
        public void E115()
        {
            double x, y;
            x = 0.999999999999999999999;
            y = x;

            if ((x > 0 && x < 1) && (y > 0 && y < 1))
                Debug.WriteLine("true");
            else
                Debug.WriteLine("false");
        }

        /// <summary>
        /// good exercie
        /// </summary>
        [TestMethod]
        public void E116()
        {
            int f = 0;
            int g = 1;
            for (int i = 0; i <= 15; i++)
            {
                Debug.WriteLine(f);
                f = f + g;
                g = f - g;
            }
        }

        [TestMethod]
        public void E117_1()
        {
            double t = 9.0;
            while (Math.Abs(t - 9.0 / t) > 0.001)
                t = (9.0 / t + t) / 2.0;

            Debug.WriteLine(t);
        }

        [TestMethod]
        public void E117_2()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
                for (int j = 0; j < i; j++)
                    sum++;

            Debug.WriteLine(sum);//499500
        }

        [TestMethod]
        public void E117_3()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i *= 2)
                for (int j = 0; j < 1000; j++)
                    sum++;

            Debug.WriteLine(sum);//10000
        }

        [TestMethod]
        public void E118()
        {
            Debug.WriteLine('b');//b
            Debug.WriteLine('b' + 'c');//197
            Debug.WriteLine((char)('a' + 4));//e
        }

        [TestMethod]
        public void E119()
        {
            int n = 10;
            string binary = "";
            for (int i = n; i > 0; i = i / 2)
                binary = (i % 2) + binary;

            Debug.WriteLine(binary);
        }

        [TestMethod]
        public void E1112()
        {
            int[] a = new int[10];
            for (int i = 0; i < 10; i++)
                a[i] = 9 - i;

            for (int i = 0; i < 10; i++)
                a[i] = a[a[i]];

            for (int i = 0; i < 10; i++)
                Debug.WriteLine(i);
        }

        [TestMethod]
        public void E1113()
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            int[,] trans = new int[N, M];

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    trans[j, i] = matrix[i, j];

            for (int i = 0; i < N; i++)
            {
                Debug.WriteLine("");
                for (int j = 0; j < M; j++)
                    Debug.Write(trans[i, j] + "   ");
            }
        }

        /// <summary>
        /// good exercise
        /// </summary>
        [TestMethod]
        public void E1114()
        {
            Debug.WriteLine(5 / 2);
            int n = 10, j = 0;
            for (int i = n; i > 1; i /= 2)
                j++;

            Debug.WriteLine(j);
        }

        [TestMethod]
        public void E1115()
        {
            int[] a = { 1, 2, 3, 4, 5, 4, 5, 6, 7 };
            int m = 8;
            int[] count = HistoGram(a, m);

            Debug.WriteLine("Sum: " + count.Sum());
            Debug.WriteLine("Lenght: " + a.Length);
        }

        public int[] HistoGram(int[] a, int m)
        {
            int[] count = new int[m];
            for (int i = 0; i < a.Length; i++)
                if (a[i] >= 0 && a[i] < m)
                    count[a[i]]++;

            return count;
        }

        [TestMethod]
        public void E1116()
        {
            Debug.WriteLine(ExR1(6));
        }

        public static string ExR1(int n)
        {
            if (n <= 0) return "";

            return ExR1(n - 3) + n + ExR1(n - 2) + n;
        }

        [TestMethod]
        public void E1118_1()
        {
            Debug.WriteLine(Mystery(2, 25));
            Debug.WriteLine(Mystery(3, 11));
        }

        [TestMethod]
        public void E1119_2()
        {
            Debug.WriteLine(Mystery2(2, 8));
            Debug.WriteLine(Mystery2(3, 4));
        }

        public static int Mystery(int a, int b)
        {
            if (b == 0) return 0;
            if (b % 2 == 0) return Mystery(a + a, b / 2);
            return Mystery(a + a, b / 2) + a;
        }

        public static int Mystery2(int a, int b)
        {
            if (b == 0) return 1;
            if (b % 2 == 0) return Mystery2(a * a, b / 2);
            return Mystery2(a * a, b / 2) * a;
        }

        [TestMethod]
        public void E1119()
        {
            long[] f = new long[100];

            for (int i = 0; i < 100; i++)
            {
                Debug.WriteLine(i + " " + F(f, i));
            }
        }

        public static long F(long[] f, int N)
        {
            if (N == 0) { f[0] = 0; return f[0]; }
            if (N == 1) { f[1] = 1; return f[1]; }

            f[N] = f[N - 1] + f[N - 2];

            return f[N];
        }

        public static long Fibonacci(int N)
        {
            if (N == 0) return 0;
            if (N == 1) return 1;

            return Fibonacci(N - 1) + Fibonacci(N - 2);
        }

        [TestMethod]
        public void E1120()
        {
            Debug.WriteLine(Ln(3 * 2 * 1));
        }

        public static double Ln(int n)
        {
            if (n == 1) return 0;

            return Math.Log(n, Math.E) + Ln(n - 1);
        }

        [TestMethod]
        public void E1122()
        {
            int key = 5;
            int[] a = new int[] { 1, 2, 3, 4, 5 };
            //Debug.WriteLine(BinarySearch(a, key));
            Debug.WriteLine(BinarySearchRecurisive(a, key, 0, a.Length - 1, 0));
        }

        public static int BinarySearchRecurisive(int[] a, int key, int lo, int hi, int depth)
        {
            int mid = (lo + hi) / 2;

            Debug.WriteLine(PrintParameters(lo, hi, depth));

            if (key < a[mid]) return BinarySearchRecurisive(a, key, lo, mid - 1, ++depth);
            else if (key > a[mid]) return BinarySearchRecurisive(a, key, mid + 1, hi, ++depth);
            else if (key == a[mid]) return mid;

            return -1;
        }

        private static string PrintParameters(int lo, int hi, int depth)
        {
            StringBuilder sb = new StringBuilder();
            while (depth-- > 0)
            {
                sb.Append(" ");
            }

            sb.Append(string.Format("lo: {0}, hi: {1}", lo, hi));

            return sb.ToString();
        }

        public static int BinarySearch(int[] a, int key)
        {
            int lo = 0;
            int hi = a.Length - 1;
            int mid;

            //while (lo < hi) wrong! can't search last one
            while (lo <= hi)
            {
                mid = (lo + hi) / 2;

                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) lo = mid + 1;
                else if (key == a[mid]) return mid;
            }

            return -1;
        }

        [TestMethod]
        public void E1124()
        {
            //Debug.WriteLine(GCD(24,105));
            Debug.WriteLine(GCD(1111111, 1234567));
        }

        public static int GCD(int p, int q)
        {
            Debug.WriteLine(string.Format("{0}, {1}", p, q));
            if (q == 0) return p;
            int r = p % q;
            return GCD(q, r);
        }


    }
}