using System;
using System.Collections.Generic;

namespace Lib.Common.Ds.Common.St
{
    public abstract class SymbolTableOrderedBase<Key, Value> : ISymbolTableOrdered<Key, Value>
    {
        public abstract Value Get(Key key);

        public abstract void Put(Key key, Value value);

        public abstract void Delete(Key key);

        public virtual bool Contains(Key key)
        {
            return Get(key) != null;
        }

        public virtual bool IsEmpty()
        {
            return Size() == 0;
        }

        public abstract int Size();

        public abstract int Rank(Key key);

        public abstract Key Min();

        public abstract Key Max();

        public virtual void DeleteMax()
        {
            if (IsEmpty()) throw new InvalidOperationException("empty");

            Delete(Max());
        }

        public virtual void DeleteMin()
        {
            if (IsEmpty()) throw new InvalidOperationException("empty");

            Delete(Min());
        }

        public abstract Key Floor(Key key);

        public abstract Key Ceiling(Key key);

        public abstract Key Select(int k);

        public abstract int Size(Key lo, Key hi);

        public abstract IEnumerable<Key> Keys(Key lo, Key hi);
    }
}
