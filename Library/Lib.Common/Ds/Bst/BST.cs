using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lib.Common.Ds.Common.St;

namespace Lib.Common.Ds.Bst
{
    public class BST<Key, Value> : SymbolTableOrderedBase<Key, Value> where Key : IComparable<Key>
    {
        private BSTNode<Key, Value> _root;

        public BST()
        {
            //if (typeof(Key).IsValueType && Nullable.GetUnderlyingType(typeof(Key)) == null)
            //    throw new InvalidOperationException("Generic Key is not Nullable. Use Nullable<T> for Key.");

            if (typeof(Value).IsValueType && Nullable.GetUnderlyingType(typeof(Value)) == null)
                throw new InvalidOperationException("Generic Value is not Nullable. Use Nullable<T> for Value.");
        }

        public BST(BSTNode<Key, Value> root)
            : this()
        {
            _root = root;

            Debug.Assert(Check());
        }

        public override void Put(Key key, Value value)
        {
            if (value == null)
            {
                Delete(key);
                return;
            }

            _root = Put(_root, key, value);

            Debug.Assert(Check());
        }

        private BSTNode<Key, Value> Put(BSTNode<Key, Value> node, Key key, Value value)
        {
            if (node == null) return new BSTNode<Key, Value>() { Key = key, Value = value, Count = 1 };

            int compare = key.CompareTo(node.Key);

            if (compare < 0) node.Left = Put(node.Left, key, value);
            else if (compare > 0) node.Right = Put(node.Right, key, value);
            else node.Value = value;
            node.Count = Size(node.Left) + Size(node.Right) + 1;

            return node;
        }

        public override Value Get(Key key)
        {
            return GetValue(_root, key);
        }

        private Value GetValue(BSTNode<Key, Value> node, Key key)
        {
            if (node == null) return default(Value);

            int compare = key.CompareTo(node.Key);

            if (compare < 0) return GetValue(node.Left, key);
            if (compare > 0) return GetValue(node.Right, key);

            return node.Value;
        }

        public override void Delete(Key key)
        {
            _root = Delete(_root, key);

            Debug.Assert(Check());
        }

        private BSTNode<Key, Value> Delete(BSTNode<Key, Value> node, Key key)
        {
            if (node == null) return null;

            int cmp = key.CompareTo(node.Key);

            if (cmp < 0) node.Left = Delete(node.Left, key);
            else if (cmp > 0) node.Right = Delete(node.Right, key);
            else
            {
                if (node.Right == null) return node.Left;
                if (node.Left == null) return node.Right;
                BSTNode<Key, Value> t = node;
                node = Min(t.Right);
                node.Right = DeleteMin(t.Right);
                node.Left = t.Left;
            }

            node.Count = Size(node.Left) + Size(node.Right) + 1;

            return node;
        }

        public override void DeleteMin()
        {
            if (IsEmpty()) throw new InvalidOperationException("empty");

            _root = DeleteMin(_root);

            Debug.Assert(Check());
        }

        private BSTNode<Key, Value> DeleteMin(BSTNode<Key, Value> node)
        {
            if (node.Left == null) return node.Right;
            node.Left = DeleteMin(node.Left);
            node.Count = Size(node.Left) + Size(node.Right) + 1;

            return node;
        }

        public override void DeleteMax()
        {
            if (IsEmpty()) throw new InvalidOperationException("empty");

            _root = DeleteMax(_root);

            Debug.Assert(Check());
        }

        private BSTNode<Key, Value> DeleteMax(BSTNode<Key, Value> node)
        {
            if (node.Right == null) return node.Left;
            node.Right = DeleteMax(node.Right);
            node.Count = Size(node.Left) + Size(node.Right) + 1;

            return node;
        }

        public override int Size()
        {
            return Size(_root);
        }

        private int Size(BSTNode<Key, Value> node)
        {
            if (node == null) return 0;

            return node.Count;
        }

        public override Key Min()
        {
            if (IsEmpty()) return default(Key);

            return Min(_root).Key;
        }

        private BSTNode<Key, Value> Min(BSTNode<Key, Value> node)
        {
            if (node.Left == null) return node;

            return Min(node.Left);
        }

        public override Key Max()
        {
            if (IsEmpty()) return default(Key);

            return Max(_root).Key;
        }

        private BSTNode<Key, Value> Max(BSTNode<Key, Value> node)
        {
            if (node.Right == null) return node;

            return Max(node.Right);
        }

        public override Key Floor(Key key)
        {
            var node = Floor(key, _root);

            return node == null ? default(Key) : node.Key;
        }

        private BSTNode<Key, Value> Floor(Key key, BSTNode<Key, Value> node)
        {
            if (node == null) return null;
            int cmp = key.CompareTo(node.Key);
            if (cmp == 0) return node;
            if (cmp < 0) return Floor(key, node.Left);

            BSTNode<Key, Value> t = Floor(key, node.Right);
            if (t != null) return t;

            return node;
        }

