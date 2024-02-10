using System;

namespace GenericsHomework
{
    public class Node<T>
    {
        public Node(T item)
            {
                Data = item ?? throw new NullReferenceException(nameof(item));
                Next = this;
            //Next is non nullable ? might want to change to not use this? idk
            }

        public Node<T> Next { get; private set; }
        public T Data { get; set; }
        
        public override string ToString()
        {
            if (Data==null)
                throw new NullReferenceException(nameof(Data)); 
            else
            {
                return Data.ToString()!;
            }
        }

        public void Append(T item)
        {
            if (Exists(item))
            {
                throw new DuplicateWaitObjectException(nameof(item));
                //this if for an array but think it can work?

            }
            else
            {
                Node<T> currentNode = this;
                while (currentNode.Next != currentNode)
                {
                    currentNode = currentNode.Next;

                }
                currentNode.Next = new Node<T>(item);
            }
        }

        /* I think it is sufficient to set Next to itself because the garbage collector 
        will be able to get back the memory and works with reference objects.
        After some research as well, it seems the garbage collector works and handles
        circular references and lists like our case here. MSDN says 
        "If a group of objects contain references to each other, but none of these object 
        are referenced directly or indirectly from stack or shared variables, 
        then garbage collection will automatically reclaim the memory.
        */
        public void Clear()
        {
            Next = this;

        }

        public bool Exists(T item)
        {
            Node<T> currentNode = this;

            for (;;)//infinite loop
            {
                if (currentNode.Data != null && currentNode.Data.Equals(item))
                {
                    return true;
                }
                if (currentNode.Next == currentNode)
                {
                    return false;
                }
                currentNode = currentNode.Next;
            }
        }
        
    }
}


