
namespace Graph_traversal
{
    public class Program
    {
        public static void Main()
        {
            int vertexCount = 5; // Количество вершин в графе

            Graph graph = new Graph(vertexCount);

            // Добавление ребер в граф
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            Console.WriteLine("Обход в ширину (BFS):");
            graph.BFS(0);
            Console.WriteLine();

            Console.WriteLine("\nОбход в глубину (DFS):");
            graph.DFS(0);
            Console.WriteLine();

            graph.PrintAdjacencyMatrix();
        }
    }
}
