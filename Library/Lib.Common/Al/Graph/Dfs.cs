using Lib.Common.Ds.Ll;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Depth-first search
    /// </summary>
    public class Dfs
    {
        public static DfsStats DepthFirstSearch(GraphBase g)
        {
            var ds = new DfsStats(g.V);

            for (var i = 0; i < g.V; i++)
                ds.Visited[i] = false;

            for (var i = 0; i < g.V; i++)
                if (!ds.Visited[i])
                {
                    ds.ComponentCount++;
                    Explore(g, i, ds);
                }

            return ds;
        }

        public static LinkedList<int> GetLinearization(GraphBase g)
        {
            return DepthFirstSearch(g).Linearization;
        }

        public static DfsStats StrongConnectedComponentAlgorithm(DirectedGraph g)
        {
            g.ReverseGraph();//reverse G
            var linearization = GetLinearization(g);

            var ds = new DfsStats(g.V) { Clock = 1, ComponentCount = 0 };

            g.ReverseGraph();//reverse G back
            foreach (var v in linearization)
            {
                if (!ds.Visited[v])
                {
                    ds.ComponentCount++;
                    Explore(g, v, ds);
                }
            }

            return ds;
        }

        /// <summary>
        /// Get predecessor of a DAG
        /// </summary>
        /// <param name="g">Graph g to be searched</param>
        /// <returns>Predecessor of a node of a DAG</returns>
        public static int GetSource(DirectedGraph g)
        {
            var ds = StrongConnectedComponentAlgorithm(g);
            return ds.Linearization.ToArray()[0];
        }

        public static void Explore(GraphBase g, int v, DfsStats dfsStats)
        {
            PreVisitVertice(v, dfsStats);

            foreach (var e in g.Adjacent(v))
            {
                if (!dfsStats.Visited[e.V2])
                {
                    Explore(g, e.V2, dfsStats);
                }
                //else if (e < v)
                //only directed graph has 'back edge'
                else if (g is DirectedGraph && e.V2 < v)//e < v is not right
                {
                    dfsStats.BackEdges.Add(new Edge { V1 = v, V2 = e.V2 });
                }
            }

            PostVisitVertice(v, dfsStats);
        }

        private static void PreVisitVertice(int v, DfsStats dfsStats)
        {
            dfsStats.Visited[v] = true;
            dfsStats.ComponentNum[v] = dfsStats.ComponentCount;
            dfsStats.PreVisit[v] = dfsStats.Clock++;
        }

        private static void PostVisitVertice(int v, DfsStats dfsStats)
        {
            dfsStats.PostVisit[v] = dfsStats.Clock++;
            dfsStats.Linearization.AddFirst(v);
        }
    }
}