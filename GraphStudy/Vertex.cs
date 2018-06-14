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

        List<int> _neighbors;//stores hash codes of neighbors instead of neighbors themselves
    }
}
