using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.DataAbstraction
{
    [TestClass]
    public class Exercies
    {
        [TestMethod]
        public void E124()
        {
            string string1 = "hello";
            string string2 = string1;
            string1 = "world";
            Debug.WriteLine(string1);
            Debug.WriteLine(string2);
        }

        [TestMethod]
        public void E125()
        {
            string s = "Hello World";
            s.ToUpper();
            s.Substring(6);
            Debug.WriteLine(s);
        }

        [TestMethod]
        public void E126()
        {
            Assert.IsTrue(IsCircular("ACTGACG", "TGACGAC"));
            Assert.IsTrue(IsCircular("ACTGACG", "CTGACGA"));
            Assert.IsTrue(IsCircular("A", "A"));
            Assert.IsTrue(IsCircular("AAA", "AAA"));
            Assert.IsTrue(IsCircular("ACTGACG", "ACTGACG"));

            Assert.IsFalse(IsCircular(null, string.Empty));
            Assert.IsFalse(IsCircular("AAAA", "AAAB"));
            Assert.IsFalse(IsCircular("ACTGACG", "TGACGAD"));
        }

        public static bool IsCircular(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2))
                return false;

            return (s1.Length == s2.Length) && ((s1 + s1).IndexOf(s2) != -1);
        }

        //public static bool IsCircular(string s1, string s2)
        //{
        //    if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2))
        //        return false;

        //    if (s1.Length != s2.Length)
        //        return false;

        //    if (s1.Length == 1 && s1[0] == s2[0])
        //        return true;

        //    int index = (s2.IndexOf(s1[0]));
        //    while (index != -1)
        //    {
        //        int i;
        //        for (i = 1; i < s2.Length; i++)
        //        {
        //            if (s1[i] != s2[(index + i) % s2.Length])
        //                break;
        //        }

        //        if (i == s2.Length)
        //            return true;

        //        index = s2.IndexOf(s1[0], index + 1);
        //    }

        //    return false;
        //}

        [TestMethod]
        public void E127()
        {
            Debug.WriteLine(Mystery("abcdefg"));
        }

        public static string Mystery(string s)
        {
            int N = s.Length;
            if (N <= 1) return s;

            string a = s.Substring(0, N / 2);
            string b = s.Substring(N / 2, N - N / 2);

            return Mystery(b) + Mystery(a);
        }

        [TestMethod]
        public void E129()
        {
            var a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var counter = new Counter("Rank Counter");

            Debug.WriteLine(Rank(a, 1, 0, a.Length, counter));
            Debug.WriteLine(counter.ToString());
        }

        public static int Rank(int[] a, int key, int low, int high, Counter counter)
        {
            counter.Increment();

            if (low > high) return -1;
            int mid = low + (high - low) / 2;

            if (key < a[mid]) return Rank(a, key, low, mid - 1, counter);
            else if (key > a[mid]) return Rank(a, key, mid + 1, high, counter);
            else return mid;
        }

        [TestMethod]
        public void E1210()
        { }

        [TestMethod]
        public void E1211()
        { }

        [TestMethod]
        public void E1212()
        {
            SmartDate date = new SmartDate(1879, 3, 9);

            Assert.AreEqual(Week.Sunday.ToString(), date.DayOfWeek());
        }

        [TestMethod]
        public void E1216()
        {
            Rational r = new Rational(3, 7);
            Rational r2 = new Rational(3, 4);

            Assert.AreEqual(new Rational(13, 14), r.Plus(new Rational(1, 2)));
            Assert.AreEqual(new Rational(1, 1), r2.Plus(new Rational(1, 4)));

            Assert.AreEqual(new Rational(1, 7), r.Minus(new Rational(2, 7)));
            Assert.AreEqual(new Rational(1, 2), r2.Minus(new Rational(1, 4)));

            Assert.AreEqual(new Rational(3, 14), r.Times(new Rational(1, 2)));
            Assert.AreEqual(new Rational(1, 2), r2.Times(new Rational(2, 3)));

            Assert.AreEqual(new Rational(3, 2), r.Divides(new Rational(2, 7)));
            Assert.AreEqual(new Rational(1, 1), r2.Divides(new Rational(3, 4)));
        }
    }
}
