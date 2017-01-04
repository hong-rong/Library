namespace Lib.Common.Al.Graph
{
    public class GraphFactory
    {
        #region Undirected Graph

        public static UndirectedGraph CreateUndirectedGraph41()
        {
            var g = new UndirectedGraph(6);

            g.AddEdge('A', 'B');
            g.AddEdge('A', 'S');
            g.AddEdge('B', 'C');
            g.AddEdge('C', 'S');
            g.AddEdge('D', 'E');
            g.AddEdge('D', 'S');
            g.AddEdge('E', 'S');

            return g;
        }

        public static UndirectedGraph CreateUndirectedGraph36()
        {
            var g = new UndirectedGraph(12);

            #region add path

            //first component
            g.AddEdge(0, 1);
            g.AddEdge(0, 4);

            g.AddEdge(4, 8);
            g.AddEdge(4, 9);

            g.AddEdge(8, 9);

            //second component
            //node F is alone

            //third component
            g.AddEdge(2, 3);
            g.AddEdge(2, 6);
            g.AddEdge(2, 7);

            g.AddEdge(3, 7);

            g.AddEdge(6, 7);
            g.AddEdge(6, 10);

            g.AddEdge(7, 10);
            g.AddEdge(7, 11);

            #endregion

            return g;
        }

        public static UndirectedGraph CreateUndirectedGraph32()
        {
            var g = new UndirectedGraph(10);

            #region add path

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(0, 3);

            g.AddEdge(1, 4);
            g.AddEdge(1, 5);

            g.AddEdge(2, 5);

            g.AddEdge(3, 6);
            g.AddEdge(3, 7);

            g.AddEdge(4, 8);
            g.AddEdge(4, 9);

            g.AddEdge(6, 7);

            g.AddEdge(8, 9);

            #endregion

            return g;
        }

        #endregion

        #region Directed Graph

        public static DirectedGraph CreateDirectedGraph61()
        {
            var g = new DirectedGraph(6);
            g.AddEdge('A', 'B', 6);
            g.AddEdge('B', 'D', 1);
            g.AddEdge('B', 'E', 2);
            g.AddEdge('C', 'A', 4);
            g.AddEdge('C', 'D', 3);
            g.AddEdge('D', 'E', 1);
            g.AddEdge('S', 'A', 1);
            g.AddEdge('S', 'C', 2);
            return g;
        }

        public static DirectedGraph GreateDirectedGraph414()
        {
            var g = new DirectedGraph(8);
            g.AddEdge('A', 'E', 2);
            g.AddEdge('B', 'A', 1);
            g.AddEdge('B', 'C', 1);
            g.AddEdge('C', 'D', 3);
            g.AddEdge('D', 'E', -1);
            g.AddEdge('E', 'B', -2);
            g.AddEdge('F', 'A', -4);
            g.AddEdge('F', 'E', -1);
            g.AddEdge('G', 'F', 1);
            g.AddEdge('S', 'G', 8);
            g.AddEdge('S', 'A', 10);
            return g;
        }

        public static DirectedGraph CreateDirectedGraph49()
        {
            var g = new DirectedGraph(5);

            g.AddEdge('A', 'B', 4);
            g.AddEdge('A', 'C', 2);
            g.AddEdge('B', 'C', 3);
            g.AddEdge('B', 'D', 2);
            g.AddEdge('B', 'E', 3);
            g.AddEdge('C', 'B', 1);
            g.AddEdge('C', 'D', 4);
            g.AddEdge('C', 'E', 5);
            g.AddEdge('E', 'D', 1);

            return g;
        }

        public static DirectedGraph CreateDirectedGraph49_Modfied()
        {
            var g = new DirectedGraph(5);

            g.AddEdge('A', 'B', 4);
            g.AddEdge('A', 'C', 2);
            g.AddEdge('B', 'C', 3);
            g.AddEdge('B', 'D', 2);
            g.AddEdge('B', 'E', 3);
            //AddEdge('C', 'B', 1);//remove cycle
            g.AddEdge('C', 'D', 4);
            g.AddEdge('C', 'E', 5);
            g.AddEdge('E', 'D', 1);

            return g;
        }

        public static DirectedGraph CreateDirectedGraph39()
        {
            var g = new DirectedGraph(12);

            #region add edge
            //A
            g.AddEdge(0, 1);
            //B
            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            //C
            g.AddEdge(2, 5);
            //E
            g.AddEdge(4, 1);
            g.AddEdge(4, 5);
            g.AddEdge(4, 6);
            //F
            g.AddEdge(5, 2);
            g.AddEdge(5, 6);
            //G
            g.AddEdge(6, 7);
            g.AddEdge(6, 9);
            //H
            g.AddEdge(7, 10);
            //I
            g.AddEdge(8, 6);
            //J
            g.AddEdge(9, 8);
            //K
            g.AddEdge(10, 11);
            //L
            g.AddEdge(11, 9);

            #endregion

            return g;
        }

        public static DirectedGraph CreateDirectedGraph38()
        {
            var g = new DirectedGraph(6);

            #region add path

            g.AddEdge(0, 2);
            g.AddEdge(1, 0);
            g.AddEdge(1, 3);
            g.AddEdge(2, 4);
            g.AddEdge(2, 5);
            g.AddEdge(3, 2);

            #endregion

            return g;
        }

        public static DirectedGraph CreateDirectGraph37()
        {
            var g = new DirectedGraph(8);

            #region add path

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(0, 5);

            g.AddEdge(1, 4);

            g.AddEdge(2, 3);

            g.AddEdge(3, 7);
            g.AddEdge(3, 0);

            g.AddEdge(4, 5);
            g.AddEdge(4, 6);
            g.AddEdge(4, 7);

            g.AddEdge(5, 6);
            g.AddEdge(5, 1);

            g.AddEdge(7, 6);

            #endregion

            return g;
        }

        #endregion
    }
}