using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C22_DS
{
    // Graph is a non-linear data structure
    // Graph is a collection of nodes and edges
    //GraphNode


    public class GraphMatrix
    {
        public enum enGraphType
        {
            Undirected,
            Directed,
           
        }
        int[,] AdjacencyMatrix;
        private Dictionary<string, int> _vertexDictionary;
        private int _numberOfVertices;
        enGraphType graphType = enGraphType.Undirected;
        public GraphMatrix(List<string> Vertices, enGraphType graphType)
        {
            this.graphType = graphType;
            _numberOfVertices = Vertices.Count;
            _vertexDictionary = new Dictionary<string, int>();
            AdjacencyMatrix = new int[_numberOfVertices, _numberOfVertices];
            for (int i = 0; i < Vertices.Count; i++)
            {
                _vertexDictionary.Add(Vertices[i], i);
            }
        }
        public void AddEdge(string source, string destination, int weight)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                int sourceIndex = _vertexDictionary[source];
                int destinationIndex = _vertexDictionary[destination];
                AdjacencyMatrix[sourceIndex, destinationIndex] = weight;
                if (graphType == enGraphType.Undirected)
                {
                    AdjacencyMatrix[destinationIndex, sourceIndex] = weight;
                }
            }
            else

                throw new Exception("Vertex not found in the graph.");
        }
        public void RemoveEdge(string source, string destination)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                int sourceIndex = _vertexDictionary[source];
                int destinationIndex = _vertexDictionary[destination];
                AdjacencyMatrix[sourceIndex, destinationIndex] = 0;
                if (graphType == enGraphType.Undirected)
                {
                    AdjacencyMatrix[destinationIndex, sourceIndex] = 0;
                }
            }
            else
                throw new Exception("Vertex not found in the graph.");
        }
        public void Isedge(string source, string destination)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                int sourceIndex = _vertexDictionary[source];
                int destinationIndex = _vertexDictionary[destination];
                if (AdjacencyMatrix[sourceIndex, destinationIndex] != 0)
                {
                    Console.WriteLine("Edge exists between " + source + " and " + destination);
                }
                else
                {
                    Console.WriteLine("Edge does not exist between " + source + " and " + destination);
                }
            }
            else
                throw new Exception("Vertex not found in the graph.");
        }

        public void DisplayGraph()
        {
            Console.Write("  ");
            foreach (var vertex in _vertexDictionary.Keys)
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < _numberOfVertices; i++)
            {
                Console.Write(_vertexDictionary.FirstOrDefault(x => x.Value == i).Key + " ");
                for (int j = 0; j < _numberOfVertices; j++)
                {
                    Console.Write(AdjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            

        }
        public int indegree(string vertex)
        {
            if (!_vertexDictionary.ContainsKey(vertex))
            {
                throw new Exception("Vertex not found in the graph.");
            }
            int vertexIndex = _vertexDictionary[vertex];
            int indegree = 0;
            for (int i = 0; i < _numberOfVertices; i++)
            {
                if (AdjacencyMatrix[i, vertexIndex] != 0)
                {
                    indegree++;
                }
            }
            return indegree;
        }
        public int outdegree(string vertex)
        {
            if (!_vertexDictionary.ContainsKey(vertex))
            {
                throw new Exception("Vertex not found in the graph.");
            }
            int vertexIndex = _vertexDictionary[vertex];
            int outdegree = 0;
            for (int i = 0; i < _numberOfVertices; i++)
            {
                if (AdjacencyMatrix[vertexIndex, i] != 0)
                {
                    outdegree++;
                }
            }
            return outdegree;
        }

    }
    public class GraphList
    {
        public enum enGraphType
        {
            Undirected,
            Directed,
        }
        private Dictionary<string, List<Tuple<string, int>>> _adjacencyList;
        private Dictionary<string, int> _vertexDictionary;
        private int _numberOfVertices;
        enGraphType graphType = enGraphType.Undirected;
        public GraphList(List<string> Vertices, enGraphType graphType)
        {
            this.graphType = graphType;
            _numberOfVertices = Vertices.Count;
            _vertexDictionary = new Dictionary<string, int>();
            _adjacencyList = new Dictionary<string, List<Tuple<string, int>>>();
            for (int i = 0; i < Vertices.Count; i++)
            {
                _vertexDictionary.Add(Vertices[i], i);
                _adjacencyList.Add(Vertices[i], new List<Tuple<string, int>>());
            }
        }
        public void AddEdge(string source, string destination, int weight)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                _adjacencyList[source].Add(new Tuple<string, int>(destination, weight));
                if (graphType == enGraphType.Undirected)
                {
                    _adjacencyList[destination].Add(new Tuple<string, int>(source, weight));
                }
            }
            else
                throw new Exception("Vertex not found in the graph.");
        }
        public void RemoveEdge(string source, string destination)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                _adjacencyList[source].RemoveAll(x => x.Item1 == destination);
                if (graphType == enGraphType.Undirected)
                {
                    _adjacencyList[destination].RemoveAll(x => x.Item1 == source);
                }
            }
            else
                throw new Exception("Vertex not found in the graph.");
        }
        public void Isedge(string source, string destination)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                if (_adjacencyList[source].Any(x => x.Item1 == destination))
                {
                    Console.WriteLine("Edge exists between " + source + " and " + destination);
                }
                else
                {
                    Console.WriteLine("Edge does not exist between " + source + " and " + destination);
                }
            }
            else
                throw new Exception("Vertex not found in the graph.");
        }
        public void DisplayGraph()
        {
            foreach (var vertex in _adjacencyList.Keys)
            {
                Console.Write(vertex + " ");
                foreach (var edge in _adjacencyList[vertex])
                {
                    Console.Write($"({edge.Item2})-> {edge.Item1} ");
                }
                Console.WriteLine();
            }
        }
        public int indegree(string vertex)
        {
            if (!_vertexDictionary.ContainsKey(vertex))
            {
                throw new Exception("Vertex not found in the graph.");
            }
            int vertexIndex = _vertexDictionary[vertex];
            int indegree = 0;
            foreach (var item in _adjacencyList)
            {
                foreach (var edge in item.Value)
                {
                    if (edge.Item1 == vertex)
                    {
                        indegree++;
                    }
                }
            }
            return indegree;
        }
        public int outdegree(string vertex)
        {
            if (!_vertexDictionary.ContainsKey(vertex))
            {
                throw new Exception("Vertex not found in the graph.");
            }
            int vertexIndex = _vertexDictionary[vertex];
            int outdegree = 0;
            foreach (var edge in _adjacencyList[vertex])
            {
                outdegree++;
            }
            return outdegree;
        }
    }

    public class GraphExample
    {
        public void GraphWithAdjancyMatrix()
        {
            //A B C D E
            int[,] graph = new int[5, 5]
            {
                { 0, 1, 1, 0, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0 }
            };
            //A B C D E
            Console.WriteLine("Adjacency Matrix:");
            Console.WriteLine("  A B C D E");
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.Write((char)('A' + i) + " ");
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
        public void GraphWithAdjancyList()
        {
            //A B C D E
            List<int>[] graph = new List<int>[5];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }
            graph[0].Add(1);
            graph[0].Add(2);
            graph[1].Add(3);
            graph[3].Add(4);
            graph[2].Add(3);

            //A B C D E
            Console.WriteLine("Adjacency List:");
            Console.WriteLine("  A B C D E");
            for (int i = 0; i < graph.Length; i++)
            {
                Console.Write((char)('A' + i) + " ");
                foreach (var item in graph[i])
                {
                    Console.Write((char)('A' + item) + " ");
                }
                Console.WriteLine();
            }
        }
        public void WeightedGraph()
        {
            int[,] graph = new int[4, 4]
           {
                { 0, 3, 5, 0 },
                { 0, 0, 0, 2},
                { 0, 0, 0, 7},
                { 0, 0, 0, 0}

           };
            Console.WriteLine("Adjacency Matrix:");
            Console.WriteLine("  A B C D");
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.Write((char)('A' + i) + " ");
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void DirectedWeightedGraphWithAdjancyMatrix()
        {
            //X Y Z W
            int[,] graph = new int[4, 4]
            {
                { 0, 6, 4, 0 },
                { 0, 0, 0, 1},
                { 0, 0, 0, 3},
                { 0, 0, 0, 0}

            };
            //X Y Z W
            Console.WriteLine("Adjacency Matrix:");
            Console.WriteLine("  X Y Z W");
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (i != graph.GetLength(0) - 1) Console.Write((char)('X' + i) + " ");
                else Console.Write((char)('W') + " ");
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
        public void DirectedWeightedGraphWithAdjancyList()
        {
            //X Y Z W
            Dictionary<char, Dictionary<char, int>> graph = new Dictionary<char, Dictionary<char, int>>();
            graph.Add('X', new Dictionary<char, int>());
            graph['X'].Add('Y', 6);
            graph['X'].Add('Z', 4);
            graph.Add('Y', new Dictionary<char, int>());
            graph['Y'].Add('W', 1);
            graph.Add('Z', new Dictionary<char, int>());
            graph['Z'].Add('W', 3);
            graph.Add('W', new Dictionary<char, int>());
            //X Y Z W
            Console.WriteLine("Adjacency List:");

            foreach (var item in graph)
            {
                Console.Write(item.Key + " ");
                foreach (var innerItem in item.Value)
                {
                    Console.Write(innerItem.Key + "(" + innerItem.Value + ") ");
                }
                Console.WriteLine();
            }
        }
    }
}

 