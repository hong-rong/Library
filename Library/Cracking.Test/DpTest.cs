using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cracking;

namespace OneHydra.SeoAutomation.Data.UnitTests.Repositories
{

    [TestClass]
    public class DpTest
    {
        private Dp _target;

        [TestInitialize]
        public void Init()
        {
            _target = new Dp();
        }

        [TestMethod]
        public void PaintFillTest()
        {
            var screen = new Color[,] 
            {
                {Color.Black}
            };
            _target.PaintFill(screen, 0, 0, Color.White);
            Assert.AreEqual(Color.White, screen[0, 0]);

            screen = new Color[,] 
            {
                {Color.Black, Color.White, Color.Red, Color.Yellow},
                {Color.White, Color.Red, Color.Yellow, Color.Green},
                {Color.Red, Color.Yellow, Color.Green, Color.Black},
                {Color.Yellow, Color.Green, Color.Black, Color.Red},
            };
            _target.PaintFill(screen, 1, 1, Color.Black);
            Assert.AreEqual(Color.Black, screen[0, 0]);
            Assert.AreEqual(Color.White, screen[0, 1]);
            Assert.AreEqual(Color.Black, screen[0, 2]);
            Assert.AreEqual(Color.Yellow, screen[0, 3]);

            Assert.AreEqual(Color.White, screen[1, 0]);
            Assert.AreEqual(Color.Black, screen[1, 1]);
            Assert.AreEqual(Color.Yellow, screen[1, 2]);
            Assert.AreEqual(Color.Green, screen[1, 3]);

            Assert.AreEqual(Color.Black, screen[2, 0]);
            Assert.AreEqual(Color.Yellow, screen[2, 1]);
            Assert.AreEqual(Color.Green, screen[2, 2]);
            Assert.AreEqual(Color.Black, screen[2, 3]);

            Assert.AreEqual(Color.Yellow, screen[3, 0]);
            Assert.AreEqual(Color.Green, screen[3, 1]);
            Assert.AreEqual(Color.Black, screen[3, 2]);
            Assert.AreEqual(Color.Black, screen[3, 3]);
        }

        #region dp

        #region TrSetp

        [TestMethod]
        public void TrStepTest()
        {
            Assert.AreEqual(1, _target.TrStep(1));
            Assert.AreEqual(2, _target.TrStep(2));
            Assert.AreEqual(4, _target.TrStep(3));
            Assert.AreEqual(7, _target.TrStep(4));
            Assert.AreEqual(13, _target.TrStep(5));
            Assert.AreEqual(1705, _target.TrStep(13));
            Assert.AreEqual(8646064, _target.TrStep(27));
        }

        [TestMethod]
        public void TrStepBruteTest()
        {
            Assert.AreEqual(1, _target.TrStepBrute(1));
            Assert.AreEqual(2, _target.TrStepBrute(2));
            Assert.AreEqual(4, _target.TrStepBrute(3));
            Assert.AreEqual(7, _target.TrStepBrute(4));
            Assert.AreEqual(13, _target.TrStepBrute(5));
            Assert.AreEqual(1705, _target.TrStepBrute(13));
            Assert.AreEqual(8646064, _target.TrStepBrute(27));
        }

        [TestMethod]
        public void TrStepMemoTest()
        {
            Assert.AreEqual(1, _target.TrStepMemo(1));
            Assert.AreEqual(2, _target.TrStepMemo(2));
            Assert.AreEqual(4, _target.TrStepMemo(3));
            Assert.AreEqual(7, _target.TrStepMemo(4));
            Assert.AreEqual(13, _target.TrStepMemo(5));
            Assert.AreEqual(1705, _target.TrStepMemo(13));
            Assert.AreEqual(8646064, _target.TrStepMemo(27));
        }

        #endregion

        #region robot path

        [TestMethod]
        public void FindPathTest()
        {
            var grid = new[]
            {
                new[] {1}
            };
            var track = _target.FindPath(grid);
            Assert.AreEqual(1, track.Count);

            grid = new[]
            {
                new[] {0}
            };
            track = _target.FindPath(grid);
            Assert.AreEqual(0, track.Count);

            grid = new[]
            {
                new[] {1, 1, 1},
                new[] {1, 1, 1},
                new[] {1, 1, 1},
                new[] {1, 1, 1},
            };
            track = _target.FindPath(grid);
            Assert.AreEqual(6, track.Count);

            grid = new[]
            {
                new[] {1, 1, 1},
                new[] {0, 1, 1},
                new[] {1, 0, 1},
                new[] {1, 1, 1},
            };
            track = _target.FindPath(grid);
            Assert.AreEqual(6, track.Count);

            grid = new[]
            {
                new[] {1, 1, 0},
                new[] {0, 1, 0},
                new[] {1, 1, 1},
                new[] {1, 0, 1},
            };
            track = _target.FindPath(grid);
            Assert.AreEqual(6, track.Count);

            grid = new[]
            {
                new[] {1, 1, 1},
                new[] {0, 1, 1},
                new[] {1, 0, 1},
                new[] {1, 1, 0},
            };
            track = _target.FindPath(grid);
            Assert.AreEqual(0, track.Count);
        }

