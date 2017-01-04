using Lib.Common.Al.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class DijkstraTest
    {
        [TestMethod]
        public void ShortestPath_Test()
        {
            var g = GraphFactory.CreateDirectedGraph49();
            var ds = Dijkstra.ShortestPath(g, 0);//start vertice: A

            //previous node
            Assert.AreEqual(-1, ds.Prev[0]);//start point set to -1
            Assert.AreEqual(2, ds.Prev[1]);
            Assert.AreEqual(0, ds.Prev[2]);
            Assert.AreEqual(1, ds.Prev[3]);
            Assert.AreEqual(1, ds.Prev[4]);

            //distanct
            Assert.AreEqual(0, ds.Dist[0]);
            Assert.AreEqual(3, ds.Dist[1]);
            Assert.AreEqual(2, ds.Dist[2]);
            Assert.AreEqual(5, ds.Dist[3]);
            Assert.AreEqual(6, ds.Dist[4]);

            Debug.WriteLine(ds);
        }

        [TestMethod]
        public void LongestPath_Test()
        {
            var g = GraphFactory.CreateDirectedGraph49_Modfied();
            var ds = Dijkstra.LongestPath(g, 0);//start vertice: A

            //previous node
            Assert.AreEqual(-1, ds.Prev[0]);//start point set to -1
            Assert.AreEqual(0, ds.Prev[1]);
            Assert.AreEqual(1, ds.Prev[2]);
            Assert.AreEqual(4, ds.Prev[3]);
            Assert.AreEqual(2, ds.Prev[4]);

            //distanct
            Assert.AreEqual(0, ds.Dist[0]);
            Assert.AreEqual(4, ds.Dist[1]);
            Assert.AreEqual(7, ds.Dist[2]);
            Assert.AreEqual(13, ds.Dist[3]);
            Assert.AreEqual(12, ds.Dist[4]);

            Debug.WriteLine(ds);
        }
    }
}