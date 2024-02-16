
namespace GenericsHomework;

    public class Node<T>
    {
        public Node(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item)); 
            Data = item;
            Next = this;
        }

        public Node<T> Next { get; private set; }
        public T Data { get; set; }
        
        public override string ToString()
        {
                return Data!.ToString()!;
        }

        public void Append(T item)
        {
        ArgumentNullException.ThrowIfNull(item,nameof(item));

        if (Exists(item))
            {
                throw new InvalidOperationException(nameof(item));
            }
            else
            {
                Node<T> currentNode = Next;

            while (currentNode.Next != this)
            {
                currentNode = currentNode.Next;
            }
   

            Node<T> newNode = new(item)
            {
                Next = this
            };
                    
                currentNode.Next = newNode;
            }
        }

    /* I think it is sufficient to set Next to itself because the garbage collector 
    will be able to get back the memory and works with reference objects.
    After some research as well, it seems the garbage collector works and handles
    circular references and lists like our case here. 
    The high level view of how the garbage collector works:
    Start with locals, statics and GC pinned objects. None of these can be collected
    Mark every object which can be reached by traversing the children of these objects Collect every object which is not marked.
    This allows for circular references to be collected just fine. 
    So long as none of them are reachable from an object known to be uncollectable then the circular reference is essentially irrelevant.
    */
    public void Clear()
        {
            Next = this;

        }

    public bool Exists(T item)
    {
     ArgumentNullException.ThrowIfNull(item, nameof(item));

        Node<T> currentNode = this;

    do
    {
        if (currentNode.Data!.Equals(item))
        {
            return true;
        }

        currentNode = currentNode.Next;
    } while (currentNode != this);
        return false;
    }
        
    }



