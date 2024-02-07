using System;

namespace GenericsHomework
{
    public class Node<T>
    {
        public T value { get; }
        public Node<T> next { get; private set; }
        public Node(T value, Node<T> next)
        {
        }
    }
}
