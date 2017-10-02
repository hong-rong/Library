using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Cracking
{
    public class Tr
    {


        #region test
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

        #region validate bst
        public bool ValidateBst(Bn n)
        {
            if (n == null) throw new ArgumentNullException();
            int index = 0;
            int[] arr = new int[n.Count];
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
    }

    #region helper

    public class G
    {
        private int _order;

        public N[] Nodes { get; set; }

        #region t sort

        public List<N> BuildOrder()
        {
            if (Nodes == null || Nodes.Length <= 0) throw new ArgumentException("Empty");

            var nodeOrders = new List<N>();
            for (int i = 0; i < Nodes.Length; i++)
            {
                if (!Nodes[i].HasVisited)
                {
                    TopSort(Nodes[i], nodeOrders);
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

        #region travel
        public void Dfs()
        {
            if (Nodes == null || Nodes.Length < 0) throw new ArgumentNullException();
            Dfs(Nodes[0]);
        }

        private void Dfs(N n)
        {
            if (n != null)
            {
                VisitN(n);
                if (n.Children != null && n.Children.Length > 0)
                {
                    for (int i = 0; i < n.Children.Length; i++)
                    {
                        if (n.Children[i].Order == 0)
                        {
                            Dfs(n.Children[i]);
                        }
                    }
                }
            }
        }

        private void VisitN(N n)
        {
            Debug.WriteLine(n.Name);
            n.Order = ++_order;
        }

        public void Bfs()
        {
            if (Nodes == null || Nodes.Length < 0) throw new ArgumentNullException();
            Queue<N> q = new Queue<N>();
            q.Enqueue(Nodes[0]);
            Nodes[0].HasVisited = true;

            while (q.Count > 0)
            {
                N n = q.Dequeue();
                VisitN(n);
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

        public int Count
        {
            get { return GetCount(this); }
        }

        private int GetCount(Bn n)
        {
            if (n == null) return 0;
            return GetCount(n.L) + GetCount(n.R) + 1;
        }

        #region H

        public int H
        {
            get { return Height(this) - 1; }
        }

        private int Height(Bn n)
        {
            if (n == null) return 0;
            int l = Height(n.L);
            int r = Height(n.R);
            return l >= r ? l + 1 : r + 1;
        }

        #endregion

        #region GetListOfD
        public List<Bn>[] GetListOfD()
        {
            List<Bn>[] list = new List<Bn>[H + 1];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new List<Bn>();
            }
            GetListOfD(list, this, 0);
            return list;
        }

        private void GetListOfD(List<Bn>[] list, Bn n, int level)
        {
            if (n != null)
            {
                list[level].Add(n);
                level++;
                GetListOfD(list, n.L, level);
                GetListOfD(list, n.R, level);
            }
        }

        #endregion

        #region IsBalanced
        public bool IsBalanced()
        {
            return IsBalanced(this).IsBalanced;
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
    }

    public class Btr
    {
        private int _order;
        public Bn R { get; set; }

        #region travel
        public void PreO()
        {
            PreO(R);
        }

        private void PreO(Bn n)
        {
            if (n != null)
            {
                VisitN(n);
                PreO(n.L);
                PreO(n.R);
            }
        }

        public void InO()
        {
            InO(R);
        }

        private void InO(Bn n)
        {
            if (n != null)
            {
                InO(n.L);
                VisitN(n);
                InO(n.R);
            }
        }

        public void PostO()
        {
            PostO(R);
        }

        private void PostO(Bn n)
        {
            if (n != null)
            {
                PostO(n.L);
                PostO(n.R);
                VisitN(n);
            }
        }
        #endregion

        public Bn GetBn(string name)
        {
            return GetBn(R, name);
        }

        private Bn GetBn(Bn n, string name)
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

        private void VisitN(Bn n)
        {
            Debug.WriteLine(n.Name);
            n.Order = ++_order;
        }
    }

    #endregion
}