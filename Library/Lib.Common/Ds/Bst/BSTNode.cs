using System;
using Lib.Common.Ds.Common;

namespace Lib.Common.Ds.Bst
{
    public class BSTNode<TKey, TValue> : BinaryNodeBase<TValue, BSTNode<TKey, TValue>> where TKey : IComparable<TKey>
    {
        public int Count;
        public TKey Key;
    }
}