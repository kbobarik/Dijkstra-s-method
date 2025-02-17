using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_s_method
{
    internal class MethodsClass
    {
        int start;
        string path;
        public MethodsClass(string path)
        {
            this.path = path;
        }


        public  void Dijkstra()
        {
            double[,] graph = Reading(path);
            int n = graph.GetLength(0);
            double[] distances = new double[n];
            bool [] visited = new bool[n]; 
            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue;
                visited[i] = false;
            }
            distances[start] = 0;
            for (int i = 0; i < n - 1; i++)
            {
                double minDistance = int.MaxValue;
                int minIndex = -1;
                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && distances[j] < minDistance)
                    {
                        minDistance = distances[j];
                        minIndex = j;
                    }
                }

                visited[minIndex] = true;

                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && graph[minIndex, j] != 0 && distances[minIndex] != int.MaxValue &&
                        distances[minIndex] + graph[minIndex, j] < distances[j])
                    {
                        distances[j] = (distances[minIndex] + graph[minIndex, j]);
                    }
                }
            }
            List<double> result = new List<double>(distances);
            Output(result);
        }

        public double[,] Reading(string path)
        {
            int n = File.ReadAllLines(path).Length;
            double[,] graph = new double[n-1,n-1];
            using (StreamReader reader = new StreamReader(path))
            {
                for(int i = 0;i < graph.GetLength(0); i++)
                {
                    string text = reader.ReadLine();
                    string[] mas = text.Split(new char[] { ',' });
                    if (mas.Length == 1)
                    {
                        start = Convert.ToInt32(mas[0]);
                    }
                    else
                    {
                        for (int j = 0; j < mas.Length; j++)
                        {
                            graph[i, j] = double.Parse(mas[j]);
                        }
                    }
                    
                }
               
            }
            return graph;
        }


        private void Output(List<double> shortestPaths)
        {
            Console.WriteLine($"Кратчайшие пути от вершины {start+1} до всех остальных:");
            for (int i = 0; i < shortestPaths.Count; i++)
            {
                Console.WriteLine($"До вершины {i+1}: {shortestPaths[i]}");
            }
        }

    }
}
