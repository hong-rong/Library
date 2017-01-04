using Lib.Common.Al.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class BfsTest
    {
        [TestMethod]
        public void BreadthFirstSearch_Test()
        {
            var ug = GraphFactory.CreateUndirectedGraph41();
            var bfsStats = Bfs.BreadthFirstSearch(ug, 5);

            Assert.AreEqual(1, bfsStats.Dist[0]);
            Assert.AreEqual(2, bfsStats.Dist[1]);
            Assert.AreEqual(1, bfsStats.Dist[2]);
            Assert.AreEqual(1, bfsStats.Dist[3]);
            Assert.AreEqual(1, bfsStats.Dist[4]);
            Assert.AreEqual(0, bfsStats.Dist[5]);

            Debug.WriteLine(bfsStats);
        }
    }
}
