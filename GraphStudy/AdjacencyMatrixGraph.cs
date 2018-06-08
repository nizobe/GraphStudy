using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    class AdjacencyMatrixGraph<T> : IGraph<T>
    {
        private Dictionary<T, List<int>> _adjacencyMatrix;

        public Dictionary<T, List<int>> AdjacencyMatrix
        {
            get
            {
                return _adjacencyMatrix;
            }

            set
            {
                _adjacencyMatrix = value;
            }
        }

        public int NumVertices
        {
            get
            {
                return _adjacencyMatrix.Keys.Count;
            }
        }

        public AdjacencyMatrixGraph()
        {
            _adjacencyMatrix = new Dictionary<T, List<int>>();
        }

        public bool VertexExists(T vertex)
        {
            return _adjacencyMatrix.ContainsKey(vertex);
        }

        public bool AddVertex(T vertex)
        {
            if(VertexExists(vertex))
            {
                return false;
            }

            _adjacencyMatrix.Add(vertex, new List<int>());

            _adjacencyMatrix[vertex].Capacity = NumVertices;//_adjacencyMatrix.Keys.Count;
            _adjacencyMatrix[vertex] = Enumerable.Repeat(0, _adjacencyMatrix.Keys.Count).ToList();
            //TODO update edges
            return true;
        }
    }
}
