namespace GenericsHomework;

public class Node<T> //Circular LinkedList
{
    public T Data { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Data = value;
        Next = this;//else refers back to itself if there are no other nodes in the list.
    }


    public override string ToString()
    {
        //Add a ToString() override that writes out the value's ToString() result.
        ArgumentNullException.ThrowIfNull(Data);
        return Data.ToString()!;
    }

    public void Append(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));//Prevent null values from being added

        //Throw an error on an attempt to Append a duplicate value. (Make sure you test for this case)
        if (Exists(value) == true) throw new ArgumentException("Cannot have duplicate: " + nameof(value));

        Node<T> cur = this;

        while(cur.Next != this)
        {
            cur = cur.Next;
        }

        Node<T> newNode = new(value);
        cur.Next = newNode;
        newNode.Next = this;//Loop the newNode back to the head
    }

    public void Clear() //c# will auto collect garbage for the rest of the nodes
    {
        Node<T> cur = this; //new node holds the same data while disconnected from the rest of the list
        cur.Next = this; //next will remove the rest of the references
    }

    public bool Exists(T value)
    {
        //Search list to see if value exists
        Node<T> cur = this;
        do
        {
            if (cur.Data!.Equals(value)) return true; //Using ! since Append checks if value is null
                cur = cur.Next;

        } while (cur != this);

        return false;
    }


}

