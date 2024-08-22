namespace AM_Linked_List.Models;

public class Node(string value, Node next)
{
    private string Value { get; set; } = value;
    private Node Next { get; set; } = next;
}