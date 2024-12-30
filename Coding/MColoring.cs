using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class MColoring
    {
        public MColoring()
        {
            int nodes = 5;

            int M = 3;

            int[] colors = new int[nodes + 1];

            int[,] vertices = new int[,] {
                { 1, 2 },
                { 2, 3 },
                { 2, 4 },
                { 3, 4 },
                { 5, 3 },
                { 1, 3 },
                { 1, 5 }
            };


            List<List<int>> graph = new List<List<int>>();

            for (int i = 0; i <= nodes; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < vertices.Length / 2; i++)
            {
                graph[vertices[i, 0]].Add(vertices[i, 1]);
                graph[vertices[i, 1]].Add(vertices[i, 0]);
            }

            if (isGraphColourableByMColours(0, graph, ref colors, graph.Count, M))
            {
                Console.WriteLine("Graph is colourable by {0} colors", M);
            }
            else
            {
                Console.WriteLine("Graph is not colourable by {0} colors", M);
            }

            #region Prepare adjacent unweighted graph using dictonary
            // Prepare adjacent unweighted graph using dictonary I

            //Dictionary<int, List<int>> graphDictionary = new Dictionary<int, List<int>>();

            //for (int i = 0; i <= nodes; i++)
            //{
            //    graphDictionary.Add(i, new List<int>());
            //}

            //for (int i = 0; i < vertices.Length / 2; i++)
            //{
            //    graphDictionary[vertices[i, 0]].Add(vertices[i, 1]);
            //    graphDictionary[vertices[i, 1]].Add(vertices[i, 0]);
            //}

            // Prepare adjacent unweighted graph using dictonary II

            //for (int i = 0; i < vertices.Length / 2; i++)
            //{
            //    if (!graphDictionary.ContainsKey(vertices[i, 0]))
            //    {
            //        graphDictionary.Add(vertices[i, 0], new List<int>());
            //    }
            //    if (!graphDictionary.ContainsKey(vertices[i, 1]))
            //    {
            //        graphDictionary.Add(vertices[i, 1], new List<int>());
            //    }

            //    graphDictionary[vertices[i, 0]].Add(vertices[i, 1]);
            //    graphDictionary[vertices[i, 1]].Add(vertices[i, 0]);

            //}
            #endregion 

        }

        bool isGraphColourableByMColours(int currentNode, List<List<int>> graph, ref int[] colors, int nodes, int M)
        {
            if (currentNode == nodes)
            {
                return true;
            }
            for (int color = 1; color <= M; color++)
            {
                if (IsSafeColor(currentNode, graph, ref colors, color))
                {
                    colors[currentNode] = color;
                    if (isGraphColourableByMColours(currentNode + 1, graph, ref colors, nodes, M))
                    {
                        return true;
                    }
                    colors[currentNode] = 0;
                }
            }
            return false;
        }

        bool IsSafeColor(int currentNode, List<List<int>> graph, ref int[] colors, int color)
        {
            foreach (var node in graph[currentNode])
            {
                if (colors[node] == color)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
