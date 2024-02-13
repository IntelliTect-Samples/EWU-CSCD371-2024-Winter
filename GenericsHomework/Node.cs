using System.Collections;

namespace GenericsHomework;
public class Node<T> : IEnumerator<T>, ICollection<T> where T : notnull
{
    public T Value { get; }
    public Node<T> Next { get; private set; }

    public int Count { get
        {
            int n = 1;
            Reset();
            while(MoveNext())
            {
                n++;
            }
            Reset();
            return n;
        } 
    }

    public bool IsReadOnly => false;

    private Node<T> _current;
    private bool _atBeginning = true;
    public T Current => _current.Value;

    object IEnumerator.Current => Current;

    public Node(T value)
    {
        Value = value ?? throw new ArgumentException(nameof(Value));
        Next = this; // Points back to itself by default
        _current = this;
    }
    public override string ToString()
    {
        return Value.ToString() ?? "";
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
        for(int i = 0; i < Count; i++)
        {
            if(current.Value.Equals(value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Add(T item) => Append(item);

    public bool Contains(T item) => Exists(item);

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(arrayIndex, nameof(arrayIndex));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(arrayIndex + Count, array.Length, nameof(arrayIndex));
        Node<T> current = this;
        for(int i = arrayIndex; i < Count; i++)
        {
            array[i] = current.Value;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        Node<T> current = this;
        do
        {
            if(current.Next.Value.Equals(item))
            {
                current.Next = current.Next.Next;
                return true;
            }
            current = current.Next;
        } while(current.Next != this);
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this;
    }

    public bool MoveNext()
    {
        if(_current.Next.Value.Equals(Value) && !_atBeginning)
        {
            return false;
        }
        _current = _current.Next;
        _atBeginning = false;
        return true;
    }

    public void Reset()
    {
        _current = this;
        _atBeginning = true;
    }

    public void Dispose() => Reset();
}

