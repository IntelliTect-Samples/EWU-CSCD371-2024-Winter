namespace GenericsHomework;
public class Node<T>where T : notnull
{
    public T Value { get; }
    public Node<T> Next { get; private set; }
    public Node(T value)
    {
        Value = value ?? throw new ArgumentException(nameof(Value));
        Next = this; // Points back to itself by default
    }
    public override string ToString()
    {
        return Value.ToString();
    }

    public void Clear()
    {
        Next = this;
    }
    public void Append(T value)
    {
        if (Exists(value))
        {
            throw new ArgumentException("Duplicate value detected.");
        }

        Node<T> newNode = new(value)
        {
            Next = Next
        };
        Next = newNode;
    }
    public bool Exists(T value)
    {
        Node<T> current = this;
        do
        {
            if (current.Value.Equals(value))
            {
                return true;
            }
            else
            {
                current = current.Next;
            }
        } while (current != this);
        return false;
    }
}

