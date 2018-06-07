using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    public class Graph<T>// : IEnumerable<T>
    {
        private Dictionary<T, List<T>> _adjacencyList;

        public Graph()
        {
            _adjacencyList = new Dictionary<T, List<T>>();
        }

        public Dictionary<T, List<T>> AdjacecnyList
        {
            get { return _adjacencyList; }
            set { _adjacencyList = value; }
        }

        public bool AddVertex(T vertex)
        {
            if (_adjacencyList.ContainsKey(vertex))
            {
                return false;
            }

            _adjacencyList.Add(vertex, new List<T>());

            return true;
        }

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

        public bool VertexExists(T vertex)
        {
            if (_adjacencyList.ContainsKey(vertex))
            {
                return true;
            }
            return false;
        }

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

        /* Returns:
         * -1 if no edge exists
         * 1 if directed edge removed
         * 2 if undirected edge removed */
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

        public List<T> Vertices()
        {//TODO maybe make a vertex object and construct as needed?
            return _adjacencyList.Keys.ToList();
        }

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
