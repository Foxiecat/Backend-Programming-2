namespace AM_Linked_List.Models;

/// <summary>
/// Node class for CustomLinkedList
/// </summary>
/// <param name="item">Desired data for a node to hold</param>
/// <typeparam name="T">The item's data type</typeparam>
public class Node<T>(T item)
{
    public T Item { get; } = item;
    public Node<T>? Next { get; set; }
    
    public void SetNext(Node<T> next)
    {
        Next = next;
    }

    public override string? ToString()
    {
        return item == null ? string.Empty : item.ToString();
    }
}