        public override Key Ceiling(Key key)
        {
            var node = Ceiling(key, _root);

            return node == null ? default(Key) : node.Key;
        }

        private BSTNode<Key, Value> Ceiling(Key key, BSTNode<Key, Value> node)
        {
            if (node == null) return null;

            int cmp = key.CompareTo(node.Key);
            if (cmp == 0) return node;

            if (cmp < 0)
            {
                BSTNode<Key, Value> t = Ceiling(key, node.Left);
                if (t != null) return t;

                return node;
            }

            return Ceiling(key, node.Right);
        }

        public override int Rank(Key key)
        {
            return Rank(key, _root);
        }

        private int Rank(Key key, BSTNode<Key, Value> node)
        {
            if (node == null) return 0;

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0) return Rank(key, node.Left);
            if (cmp > 0) return 1 + Size(node.Left) + Rank(key, node.Right);

            return Size(node.Left);
        }

        public override Key Select(int k)
        {
            if (k < 0 || k > Size()) return default(Key);

            var node = Select(_root, k);

            return node.Key;
        }

        private BSTNode<Key, Value> Select(BSTNode<Key, Value> node, int k)
        {
            if (node == null) return null;

            int t = Size(node.Left);

            if (t > k) return Select(node.Left, k);
            else if (t < k) return Select(node.Right, k - t - 1);
            else return node;
        }

        public override int Size(Key lo, Key hi)
        {
            if (lo.CompareTo(hi) > 0) return 0;
            if (Contains(hi)) return Rank(hi) - Rank(lo) + 1;
            else return Rank(hi) - Rank(lo);
        }

        public virtual IEnumerable<Key> Keys()
        {
            return Keys(Min(), Max());
        }

        public override IEnumerable<Key> Keys(Key lo, Key hi)
        {
            var queue = new Queue.Queue<Key>();
            Keys(_root, queue, lo, hi);

            foreach (var linkNode in queue)
            {
                yield return linkNode;
            }
        }

        private void Keys(BSTNode<Key, Value> node, global::Lib.Common.Ds.Queue.Queue<Key> queue, Key lo, Key hi)
        {
            if (node == null) return;

            int cmplo = lo.CompareTo(node.Key);
            int cmphi = hi.CompareTo(node.Key);
            if (cmplo < 0) Keys(node.Left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0) queue.Enqueue(node.Key);
            if (cmphi > 0) Keys(node.Right, queue, lo, hi);
        }

        public int Height()
        {
            //height of this BST (one-node tree has height 0)
            return Height(_root);
        }

        private int Height(BSTNode<Key, Value> node)
        {
            if (node == null) return -1;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        public IEnumerable<Key> LevelOrder()
        {
            var keys = new global::Lib.Common.Ds.Queue.Queue<Key>();
            var queue = new global::Lib.Common.Ds.Queue.Queue<BSTNode<Key, Value>>();
            queue.Enqueue(_root);
            while (!queue.IsEmpty())
            {
                BSTNode<Key, Value> node = queue.Dequeue();
                if (node == null) continue;
                keys.Enqueue(node.Key);
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }

            foreach (var linkNode in keys)
            {
                yield return linkNode;
            }
        }

        private bool Check()
        {
            if (!IsBST()) Debug.WriteLine("Not in symmetric order");
            if (!IsSizeConsistent()) Debug.WriteLine("Subtree counts not consistent");
            if (!IsRankConsistent()) Debug.WriteLine("Ranks not consistant");

            return IsBST() && IsSizeConsistent() && IsRankConsistent();
        }

        private bool IsRankConsistent()
        {
            for (int i = 0; i < Size(); i++)
                if (i != Rank(Select(i))) return false;

            foreach (var key in Keys())
                if (key.CompareTo(Select(Rank(key))) != 0) return false;

            return true;
        }

        private bool IsSizeConsistent()
        {
            return IsSizeConsistent(_root);
        }

        private bool IsSizeConsistent(BSTNode<Key, Value> node)
        {
            if (node == null) return true;
            if (node.Count != Size(node.Left) + Size(node.Right) + 1) return false;

            return IsSizeConsistent(node.Left) && IsSizeConsistent(node.Right);
        }

        private bool IsBST()
        {
            return IsBST(_root, default(Key), default(Key));
        }

        private bool IsBST(BSTNode<Key, Value> node, Key min, Key max)
        {
            if (node == null) return true;
            if (min != null && node.Key.CompareTo(min) <= 0) return false;
            if (max != null && node.Key.CompareTo(max) >= 0) return false;

            return IsBST(node.Left, min, node.Key) && IsBST(node.Right, node.Key, max);
        }
    }
}