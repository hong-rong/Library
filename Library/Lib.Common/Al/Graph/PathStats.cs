using System;
using System.Diagnostics;
using System.Text;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Vertice distance for Dijkstra's algorithm in priority queue
    /// </summary>
    [DebuggerDisplay("V: {V}, Dist: {Dist}")]
    public class Distance : IComparable<Distance>
    {
        public int V { get; set; }
        public int Dist { get; set; }

        public int CompareTo(Distance other)
        {
            return Dist.CompareTo(other.Dist);
        }
    }

    public class PathStats
    {
        //mark if a vertice is visited or not
        private readonly bool[] _visited;
        public bool[] Visited
        {
            get { return _visited; }
        }

        //distance for each vertice from a start vertice
        private readonly int[] _dist;
        public int[] Dist
        {
            get { return _dist; }
        }

        //previous vertice for each vertice
        private readonly int[] _prev;
        public int[] Prev
        {
            get { return _prev; }
        }

        public PathStats(int V)
        {
            _visited = new bool[V];
            _dist = new int[V];
            _prev = new int[V];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Path:");
            for (var i = 0; i < Prev.Length; i++)
            {
                sb.AppendLine(string.Format("{0}: {1}", i, Prev[i].ToString()));
            }

            sb.AppendLine("Vertice distance:");
            for (var i = 0; i < Dist.Length; i++)
            {
                sb.AppendLine(string.Format("{0}: {1}", i, Dist[i]));
            }

            return sb.ToString();
        }
    }
}
