using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp.String
{
    [TestClass]
    public class TestClass2
    {
        //[TestMethod]
        //public void Test()
        //{
        //    var isMatch = Regex.IsMatch("aaaa", "");
        //    Assert.IsTrue(isMatch);
        //}

        [TestMethod]
        public void POfTenTest()
        {
            Assert.IsTrue(POfTen(10));
            Assert.IsTrue(POfTen(100));
            Assert.IsTrue(POfTen(1000));
            Assert.IsTrue(POfTen(1000000000));

            Assert.IsFalse(POfTen(1));
            Assert.IsFalse(POfTen(101));
            Assert.IsFalse(POfTen(2000));
            Assert.IsFalse(POfTen(1000000001));
            Assert.IsFalse(POfTen(111000));
        }

        private bool POfTen(int n)
        {
            while (n > 10)
            {
                if (n % 10 == 0)
                {
                    n = n / 10;
                }
                else
                {
                    return false;
                }
            }
            if (n == 10) return true;
            return false;
        }

        [TestMethod]
        public void POfTenRecTest()
        {
            Assert.IsTrue(PofTenRec(10));
            Assert.IsTrue(PofTenRec(100));
            Assert.IsTrue(PofTenRec(1000));
            Assert.IsTrue(PofTenRec(1000000000));

            Assert.IsFalse(PofTenRec(1));
            Assert.IsFalse(PofTenRec(101));
            Assert.IsFalse(PofTenRec(2000));
            Assert.IsFalse(PofTenRec(1000000001));
            Assert.IsFalse(PofTenRec(111000));
        }

        private bool PofTenRec(int n)
        {
            if (n % 10 != 0) return false;
            if (n == 10) return true;
            n = n / 10;
            return PofTenRec(n);
        }
    }

    [TestClass]
    public class TestClass3
    {
        [TestMethod]
        public void SumIntsTest()
        {
            //var sumPairs = GetInts();
        }

        private List<Tuple<int, int>> GetInts(int[] arr, int s)
        {
            List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
            HashSet<int> dic = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dic.Contains(s - arr[i]))
                {
                    pairs.Add(new Tuple<int, int>(s - arr[i], arr[i]));
                }
                else
                {
                    dic.Add(arr[i]);
                }
            }
            return pairs;
        }
    }
}
