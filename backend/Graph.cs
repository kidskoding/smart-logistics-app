using System;
public class Graph<T> {
    private readonly Dictionary<GraphNode<T>, List<Tuple<GraphNode<T>, int>>> graph;

    public Graph() {
        graph = new Dictionary<GraphNode<T>, List<Tuple<GraphNode<T>, int>>>();
    }

    public void AddNode(GraphNode<T> node) {
        graph[node] = new List<Tuple<GraphNode<T>, int>>();
    }

    public void RemoveNode(GraphNode<T> node) {
        foreach(var neighbor in graph[node]) {
            graph[neighbor.Item1].RemoveAll(x => x.Item1.Equals(node));
        }
        graph.Remove(node);
    }

    public void AddEdge(GraphNode<T> a, GraphNode<T> b, int weight) {
        graph[a].Add(new Tuple<GraphNode<T>, int>(b, weight));
        graph[b].Add(new Tuple<GraphNode<T>, int>(a, weight));
    }

    public void RemoveEdge(GraphNode<T> a, GraphNode<T> b) {
        graph[a].RemoveAll(x => x.Item1.Equals(b));
        graph[b].RemoveAll(x => x.Item1.Equals(a));
    }

    public override string ToString() {
        string result = "";
        foreach(var node in graph) {
            result += node.Key.Value + ": ";
            foreach(var edge in node.Value) {
                result += edge.Item1.Value + "(" + edge.Item2 + ") ";
            }
            result += "\n";
        }
        return result;
    }
}