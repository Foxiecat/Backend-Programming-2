namespace AM_Linked_List.Models;

/// <summary>
/// Node class for CustomLinkedList
/// </summary>
/// <param name="item">Desired data for a node to hold</param>
/// <typeparam name="T">The item's data type</typeparam>
public class Node<T>(T item)
{
    public T Item { get; } = item;
    public Node<T>? Next { get; set; } = null;


    /// <summary>
    /// Overriding ToString to return the node's data as a string, or empty string if the data is null
    /// </summary>
    public override string? ToString()
    {
        return Item == null ? string.Empty : Item.ToString();
    }
}