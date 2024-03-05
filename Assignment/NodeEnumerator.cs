using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment;

internal sealed class NodeEnumerator<T> : IEnumerator<Node<T>> where T : IEquatable<T>
{
    private Node<T> Head { get; set; }
    private Node<T> _Current;
    public Node<T> Current => _Current;

    object IEnumerator.Current => Current;

    public NodeEnumerator(Node<T> head)
    {
        Head = head;
        _Current = head;
    }

    public void Dispose() => Reset();

    public bool MoveNext()
    {
        //bool alreadyAtHead = Head.Equals(Head.Next);
        //if(alreadyAtHead)
        //{
        //    return true;
        //}
        _Current = Current.Next;
        return !_Current.Equals(Head);
    }

    public void Reset()
    {
        if(Head != null)
        {
            _Current = Head;
        }
    }
}
