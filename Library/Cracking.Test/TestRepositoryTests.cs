using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cracking;

namespace OneHydra.SeoAutomation.Data.UnitTests.Repositories
{
  
    [TestClass]
    public class TestRepositoryTests
    {
        private TreeAndDp _target;
        
        [TestInitialize]
        public void Init()
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            _target = new TreeAndDp();
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Debug.WriteLine("unhandled error");
            Debug.WriteLine(sender);
            Debug.WriteLine(e.Exception.Message);
        }

        #region test

        #region Btr

        [TestMethod]
        public void GetBnTest()
        {
            Btr btr = CreateBtr();
            var r = btr.GetBn("10");
            Assert.IsNotNull(r);
            Assert.AreEqual("5", r.L.Name);
            Assert.AreEqual("20", r.R.Name);

            r = btr.GetBn("3");
            Assert.IsNotNull(r);
            Assert.AreEqual("9", r.L.Name);
            Assert.AreEqual("18", r.R.Name);

            r = btr.GetBn("18");
            Assert.IsNotNull(r);
            Assert.IsNull(r.L);
            Assert.IsNull(r.R);

            r = btr.GetBn("99");
            Assert.IsNull(r);
        }

        [TestMethod]
        public void PreOTest()
        {
            Btr t = CreateBtr();
            t.PreO();
            Assert.AreEqual(1, t.GetBn("10").Order);
            Assert.AreEqual(2, t.GetBn("5").Order);
            Assert.AreEqual(3, t.GetBn("20").Order);
            Assert.AreEqual(4, t.GetBn("3").Order);
            Assert.AreEqual(5, t.GetBn("9").Order);
            Assert.AreEqual(6, t.GetBn("18").Order);
            Assert.AreEqual(7, t.GetBn("7").Order);
        }

        [TestMethod]
        public void InOTest()
        {
            Btr t = CreateBtr();
            t.InO();
            Assert.AreEqual(1, t.GetBn("5").Order);
            Assert.AreEqual(2, t.GetBn("10").Order);
            Assert.AreEqual(3, t.GetBn("9").Order);
            Assert.AreEqual(4, t.GetBn("3").Order);
            Assert.AreEqual(5, t.GetBn("18").Order);
            Assert.AreEqual(6, t.GetBn("20").Order);
            Assert.AreEqual(7, t.GetBn("7").Order);
        }

        [TestMethod]
        public void PostOTest()
        {
            Btr t = CreateBtr();
            t.PostO();
            Assert.AreEqual(1, t.GetBn("5").Order);
            Assert.AreEqual(2, t.GetBn("9").Order);
            Assert.AreEqual(3, t.GetBn("18").Order);
            Assert.AreEqual(4, t.GetBn("3").Order);
            Assert.AreEqual(5, t.GetBn("7").Order);
            Assert.AreEqual(6, t.GetBn("20").Order);
            Assert.AreEqual(7, t.GetBn("10").Order);
        }

        #endregion

        #region g search

        [TestMethod]
        public void DfsTest()
        {
            G g = CreateG();
            g.Dfs();
            Assert.AreEqual(1, g.Nodes[0].Order);
            Assert.AreEqual(2, g.Nodes[1].Order);
            Assert.AreEqual(3, g.Nodes[3].Order);
            Assert.AreEqual(4, g.Nodes[2].Order);
            Assert.AreEqual(5, g.Nodes[4].Order);
            Assert.AreEqual(6, g.Nodes[5].Order);
        }

        [TestMethod]
        public void BfsTest()
        {
            G g = CreateG();
            g.Bfs();
            Assert.AreEqual(1, g.Nodes[0].Order);
            Assert.AreEqual(2, g.Nodes[1].Order);
            Assert.AreEqual(3, g.Nodes[4].Order);
            Assert.AreEqual(4, g.Nodes[5].Order);
            Assert.AreEqual(5, g.Nodes[3].Order);
            Assert.AreEqual(6, g.Nodes[2].Order);
        }

