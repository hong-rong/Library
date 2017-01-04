using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ds.Common.SymbolTable;

namespace Lib.Common.Ds.Ht
{
    public class LinearProbingHashST<Key, Value> : ISymbolTable<Key, Value>
    {
        private const int InitCapacity = 4;

        private int _n;
        private int _m;
        private Key[] _keys;
        private Value[] _vals;

        public LinearProbingHashST()
            : this(InitCapacity)
        { }

        public LinearProbingHashST(int capacity)
        {
            _m = capacity;
            _keys = new Key[_m];
            _vals = new Value[_m];
        }

        public int Size()
        {
            return _n;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public bool Contains(Key key)
        {
            return Get(key) != null;
        }

        public void Put(Key key, Value value)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (value == null)
            {
                Delete(key);
                return;
            }

            if (_n >= _m / 2) Resize(2 * _m);

            int i;
            for (i = Hash(key); _keys[i] != null; i = (i + 1) % _m)
                if (_keys[i].Equals(key))
                {
                    _vals[i] = value;
                    return;
                }
            _keys[i] = key;
            _vals[i] = value;
            _n++;
        }

        public Value Get(Key key)
        {
            if (key == null) throw new ArgumentNullException("key");

            for (int i = Hash(key); _keys[i] != null; i = (i + 1) % _m)
                if (_keys[i].Equals(key))
                {
                    return _vals[i];
                }

            return default(Value);
        }

        public void Delete(Key key)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (!Contains(key)) return;

            int i = Hash(key);
            while (!key.Equals(_keys[i]))
            {
                i = (i + 1) % _m;
            }

            _keys[i] = default(Key);
            _vals[i] = default(Value);

            i = (i + 1) % _m;
            while (_keys[i] != null)
            {
                Key keyToRehash = _keys[i];
                Value valueToRehash = _vals[i];
                _keys[i] = default(Key);
                _vals[i] = default(Value);
                _n--;
                Put(keyToRehash, valueToRehash);
                i = (i + 1) % _m;
            }

            _n--;

            if (_n > 0 && _n <= _m / 8) Resize(_m / 2);

            Debug.Assert(Check());
        }

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % _m;
        }

        public IEnumerable<Key> Keys()
        {
            var queue = new Lib.Common.Ds.Queue.Queue<Key>();
            for (var i = 0; i < _m; i++)
                if (_keys[i] != null)
                    queue.Enqueue(_keys[i]);

            foreach (var item in queue)
            {
                yield return item;
            }
        }

        private void Resize(int capacity)
        {
            var temp = new LinearProbingHashST<Key, Value>(capacity);
            for (int i = 0; i < _m; i++)
                if (_keys[i] != null)
                    temp.Put(_keys[i], _vals[i]);

            _keys = temp._keys;
            _vals = temp._vals;
            _m = temp._m;
        }

        private bool Check()
        {
            if (_m < 2 * _n)
            {
                Debug.WriteLine("Hash table size M = " + _m + "; array size N = " + _n);
                return false;
            }

            for (int i = 0; i < _m; i++)
            {
                if (_keys[i] == null) continue;
                else if (!Get(_keys[i]).Equals(_vals[i]))
                {
                    Debug.WriteLine("Get[" + _keys[i] + "]=" + Get(_keys[i]) + "; vals[i]=" + _vals[i]);
                    return false;
                }
            }

            return true;
        }
    }
}
