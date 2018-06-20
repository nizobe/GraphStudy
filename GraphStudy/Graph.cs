using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    class Graph<T>
    {
        //hash code and then thing itself
        private Dictionary<int, Vertex<T>> _vertices;
        private Dictionary<int, Edge> _edges;

        public Graph()
        {
            _vertices = new Dictionary<int, Vertex<T>>();
            _edges = new Dictionary<int, Edge>();
        }

        public Dictionary<int, Vertex<T>> Vertices
        {
            get
            {
                return _vertices;
            }

            set
            {
                _vertices = value;
            }
        }

        public Dictionary<int, Edge> Edges
        {
            get
            {
                return _edges;
            }

            set
            {
                _edges = value;
            }
        }

        public List<int> GetVertexHashes()
        {
            return _vertices.Keys.ToList();
        }

        public List<Vertex<T>> GetVertices()
        {
            return _vertices.Values.ToList();
        }

        public bool AddVertex(T vertex)
        {

            return false;
        }

        public bool VertexExists(T vertex)
        {
            return _vertices.ContainsKey(vertex.GetHashCode());
        }

        public bool VertexExists(int vertex)
        {
            return _vertices.ContainsKey(vertex);
        }
    }
}
