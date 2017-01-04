using Ds.Common.SymbolTable;
using Lib.Common.Ds.Ht;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds.St
{
    [TestClass]
    public class LinearProbingHashSTTests : STTestBase
    {
        protected override ISymbolTable<string, int?> CreateST()
        {
            var hash = new LinearProbingHashST<string, int?>();

            hash.Put("S", 0);
            hash.Put("E", 1);
            hash.Put("A", 2);
            hash.Put("R", 3);
            hash.Put("C", 4);
            hash.Put("H", 5);
            hash.Put("E", 6);
            hash.Put("X", 7);
            hash.Put("A", 8);
            hash.Put("M", 9);
            hash.Put("P", 10);
            hash.Put("L", 11);
            hash.Put("E", 12);

            return hash;
        }

        protected override ISymbolTable<string, int?> CreateEmptyST()
        {
            return new SeperateChainingHashST<string, int?>();
        }
    }
}
