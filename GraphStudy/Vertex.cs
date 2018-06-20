using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    class Vertex<T>
    {
        private T _data;

        //<int -hash code, List<<int -direction, int -weight>>>
        private Dictionary<int, List<Tuple<int,int>>> _neighbors;//stores hash codes of neighbors instead of neighbors themselves

        public Vertex(T data)
        {
            _data = data;
            _neighbors = new Dictionary<int, List<Tuple<int, int>>>();
        }

        public Vertex()
        {
            _data = default(T);
            _neighbors = new Dictionary<int, List<Tuple<int, int>>>();
        }

        //public Dictionary<int, List<Tuple<int, int>>> Neighbors
        public List<int> Neighbors
        {
            get
            {
                return _neighbors.Keys.ToList();
            }
        }

        public T Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        public bool HasNeighbor(int neighbor)
        {//TODO tell whether or not the neighbor is reachable from this vertex?
            if (_neighbors.ContainsKey(neighbor))
            {
                return true;
            }
            return false;
        }

        public bool IsDisconnected()
        {
            return _neighbors.Count == 0;
        }
    }
}
