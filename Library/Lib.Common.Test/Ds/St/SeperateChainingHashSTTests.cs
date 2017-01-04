using Ds.Common.SymbolTable;
using Lib.Common.Ds.Ht;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds.St
{
    [TestClass]
    public class SeperateChainingHashSTTests : STTestBase
    {
        protected override ISymbolTable<string, int?> CreateST()
        {
            var st = new SeperateChainingHashST<string, int?>();

            st.Put("S", 0);
            st.Put("E", 1);
            st.Put("A", 2);
            st.Put("R", 3);
            st.Put("C", 4);
            st.Put("H", 5);
            st.Put("E", 6);
            st.Put("X", 7);
            st.Put("A", 8);
            st.Put("M", 9);
            st.Put("P", 10);
            st.Put("L", 11);
            st.Put("E", 12);

            return st;
        }

        protected override ISymbolTable<string, int?> CreateEmptyST()
        {
            return new SeperateChainingHashST<string, int?>();
        }
    }
}