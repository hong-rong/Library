using Lib.Common.Ds.Pq;

namespace Lib.Common.Al.Graph
{
    public class Dijkstra
    {
        /// <summary>
        /// Dijkstra algorithm (shortest path) based on graph g for start vertice s. Positive cycles are allowed in shortest path algorithm
        /// </summary>
        /// <param name="g">Graph for search</param>
        /// <param name="s">Start vertice</param>
        public static PathStats ShortestPath(GraphBase g, int s)
        {
            var ps = new PathStats(g.V);

            for (var i = 0; i < ps.Dist.Length; i++)
            {
                ps.Dist[i] = int.MaxValue;
                ps.Prev[i] = -1;
            }

            ps.Dist[s] = 0;//start vertice

            var pq = new IndexMinPQ<Distance>(ps.Dist.Length);
            for (int i = 0; i < ps.Dist.Length; i++)
            {
                pq.Insert(i, new Distance { V = i, Dist = ps.Dist[i] });
            }

            while (!pq.IsEmpty())
            {
                var v = pq.DelRoot();

                foreach (var e in g.Adjacent(v))
                {
                    if (ps.Dist[e.V2] > ps.Dist[v] + e.Weight)
                    {
                        ps.Dist[e.V2] = ps.Dist[v] + e.Weight;
                        ps.Prev[e.V2] = v;
                        pq.ChangeKey(e.V2, new Distance { V = e.V2, Dist = ps.Dist[e.V2] });
                    }
                }
            }

            return ps;
        }

        /// <summary>
        /// Dijkstra algorithm (longest path) based on graph g for start vertice s. Positive cycles are NOT allowed in longest path algorithm
        /// </summary>
        /// <param name="g">Graph for search</param>
        /// <param name="s">Start vertice</param>
        public static PathStats LongestPath(GraphBase g, int s)
        {
            var ps = new PathStats(g.V);

            for (var i = 0; i < ps.Dist.Length; i++)
            {
                ps.Dist[i] = int.MinValue;
                ps.Prev[i] = -1;
            }

            ps.Dist[s] = 0;//start vertice
            var pq = new IndexMaxPQ<Distance>(ps.Dist.Length);
            for (int i = 0; i < ps.Dist.Length; i++)
            {
                pq.Insert(i, new Distance { V = i, Dist = ps.Dist[i] });
            }

            while (!pq.IsEmpty())
            {
                var v = pq.DelRoot();

                foreach (var e in g.Adjacent(v))
                {
                    if (ps.Dist[e.V2] < ps.Dist[v] + e.Weight)   //longest path
                    {
                        ps.Dist[e.V2] = ps.Dist[v] + e.Weight;
                        ps.Prev[e.V2] = v;
                        pq.ChangeKey(e.V2, new Distance { V = e.V2, Dist = ps.Dist[e.V2] });
                    }
                }
            }

            return ps;
        }

        private static PathStats GetPathStats(GraphBase g, int s, bool isShortest)
        {
            var ps = new PathStats(g.V);

            for (var i = 0; i < ps.Dist.Length; i++)
            {
                ps.Dist[i] = isShortest ? int.MaxValue : int.MinValue;
                ps.Prev[i] = -1;
            }

            ps.Dist[s] = 0;//start vertice
            var pq = isShortest ? new MinPQ<Distance>(ps.Dist.Length) : new MaxPQ<Distance>(ps.Dist.Length);
            pq.Insert(new Distance { Dist = 0, V = s });

            while (!pq.IsEmpty())
            {
                var v = pq.DelRoot();

                foreach (var e in g.Adjacent(v.V))
                {
                    if ((isShortest && ps.Dist[e.V2] > ps.Dist[v.V] + e.Weight) ||  //shortest path
                        (!isShortest && ps.Dist[e.V2] < ps.Dist[v.V] + e.Weight))   //longest path
                    {
                        ps.Dist[e.V2] = ps.Dist[v.V] + e.Weight;
                        ps.Prev[e.V2] = v.V;
                        pq.Insert(new Distance { V = e.V2, Dist = ps.Dist[e.V2] });
                    }
                }
            }

            return ps;
        }
    }
}