using System;
using System.Collections.Generic;
using System.IO;

namespace GraphTraversal
{
    public struct Edge
    {
        public int Vertex1;
        public int Vertex2;

        public Edge(int v1, int v2)
        {
            Vertex1 = v1;
            Vertex2 = v2;
        }
    }
    public class Graph
    {
        private List<int>[] adjacencyList;

        public Graph(int vertices)
        {
            adjacencyList = new List<int>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }
        public void AddEdge(int v1, int v2)
        {
            adjacencyList[v1].Add(v2);
        }
        public void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write(v + " ");

            foreach (int neighbor in adjacencyList[v])
            {
                if (!visited[neighbor])
                {
                    DFSUtil(neighbor, visited);
                }
            }
        }

        public void DFS()
        {
            int vertices = adjacencyList.Length;
            bool[] visited = new bool[vertices];

            Console.WriteLine("Result of graph traversal using DFS:");
            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                {
                    DFSUtil(i, visited);
                }
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\eduar\source\repos\PracticeTask\PracticeTask\graph.txt";
            string[] lines = File.ReadAllLines(filePath);
            int vertices = int.Parse(lines[0]);
            Graph graph = new Graph(vertices);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] edge = lines[i].Split(' ');
                int v1 = int.Parse(edge[0]);
                int v2 = int.Parse(edge[1]);
                graph.AddEdge(v1, v2);
            }


            graph.DFS();
            Console.ReadLine();
        }
    }
}