        //TODO: fix infinite loop
        //[TestMethod]
        public void FindPathOptimisedCompareTest()
        {
            #region init

            int r = 36;
            int c = 36;
            var grid = new int[r][];
            for (int i = 0; i < r; i++)
            {
                grid[i] = new int[c];
                for (int j = 0; j < c; j++)
                {
                    if (j == c / 2 && i != 0)
                    {
                        grid[i][j] = 0;
                    }
                    else if (i > j)
                    {
                        grid[i][j] = 0;
                    }
                    else
                    {
                        grid[i][j] = 1;
                    }
                }
            }

            #endregion

            var watch = new Stopwatch();
            watch.Start();
            var track = _target.FindPath(grid);
            watch.Stop();
            while (track.Count > 0)
            {
                Debug.WriteLine(track.Pop());
            }
            var slow = watch.Elapsed;
            Debug.WriteLine(slow);
            watch.Restart();
            track = _target.FindPathOptimsed(grid);
            watch.Stop();
            while (track.Count > 0)
            {
                Debug.WriteLine(track.Pop());
            }
            var fast = watch.Elapsed;
            Debug.WriteLine(fast);
            Assert.IsTrue(slow > fast);
        }

        #endregion

        #region find magic index
        [TestMethod]
        public void FindMagicIndexTest()
        {
            var r = _target.FindMagicIndex(new[] { 0 });
            Assert.AreEqual(0, r);

            r = _target.FindMagicIndex(new[] { -1, 1 });
            Assert.AreEqual(1, r);

            r = _target.FindMagicIndex(new[] { 0, 2, 3 });
            Assert.AreEqual(0, r);

            r = _target.FindMagicIndex(new[] { -1, 0, 1 });
            Assert.AreEqual(-1, r);

            r = _target.FindMagicIndex(new[] { -1, 0, 1, 2, 3, 5 });
            Assert.AreEqual(5, r);

            r = _target.FindMagicIndex(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            Assert.AreEqual(-1, r);

            r = _target.FindMagicIndex(new[] { -5, -4, -2, -1 });
            Assert.AreEqual(-1, r);

            r = _target.FindMagicIndex(new[] { 3, 4, 5, 6 });
            Assert.AreEqual(-1, r);
        }

        [TestMethod]
        public void FindMagicIndexWithDupsTest()
        {
            var r = _target.FindMagicIndexWithDups(new[] { 0 });
            Assert.AreEqual(0, r);

            r = _target.FindMagicIndexWithDups(new[] { -1, 1 });
            Assert.AreEqual(1, r);

            r = _target.FindMagicIndexWithDups(new[] { 0, 2, 3 });
            Assert.AreEqual(0, r);

            r = _target.FindMagicIndexWithDups(new[] { -1, 0, 1 });
            Assert.AreEqual(-1, r);

            r = _target.FindMagicIndexWithDups(new[] { -1, 0, 1, 2, 3, 5 });
            Assert.AreEqual(5, r);

            r = _target.FindMagicIndexWithDups(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            Assert.AreEqual(-1, r);

            r = _target.FindMagicIndexWithDups(new[] { -5, -4, -2, -1 });
            Assert.AreEqual(-1, r);

            r = _target.FindMagicIndexWithDups(new[] { 0, 0, 0, 0 });
            Assert.AreEqual(0, r);

            r = _target.FindMagicIndexWithDups(new[] { 3, 3, 3, 3 });
            Assert.AreEqual(3, r);

            r = _target.FindMagicIndexWithDups(new[] { -10, -5, 2, 2, 2, 3, 4, 7, 9, 12, 13 });
            Assert.AreEqual(2, r);
        }
        #endregion

        #region power set
        [TestMethod]
        public void GetAllSubsetsTest()
        {
            var list = new List<int> { 1, 2, 3 };
            var all = _target.GetAllSubsetTest(list);
            Assert.AreEqual(Math.Pow(2, list.Count) - 1, all.Count);
            var largest = all.Single(i => i.Count == 3);
            Assert.IsTrue(largest.Contains(1));
            Assert.IsTrue(largest.Contains(2));
            Assert.IsTrue(largest.Contains(3));
            Assert.IsTrue(all.Count(i => i.Count == 1) == 3);
            Assert.IsTrue(all.Count(i => i.Count == 2) == 3);
        }
        #endregion

        #region rec multiply
        [TestMethod]
        public void MultiplyByRecTest()
        {
            Assert.AreEqual(0, _target.MultiplyByRec(0, 1));
            Assert.AreEqual(1, _target.MultiplyByRec(1, 1));
            Assert.AreEqual(6, _target.MultiplyByRec(2, 3));
            Assert.AreEqual(49, _target.MultiplyByRec(7, 7));
            Assert.AreEqual(100, _target.MultiplyByRec(100, 1));
            Assert.AreEqual(998001, _target.MultiplyByRec(999, 999));
        }

        [TestMethod]
        public void MultiplyByRecWithMemoTest()
        {
            Assert.AreEqual(0, _target.MultiplyByRecWithMemo(0, 1));
            Assert.AreEqual(1, _target.MultiplyByRecWithMemo(1, 1));
            Assert.AreEqual(6, _target.MultiplyByRecWithMemo(2, 3));
            Assert.AreEqual(49, _target.MultiplyByRecWithMemo(7, 7));
            Assert.AreEqual(100, _target.MultiplyByRecWithMemo(100, 1));
            Assert.AreEqual(998001, _target.MultiplyByRecWithMemo(999, 999));
        }
        #endregion

        //hanoi

        #region perm
        [TestMethod]
        public void GetAllPermForUnqiueTest()
        {
            var expect = _target.GetAllPermForUnique_ByInsertion("123");
            Assert.AreEqual(6, expect.Count);
            Assert.IsTrue(expect.Contains("123"));
            Assert.IsTrue(expect.Contains("132"));
            Assert.IsTrue(expect.Contains("213"));
            Assert.IsTrue(expect.Contains("231"));
            Assert.IsTrue(expect.Contains("312"));
            Assert.IsTrue(expect.Contains("321"));

            expect = _target.GetAllPermForUnique_ByInsertion("12357");
            Assert.AreEqual(120, expect.Count);
        }

        [TestMethod]
        public void GetAllPermForUnique_ByPrefixTest()
        {
            var expect = _target.GetAllPermForUnique_ByPrefix("123");
            Assert.AreEqual(6, expect.Count);
            Assert.IsTrue(expect.Contains("123"));
            Assert.IsTrue(expect.Contains("132"));
            Assert.IsTrue(expect.Contains("213"));
            Assert.IsTrue(expect.Contains("231"));
            Assert.IsTrue(expect.Contains("312"));
            Assert.IsTrue(expect.Contains("321"));

            expect = _target.GetAllPermForUnique_ByPrefix("12357");
            Assert.AreEqual(120, expect.Count);
        }

        #endregion

        #region perm with dups
        [TestMethod]
        public void GetAllPermForDupTest()
        {
            var expect = _target.GetAllPermForDup("112");
            Assert.AreEqual(3, expect.Count);
            Assert.IsTrue(expect.Contains("112"));
            Assert.IsTrue(expect.Contains("121"));
            Assert.IsTrue(expect.Contains("211"));

            expect = _target.GetAllPermForDup("1233");
            Assert.AreEqual(12, expect.Count);
        }
        #endregion

        //parens

        //paint fill

        #region coins
        [TestMethod]
        public void CountCTest()
        {
            Assert.AreEqual(1, _target.CountC(1));
            Assert.AreEqual(1, _target.CountC(4));
            Assert.AreEqual(2, _target.CountC(5));
            Assert.AreEqual(2, _target.CountC(6));
            Assert.AreEqual(4, _target.CountC(10));
            Assert.AreEqual(4, _target.CountC(11));
            Assert.AreEqual(6, _target.CountC(15));
        }

        [TestMethod]
        public void CountCMemoTest()
        {
            Assert.AreEqual(1, _target.CountCMemo(1));
            Assert.AreEqual(1, _target.CountCMemo(4));
            Assert.AreEqual(2, _target.CountCMemo(5));
            Assert.AreEqual(2, _target.CountCMemo(6));
            Assert.AreEqual(4, _target.CountCMemo(10));
            Assert.AreEqual(4, _target.CountCMemo(11));
            Assert.AreEqual(6, _target.CountCMemo(15));
        }
        #endregion

        #endregion
    }
}