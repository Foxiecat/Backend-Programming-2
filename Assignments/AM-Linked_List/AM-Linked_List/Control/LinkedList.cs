using AM_Linked_List.Models;

namespace AM_Linked_List.Control;

public class LinkedList
{
    private string listName;
    private Node? _firstNode;
    private Node LastNode { get; set; }

    public LinkedList()
    {
        _firstNode = null;
    }
    
    public void Add(string text)
    {
        Node newNode = new(text);

        if (_firstNode == null) _firstNode = newNode;
        else
        {
            LastNode = _firstNode;
            while (LastNode.Next != null) LastNode = LastNode.Next;
        }
        LastNode.Next = newNode;
    }

    public void PrintLinkedList()
    {
        Node? currentNode = _firstNode;
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }
}