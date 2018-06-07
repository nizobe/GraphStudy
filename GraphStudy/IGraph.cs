using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    interface IGraph<T>
    {
        bool AddVertex(T vertex);

        bool RemoveVertex(T vertex);

        bool AddEdge(T source, T target, bool isDirected = false);

        int RemoveEdge(T source, T target, bool isDirectedEdge = false);

        bool EdgeExists(T source, T target, bool isDirectedEdge = false);//TODO maybe make this return an int or an enum to tell what type of edge?

        List<T> Vertices();
    }
}
