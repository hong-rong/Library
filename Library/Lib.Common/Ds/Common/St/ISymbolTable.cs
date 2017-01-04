namespace Ds.Common.SymbolTable
{
    public interface ISymbolTable<Key, Value>
    {
        Value Get(Key key);

        void Put(Key key, Value value);

        void Delete(Key key);

        bool Contains(Key key);

        bool IsEmpty();

        int Size();
    }
}
