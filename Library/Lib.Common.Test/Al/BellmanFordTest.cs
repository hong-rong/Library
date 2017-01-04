using Lib.Common.Al.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class BellmanFordTest
    {
        [TestMethod]
        public void ShortestPath_Test()
        {
            var g = GraphFactory.GreateDirectedGraph414();
            var stats = BellmanFord.ShortestPath(g, 7);//node char 'S' is 7
            Assert.AreEqual(5, stats.Dist[0]);
            Assert.AreEqual(5, stats.Dist[1]);
            Assert.AreEqual(6, stats.Dist[2]);
            Assert.AreEqual(9, stats.Dist[3]);
            Assert.AreEqual(7, stats.Dist[4]);
            Assert.AreEqual(9, stats.Dist[5]);
            Assert.AreEqual(8, stats.Dist[6]);
            Assert.AreEqual(0, stats.Dist[7]);//start vertice
            Debug.WriteLine(stats);
        }
    }
}
