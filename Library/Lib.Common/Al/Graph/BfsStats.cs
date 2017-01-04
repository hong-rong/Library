using System.Text;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Breadth-first search statistics
    /// </summary>
    public class BfsStats
    {
        //distance for each vertice from a start vertice
        private readonly int[] _dist;
        public int[] Dist
        {
            get { return _dist; }
        }

        public BfsStats(int V)
        {
            _dist = new int[V];
            for (var i = 0; i < _dist.Length; i++)
            {
                _dist[i] = int.MaxValue;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("breadth-first search:");
            for (var i = 0; i < Dist.Length; i++)
            {
                sb.AppendLine(string.Format("{0}: {1}", i, Dist[i]));
            }
            sb.AppendLine();

            return sb.ToString();
        }
    }
}