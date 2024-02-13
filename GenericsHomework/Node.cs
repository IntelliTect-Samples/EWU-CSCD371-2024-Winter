namespace GenericsHomework;
public class Node<T>
{
    // Value of the node
    public T Value { get; set; }

    // Pointer to the next node
    public Node<T> Next { get; private set; }
    public static int size { get; private set; }

    // Constructor that takes a value
    public Node(T value)
    {
        Value = value;
       
        Next = this; // By default, the Next pointer refers back to itself
     
      
        size++;
    }

    // Method to set the next node
    public void SetNext(Node<T> next)
    {
        Next = next;
    }

    public override string ToString()
    {
        return Value!.ToString()!;
    }

    public void Append(T value)
    {
        if (Exists(value))
        {
            throw new ArgumentException("Value already exists");
        }
        else
        {
            Node<T> newNode = new(value);

            newNode.Next = this.Next; // New node points to the current node's next
           
            this.Next = newNode; // Update current node's next to point to the new node
        }
    }

    public void Clear()
    {
        Node<T> headNode = this;
        headNode.Next = this;

    }

    public Boolean Exists(T value)
    {
        Node<T> headNode = this; 
        while (headNode.Next != headNode)
        {
            if (headNode.Value != null && headNode.Value.Equals(value))
            {
                return true;
            }
            headNode = headNode.Next;
        }
        return false;
    }
}
