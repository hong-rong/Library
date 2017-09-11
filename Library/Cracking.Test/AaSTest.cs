using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cracking.Test
{
    [TestClass]
    public class AaSTest
    {
        #region init
        private readonly ArraysAndStrings _target;

        public AaSTest()
        {
            _target = new ArraysAndStrings();
        }
        #endregion

        #region tests
        [TestMethod]
        public void HasUniqueChar_1_Test()
        {
            var actual = _target.HasUnique_1("");
            Assert.IsTrue(actual);

            actual = _target.HasUnique_1("a");
            Assert.IsTrue(actual);

            actual = _target.HasUnique_1("ABC");
            Assert.IsTrue(actual);

            actual = _target.HasUnique_1("AA");
            Assert.IsFalse(actual);

            actual = _target.HasUnique_1("zaz");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void HasUniqueChar_2_Test()
        {
            var actual = _target.HasUnique_2("");
            Assert.IsTrue(actual);

            actual = _target.HasUnique_2("a");
            Assert.IsTrue(actual);

            actual = _target.HasUnique_2("ABC");
            Assert.IsTrue(actual);

            actual = _target.HasUnique_2("AA");
            Assert.IsFalse(actual);

            actual = _target.HasUnique_2("zaz");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsPerm_1_Test()
        {
            var actual = _target.IsPerm_1("", "");
            Assert.IsTrue(actual);

            actual = _target.IsPerm_1("a", "a");
            Assert.IsTrue(actual);

            actual = _target.IsPerm_1("bcA", "Abc");
            Assert.IsTrue(actual);

            actual = _target.IsPerm_1("a", "b");
            Assert.IsFalse(actual);

            actual = _target.IsPerm_1("Cad", "aCa");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsPerm_2_Test()
        {
            var actual = _target.IsPerm_2("", "");
            Assert.IsTrue(actual);

            actual = _target.IsPerm_2("a", "a");
            Assert.IsTrue(actual);

            actual = _target.IsPerm_2("bcA", "Abc");
            Assert.IsTrue(actual);

            actual = _target.IsPerm_2("abcdefghijklmnopqrstuvwxyz", "zyxwvutsrqponmlkjihgfedcba");
            Assert.IsTrue(actual);

            actual = _target.IsPerm_2("abcdefghijklmnopqrstuvwxyz", "ayxwvutsrqponmlkjihgfedcba");
            Assert.IsFalse(actual);

            actual = _target.IsPerm_2("a", "b");
            Assert.IsFalse(actual);

            actual = _target.IsPerm_2("Cad", "aCa");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void UnifyUrl_Test()
        {
            var actual = _target.UnifyUrl("M", 1);
            Assert.AreEqual(actual, "M");

            actual = _target.UnifyUrl(" M  ", 2);
            Assert.AreEqual(actual, "%20M");

            actual = _target.UnifyUrl("MrJohnSmith", 11);
            Assert.AreEqual(actual, "MrJohnSmith");

            actual = _target.UnifyUrl("Mr John Smith    ", 13);
            Assert.AreEqual(actual, "Mr%20John%20Smith");
        }

        [TestMethod]
        public void IsPalinPerm_1_Test()
        {
            var actual = _target.IsPalinPerm_1(null);
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_1("");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_1("tact coa");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_1("a");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_1("baa");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_1(" abcd abcd");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_1("abcdefghijklmnopqrstuvwxyz_zyxwvutsrqponmlkjihgfedcba");
            Assert.IsTrue(actual);


            actual = _target.IsPalinPerm_1("abc");
            Assert.IsFalse(actual);

            actual = _target.IsPalinPerm_1("aabc");
            Assert.IsFalse(actual);

            actual = _target.IsPalinPerm_1("ab ");
            Assert.IsFalse(actual);

            actual = _target.IsPalinPerm_1("abcdefghijklmnopqrstuvwxyz_zyxwvutsrqponmlkjihgfedcbz");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsPalinPerm_2_Test()
        {
            var actual = _target.IsPalinPerm_1(null);
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_2("");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_2("tact coa");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_2("a");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_2("baa");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_2(" abcd abcd");
            Assert.IsTrue(actual);

            actual = _target.IsPalinPerm_2("abcdefghijklmnopqrstuvwxyz_zyxwvutsrqponmlkjihgfedcba");
            Assert.IsTrue(actual);


            actual = _target.IsPalinPerm_2("abc");
            Assert.IsFalse(actual);

            actual = _target.IsPalinPerm_2("aabc");
            Assert.IsFalse(actual);

            actual = _target.IsPalinPerm_2("ab ");
            Assert.IsFalse(actual);

            actual = _target.IsPalinPerm_2("abcdefghijklmnopqrstuvwxyz_zyxwvutsrqponmlkjihgfedcbz");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsOneEditAwayTest()
        {
            Assert.IsTrue(_target.IsOneEditAway("", ""));
            Assert.IsTrue(_target.IsOneEditAway("a", ""));
            Assert.IsTrue(_target.IsOneEditAway("", "a"));
            Assert.IsTrue(_target.IsOneEditAway("a", "b"));
            Assert.IsTrue(_target.IsOneEditAway("pale", "ple"));
            Assert.IsTrue(_target.IsOneEditAway("pales", "pale"));
            Assert.IsTrue(_target.IsOneEditAway("pale", "bale"));

            Assert.IsFalse(_target.IsOneEditAway("", "aa"));
            Assert.IsFalse(_target.IsOneEditAway("aa", "bb"));
            Assert.IsFalse(_target.IsOneEditAway("pale", "bake"));
            Assert.IsFalse(_target.IsOneEditAway("aaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaabb"));
        }

        [TestMethod]
        public void CompressionTest()
        {
            Assert.AreEqual("", _target.Compression(""));
            Assert.AreEqual("aa", _target.Compression("aa"));
            Assert.AreEqual("aabb", _target.Compression("aabb"));
            Assert.AreEqual("a3", _target.Compression("aaa"));
            Assert.AreEqual("a2b1c5a3", _target.Compression("aabcccccaaa"));
            Assert.AreEqual("A2z3", _target.Compression("AAzzz"));
        }

        [TestMethod]
        public void RotateMtest()
        {
            //abcd       miea
            //efgh       njfb
            //ijkl  ---> okgc
            //mnop       plhd
            var m = new int[4][];
            m[0] = new int[] { 'a', 'b', 'c', 'd' };
            m[1] = new int[] { 'e', 'f', 'g', 'h' };
            m[2] = new int[] { 'i', 'j', 'k', 'l' };
            m[3] = new int[] { 'm', 'n', 'o', 'p' };

            var e = _target.RotateM(m);
            Assert.AreEqual('m', e[0][0]);
            Assert.AreEqual('i', e[0][1]);
            Assert.AreEqual('e', e[0][2]);
            Assert.AreEqual('a', e[0][3]);

            Assert.AreEqual('n', e[1][0]);
            Assert.AreEqual('j', e[1][1]);
            Assert.AreEqual('f', e[1][2]);
            Assert.AreEqual('b', e[1][3]);

            Assert.AreEqual('o', e[2][0]);
            Assert.AreEqual('k', e[2][1]);
            Assert.AreEqual('g', e[2][2]);
            Assert.AreEqual('c', e[2][3]);

            Assert.AreEqual('p', e[3][0]);
            Assert.AreEqual('l', e[3][1]);
            Assert.AreEqual('h', e[3][2]);
            Assert.AreEqual('d', e[3][3]);
        }

        [TestMethod]
        public void ZeroMTest()
        {
            var m = new int[1][];
            m[0] = new int[] { 0 };
            _target.ZeroM(m, 1, 1);
            Assert.AreEqual(0, m[0][0]);

            m = new int[1][];
            m[0] = new int[] { 1 };
            _target.ZeroM(m, 1, 1);
            Assert.AreEqual(1, m[0][0]);

            m = new int[2][];
            m[0] = new int[] { 0, 1 };
            m[1] = new int[] { 1, 1 };
            _target.ZeroM(m, 2, 2);
            Assert.AreEqual(0, m[0][0]);
            Assert.AreEqual(0, m[0][1]);
            Assert.AreEqual(0, m[1][0]);
            Assert.AreEqual(1, m[1][1]);

            m = new int[1][];
            m[0] = new int[] { 1, 0, 3, 1 };
            _target.ZeroM(m, 1, 4);
            Assert.AreEqual(0, m[0][0]);
            Assert.AreEqual(0, m[0][1]);
            Assert.AreEqual(0, m[0][2]);
            Assert.AreEqual(0, m[0][3]);

            m = new int[1][];
            m[0] = new int[] { 1, 2, 3 };
            _target.ZeroM(m, 1, 3);
            Assert.AreEqual(1, m[0][0]);
            Assert.AreEqual(2, m[0][1]);
            Assert.AreEqual(3, m[0][2]);

            m = new int[3][];
            m[0] = new int[] { 1, 0, 3, 1 };
            m[1] = new int[] { 4, 5, 6, 1 };
            m[2] = new int[] { 0, 0, 9, 1 };
            _target.ZeroM(m, 3, 4);
            Assert.AreEqual(0, m[0][0]);
            Assert.AreEqual(0, m[0][1]);
            Assert.AreEqual(0, m[0][2]);
            Assert.AreEqual(0, m[0][3]);
            Assert.AreEqual(0, m[1][0]);
            Assert.AreEqual(0, m[1][1]);
            Assert.AreEqual(6, m[1][2]);
            Assert.AreEqual(1, m[1][3]);
            Assert.AreEqual(0, m[2][0]);
            Assert.AreEqual(0, m[2][1]);
            Assert.AreEqual(0, m[2][2]);
            Assert.AreEqual(0, m[2][3]);
        }

        [TestMethod]
        public void ZeroMOnLiveTest()
        {
            var m = new int[1][];
            m[0] = new int[] { 0 };
            _target.ZeroMOnTheFly(m, 1, 1);
            Assert.AreEqual(0, m[0][0]);

            m = new int[1][];
            m[0] = new int[] { 1 };
            _target.ZeroMOnTheFly(m, 1, 1);
            Assert.AreEqual(1, m[0][0]);

            m = new int[2][];
            m[0] = new int[] { 0, 1 };
            m[1] = new int[] { 1, 1 };
            _target.ZeroMOnTheFly(m, 2, 2);
            Assert.AreEqual(0, m[0][0]);
            Assert.AreEqual(0, m[0][1]);
            Assert.AreEqual(0, m[1][0]);
            Assert.AreEqual(1, m[1][1]);

            m = new int[1][];
            m[0] = new int[] { 1, 0, 3, 1 };
            _target.ZeroMOnTheFly(m, 1, 4);
            Assert.AreEqual(0, m[0][0]);
            Assert.AreEqual(0, m[0][1]);
            Assert.AreEqual(0, m[0][2]);
            Assert.AreEqual(0, m[0][3]);

            m = new int[1][];
            m[0] = new int[] { 1, 2, 3 };
            _target.ZeroMOnTheFly(m, 1, 3);
            Assert.AreEqual(1, m[0][0]);
            Assert.AreEqual(2, m[0][1]);
            Assert.AreEqual(3, m[0][2]);

            m = new int[3][];
            m[0] = new int[] { 1, 0, 3, 1 };
            m[1] = new int[] { 4, 5, 6, 1 };
            m[2] = new int[] { 0, 0, 9, 1 };
            _target.ZeroMOnTheFly(m, 3, 4);
            Assert.AreEqual(0, m[0][0]);
            Assert.AreEqual(0, m[0][1]);
            Assert.AreEqual(0, m[0][2]);
            Assert.AreEqual(0, m[0][3]);
            Assert.AreEqual(0, m[1][0]);
            Assert.AreEqual(0, m[1][1]);
            Assert.AreEqual(6, m[1][2]);
            Assert.AreEqual(1, m[1][3]);
            Assert.AreEqual(0, m[2][0]);
            Assert.AreEqual(0, m[2][1]);
            Assert.AreEqual(0, m[2][2]);
            Assert.AreEqual(0, m[2][3]);
        }

        [TestMethod]
        public void IsRotationTest()
        {
            Assert.IsTrue(_target.IsRotation("a", "a"));
            Assert.IsTrue(_target.IsRotation("aa", "aa"));
            Assert.IsTrue(_target.IsRotation("waterbottle", "erbottlewat"));
            Assert.IsTrue(_target.IsRotation("waterbottle", "waterbottle"));

            Assert.IsFalse(_target.IsRotation("a", "b"));
            Assert.IsFalse(_target.IsRotation("ab", "abc"));
            Assert.IsFalse(_target.IsRotation("waterbottle", "erbottlewae"));
        }
        #endregion
    }
}
