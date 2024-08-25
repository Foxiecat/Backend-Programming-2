using System.Collections;
using AM_Linked_List.Models;

namespace AM_Linked_List.Control;

public class CustomLinkedList<T> : IEnumerable
{
    public Node<T>? FirstNode { get; private set; }
    public Node<T>? LastNode { get; private set; }
    public int Count { get; private set; }
    
    
    /// <summary>
    /// Adds an item to the list if no duplicate item already exists
    /// </summary>
    /// <param name="item">The item to be added in the list</param>
    /// <exception cref="InvalidOperationException">Throws exception if item already exists in list</exception>
    public void Add(T item)
    {
        lock (this)
        {
            // Checks if inputted data already exists as a node.
            if (Find(item) != null)
            {
                throw new InvalidOperationException($"{item} already exists in the list.");
            }

            Node<T> currentNode = new (item);
            // If the list is empty, add the new node as the first and last node in the list
            if (FirstNode == null)
            {
                FirstNode = currentNode;
            }
            else
            {
                LastNode!.Next = currentNode;
            }

            LastNode = currentNode;
            Count++;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public T RemoveHead()
    {
        lock (this)
        {
            if (FirstNode == null)
            {
                throw new InvalidOperationException("List appears to be empty.");
            }

            T removedData = FirstNode.Item;

            if (FirstNode == LastNode)
            {
                FirstNode = LastNode = null;
            }
            else FirstNode = FirstNode.Next;

            Count--;
            return removedData;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public T RemoveTail()
    {
        lock (this)
        {
            if (FirstNode == null)
            {
                LastNode = null;
                throw new InvalidOperationException("List appears to be empty.");
            }
            
            T removedData = LastNode.Item;
            if (FirstNode == LastNode)
            {
                FirstNode = LastNode = null;
            }
            else
            {
                Node<T> currentNode = FirstNode;
                while (currentNode.Next != LastNode)
                {
                    currentNode = currentNode.Next;
                }
                
                LastNode = currentNode;
                currentNode.Next = null;
            }

            Count--;
            return removedData;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public T RemoveAt(int index)
    {
        lock (this)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be less than the size of the list and non-negative.");
            }

            T removedData;
            if (index == 0)
            {
                removedData = RemoveHead();
            }
            else if (index == Count - 1)
            {
                removedData = RemoveTail();
            }
            else
            {
                Node<T> currentNode = FirstNode!;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next!;
                }
                
                removedData = currentNode.Next!.Item;
                currentNode.Next = currentNode.Next.Next;
            }

            Count--;
            return removedData;
        }
    }
    
    
    /// <summary>
    /// Removes the specified item from the list if it exists
    /// </summary>
    /// <param name="itemToBeRemoved"></param>
    /// <exception cref="InvalidOperationException">Throws exception if the list is empty or the item cannot be found</exception>
    public bool Remove(T itemToBeRemoved)
    {
        lock (this)
        {
            if (FirstNode == null)
            {
                throw new InvalidOperationException("The list appears to be empty.");
            }

            // Removes the First Node if item to remove is the first node
            if (FirstNode.Item != null && FirstNode.Item.Equals(itemToBeRemoved))
            {
                FirstNode = FirstNode.Next;
                Count--;
                return true;
            }
        
            Node<T> previousNode = FirstNode;
            Node<T>? currentNode = FirstNode.Next;
        
            while (currentNode != null)
            {
                if (currentNode.Item != null && currentNode.Item.Equals(itemToBeRemoved))
                {
                    previousNode.Next = currentNode.Next;
                
                    // If removing the last node, update LastNode
                    if (currentNode.Next == null)
                    {
                        LastNode = previousNode;
                    }
                
                    Count--;
                    return true;
                }
            
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }
    }


    /// <summary>
    /// Iterates through the list to find a specified item
    /// </summary>
    /// <param name="item">Specified item to be found</param>
    /// <returns>Returns the node that contains the specified item</returns>
    public Node<T>? Find(T item)
    {
        Node<T>? currentNode = FirstNode;

        while (currentNode != null)
        {
            if (currentNode.Item != null && currentNode.Item.Equals(item))
            {
                return currentNode;
            }

            currentNode = currentNode.Next;
        }
        return null;
    }
    
    /// <summary>
    /// A simple indexer
    /// </summary>
    public T this[int index]
    {
        get
        {
            if (index < 0 | index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be less than the size of the list and non-negative.");
            }
            Node<T>? currentNode = FirstNode;
            
            // Goes through the list and finds the node at the given index
            for (int i = 0; i < index; i++)
            {
                // currentNode will never be null because index should always be within bounds
                currentNode = currentNode!.Next;
            }
            
            return currentNode!.Item ?? throw new InvalidOperationException("The item at the given index was not found or is null.");
        }
    }
    
    // Simple iteration support:
    public IEnumerator GetEnumerator()
    {
        return new CustomLinkedListEnumerator(this);
    }
    
    private class CustomLinkedListEnumerator : IEnumerator
    {
        private readonly CustomLinkedList<T> _customLinkedList;
        private Node<T>? _currentNode;
        private bool _isThisFirstNode;

        public CustomLinkedListEnumerator(CustomLinkedList<T> customLinkedList)
        {
            _customLinkedList = customLinkedList;
            _currentNode = null;
            _isThisFirstNode = true;
        }

        public bool MoveNext()
        {
            if (_isThisFirstNode)
            {
                _currentNode = _customLinkedList.FirstNode;
                _isThisFirstNode = false;
            }
            else
            {
                _currentNode = _currentNode?.Next;
            }
            
            return _currentNode != null;
        }

        public void Reset()
        {
            _currentNode = null;
            _isThisFirstNode = true;
        }

        public object? Current
        {
            get
            {
                if (_currentNode == null)
                {
                    throw new InvalidOperationException();
                }
                return _currentNode;
            }
        }
    }
}