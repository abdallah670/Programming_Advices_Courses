using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C22_DS
{
    internal class Graph
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
            Dictionary <char,Dictionary<char,int>> graph = new Dictionary<char, Dictionary<char, int>>();
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
 