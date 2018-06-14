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

        public List<List<T>> AdjacencyMatrix
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

        public AdjacencyMatrixGraph()
        {
            _vertices = new List<T>();
            _adjacencyMatrix = new List<List<T>>();
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
