using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Cracking
{
    public class TreeAndDp
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

        public int FindMagicIndexWithDups(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException();
            return FindMagicIndexWithDups(arr, 0, arr.Length - 1);
        }

        private int FindMagicIndexWithDups(int[] arr, int l, int h)
        {
            if (l > h) return -1;
            int m = (l + h) / 2;
            if (arr[m] > m) return FindMagicIndexWithDups(arr, l, m - 1);
            if (arr[m] < m) return FindMagicIndexWithDups(arr, m + 1, h);
            return m;
        }

        #region dp

        #region TrStep
        // either utilize the recursive formula or use dynamic programming
        public int TrStep(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 1 + TrStep(1);
            if (n == 3) return 1 + TrStep(2) + TrStep(1);
            return TrStep(n - 1) + TrStep(n - 2) + TrStep(n - 3);
        }

        public int TrStepBrute(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            return TrStepBrute(n - 1) + TrStepBrute(n - 2) + TrStepBrute(n - 3);
        }

        public int TrStepMemo(int n)
        {
            int[] memo = new int[n + 1];
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = -1;
            }
            return TrySetpMemo(n, memo);
        }

        private int TrySetpMemo(int n, int[] memo)
        {

            if (n < 0) return 0;
            if (n == 0) return 1;
            if (memo[n] != -1)
            {
                return memo[n];
            }
            return TrySetpMemo(n - 1, memo) + TrySetpMemo(n - 2, memo) + TrySetpMemo(n - 3, memo);
        }
        #endregion

        #region recursive multiply

        public int MultiplyByRec(int a, int b)
        {
            int small = a > b ? b : a;
            int large = a > b ? a : b;
            return AddByRec(small, large);
        }

        private int AddByRec(int s, int l)
        {
            if (s == 0) return 0;
            if (s == 1) return l;
            int h = s >> 1;
            var left = AddByRec(h, l);
            var right = AddByRec(s - h, l);
            return left + right;
        }

        public int MultiplyByRecWithMemo(int a, int b)
        {
            int small = a > b ? b : a;
            int large = a > b ? a : b;
            var memo = new Dictionary<int, int>();
            return AddByRecWithMemo(memo, small, large);
        }

        private int AddByRecWithMemo(Dictionary<int, int> memo, int s, int l)
        {
            if (s == 0) return 0;
            if (s == 1) return l;
            if (memo.ContainsKey(s)) return memo[s];
            int h = s >> 1;
            int left = AddByRecWithMemo(memo, h, l);
            int right = AddByRecWithMemo(memo, s - h, l);
            int sum = left + right;
            memo.Add(s, sum);
            return sum;
        }

        #endregion

        #region robot find path
        public Stack<Point> FindPath(int[][] grid)
        {
            if (grid == null) throw new ArgumentNullException();
            var track = new Stack<Point>();
            FindPath(grid, 0, 0, track);
            return track;
        }

        private bool FindPath(int[][] grid, int r, int c, Stack<Point> track)
        {
            if (r > grid.Length - 1 || c > grid[grid.Length - 1].Length - 1 || grid[r][c] == 0) return false;
            var hasReached = r == grid.Length - 1 && c == grid[grid.Length - 1].Length - 1;
            if (FindPath(grid, r + 1, c, track) || FindPath(grid, r, c + 1, track) || hasReached)
            {
                track.Push(new Point(r, c));
                return true;
            }
            return false;
        }

        public Stack<Point> FindPathOptimsed(int[][] grid)
        {
            if (grid == null) throw new ArgumentNullException();
            var track = new Stack<Point>();
            var h = new HashSet<Point>();
            FindPathOptimsed(grid, 0, 0, track, h);
            return track;
        }

        private bool FindPathOptimsed(int[][] grid, int r, int c, Stack<Point> track, HashSet<Point> h)
        {
            if (r > grid.Length - 1 || c > grid[grid.Length - 1].Length - 1 || grid[r][c] == 0) return false;
            var hasReached = r == grid.Length - 1 && c == grid[grid.Length - 1].Length - 1;
            var t = new Point(r, c);
            if (!h.Contains(t))
            {
                if (FindPathOptimsed(grid, r + 1, c, track, h) || FindPathOptimsed(grid, r, c + 1, track, h) || hasReached)
                {
                    track.Push(t);
                    return true;
                }
                h.Add(t);
            }
            return false;
        }
        public struct Point
        {
            private readonly int _r;
            private readonly int _c;

            public Point(int r, int c)
            {
                _r = r;
                _c = c;
            }

            public override string ToString()
            {
                return string.Format("({0},{1})", _r, _c);
            }
        }

        #endregion

        #region all subsets

        public List<List<T>> GetAllSubsetTest<T>(List<T> list)
        {
            if (list == null) throw new ArgumentNullException();
            var all = GetSubets(list);
            for (var i = 0; i < all.Count; i++)
            {
                Debug.WriteLine(string.Join("   ", all[i]));
            }
            Debug.WriteLine("total: " + all.Count);
            return all;
        }

        private List<List<T>> GetSubets<T>(List<T> list)
        {
            if (list.Count == 1) return new List<List<T>> { list };
            var all = new List<List<T>>();
            var first = list[0];
            var rest = new List<T>();
            for (var i = 1; i < list.Count; i++)
            {
                rest.Add(list[i]);
            }
            var subs = GetSubets(rest);
            all.Add(new List<T> { first });
            all.AddRange(subs);
            for (var i = 0; i < subs.Count; i++)
            {
                var temp = new List<T> { first };
                for (var j = 0; j < subs[i].Count; j++)
                {
                    temp.Add(subs[i][j]);//make a copy if T is object
                }
                all.Add(temp);
            }
            return all;
        }
        #endregion

        #region find magic index
        public int FindMagicIndex(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException();
            return FindMagicIndex(arr, 0, arr.Length - 1);
        }

        private int FindMagicIndex(int[] arr, int l, int h)
        {
            if (l > h || arr[h] < l || arr[l] > h) return -1;
            int m = (l + h) / 2;
            if (arr[m] > m) return FindMagicIndex(arr, l, m - 1);
            if (arr[m] < m) return FindMagicIndex(arr, m + 1, h);
            return m;
        }
        #endregion

        #region coins
        //25*4, 0 others
        //25*3, 25 others
        //	10*2, 5 others
        //		5*1, 0 others
        //		5*0, 5 others
        //			1*5, 0 others
        //	10*1, 15 others
        //		5*3, 0 thers
        //		5*2, 5 others
        //			1*5, 0 others
        //		5*1, 10 others
        //            ...
        //		5*0, 15 others
        //            ...
        //	10*0, 25 others
        //        ...
        //25*2, 50 others
        //	10*5, 0 others
        //        ...
        //	10*4, 1 others
        //    ...
        //25*1, 75 others
        //    ...
        //25*0, 100 others
        //    ...
        public int CountC(int n)
        {
            int[] coins = { 25, 10, 5, 1 };
            return Count(coins, 0, n);
        }

        private int Count(int[] coins, int index, int amount)
        {
            //if (amount == 0 || index == (coins.Length - 1)) return 1;
            if (index == coins.Length - 1) return 1;
            int sum = 0;
            for (int i = 0; ; i++)
            {
                var leftAmount = amount - i * coins[index];
                if (leftAmount < 0) break;
                sum = sum + Count(coins, index + 1, leftAmount);
            }
            return sum;
        }

        public int CountCMemo(int n)
        {
            int[] coins = { 25, 10, 5, 1 };
            var memo = new int[n + 1, coins.Length];
            return CountMemo(memo, coins, 0, n);
        }

        private int CountMemo(int[,] memo, int[] coins, int index, int amount)
        {
            if (index == coins.Length - 1) return 1;
            if (memo[amount, index] > 0) return memo[amount, index];
            int sum = 0;
            for (int i = 0; ; i++)
            {
                var leftAmount = amount - i * coins[index];
                if (leftAmount < 0) break;
                sum = sum + CountMemo(memo, coins, index + 1, leftAmount);
            }
            memo[amount, index] = sum;
            return sum;
        }
        #endregion

        #region all perm for unique by insertion
        //12: 12,21 ->312,132,123;321,231,213
        //123: 123,132;213,232;312,321
        public List<string> GetAllPermForUnique_ByInsertion(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new ArgumentNullException();
            var all = GetPermForUnique_ByInsertion(s);
            Debug.WriteLine(string.Join(", ", all));
            Debug.WriteLine("total: {0}", all.Count);
            return all;
        }

        private List<string> GetPermForUnique_ByInsertion(string s)
        {
            if (s.Length == 1) return new List<string> { s };
            var all = new List<string>();
            var first = s.Substring(0, 1);
            var rest = s.Substring(1, s.Length - 1);
            var subPerms = GetPermForUnique_ByInsertion(rest);
            for (int i = 0; i < subPerms.Count; i++)
            {
                for (int j = 0; j <= subPerms[i].Length; j++)
                {
                    var temp = subPerms[i].Insert(j, first);
                    all.Add(temp);
                }
            }
            return all;
        }
        #endregion

        #region all perm for unique by prefix
        public List<string> GetAllPermForUnique_ByPrefix(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new ArgumentNullException();
            var all = GetPermForUnique_ByPrefix(s);
            Debug.WriteLine(string.Join(", ", all));
            Debug.WriteLine("total: {0}", all.Count);
            return all;
        }

        private List<string> GetPermForUnique_ByPrefix(string s)
        {
            if (s.Length == 1) return new List<string> { s };
            var all = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                var subPerms = GetPermForUnique_ByPrefix(s.Remove(i, 1));
                for (int j = 0; j < subPerms.Count; j++)
                {
                    var temp = string.Format("{0}{1}", s[i], subPerms[j]);
                    all.Add(temp);
                }
            }
            return all;
        }
        #endregion

        #region perm with dups
        public List<string> GetAllPermForDup(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new ArgumentNullException();
            var all = GetPermForDup(s);
            Debug.WriteLine(string.Join(", ", all));
            Debug.WriteLine("total: {0}", all.Count);
            return all;
        }

        private List<string> GetPermForDup(string s)
        {
            if (s.Length == 1) return new List<string> { s };
            var all = new HashSet<string>();
            var first = s.Substring(0, 1);
            var rest = s.Substring(1);
            var subPerms = GetPermForDup(rest);
            for (int i = 0; i < subPerms.Count; i++)
            {
                for (int j = 0; j <= subPerms[i].Length; j++)
                {
                    var temp = subPerms[i].Insert(j, first);
                    if (!all.Contains(temp))
                    {
                        all.Add(temp);
                    }
                }
            }
            return all.ToList();
        }
        #endregion

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

    public class Tr
    {
        public N R { get; set; }
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