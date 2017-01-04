namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Breadth-first search
    /// </summary>
    public class Bfs
    {
        /// <summary>
        /// Breadth-first search on g with start vertice: s
        /// </summary>
        /// <param name="g">Graph for search</param>
        /// <param name="s">Start vertice</param>
        /// <returns>Breadth-first search results</returns>
        public static BfsStats BreadthFirstSearch(GraphBase g, int s)
        {
            var stats = new BfsStats(g.V);
            stats.Dist[s] = 0;

            var q = new Ds.Queue.Queue<int>();
            q.Enqueue(s);
            while (!q.IsEmpty())
            {
                var u = q.Dequeue();
                foreach (var e in g.Adjacent(u))
                {
                    if (stats.Dist[e.V2] == int.MaxValue)
                    {
                        q.Enqueue(e.V2);
                        stats.Dist[e.V2] = stats.Dist[u] + 1;
                    }
                }
            }

            return stats;
        }
    }
}