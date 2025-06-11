using System;

public class GraphNode<T> {
    public T Value { get; set; }
    public List<GraphNode<T>> Neighbors { get; set; }
}