using Lib.Common.Al.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class DagShortestPathTest
    {
        [TestMethod]
        public void ShortestPath_Test()
        {
            var g = GraphFactory.CreateDirectedGraph61();
            var stats = DagShortestPath.ShortestPath(g, 5);//node char 'S' is 5
            Assert.AreEqual(1, stats.Dist[0]);
            Assert.AreEqual(7, stats.Dist[1]);
            Assert.AreEqual(2, stats.Dist[2]);
            Assert.AreEqual(5, stats.Dist[3]);
            Assert.AreEqual(6, stats.Dist[4]);
            Assert.AreEqual(0, stats.Dist[5]);//start vertice
            Debug.WriteLine(stats);
        }
    }
}
