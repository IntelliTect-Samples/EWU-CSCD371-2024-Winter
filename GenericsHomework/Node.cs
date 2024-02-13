namespace GenericsHomework;
public class Node<T>
{
    // Value of the node
    public T Value { get; set; }

    // Pointer to the next node
    public Node<T> Next { get; private set; }

    // Constructor that takes a value
    public Node(T value)
    {
        Value = value;
        Next = this; // By default, the Next pointer refers back to itself
    }

    // Method to set the next node
    public void SetNext(Node<T> next)
    {
        Next = next;
    }
}
