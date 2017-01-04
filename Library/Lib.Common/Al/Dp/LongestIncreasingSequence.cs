using Lib.Common.Al.Graph;
using System.Diagnostics;

namespace Lib.Common.Al.Dp
{
    public class LongestIncreasingSequence
    {
        /// <summary>
        /// Give a sequence of number, find the longest increasing subsequence
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string GetLongest(int[] numbers)
        {
            //var g = new DirectedGraph(numbers.Length);
            var g = new DirectedGraph(10);
            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        g.AddEdge(numbers[i], numbers[j], 1);
                    }
                }
            }

            g.ReverseGraph();

            Debug.WriteLine(Dfs.StrongConnectedComponentAlgorithm(g));

            var v = Dfs.GetSource(g);

            g.ReverseGraph();//reverse back
            var stats = Dijkstra.LongestPath(g, v);
            //Debug.WriteLine(stats);
            return string.Empty;
        }
    }
}
