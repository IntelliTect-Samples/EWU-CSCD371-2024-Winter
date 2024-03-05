using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment;
    public class Node<T> : IEnumerable<T>
    {
        // Value of the node
        public T Value { get; set; }

        // Pointer to the next node
        public Node<T>? Next { get; private set; } // Nullable reference type

        // Constructor that takes a value
        public Node(T value)
        {
            Value = value;
            Next = this; // By default, the Next pointer refers back to itself
        }

        // Method to set the next node
        public void SetNext(Node<T>? next) // Nullable reference type
        {
            Next = next;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty; // Handling possible null reference
        }

        public void Append(T value)
        {
            if (Exists(value))
            {
                throw new ArgumentException("Value already exists");
            }
            else
            {
                Node<T> newNode = new Node<T>(value)
                {
                    Next = this.Next // New node points to the current node's next
                };

                this.Next = newNode; // Update current node's next to point to the new node
            }
        }

        public void Clear()
        {
            Node<T> headNode = this;
            headNode.Next = this;
        }

        public bool Exists(T value)
        {
            Node<T> headNode = this;
            do
            {
                if (headNode.Value?.Equals(value) ?? false) // Handling possible null reference
                {
                    return true;
                }
                headNode = headNode.Next!;
            } while (headNode != this);

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? currentNode = this; // Nullable reference type
            do
            {
                yield return currentNode!.Value; // Handling possible null reference
                currentNode = currentNode!.Next;
            } while (currentNode != this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> ChildItems(int maximum)
        {
            Node<T>? currentNode = this; // Nullable reference type
            int count = 0;
            do
            {
                if (count >= maximum)
                    yield break;

                yield return currentNode!.Value; // Handling possible null reference
                currentNode = currentNode!.Next;
                count++;
            } while (currentNode != this);
        }
    }
