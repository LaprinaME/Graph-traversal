using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_traversal
{
    public class Graph
    {
        private int V; // Количество вершин
        private List<int>[] adj; // Список смежности

        public Graph(int v)
        {
            V = v;
            adj = new List<int>[V]; // Создаем массив списков смежности размером V
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>(); // Инициализируем каждый список смежности
            }
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w); // Добавляем ребро между вершинами v и w, добавляя w в список смежности вершины v
        }

        public void BFS(int startVertex)
        {
            bool[] visited = new bool[V]; // Массив для отслеживания посещенных вершин
            Queue<int> queue = new Queue<int>(); // Очередь для обхода в ширину

            visited[startVertex] = true; // Помечаем начальную вершину как посещенную
            queue.Enqueue(startVertex); // Добавляем начальную вершину в очередь

            while (queue.Count != 0)
            {
                startVertex = queue.Dequeue(); // Извлекаем вершину из очереди
                Console.Write(startVertex + " "); // Выводим вершину

                foreach (int adjacentVertex in adj[startVertex]) // Для каждой смежной вершины
                {
                    if (!visited[adjacentVertex]) // Если вершина не была посещена
                    {
                        visited[adjacentVertex] = true; // Помечаем ее как посещенную
                        queue.Enqueue(adjacentVertex); // Добавляем в очередь для дальнейшего обхода
                    }
                }
            }
        }

        private void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true; // Помечаем текущую вершину как посещенную
            Console.Write(v + " "); // Выводим вершину

            foreach (int adjacentVertex in adj[v]) // Для каждой смежной вершины
            {
                if (!visited[adjacentVertex]) // Если вершина не была посещена
                {
                    DFSUtil(adjacentVertex, visited); // Рекурсивно вызываем DFSUtil для смежной вершины
                }
            }
        }

        public void DFS(int startVertex)
        {
            bool[] visited = new bool[V]; // Массив для отслеживания посещенных вершин
            DFSUtil(startVertex, visited); // Вызываем вспомогательный метод DFSUtil для обхода в глубину
        }

        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Таблица смежности вершин:");
            for (int i = 0; i < V; i++)
            {
                Console.Write(i + ": ");
                foreach (int adjacentVertex in adj[i]) // Для каждой смежной вершины
                {
                    Console.Write(adjacentVertex + " "); // Выводим смежную вершину
                }
                Console.WriteLine();

            }
        }
    }
}

