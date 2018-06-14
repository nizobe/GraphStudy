using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    class AdjacencyMatrixGraph<T> : IGraph<T>
    {
        //private List<List<T>> _adjacencyMatrix;
        private List<T> _vertices;
        private List<List<T>> _adjacencyMatrix;
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
            _vertices = new List<T>();
            _adjacencyMatrix = new List<List<T>>();
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

        public bool AddVertex(T vertex)
        {
            //TODO VertexExists()
            _vertices.Add(vertex);
            _adjacencyMatrix.Add(new List<T>(_vertices.Count));
            //TODO loop through and add to other entries
            //_adjacencyMatrix.Add(vertex);

            return false;
        }
    }
}
