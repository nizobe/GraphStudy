using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();
            graph.AddVertex("vertex1");
            graph.AddVertex("vertex2", "vertex1", "out");
            graph.AddVertex("vertex3", "vertex2");
            graph.AddEdge("vertex1", "vertex3");
            graph.AddVertex("vertex1", "vertex0");
            graph.PrintVertex("vertex1");
            graph.PrintVertex("vertex2");
            graph.PrintVertex("vertex3");

            graph.RemoveEdge("vertex1", "vertex0");

            Console.ReadLine();
        }
    }
}