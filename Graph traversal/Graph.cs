using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_traversal
{
//Создается класс Graph с приватными полями V (количество вершин) и adj (список смежности).
    public class Graph
    {
    //В конструкторе класса инициализируется массив списков смежности adj размером V.
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
//Метод AddEdge добавляет ребро между вершинами v и w, путем добавления w в список смежности вершины v.
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w); // Добавляем ребро между вершинами v и w, добавляя w в список смежности вершины v
        }
//Метод BFS (обход графа в ширину) принимает начальную вершину startVertex в качестве параметра. 
//Он использует массив visited для отслеживания посещенных вершин и очередь queue для обхода вершин в ширину.
//Начальная вершина помечается как посещенная и добавляется в очередь.
//Пока очередь не пуста, извлекается вершина из очереди, выводится её значение и для каждой смежной вершины, которая еще не была посещена, она помечается как посещенная и добавляется в очередь.
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
//Приватный метод DFSUtil (вспомогательный метод для обхода графа в глубину) используется рекурсивно для выполнения обхода в глубину. 
//Он принимает вершину v и массив visited в качестве параметров.
        private void DFSUtil(int v, bool[] visited)
        {
        //Текущая вершина помечается как посещенная и выводится её значение.
            visited[v] = true; // Помечаем текущую вершину как посещенную
            //Для каждой смежной вершины, которая еще не была посещена, рекурсивно вызывается DFSUtil.
            Console.Write(v + " "); // Выводим вершину

            foreach (int adjacentVertex in adj[v]) // Для каждой смежной вершины
            {
                if (!visited[adjacentVertex]) // Если вершина не была посещена
                {
                    DFSUtil(adjacentVertex, visited); // Рекурсивно вызываем DFSUtil для смежной вершины
                }
            }
        }
//Метод DFS (обход графа в глубину) принимает начальную вершину startVertex в качестве параметра. 
//Он создает массив visited и вызывает вспомогательный метод DFSUtil для выполнения обхода в глубину.
        public void DFS(int startVertex)
        {
            bool[] visited = new bool[V]; // Массив для отслеживания посещенных вершин
            DFSUtil(startVertex, visited); // Вызываем вспомогательный метод DFSUtil для обхода в глубину
        }
//Метод PrintAdjacencyMatrix выводит таблицу смежности вершин графа. Для каждой вершины i выводится список смежных вершин adj[i].
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

