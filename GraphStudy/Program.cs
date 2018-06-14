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
            AdjacencyListGraph<string> adjacencyListGraph = new AdjacencyListGraph<string>();
            adjacencyListGraph.AddVertex("vertex1");
            adjacencyListGraph.AddVertex("vertex2", "vertex1", "out");
            adjacencyListGraph.AddVertex("vertex3", "vertex2");
            adjacencyListGraph.AddEdge("vertex1", "vertex3");
            adjacencyListGraph.AddVertex("vertex1", "vertex0");
            adjacencyListGraph.PrintVertex("vertex1");
            adjacencyListGraph.PrintVertex("vertex2");
            adjacencyListGraph.PrintVertex("vertex3");

            adjacencyListGraph.RemoveEdge("vertex1", "vertex0");

            Console.ReadLine();
        }
    }
}