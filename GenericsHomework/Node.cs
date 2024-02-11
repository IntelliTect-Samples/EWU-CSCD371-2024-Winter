namespace GenericsHomework;

public class Node<T>
{
    public T Value { get; }
    private Node<T>? next;
    public Node<T> Next
    {
        get => next ?? this;
        private set => next = value;
    }
}
