using Lib.Common.Al.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class UndirectedGraphTest
    {
        [TestMethod]
        public void Adjacent_Test()
        {
            var ug = GraphFactory.CreateUndirectedGraph32();

            //vertice A
            Assert.AreEqual(3, ug.Adjacent(0).Count());

            //vertice B
            Assert.AreEqual(3, ug.Adjacent(1).Count());
            Assert.AreEqual(0, ug.Adjacent(1).ToList()[0].V2);
            Assert.AreEqual(4, ug.Adjacent(1).ToList()[1].V2);
            Assert.AreEqual(5, ug.Adjacent(1).ToList()[2].V2);
        }

        [TestMethod]
        public void AddEdge_No_Path_Test()
        {
            var ug = new UndirectedGraph(10);

            Assert.AreEqual(0, ug.E);
        }

        [TestMethod]
        public void AddEdge_Test()
        {
            var ug = new UndirectedGraph(10);

            ug.AddEdge(4, 0);
            ug.AddEdge(4, 3);
            ug.AddEdge(4, 7);

            Assert.AreEqual(3, ug.E);
        }

        [TestMethod]
        public void AddEdge_Char_Test()
        {
            var ug = GraphFactory.CreateUndirectedGraph41();

            Debug.WriteLine(ug.ToString());
        }
    }
}