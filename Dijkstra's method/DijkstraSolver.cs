using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DijkstraAlgorithm
{
    /// <summary>
    /// Класс для решения задачи поиска кратчайшего пути с помощью алгоритма Дейкстры.
    /// </summary>
    internal class DijkstraSolver
    {
        private readonly string _filePath; // Путь к файлу с графом
        private int _startVertex; // Начальная вершина

        public DijkstraSolver(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Основной метод выполнения алгоритма Дейкстры.
        /// </summary>
        public void Run()
        {
            double[,] graph = ReadGraphFromFile(_filePath);
            double[] distances = FindShortestPaths(graph, _startVertex);
            PrintShortestPaths(distances);
        }

        /// <summary>
        /// Читает граф из файла и возвращает его в виде матрицы смежности.
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Матрица смежности графа</returns>
        private double[,] ReadGraphFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int size = lines.Length - 1;
            double[,] graph = new double[size, size];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                if (values.Length == 1)
                {
                    _startVertex = int.Parse(values[0]); // Определяем стартовую вершину
                }
                else if (i > 0)
                {
                    for (int j = 0; j < values.Length; j++)
                    {
                        graph[i - 1, j] = double.Parse(values[j]); // Заполняем матрицу значениями из файла
                    }
                }
            }
            return graph;
        }

        /// <summary>
        /// Реализация алгоритма Дейкстры для поиска кратчайших путей.
        /// </summary>
        /// <param name="graph">Матрица смежности графа</param>
        /// <param name="start">Стартовая вершина</param>
        /// <returns>Массив расстояний до всех вершин</returns>
        private double[] FindShortestPaths(double[,] graph, int start)
        {
            int n = graph.GetLength(0);
            double[] distances = Enumerable.Repeat(double.PositiveInfinity, n).ToArray(); // Инициализируем расстояния бесконечностью
            bool[] visited = new bool[n];

            distances[start] = 0;

            for (int i = 0; i < n; i++)
            {
                int minIndex = -1;
                double minDistance = double.PositiveInfinity;

                // Ищем вершину с минимальным расстоянием
                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && distances[j] < minDistance)
                    {
                        minDistance = distances[j];
                        minIndex = j;
                    }
                }

                if (minIndex == -1) break; // Если нет доступных вершин, выходим

                visited[minIndex] = true;

                // Обновляем расстояния до соседних вершин
                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && graph[minIndex, j] > 0)
                    {
                        double newDist = distances[minIndex] + graph[minIndex, j];
                        if (newDist < distances[j])
                        {
                            distances[j] = newDist;
                        }
                    }
                }
            }
            return distances;
        }

        /// <summary>
        /// Выводит на экран кратчайшие пути от стартовой вершины до всех остальных.
        /// </summary>
        /// <param name="distances">Массив расстояний</param>
        private void PrintShortestPaths(double[] distances)
        {
            Console.WriteLine($"Кратчайшие пути от вершины {_startVertex + 1}:");
            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine($"До вершины {i + 1}: {distances[i]}");
            }
        }
    }
}
