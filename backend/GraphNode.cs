using System;

public class GraphNode<T> {
    public T Name { get; set; }
    public List<GraphNode<T>> Neighbors { get; set; }
}