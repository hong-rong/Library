namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Shortest path for general graph
    /// </summary>
    public class BellmanFord
    {
        public static PathStats ShortestPath(GraphBase g, int s)
        {
            #region Initialization
            var ps = new PathStats(g.V);
            for (int i = 0; i < ps.Dist.Length; i++)
            {
                ps.Dist[i] = int.MaxValue;
                ps.Prev[i] = -1;
            }
            ps.Dist[s] = 0;
            #endregion

            for (int i = 0; i < g.V - 1; i++)//run |V|-1 times
            {
                for (var u = g.V - 1; u >= 0; u--)//'S' starts first, earlier to get finall status
                {
                    foreach (var e in g.Adjacent(u))
                    {
                        if (ps.Dist[u] == int.MaxValue)//if distance of u hasn't ever be udpated, skip
                            break;
                        if (ps.Dist[e.V2] > ps.Dist[e.V1] + e.Weight)
                        {
                            ps.Dist[e.V2] = ps.Dist[e.V1] + e.Weight;
                            ps.Prev[e.V2] = u;
                        }
                    }
                }
            }
            return ps;
        }
    }
}
