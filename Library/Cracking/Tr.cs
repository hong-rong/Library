using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Cracking
{
    public class Tr
    {
        public bool CheckSubTr(Bn t1, Bn t2)
        {
            if (t1 == null || t2 == null) throw new ArgumentException();

            var h1 = Tr.Height(t1);
            var h2 = Tr.Height(t2);
            var list = GetNodesAtHeight(t1, h1 - h2 + 1);
            for (int i = 0; i < list.Count; i++)
            {
                if (CompareTr(list[i], t2)) return true;
            }
            return false;
        }

        private List<Bn> GetNodesAtHeight(Bn r, int height)
        {
            if (r == null) return null;

            List<Bn> list = new List<Bn>();
            Queue<Bn> q = new Queue<Bn>();
            q.Enqueue(r);
            int h = 0;

            while (q.Count != 0)
            {
                int count = q.Count;
                if (h != height)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var n = q.Dequeue();
                        q.Enqueue(n.L);
                        q.Enqueue(n.R);
                    }
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        list.Add(q.Dequeue());
                    }
                    break;
                }
                h++;
            }

            return list;
        }

        private bool CompareTr(Bn n1, Bn n2)
        {
            if (n1 == null && n2 == null) return true;
            if (n1 == null || n2 == null) return false;

            if (n1.Name != n2.Name)
            {
                return false;
            }
            var result = CompareTr(n1.L, n2.L);
            if (!result) return false;
            return CompareTr(n1.R, n2.R);
        }

        #region tr

        #region route between nodes
        public bool HasRoute(N s, N e)
        {
            if (s == null || e == null) throw new ArgumentNullException();
            Queue<N> q = new Queue<N>();
            q.Enqueue(s);
            s.HasVisited = true;

            while (q.Count > 0)
            {
                var n = q.Dequeue();
                if (n.Name == e.Name)
                {
                    return true;
                }
                if (n.Children != null && n.Children.Length > 0)
                {
                    for (int i = 0; i < n.Children.Length; i++)
                    {
                        if (!n.Children[i].HasVisited)
                        {
                            q.Enqueue(n.Children[i]);
                            n.Children[i].HasVisited = true;
                        }
                    }
                }
            }

            return false;
        }
        #endregion

        #region minimal tree
        public Bn CreateMinTr(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException();
            return CreateMinTr(arr, 0, arr.Length - 1);
        }
        private Bn CreateMinTr(int[] arr, int s, int e)
        {
            if (s > e)
            {
                return null;
            }
            int middle = (s + e) / 2;
            int value = arr[middle];
            Bn bn = new Bn { Name = value.ToString(), Order = value };
            bn.L = CreateMinTr(arr, s, middle - 1);
            bn.R = CreateMinTr(arr, middle + 1, e);
            return bn;
        }
        #endregion

        #region list Of depths
        public List<Bn>[] GetListOfDepths(Bn bn)
        {
            List<Bn>[] list = new List<Bn>[Tr.Height(bn) + 1];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new List<Bn>();
            }
            GetListOfDepths(list, bn, 0);
            return list;
        }

        private void GetListOfDepths(List<Bn>[] list, Bn n, int level)
        {
            if (n != null)
            {
                list[level].Add(n);
                level++;
                GetListOfDepths(list, n.L, level);
                GetListOfDepths(list, n.R, level);
            }
        }
        #endregion

        #region check balance
        public bool CheckBalance(Bn bn)
        {
            return IsBalanced(bn).IsBalanced;
        }

        private BalanceResult IsBalanced(Bn n)
        {
            if (n == null) return new BalanceResult
            {
                IsBalanced = true,
                Height = 0
            };
            var lh = IsBalanced(n.L);
            var rh = IsBalanced(n.R);
            if (!lh.IsBalanced || !rh.IsBalanced)
            {
                return new BalanceResult { IsBalanced = false };
            }

            return new BalanceResult
            {
                IsBalanced = Math.Abs(lh.Height - rh.Height) <= 1,
                Height = lh.Height >= rh.Height ? lh.Height + 1 : rh.Height + 1
            };
        }

        class BalanceResult
        {
            public bool IsBalanced { get; set; }
            public int Height { get; set; }
        }
        #endregion

        #region validate bst
        public bool ValidateBst(Bn n)
        {
            if (n == null) throw new ArgumentNullException();
            int index = 0;
            int[] arr = new int[Tr.Count(n)];
            CopyBst(n, arr, ref index);
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i]) return false;
            }
            return true;
        }

        private void CopyBst(Bn n, int[] arr, ref int index)
        {
            if (n != null)
            {
                CopyBst(n.L, arr, ref index);
                arr[index++] = n.Order;
                CopyBst(n.R, arr, ref index);
            }
        }

        public bool ValidateBstWithNoCopying(Bn n)
        {
            int previouseData = int.MinValue;
            return ValidateBst(n, ref previouseData);
        }

        private bool ValidateBst(Bn n, ref int previouseData)
        {
            if (n == null)
            {
                return true;
            }

            if (!ValidateBst(n.L, ref previouseData) || previouseData > n.Order)
            {
                return false;
            }
            previouseData = n.Order;

            if (!ValidateBst(n.R, ref previouseData))
            {
                return false;
            }

            return true;
        }

        public bool ValidateBstWithRange(Bn n)
        {
            if (n == null) throw new ArgumentNullException();
            return ValidateBstWithRangePerOrder(n, int.MinValue, int.MaxValue);
        }

        private bool ValidateBstWithRangePerOrder(Bn n, int min, int max)
        {
            if (n == null) return true;

            if (min > n.Order || n.Order > max)
            {
                return false;
            }
            if (!ValidateBstWithRangePerOrder(n.L, min, n.Order) || !ValidateBstWithRangePerOrder(n.R, n.Order, max))
            {
                return false;
            }

            return true;
        }

        private bool ValidateBstWithRange(Bn n, int min, int max)
        {
            if (n == null) return true;

            if (!ValidateBstWithRange(n.L, min, n.Order) || min > n.Order)
            {
                return false;
            }
            if (!ValidateBstWithRange(n.R, n.Order, max) || n.Order > max)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region successor
        public Bn FindSuccessor(Bn n, string name)
        {
            if (n == null) throw new ArgumentNullException();
            var hasFound = false;
            return FindSuccessor(n, name, ref hasFound);
        }
        private Bn FindSuccessor(Bn n, string name, ref bool hasFound)
        {
            if (n == null) return null;
            var l = FindSuccessor(n.L, name, ref hasFound);
            if (l != null) return l;

            if (n.Name == name)
            {
                hasFound = true;
            }
            else if (hasFound)
            {
                return n;
            }

            return FindSuccessor(n.R, name, ref hasFound);
        }
        #endregion

        #region build order(top sort)

        public List<N> BuildOrder(N[] nodes)
        {
            if (nodes == null || nodes.Length <= 0) throw new ArgumentException("Empty");

            var nodeOrders = new List<N>();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!nodes[i].HasVisited)
                {
                    TopSort(nodes[i], nodeOrders);
                }
            }
            nodeOrders.Reverse();
            return nodeOrders;
        }

        private void TopSort(N n, List<N> nodeOrders)
        {
            if (n != null)
            {
                n.HasVisited = true;
                if (n.Children != null && n.Children.Length > 0)
                {
                    for (int i = 0; i < n.Children.Length; i++)
                    {
                        if (!n.Children[i].HasVisited)
                        {
                            TopSort(n.Children[i], nodeOrders);
                        }
                    }
                }
                nodeOrders.Add(n);
            }
        }

        #endregion

        #region common ancestor

        #region solution one
        //has parent, search like linked list to a merge node
        public Bn CommonAncestor1(Bn n1, Bn n2)
        {
            var c1 = 0;
            var p1 = n1;
            while (p1.P != null)
            {
                p1 = p1.P;
                c1++;
            }
            var c2 = 0;
            var p2 = n2;
            while (p2.P != null)
            {
                p2 = p2.P;
                c2++;
            }
            var dat = Math.Abs(c1 - c2);
            p1 = n1;
            p2 = n2;
            if (c1 > c2)
            {
                while (dat > 0)
                {
                    p1 = p1.P;
                    dat--;
                }
            }
            else
            {
                while (dat > 0)
                {
                    p2 = p2.P;
                    dat--;
                }
            }
            while (p1 != p2)
            {
                p1 = p1.P;
                p2 = p2.P;
            }

            return p1;
        }
        #endregion

        #region solution two
        //has parent, start from n1, check if n2 is covered by a sibling node of n1's ancestor
        public Bn CommonAncestor2(Bn r, Bn n1, Bn n2)
        {
            if (!Covers(r, n1) || !Covers(r, n2)) return null;
            if (Covers(n1, n2)) return n1;
            if (Covers(n2, n1)) return n2;

            var s = GetSibling(n1);
            while (!Covers(s, n2))
            {
                s = GetSibling(s.P);
            }

            return s.P;
        }

        private Bn GetSibling(Bn n)
        {
            if (n == null || n.P == null) return null;
            return n.P.L == n ? n.P.R : n.P.L;
        }

        private bool Covers(Bn r, Bn n)
        {
            if (r == null) return false;
            if (r == n) return true;
            return Covers(r.L, n) || Covers(r.R, n);
        }
        #endregion

        #region solution three
        //no parent, check if two nodes on the same side from root node
        public Bn CommonAncestor3(Bn r, Bn n1, Bn n2)
        {
            if (r == null) return null;
            if (r == n1) return n1;
            if (r == n2) return n2;

            var n1OnLeft = Covers(r.L, n1);
            var n2OnLeft = Covers(r.L, n2);
            if (n1OnLeft != n2OnLeft) return r;
            return n1OnLeft ? CommonAncestor3(r.L, n1, n2) : CommonAncestor3(r.R, n1, n2);
        }
        #endregion

        #region solution four
        public Bn CommonAncestor4(Bn r, Bn n1, Bn n2)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region solution four
        #endregion

        #endregion

        #region check subtree
        //Tl and T2 are two very large binary trees, with Tl much bigger than T2. Create an
        //algorithm to determine if T2 is a subtree of Tl.
        //A tree T2 is a subtree of Tl if there exists a node n in Tl such that the subtree of n is identical to T2.
        //That is, if you cut off the tree at node n, the two trees would be identical.
        //Hints:#4, #11, #18, #31, #37
        #endregion

        #endregion

        #region common

        #region height
        public static int Height(Bn bn)
        {
            return GetHeight(bn) - 1;
        }

        private static int GetHeight(Bn n)
        {
            if (n == null) return 0;
            int l = GetHeight(n.L);
            int r = GetHeight(n.R);
            return l >= r ? l + 1 : r + 1;
        }
        #endregion

        #region count
        public static int Count(Bn n)
        {
            if (n == null) return 0;
            return Count(n.L) + Count(n.R) + 1;
        }
        #endregion

        #region tree travel

        #region dfs
        public static void Dfs(N[] Nodes)
        {
            if (Nodes == null || Nodes.Length < 0) throw new ArgumentNullException();
            int order = 0;
            Dfs(Nodes[0], ref order);
        }

        private static void Dfs(N n, ref int order)
        {
            if (n != null)
            {
                VisitN(n, ref order);
                if (n.Children != null && n.Children.Length > 0)
                {
                    for (int i = 0; i < n.Children.Length; i++)
                    {
                        if (n.Children[i].Order == 0)
                        {
                            Dfs(n.Children[i], ref order);
                        }
                    }
                }
            }
        }
        #endregion

        #region bfs
        public static void Bfs(N[] Nodes)
        {
            if (Nodes == null || Nodes.Length < 0) throw new ArgumentNullException();
            int order = 0;
            Bfs(Nodes, ref order);
        }

        private static void Bfs(N[] Nodes, ref int order)
        {
            if (Nodes == null || Nodes.Length < 0) throw new ArgumentNullException();
            Queue<N> q = new Queue<N>();
            q.Enqueue(Nodes[0]);
            Nodes[0].HasVisited = true;

            while (q.Count > 0)
            {
                N n = q.Dequeue();
                VisitN(n, ref order);
                if (n.Children != null && n.Children.Length > 0)
                {
                    for (int i = 0; i < n.Children.Length; i++)
                    {
                        if (n.Children[i].HasVisited == false)
                        {
                            q.Enqueue(n.Children[i]);
                            n.Children[i].HasVisited = true;
                        }
                    }
                }
            }
        }
        #endregion

        private static void VisitN(N n, ref int order)
        {
            Debug.WriteLine(n.Name);
            n.Order = ++order;
        }

        #endregion

        #region binary tree visit
        public static void PreO(Bn r)
        {
            int order = 0;
            PreOrderVisit(r, ref order);
        }

        private static void PreOrderVisit(Bn n, ref int order)
        {
            if (n != null)
            {
                VisitN(n, ref order);
                PreOrderVisit(n.L, ref order);
                PreOrderVisit(n.R, ref order);
            }
        }

        public static void InO(Bn r)
        {
            int order = 0;
            InOrderVisit(r, ref order);
        }

        private static void InOrderVisit(Bn n, ref int order)
        {
            if (n != null)
            {
                InOrderVisit(n.L, ref order);
                VisitN(n, ref order);
                InOrderVisit(n.R, ref order);
            }
        }

        public static void PostO(Bn r)
        {
            int order = 0;
            PostOrderVisit(r, ref order);
        }

        private static void PostOrderVisit(Bn n, ref int order)
        {
            if (n != null)
            {
                PostOrderVisit(n.L, ref order);
                PostOrderVisit(n.R, ref order);
                VisitN(n, ref order);
            }
        }

        private static void VisitN(Bn n, ref int order)
        {
            Debug.WriteLine(n.Name);
            n.Order = ++order;
        }
        #endregion

        #region get binary node
        public static Bn GetBn(Bn n, string name)
        {
            if (n != null)
            {
                if (n.Name == name) return n;

                var left = GetBn(n.L, name);
                if (left != null) return left;

                var right = GetBn(n.R, name);
                if (right != null) return right;
            }
            return null;
        }
        #endregion

        #endregion
    }

    #region helper

    public class G
    {
        private int _order;

        public N[] Nodes { get; set; }
    }

    public class N
    {
        public string Name { get; set; }
        public bool HasVisited { get; set; }
        public int Order { get; set; }
        public N[] Children { get; set; }
    }

    public class Bn
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public Bn L { get; set; }
        public Bn R { get; set; }
        public Bn P { get; set; }//parent node
    }

    public class Btr
    {
        private int _order;

        public Bn R { get; set; }
    }

    #endregion
}