using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    class Vertex<T>
    {
        T _data;

        //<int -hash code, List<<int -direction, int -weight>>>
        Dictionary<int, List<Tuple<int,int>>> _neighbors;//stores hash codes of neighbors instead of neighbors themselves

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
