namespace GenericsHomework;

public class Node<T> //Circular LinkedList
{
    public T Data { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        this.Data = value;
        Next = this;//else refers back to itself if there are no other nodes in the list.
    }


    public override string ToString()
    {
        //Add a ToString() override that writes out the value's ToString() result.
        Node<T> cur = this;
        string output = "";
        while (cur.Next != this)
        {
            output += cur.Data + " ";
            cur = cur.Next;
        }
        output += cur.Data;
        return output;
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

    public void Clear()//TODO: Add comment
    {
        Node<T> cur = this;
        cur.Next = this;
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

