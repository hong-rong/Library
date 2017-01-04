using System;
using System.Collections.Generic;
using System.Text;
using Ds.Common.SymbolTable;
using Lib.Common.Ds.Common;
using Lib.Common.Ds.Common.Enumeration;

namespace Lib.Common.Ds.Bs
{
    /// <summary>
    /// Symbol table(key, value pair) uses linked list implementation
    /// note that for value type Value, use nullable
    /// </summary>
    public class SequentialSearchST<Key, Value> : SequentialSearchStEnumerable<Key, Value>, ISymbolTable<Key, Value>
    {
        private int _n;

        public SequentialSearchST()
        {
            if (typeof(Value).IsValueType && Nullable.GetUnderlyingType(typeof(Value)) == null)
                throw new InvalidOperationException("Generic Value is not Nullable. Use Nullable<T> for Value.");

            _n = 0;
            Header = null;
        }

        public void Put(Key key, Value value)
        {
            //if (value = default(Value))//why?
            if (value == null)
            {
                Delete(key);
                return;
            }

            var current = new LinkNodeST<Key, Value> { Next = Header };
            while (current.Next != null)
            {
                if (current.Next.Key.Equals(key))
                {
                    current.Next.Value = value;
                    return;
                }

                current = current.Next;
            }

            Header = new LinkNodeST<Key, Value> { Key = key, Value = value, Next = Header };
            ++_n;
        }

        /// <summary>
        /// recursive way, performance bad when symbol table is large
        /// </summary>
        /// <param name="key"></param>
        public void Delete_Recursive(Key key)
        {
            Header = Delete_Recursive(Header, key);
        }

        private LinkNodeST<Key, Value> Delete_Recursive(LinkNodeST<Key, Value> node, Key key)
        {
            if (node == null) return null;

            if (node.Key.Equals(key))
            {
                --_n;
                return node.Next;
            }

            node.Next = Delete_Recursive(node.Next, key);

            return node;
        }

        /// <summary>
        /// non-recursive way
        /// </summary>
        public void Delete(Key key)
        {
            var current = new LinkNodeST<Key, Value> { Next = Header };
            while (current.Next != null)
            {
                if (current.Next.Key.Equals(key))
                {
                    --_n;
                    current.Next = current.Next.Next;
                    return;
                }

                current = current.Next;
            }
        }

        public Value Get(Key key)
        {
            var current = Header;

            while (current != null)
            {
                if (current.Key.Equals(key))
                    return current.Value;

                current = current.Next;
            }

            return default(Value);
        }

        public bool Contains(Key key)
        {
            return Get(key) != null;
        }

        public bool IsEmpty()
        {
            return Header == null;
        }

        public int Size()
        {
            return _n;
        }

        public IEnumerable<Key> Keys()
        {
            foreach (var key in this)
                yield return key;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var key in this)
            {
                sb.Append(string.Format("{0} {1} ", key, Get(key)));
            }

            return sb.ToString();
        }
    }
}