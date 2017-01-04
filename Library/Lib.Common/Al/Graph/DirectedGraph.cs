using Lib.Common.Ds.Queue;

namespace Lib.Common.Al.Graph
{
    public class DirectedGraph : GraphBase
    {
        public DirectedGraph(int v)
            : base(v)
        { }

        public void ReverseGraph()
        {
            var q = new Queue<Edge>();
            for (var v = 0; v < _V; v++)
            {
                foreach (var e in Al[v])
                {
                    q.Enqueue(new Edge { V1 = e.V2, V2 = v, Weight = e.Weight });//reverse edge
                }
            }

            for (var i = 0; i < _V; i++)
            {
                Al[i].Clear();
            }
            _E = 0;

            foreach (var e in q)
            {
                AddEdge(e);
            }
        }

        public override void AddEdge(char u, char v)
        {
            AddEdge(u, v, 0);
        }

        public override void AddEdge(char u, char v, int weight)
        {
            int nu = GetMappedNumber(u);
            int nv = GetMappedNumber(v);

            Al[nu].AddLast(new Edge { V1 = nu, V2 = nv, Weight = weight });
            _E++;
        }

        public override void AddEdge(int u, int v)
        {
            AddEdge(u, v, 0);
        }

        public override void AddEdge(int u, int v, int weight)
        {
            Al[u].AddLast(new Edge { V1 = u, V2 = v, Weight = weight });
            _E++;
        }

        public override void AddEdge(Edge e)
        {
            Al[e.V1].AddLast(e);
            _E++;
        }

        public override void RemoveEdge(Edge e)
        {
            Al[e.V1].Remove(e.V2);
            _E--;
        }
    }
}