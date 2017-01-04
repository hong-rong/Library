using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BasicProgrammingModel
{
    [TestClass]
    public class Exercise_v1
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
        }

        [Ignore]
        public void E113()
        {
            int i = 0;
            int value;
            string allValue = null;
            while (i <= 3)
            {
                string input;
                do
                {
                    input = Console.ReadKey().ToString();
                }
                while (!int.TryParse(input, out value));
                allValue = allValue + " " + input;
            }

            string[] inputs = allValue.Split(' ');
            if (inputs[0] == inputs[1] && inputs[1] == inputs[2])
                Debug.WriteLine("equal");
            else
                Debug.WriteLine("not equal");
        }

        [TestMethod]
        public void E115()
        {
            double a = 0.15 + 0.15;
            double b = 0.1 + 0.2;
            if (a == b)
            {
                Debug.WriteLine("equal");
            }
            if (a >= b)
            {
                Debug.WriteLine("great than or equal");
            }
        }

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

            //0 0 f=1, g=0 
            //1 1 f=1, g=1
            //2 1 f=2, g=1
            //3 2 f=3, g=2
            //4 3 f=5, g=3
            //5 5 f=8, g=5
            //6 8 f=13, g=8
        }

        [TestMethod]
        public void E117()
        {
            double t = 9.0;
            while (Math.Abs(t - 9.0 / t) > .001)
            {
                t = (9.0 / t + t) / 2.0;
                Debug.WriteLine(t);
            }
            Debug.WriteLine(t);

            //5.0
            //3.4
            //3.02352941176471
            //3.00009155413138

            int sum = 0;
            for (int i = 1; i < 1000; i++)
                for (int j = 0; j < i; j++)
                    sum++;
            Debug.WriteLine(sum);
            //1 0
            //2 0+1
            //3 0+1+2
            //...
            //1000 0+1+2...999

            int sum2 = 0;
            for (int i = 1; i < 1000; i *= 2)
                for (int j = 0; j < i; j++)
                    sum2++;
            Debug.WriteLine(sum2);
            //1 0
            //2 0+1
            //4 0+1+2+3
            //8 0+1+..+8
            //16
            //...
            //2^9 0+1+...2^9-1
        }

        [TestMethod]
        public void E118()
        {
            Debug.WriteLine('b');
            Debug.WriteLine('b' + 'c');
            Debug.WriteLine((char)('a' + 4));
        }

        [TestMethod]
        public void E119()
        {
            int N = 6;
            string B = "";

            for (int n = N; n > 0; n = n / 2)
            {
                B = (n % 2) + B;
            }

            Debug.WriteLine(B);
        }

        [TestMethod]
        public void E1111()
        {
            bool[][] values = new bool[3][];
            values[0] = new bool[] { true, false, true, true, true };
            values[1] = new bool[] { false, true, true, true, false };
            values[2] = new bool[] { true, false, true, false, true };

            for (int i = 0; i < values[0].Length; i++)
            {
                if (i == 0)
                    Debug.Write("   ");

                Debug.Write(string.Format("{0}  ", i + 1));

                if (i == values[0].Length - 1)
                    Debug.WriteLine("");
            }

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values[i].Length; j++)
                {
                    if (j == 0)
                    {
                        Debug.Write(string.Format("{0}  ", i + 1));
                    }

                    Debug.Write(string.Format("{0}  ", values[i][j] == true ? "*" : "_"));
                }
                Debug.WriteLine("");
            }
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
            int[][] values = new int[3][];
            values[0] = new int[] { 1, 2, 3, 4, 5 };
            values[1] = new int[] { 2, 3, 4, 5, 6 };
            values[2] = new int[] { 3, 4, 5, 6, 7 };

            int[][] trans = new int[values[0].Length][];

            for (int i = 0; i < values[0].Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    if (trans[i] == null)
                    {
                        trans[i] = new int[values.Length];
                    }

                    trans[i][j] = values[j][i];
                }
            }

            for (int i = 0; i < trans.Length; i++)
            {
                for (int j = 0; j < trans[i].Length; j++)
                {
                    Debug.Write(trans[i][j]);
                }
                Debug.WriteLine("");
            }
        }

        [TestMethod]
        public void E1114()
        {
            int N = 2;
            int S = 1;

            for (int i = 0; i < N; i++)
            {
                S = S * 2;
                if (S > N)
                {
                    Debug.WriteLine(i);
                    break;
                }
            }
        }

        [TestMethod]
        public void E1115()
        {
            int[] a = new[] { 1, 3, 3, 7, 9 };
            int M = 9;

            int length = M >= a.Length ? a.Length : M;
            int[] stats = new int[length];

            for (int k = 0; k < a.Length; k++)
            {
                if (a[k] < length)
                {
                    stats[a[k]] = stats[a[k]] + 1;
                }
            }

            for (int i = 0; i < stats.Length; i++)
            {
                Debug.WriteLine(stats[i]);
            }
        }

        [TestMethod]
        public void E11116()
        {
            //31136114211246
            Debug.WriteLine(RxR1(6));
        }

        public static string RxR1(int n)
        {
            if (n <= 0) return "";

            return RxR1(n - 3) + n + RxR1(n - 2) + n;
        }

        [TestMethod]
        public void E1118()
        {
            Debug.WriteLine(Mystery(2, 25));
            Debug.WriteLine(Mystery(3, 11));
            Debug.WriteLine(Mystery(2, 10));
        }

        public static int Mystery(int a, int b)
        {
            //if (b == 0) return 0;
            //if (b % 2 == 0) return Mystery(a + a, b / 2);
            //return Mystery(a + a, b / 2) + a;

            if (b == 0) return 1;
            if (b % 2 == 0) return Mystery(a * a, b / 2);
            return Mystery(a * a, b / 2) * a;
        }

        [TestMethod]
        public void E1119()
        {
            int count = 100;
            long[] values = new long[count];

            for (int i = 0; i < count; i++)
            {
                values[i] = F2(i, values);
                Debug.WriteLine(string.Format("{0} {1}", i, values[i]));
            }

            //for (int i = 0; i < count; i++)
            //{
            //    Debug.WriteLine(string.Format("{0} {1}", i, F1(i)));
            //}
        }

        public static long F1(int N)
        {
            if (N == 0) return 0;
            if (N == 1) return 1;
            return F1(N - 1) + F1(N - 2);
        }

        public static long F2(int N, long[] calcuatedVaues)
        {
            if (N == 0) return 0;
            if (N == 1) return 1;

            if (calcuatedVaues[N] != 0)
                return calcuatedVaues[N];

            calcuatedVaues[N] = F2(N - 1, calcuatedVaues) + F2(N - 2, calcuatedVaues);

            return calcuatedVaues[N];
        }

        [TestMethod]
        public void E1120()
        {
            Debug.WriteLine(Ln(0));
            Debug.WriteLine(Ln(1));
            Debug.WriteLine(Ln(2));
            Debug.WriteLine(Ln(5));
        }

        public static long Ln(int N)
        {
            if (N == 0) return 1;
            if (N == 1) return 1;

            return N * (N - 1);
        }

        [TestMethod]
        public void E1122()
        {
            int[] a = new[] { 10, 11, 12, 16, 18, 23, 29, 33, 48, 54, 57, 68, 77, 84, 98 };

            var position = Rank(2, a, 0, a.Length - 1, 0);

            Debug.IndentLevel = 0;
            Debug.WriteLine(position);
        }

        public static int Rank(int key, int[] a, int lo, int hi, int depth)
        {
            Debug.IndentLevel = depth;
            Debug.WriteLine(string.Format("low: {0}, high: {1}", lo, hi));

            if (lo > hi)
                return -1;

            int mid = lo + (hi - lo) / 2;

            if (key < a[mid]) return Rank(key, a, lo, mid - 1, depth + 1);
            else if (key > a[mid]) return Rank(key, a, mid + 1, hi, depth + 1);
            else return mid;
        }

        [TestMethod]
        public void E1123()
        {
            //var gcd = Gcd(104, 24);
            var gcd = Gcd(1111111, 1234567);
            Debug.WriteLine(gcd);
        }

        public static int Gcd(int p, int q)
        {
            Debug.WriteLine(string.Format("p: {0}, q: {1}", p, q));

            if (q == 0) return p;
            int r = p % q;
            return Gcd(q, r);
        }

        [TestMethod]
        public void E1127()
        {
            //Binomial(100, 50, 2.0);
            Binomial(6, 4, 1.0);
        }

        public static double Binomial(int N, int k, double p)
        {
            Debug.WriteLine(string.Format("N: {0}, k: {1}, p: {2}", N, k, p));

            if ((N == 0) || (k < 0)) return 1.0;
            return (1.0 - p) * Binomial(N - 1, k, p) + p * Binomial(N - 1, k - 1, p);
        }

        [TestMethod]
        public void E1128()
        {
            var whitelists = GetInts();
            Sort(whitelists);

            RemoveDuplication(whitelists);
        }

        private static void Sort(int[] whitelists)
        {
            Array.Sort(whitelists);

            Debug.WriteLine(string.Format("After sort:"));
            for (int i = 0; i < whitelists.Length; i++)
            {
                Debug.WriteLine(whitelists[i]);
            }
        }

        public static int[] RemoveDuplication(int[] values)
        {
            if (values == null || values.Length <= 1) return values;

            int duplicates = 0;
            for (int i = 0; i < values.Length - 1; i++)
            {
                for (int j = i + 1; j < values.Length - duplicates; j++)
                {
                    while (values[i] == values[j])
                    {
                        if (j != values.Length - duplicates - 1)
                        {
                            Debug.WriteLine(string.Format("Remove in postion: {0}, value: {1}", j, values[j]));
                            for (int k = j; k < values.Length - duplicates - 1; k++)
                            {
                                values[k] = values[k + 1];
                            }
                            duplicates = duplicates + 1;
                        }
                    }

                    continue;
                }
            }

            return values;
        }

        public static int Rank2(int key, int[] values, int low, int high)
        {
            if (low > high) return -1;

            int mid = low + (high - low) / 2;

            if (key < values[mid]) return Rank2(key, values, low, mid - 1);
            else if (key > values[mid]) return Rank2(key, values, mid + 1, high);
            else return mid;
        }

        public static int[] GetInts()
        {
            var values = File.ReadAllLines(@"C:\Users\itmin_000\Dropbox\Code\TestProject\External\Algorithm\Fundamentals\tTiny.txt");

            int[] lists = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                lists[i] = int.Parse(values[i]);
                Debug.WriteLine(lists[i]);
            }

            return lists;
        }

        [TestMethod]
        public void E1129()
        {
            var whiteList = GetInts();
            Sort(whiteList);

            var lessThanCount = Rank(97, whiteList);
            Debug.WriteLine(lessThanCount);
            lessThanCount = Rank(0, whiteList);
            Debug.WriteLine(lessThanCount);
            lessThanCount = Rank(100, whiteList);
            Debug.WriteLine(lessThanCount);

            var equalCount = Count(10, whiteList);
            Debug.WriteLine(equalCount);
            equalCount = Count(77, whiteList);
            Debug.WriteLine(equalCount);
            equalCount = Count(17, whiteList);
            Debug.WriteLine(equalCount);
        }

        /// <summary>
        /// assume sorted by assending order
        /// </summary>
        public static int Count(int key, int[] a)
        {
            if (a == null) throw new ArgumentNullException();
            if (a.Length == 0) return 0;

            int equalCount = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (key == a[i])
                {
                    equalCount = equalCount + 1;
                }
            }

            return equalCount;
        }

        /// <summary>
        /// assume sorted by assending order
        /// </summary>
        public static int Rank(int key, int[] a)
        {
            if (a == null) throw new ArgumentNullException();
            if (a.Length == 0) return 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (key <= a[i]) return i;
            }

            return a.Length;
        }

        [TestMethod]
        public void E1130()
        {
            int N = 10;
            bool[][] a = new bool[N][];
            for (int i = 0; i < N; i++)
            {
                a[i] = new bool[N];
                for (int j = 0; j < N; j++)
                {
                    a[i][j] = IsRelativelyPrime(i + 1, j + 1);
                    if (!a[i][j]) Debug.WriteLine(string.Format("{0} and {1} are not relatively prime.", i + 1, j + 1));
                }
            }
        }

        [TestMethod]
        public void TestPrime()
        {
            Assert.AreEqual(1, GetGcd(1111111, 1234567));
            Assert.AreEqual(8, GetGcd(104, 24));
        }

        public static bool IsRelativelyPrime(int i, int j)
        {
            if (GetGcd(i, j) == 1)
                return true;
            else
                return false;
        }

        public static int GetGcd(int i, int j)
        {
            if (j == 0) return i;
            int r = i % j;

            return GetGcd(j, r);
        }
    }
}