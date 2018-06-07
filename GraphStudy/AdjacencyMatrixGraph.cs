using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    class AdjacencyMatrixGraph<T>
    {
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
            _adjacencyMatrix = new List<List<T>>();
        }
    }
}
