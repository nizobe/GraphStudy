using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    public class AdjacencyListGraph<T> : IGraph<T>
    {
        private Dictionary<T, List<T>> _adjacencyList;

        /// <summary>
        /// Constructor
        /// </summary>
        public AdjacencyListGraph()
        {
            _adjacencyList = new Dictionary<T, List<T>>();
        }

        public Dictionary<T, List<T>> AdjacecnyList
        {
            get { return _adjacencyList; }
            set { _adjacencyList = value; }
        }

        /// <summary>
        /// Adds a vertex to the graph (adjacency list). This vertex will be orphaned/disconnected from any other vertex.
        /// Does not allow for duplicate vertices to be added.
        /// </summary>
        /// <returns>
        /// True if the vertex was added. False oetherwise (vertex already existed in graph).
        /// </returns>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool AddVertex(T vertex)
        {
            if (_adjacencyList.ContainsKey(vertex))
            {
                return false;
            }

            _adjacencyList.Add(vertex, new List<T>());

            return true;
        }

        /// <summary>
        /// Adds a vertex to the graph (adjacency list) with an edge to 'other'.
        /// Edge direction determined by <c>inOutUndirected</c>.
        /// "IN"                    : edge from other to vertex,
        /// "OUT"                   : edge from vertex to other,
        /// &lt;default/other&gt;   : undirected edge.
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="other"></param>
        /// <param name="inOutUndirected"></param>
        /// <returns></returns>
        public bool AddVertex(T vertex, T other, string inOutUndirected = "UNDIRECTED")
        {
            if (!AddVertex(vertex) && !AddVertex(other))
            {
                return false;
            }

            switch (inOutUndirected.ToUpperInvariant())
            {
                case "IN":
                    AddEdge(other, vertex, true);
                    break;
                case "OUT":
                    AddEdge(vertex, other, true);
                    break;
                default://undirected
                    AddEdge(vertex, other);
                    break;
            }

            return true;
        }

        /// <summary>
        /// Checks whether a vertex exists in the graph.
        /// </summary>
        /// <returns>
        /// True if it exists. False otherwise.
        /// </returns>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool VertexExists(T vertex)
        {
            if (_adjacencyList.ContainsKey(vertex))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a vertex from the graph. First removes the vertex from the adjacency list,
        /// then removes any reference to it from any other vertex's entry in the adjaceny list.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool RemoveVertex(T vertex)
        {
            if (!VertexExists(vertex))
            {
                return false;
            }

            _adjacencyList.Remove(vertex);

            foreach (var vert in _adjacencyList.Keys)
            {
                _adjacencyList[vert].Remove(vertex);
            }

            return true;
        }

        /// <summary>
        /// Adds an edge between source and target. If <c>isDirectedEdge</c> is true, only adds an edge from source to target.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="isDirectedEdge"></param>
        /// <returns></returns>
        public bool AddEdge(T source, T target, bool isDirectedEdge = false)
        {
            if (EdgeExists(source, target, isDirectedEdge))
            {
                return false;
            }

            _adjacencyList[source].Add(target);

            if (!isDirectedEdge)
            {
                _adjacencyList[target].Add(source);
            }

            return true;
        }

         /// <summary>
         /// Returns:
         /// -1 : no edge exists,
         /// 1  : directed edge removed,
         /// 2  : undirected edge removed
         /// </summary>
         /// <param name="source"></param>
         /// <param name="target"></param>
         /// <param name="isDirectedEdge"></param>
         /// <returns></returns>
        public int RemoveEdge(T source, T target, bool isDirectedEdge = false)
        {
            if (!EdgeExists(source, target, isDirectedEdge))
            {
                return -1;
            }

            _adjacencyList[source].Remove(target);

            if (isDirectedEdge)
            {
                _adjacencyList[target].Remove(source);
                return 2;
            }
            return 1;
        }

        /// <summary>
        /// Whether an edge exists between source and target.
        /// If <c>isDirectedEdge</c> is true, will only check for an edge from source to target.
        /// </summary>
        /// <returns>
        /// True if an edge exists between source and target. False otherwise.
        /// </returns> 
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="isDirectedEdge"></param>
        /// <returns></returns>
        public bool EdgeExists(T source, T target, bool isDirectedEdge = false)
        {
            if (isDirectedEdge)
            {
                if (_adjacencyList[source] == null)
                {
                    return false;
                }
                if (_adjacencyList[source].Contains(target))
                {
                    return true;
                }
            }
            else
            {
                if (_adjacencyList[source].Contains(target) && _adjacencyList[target].Contains(source))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns a List&lt;T&gt; of the vertices in the graph.
        /// </summary>
        /// <returns>
        /// List&lt;T&gt; of keys from the adjacency list dictionary.
        /// </returns>
        /// <returns></returns>
        public List<T> Vertices()
        {//TODO maybe make a vertex object and construct as needed?
            return _adjacencyList.Keys.ToList();
        }

        /// <summary>
        /// Prints out vertex data and then the vertices ajdacent to it via undirected and directed outbound edgeds.
        /// </summary>
        /// <param name="vertex"></param>
        public void PrintVertex(T vertex)
        {
            string VertexOutput = vertex.ToString();// + "\n\t";

            _adjacencyList[vertex].Sort();
            foreach (var edge in _adjacencyList[vertex])
            {
                VertexOutput += "\n\t--> " + edge.ToString();
            }

            VertexOutput += "\n";

            Console.WriteLine(VertexOutput);
        }

/*        public List<T> Edges()
        {
            //TODO make an edge object and construct as needed here
            return _adjacencyList.
        }*/
    }
}