        #endregion

        [TestMethod]
        public void HasRouteTest()
        {
            G g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[0], g.Nodes[0]));
            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[0], g.Nodes[1]));
            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[0], g.Nodes[2]));
            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[0], g.Nodes[3]));
            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[0], g.Nodes[4]));
            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[0], g.Nodes[5]));

            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[1], g.Nodes[2]));
            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[1], g.Nodes[3]));
            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[1], g.Nodes[4]));
            g = CreateG();
            Assert.IsFalse(_target.HasRoute(g.Nodes[1], g.Nodes[5]));

            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[2], g.Nodes[3]));
            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[2], g.Nodes[4]));
            g = CreateG();
            Assert.IsFalse(_target.HasRoute(g.Nodes[2], g.Nodes[5]));

            g = CreateG();
            Assert.IsTrue(_target.HasRoute(g.Nodes[3], g.Nodes[4]));
            g = CreateG();
            Assert.IsFalse(_target.HasRoute(g.Nodes[3], g.Nodes[5]));

            g = CreateG();
            Assert.IsFalse(_target.HasRoute(g.Nodes[4], g.Nodes[5]));

            g = CreateG();
            Assert.IsFalse(_target.HasRoute(g.Nodes[0], new N { Name = "9" }));
            g = CreateG();
            Assert.IsFalse(_target.HasRoute(new N { Name = "11" }, g.Nodes[0]));
        }

        [TestMethod]
        public void TestH()
        {
            Assert.AreEqual(0, new Bn().H);

            Assert.AreEqual(1, new Bn { L = new Bn(), R = new Bn() }.H);

            Assert.AreEqual(2, new Bn { L = new Bn { L = new Bn() } }.H);

            Assert.AreEqual(2, new Bn { L = new Bn { L = new Bn() }, R = new Bn() }.H);

            var btr = CreateBtr();
            Assert.AreEqual(3, btr.R.H);
        }

        [TestMethod]
        public void TestCreateMinTr()
        {
            int[] a = { 1 };
            var bn = _target.CreateMinTr(a);
            Assert.AreEqual("1", bn.Name);
            Assert.AreEqual(0, bn.H);
            Assert.IsNull(bn.L);
            Assert.IsNull(bn.R);

            a = new[] { 1, 2 };
            bn = _target.CreateMinTr(a);
            Assert.AreEqual("1", bn.Name);
            Assert.AreEqual(1, bn.H);
            Assert.IsNull(bn.L);
            Assert.AreEqual("2", bn.R.Name);

            a = new[] { 1, 2, 3 };
            bn = _target.CreateMinTr(a);
            Assert.AreEqual("2", bn.Name);
            Assert.AreEqual("1", bn.L.Name);
            Assert.AreEqual("3", bn.R.Name);
            Assert.AreEqual(1, bn.H);
            Assert.IsNull(bn.L.L);
            Assert.IsNull(bn.L.R);
            Assert.IsNull(bn.R.L);
            Assert.IsNull(bn.R.R);

            a = new[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            bn = _target.CreateMinTr(a);
            Assert.AreEqual(3, bn.H);
        }

        [TestMethod]
        public void GetListOfDTest()
        {
            int[] a = { 1 };
            var bn = _target.CreateMinTr(a);
            var list = bn.GetListOfD();
            Assert.AreEqual(bn.H + 1, list.Length);
            Assert.AreEqual(1, list[0].Count);
            Assert.AreEqual("1", list[0][0].Name);

            a = new[] { 1, 2, 3 };
            bn = _target.CreateMinTr(a);
            list = bn.GetListOfD();
            Assert.AreEqual(bn.H + 1, list.Length);
            Assert.AreEqual(1, list[0].Count);
            Assert.AreEqual(2, list[1].Count);

            a = new[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            bn = _target.CreateMinTr(a);
            list = bn.GetListOfD();
            Assert.AreEqual(bn.H + 1, list.Length);
            Assert.AreEqual(1, list[0].Count);
            Assert.AreEqual(2, list[1].Count);
            Assert.AreEqual(4, list[2].Count);
            Assert.AreEqual(1, list[3].Count);

            Bn n = new Bn { Name = "1", L = new Bn { Name = "2", L = new Bn { Name = "3" } } };
            list = n.GetListOfD();
            Assert.AreEqual(n.H + 1, list.Length);
            Assert.AreEqual(1, list[0].Count);
            Assert.AreEqual(1, list[1].Count);
            Assert.AreEqual(1, list[2].Count);
        }

        [TestMethod]
        public void IsBalanced()
        {
            Bn n = new Bn
            {
                Name = "1"
            };
            Assert.IsTrue(n.IsBalanced());

            n = new Bn
            {
                Name = "1",
                L = new Bn { Name = "2" }
            };
            Assert.IsTrue(n.IsBalanced());

            n = new Bn
            {
                Name = "1",
                L = new Bn
                {
                    Name = "2",
                    L = new Bn
                    {
                        Name = "3"
                    }
                }
            };
            Assert.IsFalse(n.IsBalanced());

            n = new Bn
            {
                Name = "1",
                L = new Bn
                {
                    Name = "2",
                },
                R = new Bn
                {
                    Name = "3"
                },
            };
            Assert.IsTrue(n.IsBalanced());

            var a = new[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            n = _target.CreateMinTr(a);
            Assert.IsTrue(n.IsBalanced());
        }

        [TestMethod]
        public void CountTest()
        {
            Bn n = new Bn
            {
                Name = "1"
            };
            Assert.AreEqual(1, n.Count);

            n = new Bn
            {
                Name = "1",
                L = new Bn { Name = "2" }
            };
            Assert.AreEqual(2, n.Count);

            n = new Bn
            {
                Name = "1",
                L = new Bn
                {
                    Name = "2",
                    L = new Bn
                    {
                        Name = "3"
                    }
                }
            };
            Assert.AreEqual(3, n.Count);

            n = new Bn
            {
                Name = "1",
                L = new Bn
                {
                    Name = "2",
                },
                R = new Bn
                {
                    Name = "3"
                },
            };
            Assert.AreEqual(3, n.Count);

            var a = new[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            n = _target.CreateMinTr(a);
            Assert.AreEqual(8, n.Count);
        }

        #region validate bst

        [TestMethod]
        public void ValidateBstTest()
        {
            var bns = CreateSearchBns();
            foreach (var bn in bns)
            {
                Assert.IsTrue(_target.ValidateBst(bn));
            }

            bns = CreateBns();
            foreach (var bn in bns)
            {
                Assert.IsFalse(_target.ValidateBst(bn));
            }
        }

        [TestMethod]
        public void ValidateBstNoCopyingTest()
        {
            var bns = CreateSearchBns();
            foreach (var bn in bns)
            {
                Assert.IsTrue(_target.ValidateBstWithNoCopying(bn));
            }

            bns = CreateBns();
            foreach (var bn in bns)
            {
                Assert.IsFalse(_target.ValidateBstWithNoCopying(bn));
            }
        }

        [TestMethod]
        public void ValidateBstWithRangeTest()
        {
            var bns = CreateSearchBns();
            foreach (var bn in bns)
            {
                Assert.IsTrue(_target.ValidateBstWithRange(bn));
            }

            bns = CreateBns();
            foreach (var bn in bns)
            {
                Assert.IsFalse(_target.ValidateBstWithRange(bn));
            }
        }

        #endregion

        [TestMethod]
        public void FindSuccessorTest()
        {
            var n = CreateBst();
            Assert.AreEqual("5", _target.FindSuccessor(n, "3").Name);
            Assert.AreEqual("7", _target.FindSuccessor(n, "5").Name);
            Assert.AreEqual("10", _target.FindSuccessor(n, "7").Name);
            Assert.AreEqual("15", _target.FindSuccessor(n, "10").Name);
            Assert.AreEqual("17", _target.FindSuccessor(n, "15").Name);
            Assert.AreEqual("20", _target.FindSuccessor(n, "17").Name);
            Assert.AreEqual("30", _target.FindSuccessor(n, "20").Name);
            Assert.IsNull(_target.FindSuccessor(n, "30"));
        }

        #region build order/top sort

        [TestMethod]
        public void BuildOrderTest()
        {
            var g = BuildProjectG();
            var o = g.BuildOrder();
            Assert.AreEqual("f", o[0].Name);
            Assert.AreEqual("e", o[1].Name);
            Assert.AreEqual("b", o[2].Name);
            Assert.AreEqual("a", o[3].Name);
            Assert.AreEqual("d", o[4].Name);
            Assert.AreEqual("c", o[5].Name);
            //f, e, a, b, d, c
        }

        private G BuildProjectG()
        {
            #region

            var a = new N { Name = "a" };
            var b = new N { Name = "b" };
            var c = new N { Name = "c" };
            var d = new N { Name = "d" };
            var e = new N { Name = "e" };
            var f = new N { Name = "f" };
            var s = new[] { a, b, c, d, e, f };
            List<Tuple<N, N>> t = new List<Tuple<N, N>>();
            t.Add(new Tuple<N, N>(a, d));
            t.Add(new Tuple<N, N>(f, b));
            t.Add(new Tuple<N, N>(b, d));
            t.Add(new Tuple<N, N>(f, a));
            t.Add(new Tuple<N, N>(d, c));

            #endregion

            return BuildG(s, t);
        }

        private G BuildG(N[] ns, List<Tuple<N, N>> pairs)
        {
            var g = new G();
            var n = new List<N>();
            for (var i = 0; i < ns.Length; i++)
            {
                var index = i;
                var nodes = pairs
                    .Where(p => p.Item1 == ns[index])
                    .Select(t => t.Item2).ToArray();
                ns[i].Children = nodes;
                n.Add(ns[i]);
            }
            g.Nodes = n.ToArray();
            return g;
        }

        #endregion

        #endregion

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

        #region find path test

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

        [TestMethod]
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
        }

        #region helper

        private List<Bn> CreateSearchBns()
        {
            var bns = new List<Bn>
            {
                new Bn
                {
                    Name = "8",
                    Order = 8,
                    L = new Bn
                    {
                        Name = "4",
                        Order = 4,
                        L = new Bn
                        {
                            Name = "2",
                            Order = 2
                        },
                        R = new Bn
                        {
                            Name = "6",
                            Order = 6
                        }
                    },
                    R = new Bn
                    {
                        Name = "10",
                        Order = 10,
                        R = new Bn
                        {
                            Name = "20",
                            Order = 20
                        }
                    }
                },

                new Bn
                {
                    Name = "10",
                    Order = 10,
                    L = new Bn
                    {
                        Name = "5",
                        Order = 5,
                        L = new Bn
                        {
                            Name = "3",
                            Order = 3
                        },
                        R = new Bn
                        {
                            Name = "7",
                            Order = 7
                        }
                    },
                    R = new Bn
                    {
                        Name = "20",
                        Order = 20,
                        R = new Bn
                        {
                            Name = "30",
                            Order = 30
                        }
                    }
                },

                new Bn
                {
                    Name = "10",
                    Order = 10,
                    L = new Bn
                    {
                        Name = "5",
                        Order = 5,
                        L = new Bn
                        {
                            Name = "3",
                            Order = 3
                        },
                        R = new Bn
                        {
                            Name = "7",
                            Order = 7
                        }
                    },
                    R = new Bn
                    {
                        Name = "20",
                        Order = 20,
                        L = new Bn
                        {
                            Name = "15",
                            Order = 15
                        }
                    }
                },

                CreateBst()
            };

            return bns;
        }

        private Bn CreateBst()
        {
            return new Bn
            {
                Name = "20",
                Order = 20,
                L = new Bn
                {
                    Name = "10",
                    Order = 10,
                    L = new Bn
                    {
                        Name = "5",
                        Order = 5,
                        L = new Bn
                        {
                            Name = "3",
                            Order = 3
                        },
                        R = new Bn
                        {
                            Name = "7",
                            Order = 7
                        }
                    },
                    R = new Bn
                    {
                        Name = "15",
                        Order = 15,
                        R = new Bn
                        {
                            Name = "17",
                            Order = 17
                        }
                    }
                },
                R = new Bn
                {
                    Name = "30",
                    Order = 30,
                }
            };
        }

        private List<Bn> CreateBns()
        {
            //not searched
            var bns = new List<Bn>
            {
                new Bn
                {
                    Name = "8",
                    Order = 8,
                    L = new Bn
                    {
                        Name = "4",
                        Order = 4,
                        L = new Bn
                        {
                            Name = "2",
                            Order = 2
                        },
                        R = new Bn
                        {
                            Name = "12",
                            Order = 12
                        }
                    },
                    R = new Bn
                    {
                        Name = "10",
                        Order = 10,
                        R = new Bn
                        {
                            Name = "20",
                            Order = 20
                        }
                    }
                },

                new Bn
                {
                    Name = "10",
                    Order = 10,
                    L = new Bn
                    {
                        Name = "5",
                        Order = 5,
                        R = new Bn
                        {
                            Name = "12",
                            Order = 12
                        }
                    },
                    R = new Bn
                    {
                        Name = "20",
                        Order = 20,
                        L = new Bn
                        {
                            Name = "3",
                            Order = 3,
                            L = new Bn
                            {
                                Name = "9",
                                Order = 9
                            },
                            R = new Bn
                            {
                                Name = "18",
                                Order = 18
                            }
                        },
                        R = new Bn
                        {
                            Name = "7",
                            Order = 7
                        }
                    }
                },

                new Bn
                {
                    Name = "10",
                    Order = 10,
                    L = new Bn
                    {
                        Name = "5",
                        Order = 5,
                    },
                    R = new Bn
                    {
                        Name = "20",
                        Order = 20,
                        L = new Bn
                        {
                            Name = "3",
                            Order = 3,
                            L = new Bn
                            {
                                Name = "9",
                                Order = 9
                            },
                            R = new Bn
                            {
                                Name = "18",
                                Order = 18
                            }
                        },
                        R = new Bn
                        {
                            Name = "7",
                            Order = 7
                        }
                    }
                },

                new Bn
                {
                    Order = 20,
                    L = new Bn
                    {
                        Order = 10,
                        R = new Bn
                        {
                            Order = 25
                        }
                    },
                    R = new Bn
                    {
                        Order = 30
                    }
                }
            };

            return bns;
        }

        private Btr CreateBtr()
        {
            Bn n18 = new Bn { Name = "18" };
            Bn n9 = new Bn { Name = "9" };

            Bn n7 = new Bn { Name = "7" };
            Bn n3 = new Bn { Name = "3", L = n9, R = n18 };

            Bn n20 = new Bn { Name = "20", L = n3, R = n7 };
            Bn n5 = new Bn { Name = "5" };

            Bn r = new Bn { Name = "10", L = n5, R = n20 };
            return new Btr { R = r };
        }

        private G CreateG()
        {
            G g = new G();
            N[] ns =
            {
                new N {Name = "0"},
                new N {Name = "1"},
                new N {Name = "2"},
                new N {Name = "3"},
                new N {Name = "4"},
                new N {Name = "5"},
            };

            ns[0].Children = new[] { ns[1], ns[4], ns[5] };
            ns[1].Children = new[] { ns[3], ns[4] };
            ns[2].Children = new[] { ns[1] };
            ns[3].Children = new[] { ns[2], ns[4] };
            ns[4].Children = null;
            ns[5].Children = null;
            g.Nodes = ns;
            return g;
        }

        #endregion
    }
}