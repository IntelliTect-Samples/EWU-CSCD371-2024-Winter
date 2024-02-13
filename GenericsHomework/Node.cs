namespace GenericsHomework;

public class Node<T>(T data)
{
    //Can add contraint such as "where T : class" to ensure homogeneous values
    //Can possibly also add "public T Data { get; }" to ensure pproperty is non nullable.
    public T Data { get; } = data;
    private Node<T>? next = null; 
    public Node<T> Next
    {
        get => next ?? this;
        private set => next = value;
    }

    public override string ToString()
    {
        return Data?.ToString() ?? string.Empty;
    }

    public void Append(T data)
    {
        if(Exists(data))
        {
            throw new ArgumentException("Duplicate Value cannot be added.", nameof(data));
        }
        Node<T> newNode = new(data);
        if(Next == this)
        {
            Next = newNode;
        }
        else
        {
            Node<T> cur = Next;
            while(cur.Next != this)
            {
                cur = cur.Next;
            }
            cur.Next = newNode;
        }
        newNode.Next = this;
    }

    public bool Exists(T data)
    {
        Node<T> cur = this;
        do
        {
            if(EqualityComparer<T>.Default.Equals(cur.Data, data))
            {
                return true;
            }
            cur = cur.Next;
        } while (cur != this);
        return false;
    }

    public void Clear()
    {
        Node<T> cur = this;//Create a new Node that holds the same data, this node is not connected to the rest of the list.
        Next = this; //Setting Next will remove external References.
        //Garbage Collection won't be a problem here as these objects are no longer referenced, and are collected automatically.
        //Circular references are broken at this point, which ultimately prevents memory leaks.
    }
}
