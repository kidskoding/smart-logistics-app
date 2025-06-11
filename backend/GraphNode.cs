using System;

public struct GraphNode<T>
{
    public T Value { get; }
    public List<GraphNode<T>> Neighbors { get; set; }

    public GraphNode(T value)
    {
        Value = value;
        Neighbors = new List<GraphNode<T>>();
    }
}