using System;
using System.Collections.Generic;
using Ds.Common.SymbolTable;
using Lib.Common.Ds.Bs;

namespace Lib.Common.Ds.Ht
{
    public class SymbolTableHash<Key, Value> : ISymbolTable<Key, Value>
    {
        private const int InitialCapacity = 4;
        private int _n;
        private int _m;
        private SequentialSearchST<Key, Value>[] _st;

        public SymbolTableHash()
            : this(InitialCapacity)
        { }

        public SymbolTableHash(int capacity)
        {
            _m = capacity;
            _st = new SequentialSearchST<Key, Value>[_m];
            for (int i = 0; i < _st.Length; i++)
                _st[i] = new SequentialSearchST<Key, Value>();
        }

        public Value Get(Key key)
        {
            if (key == null) throw new ArgumentNullException("key");

            int i = GetHash(key);

            return _st[i].Get(key);
        }

        private int GetHash(Key key)
        {
            return (key.GetHashCode() & 0x7FFFFFFF) % _m;
        }

        public void Put(Key key, Value value)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (value == null)
            {
                Delete(key);
                return;
            }

            if (_n > 10 * _m) Resize(2 * _m);

            int i = GetHash(key);
            if (!_st[i].Contains(key)) ++_n;
            _st[i].Put(key, value);
        }

        public void Delete(Key key)
        {
            if (key == null) throw new ArgumentNullException("key");

            int i = GetHash(key);
            if (_st[i].Contains(key)) --_n;
            _st[i].Delete(key);

            if (_m > InitialCapacity && _n <= 2 * _m) Resize(_m / 2);
        }

        public bool Contains(Key key)
        {
            if (key == null) throw new ArgumentNullException("key");

            return Get(key) != null;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public int Size()
        {
            return _n;
        }

        public IEnumerable<Key> Keys()
        {
            var queue = new global::Lib.Common.Ds.Queue.Queue<Key>();

            for (int i = 0; i < _st.Length; i++)
                foreach (var key in _st[i].Keys())
                    queue.Enqueue(key);

            foreach (var item in queue)
                yield return item;
        }

        private void Resize(int capacity)
        {
            var temp = new SymbolTableHash<Key, Value>(capacity);
            for (int i = 0; i < _st.Length; i++)
                foreach (var key in _st[i].Keys())
                    temp.Put(key, _st[i].Get(key));

            _m = temp._m;
            _n = temp._n;
            _st = temp._st;
        }
    }
}