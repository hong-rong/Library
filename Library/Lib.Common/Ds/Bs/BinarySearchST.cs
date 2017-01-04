using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lib.Common.Ds.Common.St;

namespace Lib.Common.Ds.Bs
{
    public class BinarySearchST<Key, Value> : SymbolTableOrderedBase<Key, Value> where Key : IComparable<Key>
    {
        private const int InitialCapacity = 2;
        private Key[] _keys;
        private Value[] _values;
        private int _n;

        public BinarySearchST(Key[] keys, Value[] values)
        {
            if (typeof(Value).IsValueType && Nullable.GetUnderlyingType(typeof(Value)) == null)
                throw new InvalidOperationException("Generic Value is not Nullable. Use Nullable<T> for Value.");

            _keys = keys;
            _values = values;
            _n = keys.Length;
        }

        public BinarySearchST()
            : this(InitialCapacity)
        { }

        public BinarySearchST(int capacity)
        {
            if (typeof(Value).IsValueType && Nullable.GetUnderlyingType(typeof(Value)) == null)
                throw new InvalidOperationException(string.Format("Generic Value is not Nullable. Use Nullable<T> for Value."));

            _keys = new Key[capacity];
            _values = new Value[capacity];
            _n = 0;
        }

        public override void Put(Key key, Value value)
        {
            if (value == null)
            {
                Delete(key);
                return;
            }

            var i = Rank(key);
            if (i < _n && _keys[i].CompareTo(key) == 0)
            {
                _values[i] = value;
                return;
            }

            if (_n == _keys.Length)
                Resize(_keys.Length * 2);

            //insert new key value pair in a proper position
            for (int j = _n; j > i; j--)
            {
                _keys[j] = _keys[j - 1];
                _values[j] = _values[j - 1];
            }

            _keys[i] = key;
            _values[i] = value;

            ++_n;
        }

        public override Value Get(Key key)
        {
            if (IsEmpty()) return default(Value);

            var i = Rank(key);

            if (i < _n && _keys[i].CompareTo(key) == 0) return _values[i];

            return default(Value);
        }

        public override void Delete(Key key)
        {
            if (IsEmpty()) return;

            int i = Rank(key);

            if (i == _n || _keys[i].CompareTo(key) != 0) return;

            for (int j = i; j < _n - 1; j++)
            {
                _keys[j] = _keys[j + 1];
                _values[j] = _values[j + 1];
            }

            --_n;
            _keys[_n] = default(Key);
            _values[_n] = default(Value);

            if (_n > 0 && _n == _keys.Length / 4)
                Resize(_keys.Length / 2);

            Debug.Assert(Check());
        }

        public override int Size()
        {
            return _n;
        }

        private void Resize(int capacity)
        {
            if (capacity <= _n) throw new InvalidOperationException("capacity cannot smaller than current size");

            var keys = new Key[capacity];
            var values = new Value[capacity];
            for (int i = 0; i < _n; i++)
            {
                keys[i] = _keys[i];
                values[i] = _values[i];
            }
            _keys = keys;
            _values = values;
        }

        #region ordered symbol table methods

        /// <summary>
        /// get number of key smaller than specified key
        /// </summary>
        public override int Rank(Key key)
        {
            int lo = 0;
            int hi = _n - 1;
            while (lo <= hi)
            {
                int m = (hi + lo) / 2;
                int cmp = key.CompareTo(_keys[m]);
                if (cmp < 0) hi = m - 1;
                else if (cmp > 0) lo = m + 1;
                else return m;
            }

            return lo;
        }

        public int Rank_Recursive(Key key)
        {
            return Rank_Recursive(0, _n - 1, key);
        }

        private int Rank_Recursive(int lo, int hi, Key key)
        {
            if (lo > hi) return lo;
            int m = (lo + hi) / 2;
            int cmp = key.CompareTo(_keys[m]);
            if (cmp < 0) return Rank_Recursive(lo, m - 1, key);
            if (cmp > 0) return Rank_Recursive(m + 1, hi, key);

            return m;
        }

        public override Key Min()
        {
            return IsEmpty() ? default(Key) : _keys[0];
        }

        public override Key Max()
        {
            return IsEmpty() ? default(Key) : _keys[_n - 1];
        }

        public override Key Floor(Key key)
        {
            int i = Rank(key);

            if (i == 0) return default(Key);

            if (i < _n && key.CompareTo(_keys[i]) == 0) return _keys[i];

            return _keys[i - 1];
        }

        public override Key Ceiling(Key key)
        {
            int i = Rank(key);

            if (i == _n) return default(Key);

            return _keys[i];
        }

        public override Key Select(int k)
        {
            if (k < 0 || k >= _n) return default(Key);

            return _keys[k];
        }

        public override IEnumerable<Key> Keys(Key lo, Key hi)
        {
            throw new NotImplementedException();
        }

        public override int Size(Key lo, Key hi)
        {
            throw new NotImplementedException();
        }

        private bool Check()
        {
            return IsSorted() && RankCheck();
        }

        private bool RankCheck()
        {
            for (int i = 0; i < Size(); i++)
                if (i != Rank(Select(i))) return false;

            for (int j = 0; j < Size(); j++)
                if (_keys[j].CompareTo(Select(Rank(_keys[j]))) != 0)
                    return false;

            return true;
        }

        private bool IsSorted()
        {
            for (int i = 1; i < Size(); i++)
                if (_keys[i].CompareTo(_keys[i - 1]) < 0)
                    return false;

            return true;
        }

        #endregion
    }
}