using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Cracking
{
    public class Tr
    {
        public Bn CommonAncestor2(Bn n1, Bn n2) 
        {


            throw new NotImplementedException();
        }

        private bool Covers(Bn r, Bn n)
        {
            if (r == null) return false;
            if (r == n) return true;

            return Covers(r.L, n) || Covers(r.R, n);
        }

        public Bn CommonAncestor3(Bn n1, Bn n2)
        {
            throw new NotImplementedException();
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
        //has parent, search like linked list merge note
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
        #endregion

        #region solution three
        #endregion

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