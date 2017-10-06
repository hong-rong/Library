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
    public class TrTest
    {
        private Tr _target;

        [TestInitialize]
        public void Init()
        {
            _target = new Tr();
        }

        [TestMethod]
        public void CheckSubTrTest() 
        {
            var btr = CreateBtr();

        }

        #region tr test

        #region route between notes
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
        #endregion

        #region minimal tree
        [TestMethod]
        public void CreateMinTrTest()
        {
            int[] a = { 1 };
            var bn = _target.CreateMinTr(a);
            Assert.AreEqual("1", bn.Name);
            Assert.AreEqual(0, Tr.Height(bn));
            Assert.IsNull(bn.L);
            Assert.IsNull(bn.R);

            a = new[] { 1, 2 };
            bn = _target.CreateMinTr(a);
            Assert.AreEqual("1", bn.Name);
            Assert.AreEqual(1, Tr.Height(bn));
            Assert.IsNull(bn.L);
            Assert.AreEqual("2", bn.R.Name);

            a = new[] { 1, 2, 3 };
            bn = _target.CreateMinTr(a);
            Assert.AreEqual("2", bn.Name);
            Assert.AreEqual("1", bn.L.Name);
            Assert.AreEqual("3", bn.R.Name);
            Assert.AreEqual(1, Tr.Height(bn));
            Assert.IsNull(bn.L.L);
            Assert.IsNull(bn.L.R);
            Assert.IsNull(bn.R.L);
            Assert.IsNull(bn.R.R);

            a = new[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            bn = _target.CreateMinTr(a);
            Assert.AreEqual(3, Tr.Height(bn));
        }
        #endregion

        #region list of depths
        [TestMethod]
        public void GetListOfDepthTest()
        {
            int[] a = { 1 };
            var bn = _target.CreateMinTr(a);
            var list = _target.GetListOfDepths(bn);
            Assert.AreEqual(Tr.Height(bn) + 1, list.Length);
            Assert.AreEqual(1, list[0].Count);
            Assert.AreEqual("1", list[0][0].Name);

            a = new[] { 1, 2, 3 };
            bn = _target.CreateMinTr(a);
            list = _target.GetListOfDepths(bn);
            Assert.AreEqual(Tr.Height(bn) + 1, list.Length);
            Assert.AreEqual(1, list[0].Count);
            Assert.AreEqual(2, list[1].Count);

            a = new[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            bn = _target.CreateMinTr(a);
            list = _target.GetListOfDepths(bn);
            Assert.AreEqual(Tr.Height(bn) + 1, list.Length);
            Assert.AreEqual(1, list[0].Count);
            Assert.AreEqual(2, list[1].Count);
            Assert.AreEqual(4, list[2].Count);
            Assert.AreEqual(1, list[3].Count);

            Bn n = new Bn { Name = "1", L = new Bn { Name = "2", L = new Bn { Name = "3" } } };
            list = _target.GetListOfDepths(n);
            Assert.AreEqual(Tr.Height(n) + 1, list.Length);
            Assert.AreEqual(1, list[0].Count);
            Assert.AreEqual(1, list[1].Count);
            Assert.AreEqual(1, list[2].Count);
        }
        #endregion

        #region check balance
        [TestMethod]
        public void CheckBalanceTest()
        {
            Bn n = new Bn
            {
                Name = "1"
            };
            Assert.IsTrue(_target.CheckBalance(n));

            n = new Bn
            {
                Name = "1",
                L = new Bn { Name = "2" }
            };
            Assert.IsTrue(_target.CheckBalance(n));

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
            Assert.IsFalse(_target.CheckBalance(n));

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
            Assert.IsTrue(_target.CheckBalance(n));

            var a = new[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            n = _target.CreateMinTr(a);
            Assert.IsTrue(_target.CheckBalance(n));
        }
        #endregion

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

        #region successor
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
        #endregion

        #region build order(top sort)
        [TestMethod]
        public void BuildOrderTest()
        {
            var g = BuildProjectG();
            var o = _target.BuildOrder(g.Nodes);
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

        #region common ancestor
        
        #region solution one
        [TestMethod]
        public void CommonAncestorTest()
        {
            var r = CreateBtr().R;
            var n = _target.CommonAncestor1(r.L, r.R.R);
            Assert.AreEqual("10", n.Name);

            n = _target.CommonAncestor1(r.L, r.R.L.R);
            Assert.AreEqual("10", n.Name);

            n = _target.CommonAncestor1(r.R.L.L, r.R.R);
            Assert.AreEqual("20", n.Name);

            n = _target.CommonAncestor1(r.R.L.L, r.R.L.R);
            Assert.AreEqual("3", n.Name);

            n = _target.CommonAncestor1(r.R.L, r.R.L.R);
            Assert.AreEqual("3", n.Name);

            n = _target.CommonAncestor1(r.R.L.L, r);
            Assert.AreEqual("10", n.Name);
        }
        #endregion

        #region solution two
        [TestMethod]
        public void CommonAncestor2Test()
        {
            var r = CreateBtr().R;
            var n = _target.CommonAncestor2(r, r.L, r.R.R);
            Assert.AreEqual("10", n.Name);

            n = _target.CommonAncestor2(r, r.L, r.R.L.R);
            Assert.AreEqual("10", n.Name);

            n = _target.CommonAncestor2(r, r.R.L.L, r.R.R);
            Assert.AreEqual("20", n.Name);

            n = _target.CommonAncestor2(r, r.R.L.L, r.R.L.R);
            Assert.AreEqual("3", n.Name);

            n = _target.CommonAncestor2(r, r.R.L, r.R.L.R);
            Assert.AreEqual("3", n.Name);

            n = _target.CommonAncestor2(r, r.R.L.L, r);
            Assert.AreEqual("10", n.Name);
        }
        #endregion

        #region solution three
        [TestMethod]
        public void CommonAncestor3Test()
        {
            var r = CreateBtr().R;
            var n = _target.CommonAncestor3(r, r.L, r.R.R);
            Assert.AreEqual("10", n.Name);

            n = _target.CommonAncestor3(r, r.L, r.R.L.R);
            Assert.AreEqual("10", n.Name);

            n = _target.CommonAncestor3(r, r.R.L.L, r.R.R);
            Assert.AreEqual("20", n.Name);

            n = _target.CommonAncestor3(r, r.R.L.L, r.R.L.R);
            Assert.AreEqual("3", n.Name);

            n = _target.CommonAncestor3(r, r.R.L, r.R.L.R);
            Assert.AreEqual("3", n.Name);

            n = _target.CommonAncestor3(r, r.R.L.L, r);
            Assert.AreEqual("10", n.Name);
        }
        #endregion

        #region solution four
        [TestMethod]
        public void CommonAncestor4Test()
        {
            var r = CreateBtr().R;
            var n = _target.CommonAncestor4(r, r.L, r.R.R);
            Assert.AreEqual("10", n.Name);

            n = _target.CommonAncestor4(r, r.L, r.R.L.R);
            Assert.AreEqual("10", n.Name);

            n = _target.CommonAncestor4(r, r.R.L.L, r.R.R);
            Assert.AreEqual("20", n.Name);

            n = _target.CommonAncestor4(r, r.R.L.L, r.R.L.R);
            Assert.AreEqual("3", n.Name);

            n = _target.CommonAncestor4(r, r.R.L, r.R.L.R);
            Assert.AreEqual("3", n.Name);

            n = _target.CommonAncestor4(r, r.R.L.L, r);
            Assert.AreEqual("10", n.Name);
        }
        #endregion

        #endregion

        #endregion

        #region common test

        #region height
        [TestMethod]
        public void HeightTest()
        {
            Assert.AreEqual(0, Tr.Height(new Bn()));

            Assert.AreEqual(1, Tr.Height(new Bn { L = new Bn(), R = new Bn() }));

            Assert.AreEqual(2, Tr.Height(new Bn { L = new Bn { L = new Bn() } }));

            Assert.AreEqual(2, Tr.Height(new Bn { L = new Bn { L = new Bn() }, R = new Bn() }));

            var btr = CreateBtr();
            Assert.AreEqual(3, Tr.Height(btr.R));
        }
        #endregion

        #region count
        [TestMethod]
        public void CountTest()
        {
            Bn n = new Bn
            {
                Name = "1"
            };
            Assert.AreEqual(1, Tr.Count(n));

            n = new Bn
            {
                Name = "1",
                L = new Bn { Name = "2" }
            };
            Assert.AreEqual(2, Tr.Count(n));

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
            Assert.AreEqual(3, Tr.Count(n));

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
            Assert.AreEqual(3, Tr.Count(n));

            var a = new[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            n = _target.CreateMinTr(a);
            Assert.AreEqual(8, Tr.Count(n));
        }
        #endregion

        #region tree travel
        [TestMethod]
        public void DfsTest()
        {
            G g = CreateG();
            Tr.Dfs(g.Nodes);
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
            Tr.Bfs(g.Nodes);
            Assert.AreEqual(1, g.Nodes[0].Order);
            Assert.AreEqual(2, g.Nodes[1].Order);
            Assert.AreEqual(3, g.Nodes[4].Order);
            Assert.AreEqual(4, g.Nodes[5].Order);
            Assert.AreEqual(5, g.Nodes[3].Order);
            Assert.AreEqual(6, g.Nodes[2].Order);
        }
        #endregion

        #region binary tree visit
        [TestMethod]
        public void PreOTest()
        {
            Btr t = CreateBtr();
            Tr.PreO(t.R);
            Assert.AreEqual(1, Tr.GetBn(t.R, "10").Order);
            Assert.AreEqual(2, Tr.GetBn(t.R, "5").Order);
            Assert.AreEqual(3, Tr.GetBn(t.R, "20").Order);
            Assert.AreEqual(4, Tr.GetBn(t.R, "3").Order);
            Assert.AreEqual(5, Tr.GetBn(t.R, "9").Order);
            Assert.AreEqual(6, Tr.GetBn(t.R, "18").Order);
            Assert.AreEqual(7, Tr.GetBn(t.R, "7").Order);
        }

        [TestMethod]
        public void InOTest()
        {
            Btr t = CreateBtr();
            Tr.InO(t.R);
            Assert.AreEqual(1, Tr.GetBn(t.R, "5").Order);
            Assert.AreEqual(2, Tr.GetBn(t.R, "10").Order);
            Assert.AreEqual(3, Tr.GetBn(t.R, "9").Order);
            Assert.AreEqual(4, Tr.GetBn(t.R, "3").Order);
            Assert.AreEqual(5, Tr.GetBn(t.R, "18").Order);
            Assert.AreEqual(6, Tr.GetBn(t.R, "20").Order);
            Assert.AreEqual(7, Tr.GetBn(t.R, "7").Order);
        }

        [TestMethod]
        public void PostOTest()
        {
            Btr t = CreateBtr();
            Tr.PostO(t.R);
            Assert.AreEqual(1, Tr.GetBn(t.R, "5").Order);
            Assert.AreEqual(2, Tr.GetBn(t.R, "9").Order);
            Assert.AreEqual(3, Tr.GetBn(t.R, "18").Order);
            Assert.AreEqual(4, Tr.GetBn(t.R, "3").Order);
            Assert.AreEqual(5, Tr.GetBn(t.R, "7").Order);
            Assert.AreEqual(6, Tr.GetBn(t.R, "20").Order);
            Assert.AreEqual(7, Tr.GetBn(t.R, "10").Order);
        }
        #endregion

        #region get binary node
        [TestMethod]
        public void GetBnTest()
        {
            Btr btr = CreateBtr();
            var r = Tr.GetBn(btr.R, "10");
            Assert.IsNotNull(r);
            Assert.AreEqual("5", r.L.Name);
            Assert.AreEqual("20", r.R.Name);

            r = Tr.GetBn(btr.R, "3");
            Assert.IsNotNull(r);
            Assert.AreEqual("9", r.L.Name);
            Assert.AreEqual("18", r.R.Name);

            r = Tr.GetBn(btr.R, "18");
            Assert.IsNotNull(r);
            Assert.IsNull(r.L);
            Assert.IsNull(r.R);

            r = Tr.GetBn(btr.R, "99");
            Assert.IsNull(r);
        }
        #endregion

        #endregion

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
            //        10
            //    5       20
            //         3      7
            //       9   18
            Bn n18 = new Bn { Name = "18" };
            Bn n9 = new Bn { Name = "9" };

            Bn n7 = new Bn { Name = "7" };
            Bn n3 = new Bn { Name = "3", L = n9, R = n18 };

            Bn n20 = new Bn { Name = "20", L = n3, R = n7 };
            Bn n5 = new Bn { Name = "5" };

            Bn r = new Bn { Name = "10", L = n5, R = n20 };

            //setup parent
            n18.P = n3;
            n9.P = n3;

            n7.P = n20;
            n3.P = n20;

            n20.P = r;
            n5.P = r;

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