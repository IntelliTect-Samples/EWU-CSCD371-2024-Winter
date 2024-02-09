namespace GenericsHomework;

public class Node<T>
{
    public Node(T data)
    {
        Data = data;
    }

    public T Data { get; set; }
}

