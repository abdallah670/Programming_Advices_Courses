using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C22_DS
{
    internal class Program
    {
        static void Main(string[] args)
        {
         // Collections.List();
          //  Collections.HashTable();
           // Collections.Dictionary();
           //Collections.HashSet();
         //  Collections.SortedSet();
        
           // ExampleofTree.ExampleofGeneralTree();
           // ExampleofTree.ExampleofBinaryTree();
           Graph graph
                = new Graph();
            // graph.GraphWithAdjancyMatrix();
            // graph.GraphWithAdjancyList();
            // graph.WeightedGraph();
            graph.DirectedWeightedGraphWithAdjancyMatrix();
            graph.DirectedWeightedGraphWithAdjancyList();



            Console.ReadKey();  

        }
    }
}
