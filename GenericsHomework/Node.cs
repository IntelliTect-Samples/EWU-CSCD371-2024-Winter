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

    public Node (T value)
    {
        Value = value;
        next = null;
    }

    public override string ToString()
    {
        return Value?.ToString() ?? string.Empty;
    }

    public void Append(T value)
    {
        if(Exists(value))
        {
            throw new ArgumentException("Duplicate Value cannot be added.", nameof(value));
        }
        Node<T> newNode = new Node<T>(value);
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

    public bool Exists(T value)
    {
        Node<T> cur = this;
        do
        {
            if(EqualityComparer<T>.Default.Equals(cur.Value, value))
            {
                return true;
            }
            cur = cur.Next;
        } while (cur != this);
        return false;
    }

    public void Clear()
    {
        Next = this;
    }
}
