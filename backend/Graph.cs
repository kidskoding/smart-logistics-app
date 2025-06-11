public class Graph<T>
{
    private List<GraphNode<T>> graph;

    public Graph() {
        graph = [];
    }

    public void AddNode(GraphNode<T> node)
    {
        graph.Add(node);
    }

    public void RemoveNode(GraphNode<T> node)
    {
        graph.Remove(node);
        foreach (GraphNode<T> other in graph)
        {
            if (other.Neighbors.Count > 0)
            {
                other.Neighbors.Remove(node);
            }
        }
    }

    public void AddEdge(GraphNode<T> a, GraphNode<T> b)
    {
        a.Neighbors.Add(b);
        b.Neighbors.Add(a);
    }

    public void RemoveEdge(GraphNode<T> a, GraphNode<T> b)
    {
        a.Neighbors.RemoveAll(n => n.Equals(b));
        b.Neighbors.RemoveAll(n => n.Equals(b));
    }
}