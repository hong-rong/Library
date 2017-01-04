using System.Collections.Generic;
using Ds.Common.SymbolTable;

namespace Lib.Common.Ds.Common.St
{
    public interface ISymbolTableOrdered<Key, Value> : ISymbolTable<Key, Value>
    {
        int Rank(Key key);

        Key Min();

        Key Max();

        void DeleteMin();

        void DeleteMax();

        Key Floor(Key key);

        Key Ceiling(Key key);

        Key Select(int k);

        int Size(Key lo, Key hi);

        IEnumerable<Key> Keys(Key lo, Key hi);
    }
}
