using System.Collections;

namespace LinkedListSolution;

public class LinkedList<T> : IEnumerable<T>
{
    private Node<T> _start;
    
    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = _start;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
    
    public bool Add(T data)
    {
        if (Find(data))
            return false;

        if (_start == null)
        {
            _start = new Node<T>(data);
            return true;
        }

        Node<T> current = _start;
        while (current.Next != null)
        {
            current = current.Next;
        }
        
        current.Next = new Node<T>(data);
        return true;
    }

    public bool Remove(T data)
    {
        if (_start == null)
        {
            return false;
        }

        Node<T> current = _start;
        Node<T> previous = null;
        while (current.Next != null)
        {
            if (current.Data.Equals(data))
            {
                // do remove
                // start
                if (previous == null)
                {
                    _start = _start.Next;
                    return true;
                }
                // middle
                if (current.Next != null)
                {
                    previous.Next = current.Next;
                    return true;
                }
                // end
                previous.Next = null;
                return false;
            }

            previous = current;
            current = current.Next;
        }
        
        return false;
    }

    public bool Find(T data)
    {
        Node<T> current = _start.Next;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return true;
            
            current = current.Next;
        }
        return false;
    }

    public override string ToString()
    {
        return _start.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}