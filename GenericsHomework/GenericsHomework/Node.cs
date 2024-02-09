using System;

namespace GenericsHomework
{
    public class Node<T>
    {
        public Node(T item)
            {
                Data = item ?? throw new NullReferenceException(nameof(item));
                Next = this;
            //Next is non nullable ? might want to change to not use this ? idk
            }
        public Node<T> Next { get; private set; }
        public T Data { get; set; }

        public void Append(T item)
        {
            Node<T> currentNode = this;
            while(currentNode.Next!=currentNode)
            {
                currentNode = currentNode.Next;

            }
            currentNode.Next = new Node<T>(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}



